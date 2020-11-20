using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    public partial class WorkLog : Form
    {
        private string User;
        public WorkLog()
        {
            InitializeComponent();
            User = MainForm.User_ID;
        }

        private void WorkLog_Load(object sender, EventArgs e)
        {   

            // Grid 디자인 세팅
            Common.SetGridDesign(WLGrid);
            Common.SetGridDesign(LotGrid);     
            WLGrid.Font = new Font("Fixsys", 12, FontStyle.Regular);
            LotGrid.Font = new Font("Fixsys", 14, FontStyle.Regular);

            //콤보박스 초기값설정
            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            ProcCombo.SelectedIndex = 0;
            Check_Admin();

            //WLGrid (작업지시서) 조회
            DataSearch();

            // 컬럼명 설정
            if (WLGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "작업코드", "제품명", "작업상태", "계획수량", "생산수량", "불량수량", "작업시작일", "작업완료일", "계획일자", "비고" };
                for (int i = 0; i < header.Length; i++)
                {
                    WLGrid.Columns[i].HeaderText = $"{header[i]}";
                }
            }
            // 컬럼 폭 설정
            int[] WLGrid_SetColumnWidth = new int[] { 130, 140, 50, 50, 50, 50, 140, 140, 140, 40 };
            for (int i = 0; i < WLGrid_SetColumnWidth.Length; i++)
            {
                Common.SetColumnWidth(WLGrid, i, WLGrid_SetColumnWidth[i]);
            }
            // LotGrid 컬럼명
            Inquiry_lot();

            int[] LotGrid_SetColumnWidth = new int[] { 150,100,150,150 ,100};
            for (int i = 0; i < LotGrid_SetColumnWidth.Length; i++)
            {
                Common.SetColumnWidth(LotGrid, i, LotGrid_SetColumnWidth[i]);
            }
 
        }
        private void Check_Admin()
        {
            string admin_yn = $"SELECT PROCID, ADMIN_YN FROM EMP_AUTHORITY WHERE EMPLOYEEID = '{User}'";
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
        public void Inquiry_lot()
        {
            string Selected_lot =   $"SELECT " +
                                        $"L.LOTID" +
                                        $",L.EQPTID"+
                                        $",L.LOTSTDTTM" +
                                        $",L.LOTEDDTTM, " +
                                        $"CASE WHEN L.LOTID IN(" +
                                                            $"SELECT " +
                                                            $"DEFECT_LOTID " +
                                                            $"FROM DEFECTLOT " +
                                                            $"WHERE WOID='{woid}') THEN 'Y' ELSE 'N' END " +
                                    $"FROM LOT L, DEFECTLOT D " +
                                    $"WHERE WOID = '{woid}' AND L.LOTID = D.DEFECT_LOTID";
            Common.DB_Connection(Selected_lot, LotGrid);
            if (LotGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "LOT코드","설비코드" ,"시작시간", "종료시간", "불량" };
                for (int i = 0; i < header.Length; i++)
                {
                    LotGrid.Columns[i].HeaderText = $"{header[i]}";

                }
            }
            Common.Disable_sorting_Datagrid(LotGrid);
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataSearch()
        {

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            if (ProcCombo.SelectedIndex == 0)
            {
                //배합 콤보박스 선택 PROCID='P0001'
                string select_wo_mix = $"SELECT \n" +
                                           $"W.WOID \n" +
                                           $",P.PRODNAME \n" +
                                           $",CASE W.WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END AS WOSTAT \n" +
                                           $",W.PLANQTY \n" +
                                           $",W.PRODQTY  \n" +
                                           $",COUNT(D.DEFECT_LOTID) \n" +
                                           $",W.WOSTDTTM \n" +
                                           $",W.WOEDDTTM \n" +
                                           $",W.PLANDTTM \n" +
                                           $",W.ETC  \n" +
                                       $"FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D  \n" +
                                       $"WHERE \n" +
                                           $" W.PROCID = 'P0001'  \n" +
                                           $"AND PLANDTTM >= '{date1.Year}/{date1.Month}/{date1.Day}'   \n" +
                                           $"AND PLANDTTM <= TO_DATE('{date2.Year}/{date2.Month}/{date2.Day}')+1  \n" +
                                           $"AND W.WOID = L.WOID(+)  \n" +
                                           $"AND W.PRODID = P.PRODID  \n" +
                                           $"AND L.LOTID = D.DEFECT_LOTID(+)  \n" +
                                           $"AND WOSTAT <>'D'  \n" +
                                           $"AND W.WOSTAT NOT IN (SELECT W.WOSTAT FROM WORKORDER W WHERE W.WOSTAT = 'P')  \n" +
                                           $"AND L.LOTSTAT <> 'D' \n" +
                                       $"GROUP BY W.WOID, P.PRODNAME, W.WOSTAT, W.PLANQTY, W.PRODQTY, W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC  \n" +
                                       $"ORDER BY (DECODE(WOSTAT,'진행중',0,1))";
                Common.DB_Connection(select_wo_mix, WLGrid);

            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                //사출 콤보박스 선택 PROCID='P0002'
                string select_wo_injection = $"SELECT \n" +
                                               $"W.WOID \n" +
                                               $",P.PRODNAME \n" +
                                               $",CASE W.WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END AS WOSTAT \n" +
                                               $",W.PLANQTY \n" +
                                               $",W.PRODQTY  \n" +
                                               $",COUNT(D.DEFECT_LOTID) \n" +
                                               $",W.WOSTDTTM \n" +
                                               $",W.WOEDDTTM \n" +
                                               $",W.PLANDTTM \n" +
                                               $",W.ETC  \n" +
                                           $"FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D  \n" +
                                           $"WHERE  \n" +
                                               $"W.PROCID = 'P0002'  \n" +
                                               $"AND PLANDTTM >= '{date1.Year}/{date1.Month}/{date1.Day}'   \n" +
                                               $"AND PLANDTTM <= TO_DATE('{date2.Year}/{date2.Month}/{date2.Day}')+1  \n" +
                                               $"AND W.WOID = L.WOID(+)  \n" +
                                               $"AND W.PRODID = P.PRODID  \n" +
                                               $"AND L.LOTID = D.DEFECT_LOTID(+)  \n" +
                                               $"AND WOSTAT <>'D'  \n" +
                                               $"AND W.WOSTAT NOT IN (SELECT W.WOSTAT FROM WORKORDER W WHERE W.WOSTAT = 'P')  \n" +
                                               $"AND L.LOTSTAT <> 'D' \n" +
                                           $"GROUP BY W.WOID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC  \n" +
                                           $"ORDER BY (DECODE(WOSTAT,'진행중',0,1))";
                Common.DB_Connection(select_wo_injection, WLGrid);

            }
            Common.Disable_sorting_Datagrid(WLGrid);
        }

        private void InquiryBtn_Click(object sender, EventArgs e)
        {
            //조회버튼
            DataSearch();
            SetRowColor();
        }

        public string woid;

        private void WLGrid_MouseClick(object sender, MouseEventArgs e)
        {
            //WLGrid 선택했을때 LotGrid에 표시될 데이터값
            for (int i = 0; i < WLGrid.Rows.Count-1; i++)
            {

                if (WLGrid.Rows[i].Selected == true)
                {               
                    woid = WLGrid.Rows[i].Cells[0].Value.ToString();
                    string Selected_lot =   $"SELECT " +
                                                $"L.LOTID" +
                                                $",L.EQPTID "+
                                                $",L.LOTSTDTTM" +
                                                $",L.LOTEDDTTM"+
                                                $",CASE WHEN L.LOTID IN(SELECT DEFECT_LOTID FROM DEFECTLOT WHERE WOID='{woid}') THEN 'Y' ELSE 'N' END AS 불량 "+
                                            $"FROM LOT L "+
                                            $"WHERE WOID = '{woid}'";
                    Common.DB_Connection(Selected_lot, LotGrid);
                    Common.Disable_sorting_Datagrid(LotGrid);
                }
            }
            
        }
        public void SetRowColor()
        {
            for (int i = 0; i < WLGrid.Rows.Count - 1; i++)
            {
                if (WLGrid.Rows[i].Displayed)
                {
                    if (WLGrid.Columns.Contains("WOSTAT"))
                    {
                        if (WLGrid.Rows[i].Cells["WOSTAT"].Value.ToString().Contains("진행중"))
                        {
                            WLGrid.FirstDisplayedCell = WLGrid.Rows[i].Cells[0];
                            WLGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                        }
                    }
                }
            }
        }
    }
}
