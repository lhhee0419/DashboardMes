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
       // private static Login login = new Login();
        public MainForm()
        {
            InitializeComponent();
        }

        private void login_check()
        {
            Login login = new Login();
            //login DialogResult Value
            DialogResult result = login.ShowDialog();
            //로그인 실패시
            if (result != DialogResult.OK)
            {
                MessageBox.Show("프로그램 종료");
                this.Close();
            }
            else
            {
                MessageBox.Show("로그인 성공");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            login_check();
            
            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            ProcCombo.SelectedIndex = 0; //콤보박스 초기값설정

            Common.SetGridDesign(WoGrid);

            DataSearch();

            if (WoGrid.Rows.Count > 0)
            {
                WoGrid.Columns[0].HeaderText = "작업지시코드";
                WoGrid.Columns[1].HeaderText = "제품코드";
                WoGrid.Columns[2].HeaderText = "제품명";
                WoGrid.Columns[3].HeaderText = "작업상태";
                WoGrid.Columns[4].HeaderText = "계획수량";
                WoGrid.Columns[5].HeaderText = "생산수량";
                WoGrid.Columns[6].HeaderText = "불량수량";
                WoGrid.Columns[7].HeaderText = "계획날짜";
                WoGrid.Columns[8].HeaderText = "비고";        
            }
        }


        private void DataSearch()
        {

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            if (ProcCombo.SelectedIndex == 0)
            {
                //배합 콤보박스 선택
                // string select_wo_mix = $"SELECT W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY,COUNT(*), W.PLANDTTM, W.ETC FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D WHERE plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' AND W.PROCID = 'P0001' AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.PLANDTTM, W.ETC ";
                string select_wo_mix =  $"SELECT W.WOID, W.PRODID, P.PRODNAME, "+
                                        $"CASE WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '시작' WHEN 'E' THEN '종료' END,"+
                                        $"W.PLANQTY,W.PRODQTY,COUNT(*), W.PLANDTTM, W.ETC "+
                                        $"FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D " +
                                        $"WHERE plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' AND  " +
                                        $"plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' AND W.PROCID = 'P0001' " +
                                        $"AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID " +
                                        $"GROUP BY W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.PLANDTTM, W.ETC ";
                Common.DB_Connection(select_wo_mix, WoGrid);
                WoGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                //사출 콤보박스 선택
                string select_wo_injection =   $"SELECT W.WOID, W.PRODID, P.PRODNAME, " +
                                               $"CASE WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '시작' WHEN 'E' THEN '종료' END," +
                                               $"W.PLANQTY,W.PRODQTY,COUNT(*), W.PLANDTTM, W.ETC " +
                                               $"FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D " +
                                               $"WHERE plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' AND  " +
                                               $"plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' AND W.PROCID = 'P0002' " +
                                               $"AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID " +
                                               $"GROUP BY W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.PLANDTTM, W.ETC ";
                Common.DB_Connection(select_wo_injection, WoGrid);

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
                }
            }
            Startworking startworkingForm = new Startworking(); 
            if(woid != "")
            {
                startworkingForm.Selected_woid = woid;
                Common.Create_Tab("startworking", "작업시작", startworkingForm, maintab);
            }
            startworkingForm.FormClosed += Form_closing;


        }
        public void Form_closing(object sender, FormClosedEventArgs e)
        {
            maintab.TabPages.Remove(maintab.SelectedTab);
        }
                                                                                                                                                                      
        private void logoutbtn_Click(object sender, EventArgs e)
        {
            //로그아웃버튼
            this.Close();
            Application.Restart();
            login_check();
           
        }

        bool isMove;
        Point fpt;
        public string woid ="";

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
    }
}

