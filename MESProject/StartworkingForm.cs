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
        private static int time = 2000;
        private static int mixing_time = 2000; //1분(60000)
        private static int delaytime = 3;
        string Userid, Lotid, CurrQty, woid, LAST_LOTID;
        int PLANQTY, PRODQTY;
        Size sz1, sz2, sz3, sz4, sz5, sz6, sz7, sz8, sz9, sz10;
        int i = 0;
        Size sz = new Size();


        public Startworking()
        {
            InitializeComponent();
            sz1 = s1.Size;
            sz2 = s2.Size;
            sz3 = s3.Size;
            sz4 = p1.Size;
            sz5 = m1.Size;
            sz6 = m2.Size;
            sz7 = ms1.Size;
            sz8 = ms2.Size;
            sz9 = p2.Size;
            sz10 = s10.Size;
        }

        private void Startworking_Load(object sender, EventArgs e)
        {
            clear_Color();
            //사용자 ID
            Userid = MainForm.User_ID;

            //시간표시 타이머
            timer8.Interval = 1000;
            timer8.Start();

            //작업지시서, LOT 조회
            Inquiry_Woid();
            Inquiry_Lot();

            //작업지시서 상태가 종료일 때 버튼 사용 금지
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

            //DataGridView 디자인
            Common.SetGridDesign(WoGrid);
            Common.SetGridDesign(LotGrid);
            int[] SetCoiumnWidth_LotGrid = new int[] { 130, 30, 30, 140 };
            for (int i = 0; i < SetCoiumnWidth_LotGrid.Length; i++)
            {
                Common.SetColumnWidth(LotGrid, i, SetCoiumnWidth_LotGrid[i]);
            }
            LotGrid.Font = new Font("Fixsys", 12, FontStyle.Regular);
            WoGrid.Font = new Font("Fixsys", 13, FontStyle.Regular);
            WoGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            //배합기 작업 버튼 잠금
            BtnEnabled();

            //저장소 현재량 조회
            Select_store("SL001");
            silo1_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL002");
            silo2_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL003");
            silo3_Qty.Text = "저장량: " + CurrQty;
            Select_store("SL010");
            silo10_Qty.Text = "저장량: " + CurrQty;

            //계획수량 만큼만 돌아가도록
            PLANQTY = Convert.ToInt32(WoGrid.Rows[0].Cells[3].Value.ToString());
            PRODQTY = Convert.ToInt32(WoGrid.Rows[0].Cells[4].Value.ToString());

            if (PLANQTY < PRODQTY)
            {
                ProdQty_check();
            }
            else
            {

            }

        }
        private void clear_Color()
        {
            Size mvSize = new Size();
            mvSize.Height = 0;
            mvSize.Width = sz1.Width;
            s1.Size = mvSize;

            mvSize.Height = 0;
            mvSize.Width = sz2.Width;
            s2.Size = mvSize;

            mvSize.Height = 0;
            mvSize.Width = sz3.Width;
            s3.Size = mvSize;

            mvSize.Height = sz4.Height;
            mvSize.Width = 0;
            p1.Size = mvSize;

            mvSize.Height = 0;
            mvSize.Width = sz5.Width;
            m1.Size = mvSize;

            mvSize.Height = 0;
            mvSize.Width = sz6.Width;
            m2.Size = mvSize;

            mvSize.Height = 0;
            mvSize.Width = sz7.Width;
            ms1.Size = mvSize;

            mvSize.Height = 0;
            mvSize.Width = sz8.Width;
            ms2.Size = mvSize;

            mvSize.Height = sz9.Height;
            mvSize.Width = 0;
            p2.Size = mvSize;

            mvSize.Height = 0;
            mvSize.Width = sz10.Width;
            s10.Size = mvSize;

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

        private void ProdQty_check()
        {
            StopTimer();
            StartBtn1.Enabled = false;
            StartBtn2.Enabled = false;
        }
        private void EQPTDATA_TEMP()
        {

            Random random = new Random();
            int TEMP = random.Next(25, 40);

            string INSERT_TEMP = $"INSERT INTO EQPTDATACOLLECT (EQPTID," +
                                                             $" LOTID," +
                                                             $" EQPTITEMID," +
                                                             $" EQPTITEMVALUE," +
                                                             $" EQPTITEMDTTM)" +
                                                             $" VALUES(" +
                                                             $" '{EQPTID}'," +
                                                             $" '{LAST_LOTID}'," +  //LOTID
                                                             $" 'ED001'," +
                                                             $" '{TEMP}'," +
                                                             $" TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'))";
            Common.DB_Connection(INSERT_TEMP);
        }

        private void EQPTDATA_PRESS()
        {
            Random random = new Random();
            int PRESS = random.Next(100, 150);

            string INSERT_PRESS = $"INSERT INTO EQPTDATACOLLECT (EQPTID," +
                                                             $" LOTID," +
                                                             $" EQPTITEMID," +
                                                             $" EQPTITEMVALUE," +
                                                             $" EQPTITEMDTTM)" +
                                                             $" VALUES(" +
                                                             $" '{EQPTID}'," +
                                                             $" '{LAST_LOTID}'," +  //LOTID
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
            string EqptStat = $"UPDATE EQUIPMENT SET EQPTSTATS = '{eqptstat}' WHERE EQPTID='{EQPTID}'";
            Common.DB_Connection(EqptStat);
        }

        private void StartBtn1_Click(object sender, EventArgs e)
        {
            //1호 배합시작버튼
            Stopbtn.Enabled = true;
            EQPTID = "MX001";
            Eqptstat_Changed("RUN");
            SetTimer();
            timer1.Start();
            StartBtn1.Enabled = false;

        }
        private void StartBtn2_Click(object sender, EventArgs e)
        {
            //2호 배합시작버튼
            Stopbtn.Enabled = true;
            EQPTID = "MX002";
            Eqptstat_Changed("RUN");
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

            //DB에 WORKORDER_PRODQTY 업데이트
            string UPDATE_WO_PRODQTY = $"UPDATE " +
                                            $"WORKORDER " +
                                        $"SET " +
                                            $"PRODQTY = (" +
                                                        $"SELECT NVL(SUM(LOTQTY),0) " +
                                                        $"FROM LOT " +
                                                        $"WHERE WOID ='{Selected_woid}' " +
                                                        $"AND LOTSTAT <> 'D'" +
                                                        $") " +
                                        $"WHERE WOID = '{Selected_woid}'";
            Common.DB_Connection(UPDATE_WO_PRODQTY);

            string DD = $"SELECT LOTID FROM LOT WHERE WOID = '{Selected_woid}' AND ROWNUM = 1 ORDER BY LOTID DESC ";
            DataTable dataTable1 = Common.DB_Connection(DD);
            LAST_LOTID = dataTable1.Rows[0][0].ToString();
            EQPTDATA_TEMP();
            EQPTDATA_PRESS();
            Inquiry_Lot();
            Inquiry_Woid();
        }


        public void SetTimer()
        {
            timer1.Interval = time;
            timer2.Interval = time;
            timer3.Interval = time;
            timer4.Interval = time;
            timer5.Interval = mixing_time;
            timer6.Interval = time;
            timer7.Interval = time;

        }
        public void StopTimer()
        {
            clear_Color();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();
            timer7.Stop();
            Stopbtn.Enabled = false;
            if (EQPTID == "MX001")
            {
                StartBtn1.Enabled = true;
                Mixing1_1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing1_2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing1_3.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_Start1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_End1.BackColor = Color.FromArgb(51, 153, 255);
                pass1.BackColor = Color.FromArgb(51, 153, 255);
            }
            else if (EQPTID == "MX002")
            {
                StartBtn2.Enabled = true;
                Mixing2_1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing2_2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing2_3.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_Start2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_End2.BackColor = Color.FromArgb(51, 153, 255);
                pass2.BackColor = Color.FromArgb(51, 153, 255);
            }


        }
        private void Stopbtn_Click(object sender, EventArgs e)
        {
            // 긴급 중지 버튼
            StopTimer();
            Stopbtn.Enabled = false;
            Eqptstat_Changed("DOWN");
        }
        private void timer1_Tick(object sender, EventArgs e)
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
                }else if(silo10_currQty >= 10000)
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
            else
            {
                //1호 이송
                if (EQPTID == "MX001")
                {
                    Mixing1_1.BackColor = Color.FromArgb(255, 128, 0);
                    for (i = 0; i < sz1.Height; i++)
                    {
                        sz.Height = i;
                        sz.Width = sz1.Width;
                        s1.Size = sz;
                        Delay(delaytime);
                    }
                    for (i = 0; i < 230; i++)
                    {
                        p1.Location = new Point(103, 250);
                        sz.Height = sz4.Height;
                        sz.Width = i;
                        p1.Size = sz;
                        Delay(delaytime);
                    }
                    for (i = 0; i < sz5.Height + 3; i++)
                    {
                        sz.Height = i;
                        sz.Width = sz5.Width;
                        m1.Size = sz;
                        Delay(delaytime);
                    }
                    clear_Color();
                }
                else if (EQPTID == "MX002")
                {
                    Mixing2_1.BackColor = Color.FromArgb(255, 128, 0);
                    for (i = 0; i < sz1.Height; i++)
                    {
                        sz.Height = i;
                        sz.Width = sz1.Width;
                        s1.Size = sz;
                        Delay(delaytime - 2);
                    }
                    for (i = 0; i < sz4.Width; i++)
                    {
                        p1.Location = new Point(101, 250);
                        sz.Height = sz4.Height;
                        sz.Width = i;
                        p1.Size = sz;
                        Delay(delaytime - 2);
                    }
                    for (i = 0; i < sz6.Height + 3; i++)
                    {
                        sz.Height = i;
                        sz.Width = sz6.Width;
                        m2.Size = sz;
                        Delay(delaytime - 2);
                    }
                    clear_Color();
                }
                Update_store('-', 10, "SL001");
                Select_store("SL001");
                silo1_Qty.Text = "저장량: " + CurrQty;
                timer1.Stop();
                timer2.Start();
            }


        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            //2호 이송
            if (EQPTID == "MX001")
            {
                Mixing1_1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing1_2.BackColor = Color.FromArgb(255, 128, 0);
                for (i = 0; i < sz2.Height; i++)
                {
                    sz.Height = i;
                    sz.Width = sz2.Width;
                    s2.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < 130; i++)
                {
                    p1.Location = new Point(200, 250);
                    sz.Height = sz4.Height;
                    sz.Width = i;
                    p1.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < sz5.Height + 3; i++)
                {
                    sz.Height = i;
                    sz.Width = sz5.Width;
                    m1.Size = sz;
                    Delay(delaytime);
                }
                clear_Color();

            }
            else if (EQPTID == "MX002")
            {

                Mixing2_1.BackColor = Color.FromArgb(51, 153, 255);
                Mixing2_2.BackColor = Color.FromArgb(255, 128, 0);
                for (i = 0; i < sz2.Height; i++)
                {
                    sz.Height = i;
                    sz.Width = sz2.Width;
                    s2.Size = sz;
                    Delay(delaytime - 1);
                }
                for (i = 0; i < 320; i++)
                {
                    p1.Location = new Point(200, 250);
                    sz.Height = sz4.Height;
                    sz.Width = i;
                    p1.Size = sz;
                    Delay(delaytime - 1);
                }
                for (i = 0; i < sz6.Height + 3; i++)
                {
                    sz.Height = i;
                    sz.Width = sz6.Width;
                    m2.Size = sz;
                    Delay(delaytime - 1);
                }
                clear_Color();
            }
            int silo2_currQty = Convert.ToInt32((silo2_Qty.Text).Substring(4));

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
                Mixing1_2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing1_3.BackColor = Color.FromArgb(255, 128, 0);
                for (i = 0; i < sz3.Height; i++)
                {
                    sz.Height = i;
                    sz.Width = sz3.Width;
                    s3.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < 25; i++)
                {
                    p1.Location = new Point(300, 250);
                    sz.Height = sz4.Height;
                    sz.Width = i;
                    p1.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < sz5.Height + 3; i++)
                {
                    sz.Height = i;
                    sz.Width = sz5.Width;
                    m1.Size = sz;
                    Delay(delaytime);
                }
                clear_Color();
            }
            else if (EQPTID == "MX002")
            {
                Mixing2_2.BackColor = Color.FromArgb(51, 153, 255);
                Mixing2_3.BackColor = Color.FromArgb(255, 128, 0);
                for (i = 0; i < sz3.Height; i++)
                {
                    sz.Height = i;
                    sz.Width = sz3.Width;
                    s3.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < 220; i++)
                {
                    p1.Location = new Point(300, 250);
                    sz.Height = sz4.Height;
                    sz.Width = i;
                    p1.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < sz6.Height + 3; i++)
                {
                    sz.Height = i;
                    sz.Width = sz6.Width;
                    m2.Size = sz;
                    Delay(delaytime);
                }
                clear_Color();
            }

            Update_store('-', 10, "SL003");
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
                Mixing1_3.BackColor = Color.FromArgb(51, 153, 255);
                Mixing_Start1.BackColor = Color.FromArgb(255, 128, 0);
            }
            else if (EQPTID == "MX002")
            {
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
                Mixing_End1.BackColor = Color.FromArgb(51, 153, 255);
                pass1.BackColor = Color.FromArgb(255, 128, 0);
                for (i = 0; i < sz7.Height; i++)
                {
                    sz.Height = i;
                    sz.Width = sz7.Width;
                    ms1.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < 108; i++)
                {
                    sz.Height = sz9.Height;
                    sz.Width = i;
                    p2.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < sz10.Height + 3; i++)
                {
                    sz.Height = i;
                    sz.Width = sz10.Width;
                    s10.Size = sz;
                    Delay(delaytime);
                }
                clear_Color();
            }
            else if (EQPTID == "MX002")
            {
                Mixing_End2.BackColor = Color.FromArgb(51, 153, 255);
                pass2.BackColor = Color.FromArgb(255, 128, 0);
                for (i = 0; i < sz8.Height; i++)
                {
                    sz.Height = i;
                    sz.Width = sz8.Width;
                    ms2.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < 107; i++)
                {
                    p2.Location = new Point(520 - i, 438);
                    sz.Height = sz9.Height;
                    sz.Width = i;
                    p2.Size = sz;
                    Delay(delaytime);
                }
                for (i = 0; i < sz10.Height + 3; i++)
                {
                    sz.Height = i;
                    sz.Width = sz10.Width;
                    s10.Size = sz;
                    Delay(delaytime);
                }
                clear_Color();
            }
            string lot_eddttm = $"UPDATE LOT SET LOTEDDTTM=TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'), LOTSTAT = 'E' WHERE LOTID = '{Lotid}' ";
            Common.DB_Connection(lot_eddttm);
            Inquiry_Lot();
            Random random = new Random();
            int num = random.Next(20, 30);
            int silo10_currQty = Convert.ToInt32((silo10_Qty.Text).Substring(4));
            if (silo10_currQty + num > 10000)
            {
                num = 10000 - silo10_currQty;
                Update_store('+', num, "SL010");
                Select_store("SL010");
                silo10_Qty.Text = "저장량: " + CurrQty;
                timer7.Stop();
                MessageBox.Show("SILO#10의 저장소가 꽉 찼습니다.");
            }
            else
            {
                Update_store('+', num, "SL010");
                Select_store("SL010");
                silo10_Qty.Text = "저장량: " + CurrQty;
                timer7.Stop();
                timer1.Start();
            }
            timer6.Stop();
            timer7.Start();
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            if (EQPTID == "MX001")
            {
                pass1.BackColor = Color.FromArgb(51, 153, 255);
            }
            else if (EQPTID == "MX002")
            {
                pass2.BackColor = Color.FromArgb(51, 153, 255);
            }
        }
        private void timer8_Tick(object sender, EventArgs e)
        {
            // 현재시간
            CurDTTM.Text = DateTime.Now.ToString();
        }

    }
}