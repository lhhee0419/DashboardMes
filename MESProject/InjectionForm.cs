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
        public Startworking()
        {
            InitializeComponent();
        }

        private void Startworking_Load(object sender, EventArgs e)
        {
            Common.SetGridDesign(WoGrid);
            Common.SetGridDesign(LotGrid);

            string select_wo_mix = $"SELECT W.WOID as 작업지시코드 , W.PRODID as 제품코드, P.PRODNAME as 제품명, W.WOSTAT as 작업상태, W.PLANQTY as 계획수량(KG) ,W.PRODQTY as 생산수량(KG),COUNT(*) AS 불량수량, W.PLANDTTM as 계획날짜, W.WOSTDTTM as 시작날짜, W.ETC as 비고 FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D WHERE  W.PROCID = 'P0001' AND W.PRODID = P.PRODID AND W.WOID = L.WOID AND L.LOTID = D.DEFECT_LOTID GROUP BY W.WOID, W.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY,W.PRODQTY, W.PLANDTTM, W.WOSTDTTM, W.ETC ";
            Common.DB_Connection(select_wo_mix, WoGrid);

            //string select_lot_mix = $"select L.LOTID as LOT코드, L.LOTSTAT as LOT상태, d.defect_lotid as 불량, L.LOTSTDTTM as 시작시간, L.LOTEDDTTM as 종료시간 FROM lot L,DEFECTLOT D";
            //Common.DB_Connection(select_lot_mix, LotGrid);



        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기 버튼
            this.Close();
        }
    }
}
