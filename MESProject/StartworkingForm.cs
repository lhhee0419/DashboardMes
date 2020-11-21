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
        //1200000
        int mixing_time = 1200000, delaytime = 5;
        string Userid, Lotid, CurrQty, woid;
        int Temp, Press;
        Size orj_s1, orj_s2, orj_s3, orj_p1, orj_m1, orj_m2, orj_ms1, orj_ms2, orj_p2, orj_s10;
        Color Offcolor = Color.FromArgb(51, 153, 255);
        Color Oncolor = Color.FromArgb(255, 128, 0);
        int stop_timer_flag = 0;
        string[] Defect = new string[] { "DF001", "DF002", "DF005", "DF006", "DF007" };
        Random random1 = new Random();
        public Startworking()
        {
            InitializeComponent();
        }

        private void Startworking_Load(object sender, EventArgs e)
        {
            //애니메이션 설정
            orj_s1 = s1.Size;
            orj_s2 = s2.Size;
            orj_s3 = s3.Size;
            orj_p1 = p1.Size;
            orj_m1 = m1.Size;
            orj_m2 = m2.Size;
            orj_ms1 = ms1.Size;
            orj_ms2 = ms2.Size;
            orj_p2 = p2.Size;
            orj_s10 = s10.Size;
            clear_Color_all();

            //사용자 ID
            Userid = MainForm.User_ID;

            //시간표시 타이머
            timer8.Interval = 1000;
            timer8.Start();

            timer1.Interval = 3000;
            //작업지시서, LOT 조회
            Inquiry_Woid();
            Inquiry_Lot();

            //작업지시서 상태가 종료일 때 버튼 사용 금지
            Inquiry_Wostat();

            //DataGridView 디자인
            Common.SetGridDesign(WoGrid);
            Common.SetGridDesign(LotGrid);
            int[] SetCoiumnWidth_LotGrid = new int[] { 115, 23, 58, 20, 130 };
            for (int i = 0; i < SetCoiumnWidth_LotGrid.Length; i++)
            {
                Common.SetColumnWidth(LotGrid, i, SetCoiumnWidth_LotGrid[i]);
            }
            LotGrid.Font = new Font("Fixsys", 11, FontStyle.Regular);
            WoGrid.Font = new Font("Fixsys", 13, FontStyle.Regular);
            WoGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //저장소 현재량 조회
            Select_store("SL001");
            silo1_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL002");
            silo2_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL003");
            silo3_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL010");
            silo10_Qty.Text = "저장량: " + CurrQty;

        }
        private void Inquiry_Wostat()
        {
            string wostat = WoGrid.Rows[0].Cells[2].Value.ToString();
            if (wostat == "종료")
            {
                EndBtn.Enabled = false;
                StartBtn1.Enabled = false;
                StartBtn2.Enabled = false;
            }
            else if (wostat == "대기")
            {
                EndBtn.Enabled = false;
                StartBtn1.Enabled = false;
                StartBtn2.Enabled = false;
                FaultyBtn.Enabled = false;
            }
        }
        private void clear_Color(PictureBox pBox)
        {
            pBox.Width = 0;
            pBox.Height = 0;
        }
        private void clear_Color_all()
        {
            clear_Color(s1);
            clear_Color(s2);
            clear_Color(s3);
            clear_Color(p1);
            clear_Color(m1);
            clear_Color(m2);
            clear_Color(ms1);
            clear_Color(ms2);
            clear_Color(p2);
            clear_Color(s10);
        }
        private void DrawLeftToRight(PictureBox PBox, Size sz, int StopWidth = 0, Point point = new Point(), int delay = 0)
        {
            PBox.Height = sz.Height;
            for (int i = 0; i < sz.Width; i++)
            {
                if (!point.IsEmpty)
                    PBox.Location = point;
                if (StopWidth > 0 && StopWidth < i)
                    continue;
                if (delay != 0)
                    delaytime = delay;
                PBox.Width = i;
                Delay(delaytime - 1);
            }
        }

        private void UpToDown(PictureBox PBox, Size sz)
        {
            PBox.Width = sz.Width;

            for (int i = 0; i < sz.Height; i++)
            {
                PBox.Height = i;
                Delay(delaytime);
            }
        }

        private void DrawoRightToLeft(PictureBox PBox, Size sz, int StopWidth = 0, Point point = new Point())
        {
            PBox.Height = sz.Height;
            for (int i = 0; i < StopWidth; i++)
            {
                if (!point.IsEmpty)
                    PBox.Location = new Point(point.X - i, point.Y);
                if (StopWidth > 0 && StopWidth < i)
                    continue;
                PBox.Width = i;
                Delay(delaytime);
            }
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



        public void Inquiry_Woid()
        {
            //WoGrid에 표시될 데이터 가져오기
            string select_wo = $"SELECT \n" +
                                    $"P.PRODID  \n" +
                                    $",P.PRODNAME  \n" +
                                    $",CASE WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END \n" +
                                    $",W.PLANQTY \n" +
                                    $",W.PRODQTY \n" +
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
            Common.Disable_sorting_Datagrid(WoGrid);
        }
        public void Inquiry_Lot()
        {
            //LotGrid에 표시될 데이터 가져오기
            string Selected_lot = $"SELECT \n" +
                                    $"LOTID \n" +
                                    $",LOTSTAT \n" +
                                    $",EQPTID \n" +
                                    $",CASE WHEN L.LOTID IN( \n" +
                                        $"SELECT DEFECT_LOTID \n" +
                                        $"FROM DEFECTLOT \n" +
                                        $"WHERE WOID='{Selected_woid}') THEN 'Y' ELSE 'N' END \n" +
                                    $",TO_CHAR(LOTSTDTTM, 'YY-MM-DD HH24:MI:SS') \n" +
                                    $",TO_CHAR(LOTEDDTTM, 'YY-MM-DD HH24:MI:SS') \n" +
                                  $"FROM LOT L \n" +
                                  $"WHERE WOID = '{Selected_woid}' AND LOTSTAT <>'D' \n" +
                                  $"ORDER BY LOTID DESC\n";

            Common.DB_Connection(Selected_lot, LotGrid);

            if (LotGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "LOT코드", "상태", "설비코드", "불량", "시작시간", "종료시간" };
                for (int i = 0; i < header.Length; i++)
                {
                    LotGrid.Columns[i].HeaderText = $"{header[i]}";
                    LotGrid.Columns[i].ReadOnly = true;
                }
            }
            Common.Disable_sorting_Datagrid(LotGrid);

        }

        private void EQPTDATA_TEMP()
        {
            Random random = new Random();
            int TEMP = random.Next(120, 150);

            string INSERT_TEMP = $"INSERT INTO EQPTDATACOLLECT (EQPTID," +
                                                             $" LOTID," +
                                                             $" EQPTITEMID," +
                                                             $" EQPTITEMVALUE," +
                                                             $" EQPTITEMDTTM)" +
                                                             $" VALUES(" +
                                                             $" '{EQPTID}'," +
                                                             $" '{Lotid}'," +  //LOTID
                                                             $" 'ED001'," +
                                                             $" '{TEMP}'," +
                                                             $" TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'))";
            Common.DB_Connection(INSERT_TEMP);
        }

        private void EQPTDATA_PRESS()
        {
            Random random = new Random();
            int PRESS = random.Next(100, 160);

            string INSERT_PRESS = $"INSERT INTO EQPTDATACOLLECT (EQPTID," +
                                                             $" LOTID," +
                                                             $" EQPTITEMID," +
                                                             $" EQPTITEMVALUE," +
                                                             $" EQPTITEMDTTM)" +
                                                             $" VALUES(" +
                                                             $" '{EQPTID}'," +
                                                             $" '{Lotid}'," +  //LOTID
                                                             $" 'ED002'," +
                                                             $" '{PRESS}'," +
                                                             $" TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'))";
            Common.DB_Connection(INSERT_PRESS);
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

        private void Startworking_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop_timer_flag = 1;
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
            Eqptstat_Changed("DOWN");
            Inquiry_Woid();
        }
        private void Eqptstat_Changed(string eqptstat)
        {
            //설비 상태 변경
            string EqptStat = $"UPDATE EQUIPMENT SET EQPTSTATS = '{eqptstat}' WHERE EQPTID='{EQPTID}'";
            Common.DB_Connection(EqptStat);
        }

        private void StartBtn1_Click(object sender, EventArgs e)
        {
            //1호 배합시작버튼
            Stopbtn.Enabled = true;
            EQPTID = "MX001";
            Eqptstat_Changed("RUN");
            Check_Store_CurrQty();
            stop_timer_flag = 0;
            timer1.Start();
            StartBtn1.Enabled = false;
            StartBtn2.Enabled = false;

        }
        private void StartBtn2_Click(object sender, EventArgs e)
        {
            //2호 배합시작버튼
            Stopbtn.Enabled = true;
            EQPTID = "MX002";
            Eqptstat_Changed("RUN");
            Check_Store_CurrQty();
            timer1.Start();
            stop_timer_flag = 0;
            StartBtn1.Enabled = false;
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
            if (data_Table.Rows.Count > 0)
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

            //DB에 WORKORDER_PRODQTY 업데이트
            string UPDATE_WO_PRODQTY = $"UPDATE " +
                                            $"WORKORDER " +
                                        $"SET " +
                                            $"PRODQTY = (" +
                                                        $"SELECT NVL(SUM(LOTQTY),0) " +
                                                        $"FROM LOT " +
                                                        $"WHERE WOID ='{Selected_woid}' " +
                                                        $"AND LOTSTAT <> 'D' " +
                                                        $"AND LOTID NOT IN(SELECT DEFECT_LOTID FROM DEFECTLOT)" +
                                                        $") " +
                                        $"WHERE WOID = '{Selected_woid}'";
            Common.DB_Connection(UPDATE_WO_PRODQTY);

            string DD = $"SELECT LOTID FROM LOT WHERE WOID = '{Selected_woid}' AND ROWNUM = 1 ORDER BY LOTID DESC ";
            DataTable dataTable1 = Common.DB_Connection(DD);
            Lotid = dataTable1.Rows[0][0].ToString();
            EQPTDATA_TEMP();
            EQPTDATA_PRESS();
            Inquiry_Lot();
            Inquiry_Woid();
        }

        public void StopTimer()
        {
            stop_timer_flag = 1;
            Stopbtn.Enabled = false;
            StartBtn1.Enabled = true;
            StartBtn2.Enabled = true;
        }
        private void Check_Store_CurrQty()
        {
            Select_store("SL001");
            silo1_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL002");
            silo2_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL003");
            silo3_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL010");
            silo10_Qty.Text = "저장량: " + CurrQty;
            int silo1_currQty = Convert.ToInt32((silo1_Qty.Text).Substring(4));
            int silo2_currQty = Convert.ToInt32((silo2_Qty.Text).Substring(4));
            int silo3_currQty = Convert.ToInt32((silo3_Qty.Text).Substring(4));
            int silo10_currQty = Convert.ToInt32((silo10_Qty.Text).Substring(4));
            if (silo1_currQty <= 50 || silo2_currQty <= 50 || silo3_currQty <= 50 || silo10_currQty >= 10000)
            {
                timer1.Stop();
                if (silo1_currQty <= 50)
                {
                    MessageBox.Show("저장소 SILO#1의 원재료가 부족합니다.");
                }
                else if (silo2_currQty <= 50)
                {
                    MessageBox.Show("저장소 SILO#2의 원재료가 부족합니다.");
                }
                else if (silo3_currQty <= 50)
                {
                    MessageBox.Show("저장소 SILO#3의 원재료가 부족합니다.");
                }
                else if (silo10_currQty >= 10000)
                {
                    MessageBox.Show("저장소 SILO#10가 꽉 찼습니다. ");
                }
                if (EQPTID == "MX001")
                {
                    StartBtn1.Enabled = true;
                }
                else if (EQPTID == "MX002")
                {
                    StartBtn2.Enabled = true;
                }
            }
        }
        private void Stopbtn_Click(object sender, EventArgs e)
        {
            // 긴급 중지 버튼
            StopTimer();
            // Stopbtn.Enabled = false;
            Eqptstat_Changed("DOWN");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            /* timer1.Interval = 12000;*/
            timer1.Interval = 1300000;
            try
            {
                if (EQPTID == "MX001")
                {
                    /* //1호 이송
                     Mixing1_1.BackColor = Oncolor;
                     UpToDown(s1, orj_s1);
                     DrawLeftToRight(p1, orj_p1, 220, new Point(103, 250));
                     UpToDown(m1, orj_m1);
                     clear_Color_all();
                     Update_store('-', 10, "SL001");
                     Select_store("SL001");
                     silo1_Qty.Text = "저장량: " + CurrQty;
                     Delay(500);

                     //2호 이송
                     Mixing1_1.BackColor = Offcolor;
                     Mixing1_2.BackColor = Oncolor;
                     UpToDown(s2, orj_s2);
                     DrawLeftToRight(p1, orj_p1, 120, new Point(200, 250));
                     UpToDown(m1, orj_m1);
                     clear_Color_all();
                     Update_store('-', 10, "SL002");
                     Select_store("SL002");
                     silo2_Qty.Text = "저장량: " + CurrQty;
                     Delay(500);


                     //3호 이송
                     Mixing1_2.BackColor = Offcolor;
                     Mixing1_3.BackColor = Oncolor;
                     UpToDown(s3, orj_s3);
                     DrawLeftToRight(p1, orj_p1, 25, new Point(300, 250));
                     UpToDown(m1, orj_m1);
                     clear_Color_all();
                     Update_store('-', 10, "SL003");
                     Select_store("SL003");
                     silo3_Qty.Text = "저장량: " + CurrQty;
                     Delay(500);

                     //배합 시작
                     Mixing1_3.BackColor = Offcolor;
                     Mixing_Start1.BackColor = Oncolor;
                     Create_Lot();
                     if (Lotid != null)
                     {
                         string eqpt_value = $"SELECT EQPTITEMID,EQPTITEMVALUE FROM EQPTDATACOLLECT WHERE LOTID= '{Lotid}'";
                         DataTable dataTable = Common.DB_Connection(eqpt_value);
                         Temp = Convert.ToInt32(dataTable.Rows[0][1].ToString());
                         Press = Convert.ToInt32(dataTable.Rows[1][1].ToString());
                     }
                     Delay(mixing_time);

                     //배합 완료
                     Mixing_Start1.BackColor = Offcolor;
                     Mixing_End1.BackColor = Oncolor;
                     int k = random1.Next(0, 4);
                     if (Lotid != null)
                     {
                         if (Temp >= 145 || Press >= 155)
                         {
                             string Defectid = Defect[k];
                             string add_defectlot = $"INSERT INTO DEFECTLOT VALUES ('{Lotid}',1,TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'),'{Defectid}')";
                             Common.DB_Connection(add_defectlot);
                         }
                         string lot_eddttm = $"UPDATE " +
                                                 $"LOT " +
                                             $"SET " +
                                                 $"LOTEDDTTM = TO_CHAR(SYSDATE ,'YY/MM/DD HH24:MI:SS')" +
                                                 $",LOTSTAT = 'E' " +
                                             $"WHERE LOTID = '{Lotid}' ";
                         Common.DB_Connection(lot_eddttm);
                     }
                     Inquiry_Lot();
                     Delay(500);

                     //배출 완료
                     Mixing_End1.BackColor = Offcolor;
                     pass1.BackColor = Oncolor;
                     UpToDown(ms1, orj_ms1);
                     DrawLeftToRight(p2, orj_p2, 108);
                     UpToDown(s10, orj_s10);
                     clear_Color_all();
                     Random random = new Random();
                     int num = random.Next(20, 30);
                     if (silo10_Qty.Text.Length > 4)
                     {
                         int silo10_currQty = Convert.ToInt32((silo10_Qty.Text).Substring(4));
                         if (silo10_currQty + num > 10000)
                         {
                             num = 10000 - silo10_currQty;
                             Update_store('+', num, "SL010");
                             Select_store("SL010");
                             silo10_Qty.Text = "저장량: " + CurrQty;
                             MessageBox.Show("SILO#10의 저장소가 꽉 찼습니다.");
                         }
                         else
                         {
                             Update_store('+', num, "SL010");
                             Select_store("SL010");
                             silo10_Qty.Text = "저장량: " + CurrQty;
                         }
                     }

                     Delay(500);
                     Inquiry_Lot();
                     Inquiry_Woid();
                     pass1.BackColor = Offcolor;*/
                    //배합 시작
                    Mixing1_3.BackColor = Offcolor;
                    Mixing_Start1.BackColor = Oncolor;
                    Create_Lot();
                    if (Lotid != null)
                    {
                        string eqpt_value = $"SELECT EQPTITEMID,EQPTITEMVALUE FROM EQPTDATACOLLECT WHERE LOTID= '{Lotid}'";
                        DataTable dataTable = Common.DB_Connection(eqpt_value);
                        Temp = Convert.ToInt32(dataTable.Rows[0][1].ToString());
                        Press = Convert.ToInt32(dataTable.Rows[1][1].ToString());
                    }
                    Delay(mixing_time);

                    //배합 완료
                    Mixing_Start1.BackColor = Offcolor;
                    Mixing_End1.BackColor = Oncolor;
                    int k = random1.Next(0, 4);
                    if (Lotid != null)
                    {
                        if (Temp >= 145 || Press >= 155)
                        {
                            string Defectid = Defect[k];
                            string add_defectlot = $"INSERT INTO DEFECTLOT VALUES ('{Lotid}',1,TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'),'{Defectid}')";
                            Common.DB_Connection(add_defectlot);
                        }
                        string lot_eddttm = $"UPDATE " +
                                                $"LOT " +
                                            $"SET " +
                                                $"LOTEDDTTM = TO_CHAR(SYSDATE ,'YY/MM/DD HH24:MI:SS')" +
                                                $",LOTSTAT = 'E' " +
                                            $"WHERE LOTID = '{Lotid}' ";
                        Common.DB_Connection(lot_eddttm);
                    }
                    Inquiry_Lot();
                    Delay(500);


                }
                else if (EQPTID == "MX002")
                {
                    //1호 이송
                    Mixing2_1.BackColor = Oncolor;
                    UpToDown(s1, orj_s1);
                    DrawLeftToRight(p1, orj_p1, 0, new Point(101, 250), 2);
                    UpToDown(m2, orj_m2);
                    clear_Color_all();
                    Update_store('-', 10, "SL001");
                    Select_store("SL001");
                    silo1_Qty.Text = "저장량: " + CurrQty;
                    Delay(500);

                    //2호이송
                    Mixing2_1.BackColor = Color.FromArgb(51, 153, 255);
                    Mixing2_2.BackColor = Color.FromArgb(255, 128, 0);
                    UpToDown(s2, orj_s1);
                    DrawLeftToRight(p1, orj_p1, 320, new Point(200, 250));
                    UpToDown(m2, orj_m2);
                    clear_Color_all();
                    Update_store('-', 10, "SL002");
                    Select_store("SL002");
                    silo2_Qty.Text = "저장량: " + CurrQty;
                    Delay(500);

                    //3호 이송
                    Mixing2_2.BackColor = Color.FromArgb(51, 153, 255);
                    Mixing2_3.BackColor = Color.FromArgb(255, 128, 0);
                    UpToDown(s3, orj_s3);
                    DrawLeftToRight(p1, orj_p1, 220, new Point(300, 250));
                    UpToDown(m2, orj_m2);
                    clear_Color_all();
                    Update_store('-', 10, "SL003");
                    Select_store("SL003");
                    silo3_Qty.Text = "저장량: " + CurrQty;

                    Delay(500);

                    //배합시작
                    Mixing2_3.BackColor = Color.FromArgb(51, 153, 255);
                    Mixing_Start2.BackColor = Color.FromArgb(255, 128, 0);
                    Create_Lot();
                    if (LotGrid.Rows.Count > 0)
                    {
                        Lotid = LotGrid.Rows[0].Cells[0].Value.ToString();
                        string eqpt_value = $"SELECT EQPTITEMID,EQPTITEMVALUE FROM EQPTDATACOLLECT WHERE LOTID= '{Lotid}'";
                        DataTable dataTable = Common.DB_Connection(eqpt_value);
                        Temp = Convert.ToInt32(dataTable.Rows[0][1].ToString());
                        Press = Convert.ToInt32(dataTable.Rows[1][1].ToString());
                    }
                    Delay(mixing_time);

                    //배합 완료
                    Mixing_Start2.BackColor = Color.FromArgb(51, 153, 255);
                    Mixing_End2.BackColor = Color.FromArgb(255, 128, 0);
                    int k = random1.Next(0, 4);
                    if(Lotid != null)
                    {
                        if (Temp >= 145 || Press >= 155)
                        {
                            string Defectid = Defect[k];
                            string add_defectlot = $"INSERT INTO DEFECTLOT VALUES ('{Lotid}',1,TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'),'{Defectid}')";
                            Common.DB_Connection(add_defectlot);
                            string lot_eddttm = $"UPDATE LOT SET LOTEDDTTM=TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'), LOTSTAT = 'E' WHERE LOTID = '{Lotid}' ";
                            Common.DB_Connection(lot_eddttm);
                        }
                    }
                    Inquiry_Lot();
                    Delay(500);

                    //배츌완료
                    Mixing_End2.BackColor = Color.FromArgb(51, 153, 255);
                    pass2.BackColor = Color.FromArgb(255, 128, 0);
                    UpToDown(ms2, orj_ms2);
                    DrawoRightToLeft(p2, orj_p2, 107, new Point(520, 438));
                    UpToDown(s10, orj_s10);
                    clear_Color_all();
                    Random random = new Random();
                    int num = random.Next(20, 30);
                    if (silo10_Qty.Text.Length > 4)
                    {
                        int silo10_currQty = Convert.ToInt32((silo10_Qty.Text).Substring(4));
                        if (silo10_currQty + num > 10000)
                        {
                            num = 10000 - silo10_currQty;
                            Update_store('+', num, "SL010");
                            Select_store("SL010");
                            silo10_Qty.Text = "저장량: " + CurrQty;
                            MessageBox.Show("SILO#10의 저장소가 꽉 찼습니다.");
                        }
                        else
                        {
                            Update_store('+', num, "SL010");
                            Select_store("SL010");
                            silo10_Qty.Text = "저장량: " + CurrQty;
                            timer1.Start();
                        }
                    }
                    Delay(500);
                    pass2.BackColor = Color.FromArgb(51, 153, 255);
                }
                if (stop_timer_flag == 1)
                    timer1.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void timer8_Tick(object sender, EventArgs e)
        {
            try
            {
                // 현재시간
                CurDTTM.Text = DateTime.Now.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : timer8Tick");
            }
        }

    }
}