using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    public partial class Startworking : Form
    {
        public string Selected_woid { get; set; }
        public Startworking(string woid)
        {
            InitializeComponent();
            this.woid = woid;
        }

        private void Startworking_Load(object sender, EventArgs e)
        {
            //DataGridView 디자인
            Common.SetGridDesign(WoGrid);
            Common.SetGridDesign(LotGrid);

            Inquiry_Woid();
            Inquiry_Lot();
            WoGrid.Font = new Font("Fixsys", 13, FontStyle.Regular);
            WoGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
        public void Inquiry_Woid()
        {
            //WoGrid에 표시될 데이터 가져오기
            string select_wo =  $"SELECT " +
                                    $"W.WOID" +
                                    $",P.PRODID " +
                                    $",P.PRODNAME " +
                                    $",CASE WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END" +
                                    $",W.PLANQTY" +
                                    $",NVL(W.PRODQTY,0)" +
                                    $",COUNT(D.DEFECT_LOTID)" +
                                    $",W.PLANDTTM" +
                                    $",W.WOSTDTTM" +
                                    $",W.ETC " +
                                $"FROM WORKORDER W, PRODUCT P, LOT L, DEFECTLOT D " +
                                $"WHERE W.WOID = '{Selected_woid}' " +
                                    $"AND W.PRODID = P.PRODID " +
                                    $"AND W.WOID = L.WOID(+) " +
                                    $"AND L.LOTID = D.DEFECT_LOTID(+) " +
                                $"GROUP BY W.WOID, P.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY, W.PRODQTY, W.PLANDTTM, W.WOSTDTTM, W.ETC ";

            Common.DB_Connection(select_wo, WoGrid);
            if (WoGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "작업코드", "제품코드", "제품명", "작업상태", "계획수량", "생산수량", "불량수량", "계획날짜", "작업지시 시작일", "비고" };
                for (int i = 0; i < header.Length; i++)
                {
                    WoGrid.Columns[i].HeaderText = $"{header[i]}";
                    WoGrid.Columns[i].ReadOnly = true;

                }
            }
           WoGrid.RowTemplate.Height = 85;
        }
        public void Inquiry_Lot()
        {
            //LotGrid에 표시될 데이터 가져오기
            string Selected_lot = $"SELECT "+
                                    $"LOTID" +
                                    $",LOTSTAT" +
                                    $",CASE WHEN L.LOTID IN(" +
                                        $"SELECT DEFECT_LOTID " +
                                        $"FROM DEFECTLOT " +
                                        $"WHERE WOID='{Selected_woid}') THEN 'Y' ELSE 'N' END" +
                                    $",LOTSTDTTM" +
                                    $",LOTEDDTTM " +
                                  $"FROM LOT L " +
                                  $"WHERE WOID = '{Selected_woid}' AND LOTSTAT <>'D' " +
                                  $"ORDER BY LOTID";

            Common.DB_Connection(Selected_lot, LotGrid);
            if (LotGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "LOT코드", "LOT상태", "LOT불량", "시작시간", "종료시간" };
                for (int i = 0; i < header.Length; i++)
                {
                    LotGrid.Columns[i].HeaderText = $"{header[i]}";
                    LotGrid.Columns[i].ReadOnly = true;
                }

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
        string woid;
        private void LotDelBtn_Click(object sender, EventArgs e)
        {
            //LOT 삭제 버튼
            for (int i = 0; i < LotGrid.Rows.Count - 1; i++)
            {

                if (LotGrid.Rows[i].Selected == true)
                {
                    woid = LotGrid.Rows[i].Cells[0].FormattedValue.ToString();
                }
            }
            string delete_lot = $" UPDATE LOT SET LOTSTAT = 'D' WHERE LOTID = '{woid}'";
            Common.DB_Connection(delete_lot);
            //MessageBox.Show($"LOT코드: {woid}가 삭제 되었습니다.");
            Inquiry_Lot();
        }

        private void StockBtn_Click(object sender, EventArgs e)
        {
            //원재료 재고조회 버튼
            MaterialStock materialStockForm = new MaterialStock();
            materialStockForm.ShowDialog();
        }

        private void FaultyBtn_Click(object sender, EventArgs e)
        {
            //불량등록 버튼
            // Faulty 폼으로 woid값 전달
            string woid = WoGrid.Rows[0].Cells[0].Value.ToString();
            Faulty faulty = new Faulty(woid);
            faulty.Owner = this;
            faulty.ShowDialog();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            string woid = WoGrid.Rows[0].Cells[0].Value.ToString();
            string lotid = LotGrid.Rows[0].Cells[0].Value.ToString();
            // stopworking 폼으로 woid값 전달
            if (WoGrid.Rows[0].Cells[3].Value.ToString() == "진행중" )
            {
                //WOSTATS가 진행중일 경우 STOPWORKING 폼을 오픈
                Stopworking stopworking = new Stopworking(woid, lotid, this);
                stopworking.ShowDialog();
            }
            else
            {
                MessageBox.Show("재시작");
                //재시작시 작업상태를 진행중(S), STOPWKEDDTTM을 SYSDATE로 변경, 해당하는 EQPTID에 EQPTSTATS를 RUN으로 변경
                string update_wostat = $"UPDATE WORKORDER W SET W.WOSTAT ='S', W.ETC = TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') WHERE WOID = '{Selected_woid}'";
                Common.DB_Connection(update_wostat);

                //EQPTID에 EQPTSTATS를 RUN으로 변경
                string Update_EQPTSTATS = $"UPDATE EQUIPMENT E SET E.EQPTSTATS = 'RUN' WHERE E.EQPTID IN(SELECT EQPTID FROM LOT WHERE LOTID = '{lotid}')";
                Common.DB_Connection(Update_EQPTSTATS);
                //테이블 재조회
                Inquiry_Lot();
                Inquiry_Woid();
            }
            
        }

        private void EndBtn_Click(object sender, EventArgs e)
        {
            //종료버튼
        }
    }
}


