using System;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Microsoft.SqlServer.Server;
using System.Runtime.CompilerServices;

namespace MESProject
{
    public partial class MainForm : Form
    {
        // 창 이동 변수 선언
        bool isMove;
        Point fpt;
        public static string User_ID { get; set; }
        public string woid = "";
        string wostat;
        int count = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void login_check()
        {
            this.Hide();
            Login login = new Login();
            //login DialogResult Value
            DialogResult result = login.ShowDialog();
            //로그인 실패시
            if (result != DialogResult.OK)
            {   
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            login_check();
            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            ProcCombo.SelectedIndex = 0; //콤보박스 초기값설정
            Check_Admin();
            Common.SetGridDesign(WoGrid);
            DataSearch();
            if (WoGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "작업코드", "제품코드", "제품명", "작업상태", "계획수량", "생산수량", "불량수량", "계획날짜", "비고" };
                for (int i = 0; i < header.Length; i++)
                {
                    WoGrid.Columns[i].HeaderText = $"{header[i]}";
                    WoGrid.Columns[i].ReadOnly = true;

                }
            }
            WoGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

          

        }

        private void Check_Admin()
        {
            try
            {
                if (User_ID != null)
                {
                    string admin_yn = $"SELECT PROCID, ADMIN_YN FROM EMP_AUTHORITY WHERE EMPLOYEEID = '{User_ID}'";
                    DataTable dataTable = Common.DB_Connection(admin_yn);
                    string y_n = dataTable.Rows[0][1].ToString();
                    string user_procid = dataTable.Rows[0][0].ToString();

                    if (y_n == "Y")
                    {
                        ProcCombo.Visible = true;
                    }
                    else if (y_n == "N")
                    {
                        if (user_procid == "P0001")
                        {
                            ProcCombo.SelectedIndex = 0;
                        }
                        else if (user_procid == "P0002")
                        {
                            ProcCombo.SelectedIndex = 1;
                        }
                    }
                }
            }
           catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void DataSearch()
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
            if (ProcCombo.SelectedIndex == 0)
            {
                //배합 콤보박스 선택
                string select_wo_mix = $"SELECT \n" +
                                            $"W.WOID \n" +
                                            $",W.PRODID \n " +
                                            $",P.PRODNAME \n " +
                                            $",CASE WOSTAT WHEN 'P' THEN '대기'  WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END AS WOSTAT \n" +
                                            $",W.PLANQTY \n" +
                                            $",W.PRODQTY \n" +
                                            $",COUNT(D.DEFECT_LOTID) AS 불량수량 \n" +
                                            $",W.PLANDTTM \n" +
                                            $",W.ETC \n " +
                                        $"FROM WORKORDER W \n " +
                                            $"INNER JOIN PRODUCT P ON W.PRODID = P.PRODID \n" +
                                            $"LEFT JOIN LOT L ON W.WOID = L.WOID AND L.LOTSTAT <> 'D'  \n" +
                                            $"LEFT JOIN DEFECTLOT D ON L.LOTID = D.DEFECT_LOTID \n" +
                                        $"WHERE W.plandttm BETWEEN '{date1.Year}/{date1.Month}/{date1.Day}' AND TO_DATE('{date2.Year}/{date2.Month}/{date2.Day}')+1 \n" +
                                            $"AND W.PROCID = 'P0001' \n" +
                                            $"OR (W.PROCID = 'P0001' AND W.WOSTAT ='S') \n" +
                                        $"GROUP BY W.WOID, W.PRODID, P.PRODNAME, WOSTAT, W.WOSTAT,W.PLANQTY, W.PRODQTY,W.PLANDTTM, W.ETC \n" +
                                        $"ORDER BY(DECODE(WOSTAT, '진행중', 0, 1)) ,W.WOID\n";
                Common.DB_Connection(select_wo_mix, WoGrid);

                //(배합)진행중인 작업지시서 수 조회 
                string select_wostat = "SELECT \n" +
                                     "COUNT(WOID)\n" +
                                   "FROM \n" +
                                       "WORKORDER \n" +
                                   "WHERE WOSTAT='S' \n" +
                                       "AND PROCID='P0001'";
                DataTable WostatTable = Common.DB_Connection(select_wostat);
                count = Convert.ToInt32(WostatTable.Rows[0][0].ToString());
            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                //사출 콤보박스 선택
                string select_wo_injection = $"SELECT \n" +
                                                $"W.WOID \n" +
                                                $",W.PRODID \n " +
                                                $",P.PRODNAME \n " +
                                                $",CASE WOSTAT WHEN 'P' THEN '대기'  WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END AS WOSTAT \n" +
                                                $",W.PLANQTY \n" +
                                                $",W.PRODQTY  \n" +
                                                $",COUNT(D.DEFECT_LOTID) AS 불량수량 \n" +
                                                $",W.PLANDTTM \n" +
                                                $",W.ETC \n " +
                                            $"FROM WORKORDER W \n " +
                                                $"INNER JOIN PRODUCT P ON W.PRODID = P.PRODID \n" +
                                                $"LEFT JOIN LOT L ON W.WOID = L.WOID AND L.LOTSTAT <> 'D' \n" +
                                                $"LEFT JOIN DEFECTLOT D ON L.LOTID = D.DEFECT_LOTID \n" +
                                            $"WHERE W.plandttm BETWEEN '{date1.Year}/{date1.Month}/{date1.Day}' AND TO_DATE('{date2.Year}/{date2.Month}/{date2.Day}')+1 \n" +
                                                $"AND W.PROCID = 'P0002' \n" +
                                                $"OR (W.PROCID = 'P0002' AND W.WOSTAT ='S') \n" +
                                            $"GROUP BY W.WOID, W.PRODID, P.PRODNAME, WOSTAT, W.WOSTAT,W.PLANQTY, W.PRODQTY,W.PLANDTTM, W.ETC \n" +
                                            $"ORDER BY(DECODE(WOSTAT, '진행중', 0, 1)) ,W.WOID\n";
                Common.DB_Connection(select_wo_injection, WoGrid);

                //(사출)진행중인 작업지시서 수 조회 
                string select_wostat2 = "SELECT \n" +
                                     "COUNT(WOID)\n" +
                                   "FROM \n" +
                                       "WORKORDER \n" +
                                   "WHERE WOSTAT='S' \n" +
                                       "AND PROCID='P0002' \n";
                DataTable WostatTable = Common.DB_Connection(select_wostat2);
                count = Convert.ToInt32(WostatTable.Rows[0][0].ToString());
            }
            SetRowColor();
        }
        public void SetRowColor()
        {
            for (int i = 0; i < WoGrid.Rows.Count - 1; i++)
            {
                if (WoGrid.Rows[i].Displayed)
                {
                    if (WoGrid.Columns.Contains("WOSTAT"))
                    {
                        if (WoGrid.Rows[i].Cells["WOSTAT"].Value.ToString().Contains("진행중"))
                        {
                            WoGrid.FirstDisplayedCell = WoGrid.Rows[i].Cells[0];
                            WoGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                        }
                    }
                }
            }
        }
        private void InquiryBtn_Click(object sender, EventArgs e)
        {
            //조회 버튼 클릭 시
            DataSearch();
        }
        private void WostBtn_Click(object sender, EventArgs e)
        {
            //작업시작 버튼

            for (int i = 0; i < WoGrid.Rows.Count - 1; i++)
            {
                if (WoGrid.Rows[i].Selected == true)
                {
                    woid = WoGrid.Rows[i].Cells[0].Value.ToString();
                    wostat = WoGrid.Rows[i].Cells[3].Value.ToString();
                }
            }

            //진행중인 작업지시서 수가 0 이면 WOSTAT를 진행중으로 변경
            if (wostat != "종료" && count == 0)
            {
                string update_wostat = $"UPDATE WORKORDER SET WOSTAT ='S', WOSTDTTM = TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') WHERE WOID = '{woid}'";
                Common.DB_Connection(update_wostat);
            }

            Startworking startworkingForm = new Startworking();
            StartWorkingFormIM startWorkingFormIM = new StartWorkingFormIM();
            DataSearch();
            if (woid != "")
            {

                if (ProcCombo.SelectedIndex == 0)
                {
                    //배합
                    Startworking.Selected_woid = woid;
                    Common.Create_Tab("startworking", "작업시작", startworkingForm, maintab);
                }
                if (ProcCombo.SelectedIndex == 1)
                {
                    //사출
                    StartWorkingFormIM.Selected_woid = woid;
                    Common.Create_Tab("startworkingIM", "작업시작", startWorkingFormIM, maintab);
                }

            }
            startWorkingFormIM.FormClosed += Form_closing;
            startworkingForm.FormClosed += Form_closing;

        }

