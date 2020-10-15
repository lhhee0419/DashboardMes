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
    public partial class Startworking : Form
    {   
        public string Selected_woid { get; set; }
        public Startworking()
        {
            InitializeComponent();
        }

        private void Startworking_Load(object sender, EventArgs e)
        {
            Common.SetGridDesign(WoGrid);
            Common.SetGridDesign(LotGrid);
            
            string select_wo_mix = $"SELECT W.WOID, P.PRODID ,P.PRODNAME, W.WOSTAT, W.PLANQTY, W.PRODQTY, COUNT(*), W.PLANDTTM, W.WOSTDTTM, W.ETC FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D WHERE W.WOID = '{Selected_woid}' AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, P.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY, W.PRODQTY, W.PLANDTTM, W.WOSTDTTM, W.ETC ";
            Common.DB_Connection(select_wo_mix, WoGrid);
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
                WoGrid.Columns[8].HeaderText = "작업지시 시작일";
                WoGrid.Columns[9].HeaderText = "비고";
            }
            Inquiry_Lot();



        }
        public void Inquiry_Lot()
        {
            string Selected_lot = $"SELECT LOTID, LOTSTAT, CASE WHEN L.LOTID IN(SELECT DEFECT_LOTID FROM DEFECTLOT WHERE WOID='{Selected_woid}') THEN 'Y' ELSE 'N' END  , LOTSTDTTM,LOTEDDTTM FROM LOT L WHERE WOID = '{Selected_woid}'";
            Common.DB_Connection(Selected_lot, LotGrid);
            if (LotGrid.Rows.Count > 0)
            {
                LotGrid.Columns[0].HeaderText = "LOT코드";
                LotGrid.Columns[1].HeaderText = "LOT상태";
                LotGrid.Columns[2].HeaderText = "LOT불량";
                LotGrid.Columns[3].HeaderText = "시작시간";
                LotGrid.Columns[4].HeaderText = "종료시간";
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기버튼
            this.Close();
        }

        private void LotaddBtn_Click(object sender, EventArgs e)
        {
            //LOT추가 버튼
            Lot lotForm = new Lot(this);
            lotForm.ShowDialog();
        }
    }
}
