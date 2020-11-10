using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MESProject
{
    public partial class Startworking : Form
    {
        public static string Selected_woid { get; set; }
        public static string EQPTID { get; set; }
        public static int time = 1000;
        string Userid, Lotid, CurrQty, woid;

        public Startworking()
        {
            InitializeComponent();
        }

        private void Startworking_Load(object sender, EventArgs e)
        {
            Userid = MainForm.User_ID;
            timer8.Interval = 1000;
            timer8.Start();
            //작업지시서, LOT 조회
            Inquiry_Woid();
            Inquiry_Lot();

            //DataGridView 디자인
            Common.SetGridDesign(WoGrid);
            Common.SetGridDesign(LotGrid);
            Common.SetColumnWidth(LotGrid, 0, 130);
            Common.SetColumnWidth(LotGrid, 1, 30);
            Common.SetColumnWidth(LotGrid, 2, 30);
            Common.SetColumnWidth(LotGrid, 3, 140);
            LotGrid.Font = new Font("Fixsys", 12, FontStyle.Regular);
            WoGrid.Font = new Font("Fixsys", 13, FontStyle.Regular);
            WoGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            //배합기 작업 버튼 잠금
            BtnEnabled();

            //저장소 현재량 조회
            SetStore_CurQty();

        }
        private void BtnEnabled()
        {
            if (LotGrid.Rows.Count > 1)
            {
                string lotid = LotGrid.Rows[0].Cells[0].Value.ToString();
                string select_eqpt = $"SELECT EQPTID FROM LOT WHERE LOTID ='{lotid}'";
                DataTable dataTable = Common.DB_Connection(select_eqpt);
                string eqptid = dataTable.Rows[0][0].ToString();
                if (eqptid == "MX001")
                {
                    EQPTID = "MX001";
                    StartBtn2.Enabled = false;
                }
                else if (eqptid == "MX002")
                {
                    EQPTID = "MX002";
                    StartBtn1.Enabled = false;
                }
            }
        }
        private void SetStore_CurQty()
        {
            Select_store("SL001");
            silo1_Qty.Text = "저장량: " + CurrQty;
            Update_store('-', 10, "SL002");
            Select_store("SL002");
            silo2_Qty.Text = "저장량: " + CurrQty;
            Update_store('-', 15, "SL003");
            Select_store("SL003");
            silo3_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL010");
            silo10_Qty.Text = "저장량: " + CurrQty;
        }
        public void Inquiry_Woid()
        {
            //WoGrid에 표시될 데이터 가져오기
            string select_wo = $"SELECT \n" +
                                    $"P.PRODID  \n" +
                                    $",P.PRODNAME  \n" +
                                    $",CASE WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END \n" +
                                    $",W.PLANQTY \n" +
                                    $",NVL(SUM(L.LOTQTY), 0) \n" +
                                    $",COUNT(D.DEFECT_LOTID) \n" +
                                    $",W.PLANDTTM \n" +
                                    $",W.WOSTDTTM \n" +
                                    $",W.ETC  \n" +
                                $"FROM WORKORDER W  \n" +
                                    $"INNER JOIN PRODUCT P ON W.PRODID = P.PRODID \n" +
                                    $"LEFT JOIN LOT L ON W.WOID = L.WOID AND L.LOTSTAT <> 'D' \n" +
                                    $"LEFT JOIN DEFECTLOT D ON L.LOTID = D.DEFECT_LOTID \n" +
                                $"WHERE W.WOID = '{Selected_woid}'  \n" +
                                $"GROUP BY P.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY, W.PRODQTY, W.PLANDTTM, W.WOSTDTTM, W.ETC  \n";
            Common.DB_Connection(select_wo, WoGrid);
            if (WoGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "제품코드", "제품명", "작업상태", "계획수량", "생산수량", "불량수량", "계획날짜", "작업지시 시작일", "비고" };
                for (int i = 0; i < header.Length; i++)
                {
                    WoGrid.Columns[i].HeaderText = $"{header[i]}";
                    WoGrid.Columns[i].ReadOnly = true;

                }
            }
            WoGrid.RowTemplate.Height = 55;
        }
        public void Inquiry_Lot()
        {
            //LotGrid에 표시될 데이터 가져오기
            string Selected_lot = $"SELECT " +
                                    $"LOTID" +
                                    $",LOTSTAT" +
                                    $",CASE WHEN L.LOTID IN(" +
                                        $"SELECT DEFECT_LOTID " +
                                        $"FROM DEFECTLOT " +
                                        $"WHERE WOID='{Selected_woid}') THEN 'Y' ELSE 'N' END" +
                                    $",TO_CHAR(LOTSTDTTM, 'YY-MM-DD HH24:MI:SS')" +
                                    $",TO_CHAR(LOTEDDTTM, 'YY-MM-DD HH24:MI:SS') " +
                                  $"FROM LOT L " +
                                  $"WHERE WOID = '{Selected_woid}' AND LOTSTAT <>'D' " +
                                  $"ORDER BY LOTID";

            Common.DB_Connection(Selected_lot, LotGrid);

            if (LotGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "LOT코드", "상태", "불량", "시작시간", "종료시간" };
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
            Lot lotForm = new Lot(Selected_woid, EQPTID);
            lotForm.ShowDialog();
            Inquiry_Lot();
            Inquiry_Woid();
        }

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
            Inquiry_Lot();
            Inquiry_Woid();
        }

        private void StockBtn_Click(object sender, EventArgs e)
        {
            //원재료 재고조회 버튼
           
        }

        private void FaultyBtn_Click(object sender, EventArgs e)
        {
            //불량등록 버튼
            // Faulty 폼으로 woid값 전달
            Faulty faulty = new Faulty(Selected_woid);
            faulty.Owner = this;
            faulty.ShowDialog();
            Inquiry_Lot();
            Inquiry_Woid();
        }



        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopTimer();
            string woid = Selected_woid;
            string lotid = LotGrid.Rows[0].Cells[0].Value.ToString();
            // stopworking 폼으로 woid값 전달
            if (WoGrid.Rows[0].Cells[2].Value.ToString() == "진행중")
            {
                //WOSTATS가 진행중일 경우 STOPWORKING 폼을 오픈
                Stopworking stopworking = new Stopworking(lotid);
                stopworking.ShowDialog();
            }
            else
            {
                string select_wostat = "SELECT \n" +
                                     "COUNT(WOID)\n" +
                                   "FROM \n" +
                                       "WORKORDER \n" +
                                   "WHERE WOSTAT='S' \n" +
                                       "AND PROCID='P0001'";
                DataTable WostatTable = Common.DB_Connection(select_wostat);
                int count = Convert.ToInt32(WostatTable.Rows[0][0].ToString());
                if (count == 0)
                {
                    MessageBox.Show("재시작");
                    //재시작시 작업상태를 진행중(S), STOPWKEDDTTM을 SYSDATE로 변경, 해당하는 EQPTID에 EQPTSTATS를 RUN으로 변경
                    string update_wostat = $"UPDATE WORKORDER W SET W.WOSTAT ='S' WHERE WOID = '{Selected_woid}'";
                    Common.DB_Connection(update_wostat);
                }   
            }
            //테이블 재조회
            Inquiry_Lot();
            Inquiry_Woid();
        }

        private void EndBtn_Click(object sender, EventArgs e)
        {
            //종료버튼
            StopTimer();
            string Wo_eddttm = $"UPDATE " +
                                    $"WORKORDER " +
                                $"SET " +
                                    $"WOSTAT = 'E' " +
                                    $",WOEDDTTM=TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') " +
                                $"WHERE WOID='{Selected_woid}' ";
            Common.DB_Connection(Wo_eddttm);
            Eqptstat_Changed();
            Inquiry_Woid();

        }
        private void Eqptstat_Changed()
        {
            string EqptStat = $"UPDATE EQUIPMENT SET EQPTSTATS = 'DOWN' WHERE EQPTID='{EQPTID}'";
            Common.DB_Connection(EqptStat);
        }

        private void StartBtn1_Click(object sender, EventArgs e)
        {
            //1호 배합시작버튼
            EQPTID = "MX001";
            Eqptstat_Changed();
            SetTimer();
            timer1.Start();
            StartBtn1.Enabled = false;

        }
        private void StartBtn2_Click(object sender, EventArgs e)
        {
            //2호 배합시작버튼
            EQPTID = "MX002";
            Eqptstat_Changed();
            SetTimer();
            timer1.Start();
            StartBtn2.Enabled = false;
        }
        private void Update_store(char pm, int Qty, string StoreID)
        {
            string Mixing = $"UPDATE STORE_STORAGE SET CURRQTY = CURRQTY {pm} {Qty} WHERE STORID='{StoreID}' ";
            Common.DB_Connection(Mixing);
        }

        private void Select_store(string StoreID)
        {
            string Select_Store = $"SELECT CURRQTY FROM STORE_STORAGE WHERE STORID='{StoreID}' ";
            DataTable data_Table = Common.DB_Connection(Select_Store);
            CurrQty = data_Table.Rows[0][0].ToString();
        }


        public void Create_Lot()
        {
            string create_Lot = $"INSERT INTO LOT( \n" +
                                         $"LOTID  \n" +
                                         $", LOTSTAT \n" +
                                         $", LOTCRDTTM \n" +
                                         $", LOTSTDTTM \n" +
                                         $", WOID \n" +
                                         $", LOTCRQTY \n" +
                                         $", LOTQTY \n" +
                                         $", EQPTID \n" +
                                         $", PROCID \n" +
                                         $", INSUSER \n" +
                                         $", INSDTTM) \n" +
                                        $"VALUES \n" +
                                        $"((SELECT 'L' || TO_CHAR(SYSDATE, 'YYYYMMDD') || TO_CHAR(LAST_SEQ + 1, 'FM0000') " +
                                        $"FROM(SELECT NVL(MAX(SUBSTR(LOTID, -4)), 0) LAST_SEQ " +
                                        $"FROM LOT " +
                                        $"WHERE LOTID LIKE 'L' || TO_CHAR(SYSDATE, 'YYYYMMDD') || '%'))\n" +
                                        $",'S' \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                        $",'{Selected_woid}' \n" +
                                        $",1 \n" +
                                        $",1 \n" +
                                        $",'{EQPTID}' \n" +
                                        $",(SELECT PROCID FROM WORKORDER WHERE WOID = '{Selected_woid}') \n" +
                                        $",'{Userid}' \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS')) \n";
            Common.DB_Connection(create_Lot);
            Inquiry_Lot();
            Inquiry_Woid();
        }
        private static DateTime Delay(int MS)

        {

            DateTime ThisMoment = DateTime.Now;

            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);

            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)

            {

                System.Windows.Forms.Application.DoEvents();

                ThisMoment = DateTime.Now;

            }

            return DateTime.Now;

        }
        public void SetTimer()
        {
            timer1.Interval = time;
            timer2.Interval = time;
            timer3.Interval = time;
            timer4.Interval = time;
            timer5.Interval = time;
            timer6.Interval = time;
            timer7.Interval = time;

        }
        public void StopTimer()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();
            timer7.Stop();
            if (EQPTID == "MX001")
            {
                PassGif1.Visible = false;
                PassGif2.Visible = false;
                PassGif3.Visible = false;
                StartBtn1.Enabled = true;
                MixingP1.Visible = false;
                Mixing1_1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing1_2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing1_3.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_Start1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_End1.BackColor = Color.FromArgb(51, 153, 255);
                pass1.BackColor = Color.FromArgb(51, 153, 255);
            }
            else if (EQPTID == "MX002")
            {
                PassGif_2_1.Visible = false;
                PassGif_2_2.Visible = false;
                PassGif_2_3.Visible = false;
                StartBtn2.Enabled = true;
                MixingP2.Visible = false;
                Mixing2_1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing2_2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing2_3.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_Start2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_End2.BackColor = Color.FromArgb(51, 153, 255);
                pass2.BackColor = Color.FromArgb(51, 153, 255);
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            //1호 이송
            if (EQPTID == "MX001")
            {
                PassGif1.Visible = true;
                Mixing1_1.BackColor = Color.FromArgb(255, 128, 0);


            }
            else if (EQPTID == "MX002")
            {
                PassGif_2_1.Visible = true;
                Mixing2_1.BackColor = Color.FromArgb(255, 128, 0);
            }

            Update_store('-', 15, "SL001");
            Select_store("SL001");
            silo1_Qty.Text = "저장량: " + CurrQty;

            timer1.Stop();
            timer2.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            //2호 이송
            if (EQPTID == "MX001")
            {
                PassGif1.Visible = false;
                PassGif2.Visible = true;
                Mixing1_1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing1_2.BackColor = Color.FromArgb(255, 128, 0);

            }
            else if (EQPTID == "MX002")
            {
                PassGif_2_1.Visible = false;
                PassGif_2_2.Visible = true;
                Mixing2_1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing2_2.BackColor = Color.FromArgb(255, 128, 0);
            }
            Update_store('-', 10, "SL002");
            Select_store("SL002");
            silo2_Qty.Text = "저장량: " + CurrQty;
            timer2.Stop();
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            //3호 이송
            if (EQPTID == "MX001")
            {
                PassGif2.Visible = false;
                PassGif3.Visible = true;
                Mixing1_2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing1_3.BackColor = Color.FromArgb(255, 128, 0);
            }
            else if (EQPTID == "MX002")
            {
                PassGif_2_2.Visible = false;
                PassGif_2_3.Visible = true;
                Mixing2_2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing2_3.BackColor = Color.FromArgb(255, 128, 0);
            }
            Update_store('-', 15, "SL003");
            Select_store("SL003");
            silo3_Qty.Text = "저장량: " + CurrQty;
            timer3.Stop();
            timer4.Start();
        }



        private void timer4_Tick(object sender, EventArgs e)
        {
            //배합 시작
            if (EQPTID == "MX001")
            {
                PassGif3.Visible = false;
                Mixing1_3.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_Start1.BackColor = Color.FromArgb(255, 128, 0);
            }
            else if (EQPTID == "MX002")
            {
                PassGif_2_3.Visible = false;
                Mixing2_3.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_Start2.BackColor = Color.FromArgb(255, 128, 0);
            }

            Create_Lot();
            Lotid = LotGrid.Rows[LotGrid.Rows.Count - 2].Cells[0].Value.ToString();
            timer4.Stop();
            timer5.Start();
        }
        private void timer5_Tick(object sender, EventArgs e)
        {

            //배합 완료
            if (EQPTID == "MX001")
            {
                Mixing_Start1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_End1.BackColor = Color.FromArgb(255, 128, 0);
            }
            else if (EQPTID == "MX002")
            {
                Mixing_Start2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_End2.BackColor = Color.FromArgb(255, 128, 0);
            }

            timer5.Stop();
            timer6.Start();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            //배출완료     

            if (EQPTID == "MX001")
            {
                MixingP1.Visible = true;
                Mixing_End1.BackColor = Color.FromArgb(51, 153, 255);
                pass1.BackColor = Color.FromArgb(255, 128, 0);
            }
            else if (EQPTID == "MX002")
            {
                MixingP2.Visible = true;
                Mixing_End2.BackColor = Color.FromArgb(51, 153, 255);
                pass2.BackColor = Color.FromArgb(255, 128, 0);
            }
            string lot_eddttm = $"UPDATE LOT SET LOTEDDTTM=TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'), LOTSTAT = 'E' WHERE LOTID = '{Lotid}' ";
            Common.DB_Connection(lot_eddttm);
            Inquiry_Lot();
            timer6.Stop();
            timer7.Start();
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            MixingP1.Visible = false;
            MixingP2.Visible = false;
            if (EQPTID == "MX001")
            {
                pass1.BackColor = Color.FromArgb(51, 153, 255);
            }
            else if (EQPTID == "MX002")
            {
                pass2.BackColor = Color.FromArgb(51, 153, 255);
            }
            Random random = new Random();
            int num = random.Next(20, 30);
            Update_store('+', num, "SL010");
            Select_store("SL010");
            silo10_Qty.Text = "저장량: " + CurrQty;
            timer7.Stop();
            timer1.Start();
        }
        private void timer8_Tick(object sender, EventArgs e)
        {
            // 현재시간
            CurDTTM.Text = System.DateTime.Now.ToString();
        }

    }
}