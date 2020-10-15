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
        public WorkLog()
        {
            InitializeComponent();
        }

        private void WorkLog_Load(object sender, EventArgs e)
        {
            // Grid 디자인 세팅
            Common.SetGridDesign(WLGrid);
            Common.SetGridDesign(LotGrid);

            //콤보박스 초기값설정
            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            ProcCombo.SelectedIndex = 0;

            // 컬럼명 설정
            DataSearch();
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
            // LotGrid 컬럼명
            string Selected_lot = $"SELECT L.LOTID, L.LOTSTDTTM, L.LOTEDDTTM, CASE WHEN L.LOTID IN(SELECT DEFECT_LOTID FROM DEFECTLOT WHERE WOID='{woid}') THEN 'Y' ELSE 'N' END FROM LOT L, DEFECTLOT D WHERE WOID = '{woid}' AND L.LOTID = D.DEFECT_LOTID";
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
                //배합 콤보박스 선택 PROCID='P0001'
                string select_wo_mix = $"SELECT W.WOID, P.PRODNAME, W.WOSTAT, E.EQPTID, W.PLANQTY, W.PRODQTY, COUNT(*), W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC FROM WORKORDER W, PRODUCT P, EQUIPMENT E, LOT L, DEFECTLOT D WHERE W.PROCID = E.PROCID AND W.PROCID = 'P0001' AND plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' AND W.WOID = L.WOID AND W.PRODID = P.PRODID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, P.PRODNAME, W.WOSTAT, W.PLANQTY, E.EQPTID, W.PRODQTY, W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC";
                Common.DB_Connection(select_wo_mix, WLGrid);
                WLGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                //사출 콤보박스 선택 PROCID='P0002'
                string select_wo_injection = $"SELECT W.WOID, P.PRODNAME, W.WOSTAT, E.EQPTID, W.PLANQTY,W.PRODQTY, COUNT(*), W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC FROM WORKORDER W, PRODUCT P, EQUIPMENT E, LOT L, DEFECTLOT D WHERE W.PROCID = E.PROCID AND W.PROCID = 'P0002' AND plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' AND W.WOID = L.WOID AND W.PRODID = P.PRODID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, P.PRODNAME, W.WOSTAT, W.PLANQTY, E.EQPTID, W.PRODQTY, W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC";
                Common.DB_Connection(select_wo_injection, WLGrid);
                WLGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }

        private void InquiryBtn_Click(object sender, EventArgs e)
        {
            //조회버튼
            DataSearch();
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

                    string Selected_lot = $"SELECT L.LOTID, L.LOTSTDTTM, L.LOTEDDTTM, CASE WHEN L.LOTID IN(SELECT DEFECT_LOTID FROM DEFECTLOT WHERE WOID='{woid}') THEN 'Y' ELSE 'N' END FROM LOT L, DEFECTLOT D WHERE WOID = '{woid}' AND L.LOTID = D.DEFECT_LOTID";
                    Common.DB_Connection(Selected_lot, LotGrid);
                    LotGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            if (LotGrid.Rows.Count > 0)
            {
                LotGrid.Columns[0].HeaderText = "LOT코드";
                LotGrid.Columns[1].HeaderText = "시작시간";
                LotGrid.Columns[2].HeaderText = "종료시간";
                LotGrid.Columns[3].HeaderText = "불량";
            }
        }

        
    }
}
