using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;


namespace MESProject
{
    public partial class StartWorkingFormIM : Form
    {
        public static string Selected_woid { get; set; }
        public static string EQPTID { get; set; }
        string userid = MainForm.User_ID;
        string silo010 = "SL010";
        string woid;
        bool isMove;
        Point fpt;
        int PLANQTY;
        int PRODQTY;
        string LAST_LOTID;
        int need_siloQty = 50;

        Size sz2 = new Size();
        Size sz3 = new Size();
        Size sz4 = new Size();
        Size sz5 = new Size();
        Size sz6 = new Size();
        Size sz7 = new Size();

        //실행중인 스레드 가져오기
        public Thread th = Thread.CurrentThread;
        public StartWorkingFormIM()
        {
            InitializeComponent();
            sz2 = pictureBox2.Size;
            sz3 = pictureBox3.Size;
            sz4 = pictureBox4.Size;
            sz5 = pictureBox5.Size;
            sz6 = pictureBox6.Size;
            sz7 = pictureBox7.Size;

        }

        private void StartWorkingFormIM_Load(object sender, EventArgs e)
        {
            clear_Color();
            STOP_BTN.Enabled = false;
            //1,2호기의 버튼과 라벨을 보기위해 EQPTID 초기화
            EQPTID = "";
            //실시간 타이머 설정
            System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
            MyTimer.Interval = 1000;
            MyTimer.Tick += new EventHandler(timer_Tick);
            MyTimer.Enabled = true;

            //DataGridView 디자인
            Common.SetGridDesign(WoGrid);
            Common.SetGridDesign(LotGrid);

            WoGrid.Font = new Font("Fixsys", 13, FontStyle.Regular);
            LotGrid.Font = new Font("Fixsys", 12, FontStyle.Regular);
            WoGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            LotGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //데이터 조회
            Inquiry_Woid();
            Inquiry_Lot();

            //버튼 관리
            BtnEnabled();

            //작업지시서 상태가 종료일 때 버튼 사용 금지
            string wostat = WoGrid.Rows[0].Cells[2].Value.ToString();
            if (wostat == "종료")
            {
                EndBtn.Enabled = false;
                StopBtn.Enabled = false;
                IM1_STBtn.Enabled = false;
                IM2_STBtn.Enabled = false;
            }

            //1,2호기의 생산량 조회
            string SELECT_PRODQTY = $"SELECT COUNT(*) FROM LOT " +
                                    $"WHERE EQPTID = '{EQPTID}' AND" +
                                    $" SUBSTR(LOTCRDTTM,1,8) = TO_CHAR(SYSDATE, 'YY/MM/DD') AND" +
                                    $" WOID = '{Selected_woid}'";

            DataTable dataTable1 = Common.DB_Connection(SELECT_PRODQTY);
            string N_PRODQTY_VALUE = dataTable1.Rows[0][0].ToString();

            if (EQPTID == "IM001")
            {
                IM1_ProdQty_Value.Text = $"{N_PRODQTY_VALUE} EA";
                IM2_ProdQty_Value.Visible = false;
                IM2_ProdQty.Visible = false;
                
            }
            else if (EQPTID == "IM002")
            {
                IM2_ProdQty_Value.Text = $"{N_PRODQTY_VALUE} EA";
                IM1_ProdQty_Value.Visible = false;
                IM1_ProdQty.Visible = false;
            }


            Select_Silo_Qty();

            PLANQTY = Convert.ToInt32(WoGrid.Rows[0].Cells[3].Value.ToString());
            PRODQTY = Convert.ToInt32(WoGrid.Rows[0].Cells[4].Value.ToString());

            if (PLANQTY <= PRODQTY)
            {
                ProdQty_check();
            }
            else
            {

            }

        }

        //-------------------------------------------함수------------------------------------------------------------

        public void BtnEnabled()
        {
            //LOTGRID에 데이터가 한건이라도 있을경우 첫번째 행의 EQPTID를 가져옴.
            if (LotGrid.Rows.Count > 1)
            {
                string lotid = LotGrid.Rows[0].Cells[0].Value.ToString();
                string select_eqpt = $"SELECT EQPTID FROM LOT WHERE LOTID ='{lotid}'";
                DataTable dataTable = Common.DB_Connection(select_eqpt);
                string eqptid = dataTable.Rows[0][0].ToString();

                if (eqptid == "IM001")
                {
                    //EQPTID = IM001일경우 2호기 버튼과 라벨을 숨김.
                    EQPTID = "IM001";
                    IM1_STBtn.Enabled = true;
                    IM2_STBtn.Enabled = false;
                    IM2_ProdQty.Visible = false;
                    IM2_ProdQty_Value.Visible = false;
                }
                else if (eqptid == "IM002")
                {
                    //EQPTID = IM002일경우 1호기 버튼과 라벨을 숨김.
                    EQPTID = "IM002";
                    IM2_STBtn.Enabled = true;
                    IM1_STBtn.Enabled = false;
                    IM1_ProdQty.Visible = false;
                    IM1_ProdQty_Value.Visible = false;
                }
            }
        }

