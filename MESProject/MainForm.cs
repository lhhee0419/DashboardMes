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
        private static Login login = new Login();
        public MainForm()
        {
            InitializeComponent();
            // this.Style = MetroFramework.MetroColorStyle.White;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            ProcCombo.SelectedIndex = 0; //콤보박스 초기값설정

            Common.SetGridDesign(WoGrid);

            if (ProcCombo.SelectedIndex == 0)
            {
                string select_wo_mix = $"SELECT W.WOID as 작업지시코드 , W.PRODID as 제품코드, P.PRODNAME as 제품명, W.WOSTAT as 작업상태, W.PLANQTY as 계획수량 ,W.PRODQTY as 생산수량,COUNT(*) AS 불량수량, W.PLANDTTM as 계획날짜, W.ETC as 비고 FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D WHERE  W.PROCID = 'P0001' AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.PLANDTTM, W.ETC ";
                Common.DB_Connection(select_wo_mix, WoGrid);

            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                string select_wo_injection = $"W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY,COUNT(*), W.PLANDTTM, W.ETC FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D WHERE  W.PROCID = 'P0002' AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.PLANDTTM, W.ETC ";
                Common.DB_Connection(select_wo_injection, WoGrid);
            }


        }


        private void InquiryBtn_Click(object sender, EventArgs e)
        {
            //조회버튼 클릭시 
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            if (ProcCombo.SelectedIndex == 0)
            {
                //배합 콤보박스 선택
                string select_wo_mix = $"SELECT W.WOID as 작업지시코드 , W.PRODID as 제품코드, P.PRODNAME as 제품명, W.WOSTAT as 작업상태, W.PLANQTY as 계획수량 ,W.PRODQTY as 생산수량,COUNT(*) AS 불량수량, W.PLANDTTM as 계획날짜, W.ETC as 비고 FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D WHERE plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' AND W.PROCID = 'P0001' AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.PLANDTTM, W.ETC ";
                Common.DB_Connection(select_wo_mix, WoGrid);

            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                //사출 콤보박스 선택
                string select_wo_injection = $"SELECT W.WOID as 작업지시코드 , W.PRODID as 제품코드, P.PRODNAME as 제품명, W.WOSTAT as 작업상태, W.PLANQTY as 계획수량 ,W.PRODQTY as 생산수량,COUNT(*) AS 불량수량, W.PLANDTTM as 계획날짜, W.ETC as 비고 FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D WHERE plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' AND W.PROCID = 'P0002' AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.PLANDTTM, W.ETC ";
                Common.DB_Connection(select_wo_injection, WoGrid);

            }



        }

        private void WostBtn_Click(object sender, EventArgs e)
        {
            //작업시작 버튼                                                                               
            Startworking startworkingForm = new Startworking();
            startworkingForm.TopLevel = false;
            maintab.TabPages.Add((maintab.TabPages.Count + 1).ToString());
            maintab.TabPages[maintab.TabPages.Count - 1].Controls.Add(startworkingForm);
            maintab.SelectedIndex = maintab.TabPages.Count - 1;
            maintab.SelectedTab.Text = "작업시작";
            //maintab.TabPages[maintab.TabPages.Count - 1].Controls.Add(startworkingForm);
            startworkingForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            startworkingForm.Show();
            startworkingForm.FormClosed += Form_closing;
           
        }
        public void Form_closing(object sender, FormClosedEventArgs e)
        {
            maintab.TabPages.Remove(maintab.SelectedTab);
        }
                                                                                                                                                                      
        private void logoutbtn_Click(object sender, EventArgs e)
        {
            //로그아웃버튼
            login.Show();
            this.Hide();
        }
    }
}
/**/
