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
        public string Selected_woid { get; set; }
        public WorkLog()
        {
            InitializeComponent();
        }

        private void WorkLog_Load(object sender, EventArgs e)
        {
            Common.SetGridDesign(WLGrid);
            Common.SetGridDesign(LotGrid);

            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            ProcCombo.SelectedIndex = 0; //콤보박스 초기값설정

            if (WLGrid.Rows.Count > 0)
            {
                WLGrid.Columns[0].HeaderText = "작업지시코드";
                WLGrid.Columns[1].HeaderText = "제품명";
                WLGrid.Columns[2].HeaderText = "작업상태";
                WLGrid.Columns[3].HeaderText = "설비코드";
                WLGrid.Columns[4].HeaderText = "계획수량";
                WLGrid.Columns[5].HeaderText = "생산수량";
                WLGrid.Columns[6].HeaderText = "불량수량";
                WLGrid.Columns[7].HeaderText = "작업시작일";
                WLGrid.Columns[8].HeaderText = "작업완료일";
                WLGrid.Columns[9].HeaderText = "계획일자";
                WLGrid.Columns[10].HeaderText = "비고";
            }
            //wl_id
            //SELECT L.LOTID, L.LOTSTDTTM, L.LOTEDDTTM, CASE WHEN L.LOTID IN(SELECT DEFECT_LOTID FROM DEFECTLOT WHERE WOID='W202010110001') THEN 'Y' ELSE 'N' END FROM LOT L, DEFECTLOT D WHERE WOID = 'W202010110001'
            string Selected_lot = $"SELECT L.LOTID, L.LOTSTDTTM, L.LOTEDDTTM, CASE WHEN L.LOTID IN(SELECT DEFECT_LOTID FROM DEFECTLOT WHERE WOID='{woid}') THEN 'Y' ELSE 'N' END FROM LOT L, DEFECTLOT D WHERE WOID = '{woid}'";
            Common.DB_Connection(Selected_lot, LotGrid);
            if (LotGrid.Rows.Count > 0)
            {
                LotGrid.Columns[0].HeaderText = "LOT코드";
                LotGrid.Columns[1].HeaderText = "시작시간";
                LotGrid.Columns[2].HeaderText = "종료시간";
                LotGrid.Columns[3].HeaderText = "불량";
            }
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
                //배합 콤보박스 선택
                string select_wo_mix = $"SELECT W.WOID, P.PRODNAME, W.WOSTAT, E.EQPTID, W.PLANQTY, W.PRODQTY, COUNT(*), W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC FROM WORKORDER W, PRODUCT P, EQUIPMENT E, LOT L, DEFECTLOT D WHERE W.PROCID='0001' and plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' and W.WOID = L.WOID AND W.PRODID = P.PRODID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, P.PRODNAME, W.WOSTAT, E.EQPTID, W.PLANQTY, W.PRODQTY, W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC";
                Common.DB_Connection(select_wo_mix, WLGrid);
                WLGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                //사출 콤보박스 선택
                string select_wo_injection = $"SELECT W.WOID, P.PRODNAME, W.WOSTAT, E.EQPTID, W.PLANQTY, W.PRODQTY, COUNT(*), W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC FROM WORKORDER W, PRODUCT P, EQUIPMENT E, LOT L, DEFECTLOT D WHERE W.PROCID='0002' and plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' and W.WOID = L.WOID AND W.PRODID = P.PRODID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, P.PRODNAME, W.WOSTAT, E.EQPTID, W.PLANQTY, W.PRODQTY, W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC";
                Common.DB_Connection(select_wo_injection, WLGrid);

            }
        }

        private void InquiryBtn_Click(object sender, EventArgs e)
        {
            DataSearch();
        }

        public string woid;
    }
}