        public void Form_closing(object sender, FormClosedEventArgs e)
        {
            maintab.TabPages.Remove(maintab.SelectedTab);
            DataSearch();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            //로그아웃버튼
            this.Close();
            Application.Restart();
            login_check();

        }



        private void maintab_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);
        }

        private void maintab_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void maintab_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }

        private void WoLogBtn_Click(object sender, EventArgs e)
        {
            //작업일지 버튼
            WorkLog workLogForm = new WorkLog();
            Common.Create_Tab("workLogForm", "작업일지", workLogForm, maintab);
            workLogForm.FormClosed += Form_closing;

        }

        private void WoGrid_DataSourceChanged(object sender, EventArgs e)
        {
            WoGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void WoGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < WoGrid.Rows.Count - 1; i++)
            {
                if (WoGrid.Rows[i].Selected == true)
                {
                    woid = WoGrid.Rows[i].Cells[0].Value.ToString();
                }
            }
            Startworking startworkingForm = new Startworking();
            StartWorkingFormIM startWorkingFormIM = new StartWorkingFormIM();
            if (woid != "")
            {

                if (ProcCombo.SelectedIndex == 0)
                {
                    //배합
                    Startworking.Selected_woid = woid;
                    Common.Create_Tab("startworking", "작업시작", startworkingForm, maintab);
                }
                if (ProcCombo.SelectedIndex == 1)
                {
                    //사출
                    StartWorkingFormIM.Selected_woid = woid;
                    Common.Create_Tab("startworkingIM", "작업시작", startWorkingFormIM, maintab);
                }

            }
            startWorkingFormIM.FormClosed += Form_closing;
            startworkingForm.FormClosed += Form_closing;
        }

        private void MaterialBtn_Click(object sender, EventArgs e)
        {
            //원재료재고관리
            MaterialStock materialStockForm = new MaterialStock();
            materialStockForm.ShowDialog();
        }

        private void ProcCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSearch();
        }
    }
}