        private void Select_Silo_Qty()
        {
            // SL010의 현재 재고량 조회
            string SELECT_SL010 = $"SELECT CURRQTY FROM STORE_STORAGE WHERE STORID = '{silo010}'";
            DataTable dataTable = Common.DB_Connection(SELECT_SL010);
            string SILO_CURRQTY = dataTable.Rows[0][0].ToString();
            SL010_CURRQTY.Text = "저장량 : " + SILO_CURRQTY;
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
            Timer_Stop();
            IM1_STBtn.Enabled = false;
            IM2_STBtn.Enabled = false;
            Inquiry_Woid();
        }

        private void EQPTDATA_TEMP()
        {

            Random random = new Random();
            int TEMP = random.Next(25,40);
            
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

        //----------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------버튼------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기버튼
            //스레드 지속
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
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Timer_Stop();
            string lotid = LotGrid.Rows[0].Cells[0].Value.ToString();
            // stopworking 폼으로 woid값 전달
            if (WoGrid.Rows[0].Cells[2].Value.ToString() == "진행중")
            {
                //WOSTATS가 진행중일 경우 STOPWORKING 폼을 오픈
                Stopworking stopworking = new Stopworking(lotid);
                stopworking.ShowDialog();
                if (EQPTID == "IM001")
                {
                    IM1_STBtn.Enabled = true;
                }
                else if (EQPTID == "IM002")
                {
                    IM2_STBtn.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("재시작");
                //재시작시 작업상태를 진행중(S), STOPWKEDDTTM을 SYSDATE로 변경, 해당하는 EQPTID에 EQPTSTATS를 RUN으로 변경
                string update_wostat = $"UPDATE WORKORDER W SET W.WOSTAT ='S' WHERE WOID = '{Selected_woid}'";
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
            Timer_Stop();
            //해당하는 작업지시번호의 상태를 완료(E)로 변경
            string UPDATE_WOSTAT_P = $"UPDATE WORKORDER SET WOSTAT = 'E' WHERE WOID = '{Selected_woid}'";
            Common.DB_Connection(UPDATE_WOSTAT_P);
            Inquiry_Woid();
        }
        private void IM1_STBtn_Click(object sender, EventArgs e)
        {
            EQPTID = "IM001";
            //EQPTID에 EQPTSTATS를 RUN으로 변경
            string Update_EQPTSTATS = $"UPDATE EQUIPMENT E SET E.EQPTSTATS = 'RUN' WHERE E.EQPTID ='{EQPTID}'";
            Common.DB_Connection(Update_EQPTSTATS);

            Timer_Start();
        }

        private void IM2_STBtn_Click(object sender, EventArgs e)
        {
            EQPTID = "IM002";
            //EQPTID에 EQPTSTATS를 RUN으로 변경
            string Update_EQPTSTATS = $"UPDATE EQUIPMENT E SET E.EQPTSTATS = 'RUN' WHERE E.EQPTID ='{EQPTID}'";
            Common.DB_Connection(Update_EQPTSTATS);

            Timer_Start();
        }

        private void EndBtn_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);
        }

        private void EndBtn_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void EndBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }
        private void STOP_BTN_Click(object sender, EventArgs e)
        {
            Timer_Stop();
            //EQPTID에 EQPTSTATS를 DOWN으로 변경
            string lotid = LotGrid.Rows[0].Cells[0].Value.ToString();
            string Update_EQPTSTATS = $"UPDATE EQUIPMENT E SET EQPTSTATS = 'DOWN' WHERE EQPTID IN (SELECT EQPTID FROM LOT WHERE LOTID = '{lotid}')";
            Common.DB_Connection(Update_EQPTSTATS);
            BtnEnabled();
        }

        //----------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------공정 타이머---------------------------------------
        //----------------------------------------------------------------------------------------------------------------------

        public System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public void Timer_Start()
        {
            timer1.Interval = 1000;
            string SELECT_SL010 = $"SELECT CURRQTY FROM STORE_STORAGE WHERE STORID = '{silo010}'";
            DataTable dataTable4 = Common.DB_Connection(SELECT_SL010);
            int SILO_CURRQTY = Convert.ToInt32(dataTable4.Rows[0][0].ToString());
            if(need_siloQty <= SILO_CURRQTY)
            {
                timer1.Start();
                IM1_STBtn.Enabled = false;
                IM2_STBtn.Enabled = false;
                STOP_BTN.Enabled = true;
            }
            else
            {
                MessageBox.Show("배합량이 부족합니다.");
                Timer_Stop();
            }
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        public void Timer_Stop()
        {
            timer1.Enabled = false;
            timer1.Dispose();
            timer1.Stop();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 9000;

            //사일로 현재량 MINUS
            string SILO1_CURRQTY_MINUS = $"UPDATE STORE_STORAGE SET CURRQTY = CURRQTY - {need_siloQty} WHERE STORID = '{silo010}'";
            Common.DB_Connection(SILO1_CURRQTY_MINUS);

            string SELECT_SL010 = $"SELECT CURRQTY FROM STORE_STORAGE WHERE STORID = '{silo010}'";
            DataTable dataTable4 = Common.DB_Connection(SELECT_SL010);
            string SILO_CURRQTY = dataTable4.Rows[0][0].ToString();
            SL010_CURRQTY.Text = "저장량 : " + SILO_CURRQTY;
            int SL010_QTY = Convert.ToInt32(SILO_CURRQTY);

            //Silo 재고량 재조회
            Select_Silo_Qty();

            // 1호기 일경우 1호기 라벨 백컬러를 사용.
            if (EQPTID == "IM001")
            {
                IM1_Ani();
                B_Backcolor(IM1_1, IM1_2, IM1_3, IM1_4);
            }
            else if (EQPTID == "IM002")
            {
                IM2_Ani();
                B_Backcolor(IM2_1, IM2_2, IM2_3, IM2_4);
            }

            //LOT생성
            string IM_lotCreate = $"INSERT INTO LOT( \n" +
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
                                        $"((SELECT 'L' || TO_CHAR(TO_NUMBER(TO_CHAR(SYSDATE, 'YYYYMMDD') || NVL(TO_CHAR(MAX(SUBSTR(LOTID, 10))), 'FM0000')) + 1) FROM LOT) \n" +
                                        $",'S' \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                        $",'{Selected_woid}' \n" +
                                        $",1 \n" +
                                        $",1 \n" +
                                        $",'{EQPTID}' \n" +
                                        $",(SELECT PROCID FROM WORKORDER WHERE WOID = '{Selected_woid}') \n" +
                                        $",'{userid}' \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS')) \n";
            Common.DB_Connection(IM_lotCreate);
            
            string DD = $"SELECT LOTID FROM LOT WHERE WOID = '{Selected_woid}' AND ROWNUM = 1 ORDER BY LOTID DESC ";
            DataTable dataTable1 = Common.DB_Connection(DD);

            LAST_LOTID = dataTable1.Rows[0][0].ToString();
            EQPTDATA_TEMP();
            EQPTDATA_PRESS();
            Inquiry_Lot();
            Inquiry_Woid();

            //딜레이 // 시작 시간과 완료 시간에 텀을 주기위한 딜레이
            Delay(1000);

            //LOT EDDTTM 업데이트
            string SELECT_LOTID = $"SELECT 'L' || TO_CHAR(TO_NUMBER(TO_CHAR(SYSDATE, 'YYYYMMDD') || NVL(TO_CHAR(MAX(SUBSTR(LOTID, 10))), 'FM0000'))) FROM LOT";
            DataTable dataTable = Common.DB_Connection(SELECT_LOTID);
            string lotid = dataTable.Rows[0][0].ToString();

            string UPDATE_LOT_EDDTTM = $"UPDATE LOT SET LOTEDDTTM = TO_CHAR(SYSDATE,'YY/MM/DD HH24:MI:SS'), LOTSTAT = 'E' WHERE LOTID = '{lotid}'";
            Common.DB_Connection(UPDATE_LOT_EDDTTM);

            //금일 생산량 IM@_PRODQTY_VALUE를 업데이트함.
            string IM_PRODQTY_VALUE = $"SELECT COUNT(*) FROM LOT WHERE EQPTID = '{EQPTID}' AND SUBSTR(LOTCRDTTM,1,8) = TO_CHAR(SYSDATE, 'YY/MM/DD') AND WOID = '{Selected_woid}'";
            DataTable dataTable2 = Common.DB_Connection(IM_PRODQTY_VALUE);

            if (EQPTID == "IM001")
            {
                IM1_ProdQty_Value.Text = $"{dataTable2.Rows[0][0].ToString()} EA";
            }
            else
            {
                IM2_ProdQty_Value.Text = $"{dataTable2.Rows[0][0].ToString()} EA";
            }

            //DB에 WORKORDER_PRODQTY 업데이트
            string UPDATE_WO_PRODQTY = $"UPDATE WORKORDER SET (PRODQTY) = (SELECT NVL(SUM(LOTQTY),0) FROM LOT WHERE WOID ='{Selected_woid}' AND LOTSTAT <> 'D') WHERE WOID = '{Selected_woid}'";
            Common.DB_Connection(UPDATE_WO_PRODQTY);

            //LOTGRID 재조회 및 버튼과 라벨 표시
            Inquiry_Lot();
            Inquiry_Woid();
            BtnEnabled();

            PLANQTY = Convert.ToInt32(WoGrid.Rows[0].Cells[3].Value.ToString())-1;
            PRODQTY = Convert.ToInt32(WoGrid.Rows[0].Cells[4].Value.ToString());

            if (PLANQTY < PRODQTY)
            {
                ProdQty_check();
            }

            if (SL010_QTY < need_siloQty)
            {
                Timer_Stop();
                MessageBox.Show(" 저장소 SL010 의 원재료가 부족합니다.");
            }

        }

        private void B_Backcolor(Button a, Button b, Button c, Button d)
        {
            Button[] buttons = new Button[4] { a, b, c, d };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        buttons[j].BackColor = Color.Yellow;
                        Delay(500);
                    }
                    else
                    {
                        buttons[i].BackColor = Color.FromArgb(51, 153, 255);
                    }
                }
            }
            buttons[3].BackColor = Color.FromArgb(51, 153, 255);
        }

        
        private void timer_Tick(object sender, EventArgs e)
        {
            //현재시간을 나타내기 위함
            CurTime.Text = DateTime.Now.ToString();
        }
        private static DateTime Delay(int MS)
        {
            //Delay 함수
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

        //----------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------애니메이션------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        private void clear_Color()
        {
            Size mvSize = new Size();

            mvSize.Width = sz2.Width;
            mvSize.Height = 0;
            pictureBox2.Size = mvSize;

            mvSize.Width = 0;
            mvSize.Height = sz3.Height;
            pictureBox3.Size = mvSize;

            mvSize.Width = sz4.Width;
            mvSize.Height = 0;
            pictureBox4.Size = mvSize;

            mvSize.Width = sz5.Width;
            mvSize.Height = 0;
            pictureBox5.Size = mvSize;

            mvSize.Width = 0;
            mvSize.Height = sz6.Height;
            pictureBox6.Size = mvSize;

            mvSize.Width = sz7.Width;
            mvSize.Height = 0;
            pictureBox7.Size = mvSize;
        }

        private void IM1_Ani()
        {
            int i = 0;
            Size sz = new Size();
            for (i = 0; i < sz2.Height; i++)
            {
                sz.Width = sz2.Width;
                sz.Height = i;
                pictureBox2.Size = sz;
                Delay(10);
            }

            for (i = 0; i < sz3.Width; i++)
            {
                sz.Width = i;
                sz.Height = sz3.Height;
                pictureBox3.Size = sz;
                Delay(10);
            }

            for (i = 0; i < sz4.Height; i++)
            {
                sz.Width = sz4.Width;
                sz.Height = i;
                pictureBox4.Size = sz;
                Delay(10);
            }
            clear_Color();
        }

        private void IM2_Ani()
        {
            int i = 0;
            Size sz = new Size();

            for (i = 0; i < sz5.Height; i++)
            {
                sz.Width = sz5.Width;
                sz.Height = i;
                pictureBox5.Size = sz;
                Delay(5);
            }
            for (i = 0; i < sz6.Width; i++)
            {
                sz.Height = sz6.Height;
                sz.Width = i;
                pictureBox6.Size = sz;
                Delay(5);
            }
            for (i = 0; i < sz7.Height; i++)
            {
                sz.Width = sz7.Width;
                sz.Height = i;
                pictureBox7.Size = sz;
                Delay(5);
            }
            clear_Color();
        }

    }
}

