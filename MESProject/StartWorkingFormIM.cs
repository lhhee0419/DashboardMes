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
        public static string prodID { get; set; }
        bool isMove;
        Point fpt;
        string LAST_LOTID;
        string woid;

        string silo010 = "SL010";
        int need_siloQty = 10;
        int stop_timer_flag = 0;

        Size orj_sm1_1, orj_sm1_2, orj_sm1_3, orj_sm2_1, orj_sm2_2, orj_sm2_3;
        Random random = new Random();

        public StartWorkingFormIM()
        {
            InitializeComponent();
            orj_sm1_1 = sm1_1.Size;
            orj_sm1_2 = sm1_2.Size;
            orj_sm1_3 = sm1_3.Size;
            orj_sm2_1 = sm2_1.Size;
            orj_sm2_2 = sm2_2.Size;
            orj_sm2_3 = sm2_3.Size;

        }
        
        private void StartWorkingFormIM_Load(object sender, EventArgs e)
        {
            this.ParentForm.Size = new Size(1534, 811);
            timer1.Tick += new EventHandler(timer1_Tick);

            clear_Color_all();
            IM1_STOPBTN.Enabled = false;
            //1,2호기의 버튼과 라벨을 보기위해 EQPTID 초기화
            //EQPTID = "";
            //실시간 타이머 설정
            System.Windows.Forms.Timer DatetimeTimer = new System.Windows.Forms.Timer();
            DatetimeTimer.Interval = 1000;
            DatetimeTimer.Tick += new EventHandler(timer_Tick);
            DatetimeTimer.Enabled = true;

            //DataGridView 디자인
            Common.SetGridDesign(WoGrid);
            Common.SetGridDesign(LotGrid);

            //데이터 조회 및 
            Inquiry_Woid();
            Inquiry_Lot();

            //버튼 관리
            STBTN_Visible();

            //작업지시서 상태가 종료일 때 버튼 사용 금지
            string wostat = WoGrid.Rows[0].Cells[2].Value.ToString();
            if (wostat == "종료")
            {
                EndBtn.Enabled = false;
                IM1_STBtn.Enabled = false;
                IM1_STOPBTN.Enabled = false;
            }

            //1,2호기의 생산량 조회
            ProdQty_FormLoad("IM001",IM1_ProdQty_Value);
            ProdQty_FormLoad("IM002",IM2_ProdQty_Value);

            //사일로 재고량 조회
            Select_Silo_Qty();
        }

        //-------------------------------------------함수------------------------------------------------------------

        public void STBTN_Visible()
        {
            if(timer1.Enabled == false)
            {
                IM1_STBtn.Enabled = true;
                IM1_STOPBTN.Enabled = true;
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
                                    $",NVL(COUNT(LOTID),0) \n" +
                                    $",COUNT(D.DEFECT_LOTID)" +
                                    $",(SELECT PRODWEIGHT FROM PRODUCT WHERE PRODID = (SELECT PRODID FROM WORKORDER WHERE WOID = '{Selected_woid}'))" +
                                    $",W.PLANDTTM \n" +
                                    $",W.WOSTDTTM \n" +
                                    $",W.ETC  \n" +
                                $"FROM WORKORDER W  \n" +
                                    $"INNER JOIN PRODUCT P ON W.PRODID = P.PRODID \n" +
                                    $"LEFT JOIN LOT L ON W.WOID = L.WOID AND L.LOTSTAT <> 'D'\n" +
                                    $"LEFT JOIN DEFECTLOT D ON L.LOTID = D.DEFECT_LOTID \n" +
                                $"WHERE W.WOID = '{Selected_woid}' \n" +
                                $"GROUP BY P.PRODID, P.PRODNAME, W.WOSTAT, W.PLANQTY, W.PRODQTY, W.PLANDTTM, W.WOSTDTTM, W.ETC  \n";
            Common.DB_Connection(select_wo, WoGrid);
            if (WoGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "제품코드", "제품명", "작업상태", "계획수량", "생산수량", "불량수량","제품중량", "계획날짜", "작업지시 시작일", "비고" };
                for (int i = 0; i < header.Length; i++)
                {
                    WoGrid.Columns[i].HeaderText = $"{header[i]}";
                    WoGrid.Columns[i].ReadOnly = true;
                }
            }
            WoGrid.Font = new Font("Fixsys", 16, FontStyle.Regular);
            prodID = WoGrid.Rows[0].Cells[0].Value.ToString();
            WoGrid.RowTemplate.Height = 55;
            Common.Disable_sorting_Datagrid(WoGrid);
            WoGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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
                string[] header = new string[] { "LOT코드", "상태","설비코드", "불량", "시작시간", "종료시간" };
                for (int i = 0; i < header.Length; i++)
                {
                    LotGrid.Columns[i].HeaderText = $"{header[i]}";
                    LotGrid.Columns[i].ReadOnly = true;
                }
            }
            int[] SetCoiumnWidth_LotGrid = new int[] { 180, 50, 90, 50, 190 };
            for (int i = 0; i < SetCoiumnWidth_LotGrid.Length; i++)
            {
                Common.SetColumnWidth(LotGrid, i, SetCoiumnWidth_LotGrid[i]);
            }
            LotGrid.Font = new Font("Fixsys", 16, FontStyle.Regular);
            Common.Disable_sorting_Datagrid(LotGrid);

        }

        private void EQPTDATA_TEMP()
        {
            int TEMP = random.Next(180, 250);
            if(EQPTID != null && LAST_LOTID != null)
            {
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
            
        }
        private void EQPTDATA_PRESS()
        {
            int PRESS = random.Next(700,1050);
            if (EQPTID != null && LAST_LOTID != null)
            {
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
        }
        private void Update_EQPTStats(string stats)
        {
            if(EQPTID != null)
            {
                string Update_EQPTSTATS = $"UPDATE EQUIPMENT E SET E.EQPTSTATS = '{stats}' WHERE E.EQPTID ='{EQPTID}'";
                Common.DB_Connection(Update_EQPTSTATS);
            }
        }
        private void ProdQty_FormLoad(string Equipment_ID, Label ProdQty_Name)
        {
            string SELECT_PRODQTY = $"SELECT COUNT(*) FROM LOT " +
                                    $"WHERE EQPTID = '{Equipment_ID}' AND" +
                                    $" SUBSTR(LOTCRDTTM,1,8) = TO_CHAR(SYSDATE, 'YY/MM/DD') AND" +
                                    $" WOID = '{Selected_woid}'";
            DataTable dataTable = Common.DB_Connection(SELECT_PRODQTY);
            string N_PRODQTY_VALUE = dataTable.Rows[0][0].ToString();

            ProdQty_Name.Text = $"{N_PRODQTY_VALUE} EA";

        }
        private void StartWorkingFormIM_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop_timer_flag = 1;
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
            Inquiry_Lot();
            Inquiry_Woid();
        }
        
        private void EndBtn_Click(object sender, EventArgs e)
        {
            Timer_Stop();
            //해당하는 작업지시번호의 상태를 완료(E)로 변경
            string UPDATE_WOSTAT_P = $"UPDATE WORKORDER SET WOSTAT = 'E' WHERE WOID = '{Selected_woid}'";
            Common.DB_Connection(UPDATE_WOSTAT_P);
            Update_EQPTStats("DOWN");
            Inquiry_Woid();
            IM1_Run.Visible = false;
            IM2_Run.Visible = false;
        }
        private void IM1_STBtn_Click(object sender, EventArgs e)
        {
            EQPTID = "IM001";
            //EQPTID에 EQPTSTATS를 RUN으로 변경
            Update_EQPTStats("RUN");
            Timer_Start();
        }

        private void IM2_STBtn_Click(object sender, EventArgs e)
        {
            stop_timer_flag = 0;
            EQPTID = "IM002";
            //EQPTID에 EQPTSTATS를 RUN으로 변경
            Update_EQPTStats("RUN");
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

            if (stop_timer_flag == 1)
            {
                //EQPTID에 EQPTSTATS를 DOWN으로 변경
                Update_EQPTStats("DOWN");
            }            
        }

        //----------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------공정 타이머---------------------------------------
        //----------------------------------------------------------------------------------------------------------------------

        public System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public void Timer_Start()
        {
            //stop_timer_flag = 0;

            timer1.Interval = 1000;
            string SELECT_SL010 = $"SELECT CURRQTY FROM STORE_STORAGE WHERE STORID = '{silo010}'";
            DataTable dataTable4 = Common.DB_Connection(SELECT_SL010);
            int SILO_CURRQTY = Convert.ToInt32(dataTable4.Rows[0][0].ToString());
            if (need_siloQty <= SILO_CURRQTY)
            {
                IM1_STBtn.Enabled = false;
                IM1_STOPBTN.Enabled = false;
                IM1_STOPBTN.Enabled = true;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("배합량이 부족합니다.");
                IM1_STBtn.Enabled = true;
                IM1_STOPBTN.Enabled = true;
                Timer_Stop();
            }
        }

        public void Timer_Stop()
        {
            stop_timer_flag = 1;
            timer1.Stop();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_check();
            timer1.Interval = 8000;
                        
            if (EQPTID != null)
            {
                silo_run.Visible = true;
                //사일로 현재량 MINUS
                string SILO1_CURRQTY_MINUS = $"UPDATE STORE_STORAGE SET CURRQTY = CURRQTY - {need_siloQty} WHERE STORID = '{silo010}'";
                Common.DB_Connection(SILO1_CURRQTY_MINUS);

                string SELECT_SL010 = $"SELECT CURRQTY FROM STORE_STORAGE WHERE STORID = '{silo010}'";
                DataTable dataTable1 = Common.DB_Connection(SELECT_SL010);
                string SILO_CURRQTY = dataTable1.Rows[0][0].ToString();
                SL010_CURRQTY.Text = "저장량 : " + SILO_CURRQTY;
                int SL010_QTY = Convert.ToInt32(SILO_CURRQTY);

                //Silo 재고량 재조회
                Select_Silo_Qty();
                Delay(1000);
                // 1호기 일경우 1호기 라벨 백컬러를 사용.
                if (EQPTID == "IM001")
                {
                    IM1_Ani_();
                    IM1_Run.Visible = true;
                    B_Backcolor(IM1_1, IM1_2, IM1_3, IM1_4);
                }
                else if (EQPTID == "IM002")
                {
                    IM2_Ani_();
                    IM2_Run.Visible = true;
                    B_Backcolor(IM2_1, IM2_2, IM2_3, IM2_4);
                }
                silo_run.Visible = false;
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
                                            $"((SELECT 'L' || TO_CHAR(SYSDATE, 'YYYYMMDD') || TO_CHAR(LAST_SEQ + 1, 'FM0000') " +
                                            $"FROM(SELECT NVL(MAX(SUBSTR(LOTID, -4)), 0) LAST_SEQ " +
                                            $"FROM LOT " +
                                            $"WHERE LOTID LIKE 'L' || TO_CHAR(SYSDATE, 'YYYYMMDD') || '%'))\n" +
                                            $",'S' \n" +
                                            $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                            $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                            $",'{Selected_woid}' \n" +
                                            $",(SELECT PRODWEIGHT FROM PRODUCT WHERE PRODID = '{prodID}') \n" +
                                            $",(SELECT PRODWEIGHT FROM PRODUCT WHERE PRODID = '{prodID}') \n" +
                                            $",'{EQPTID}' \n" +
                                            $",(SELECT PROCID FROM WORKORDER WHERE WOID = '{Selected_woid}') \n" +
                                            $",'{userid}' \n" +
                                            $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS')) \n";
                Common.DB_Connection(IM_lotCreate);

                string last_LOTID = $"SELECT LOTID FROM (SELECT * FROM LOT WHERE WOID = '{Selected_woid}' ORDER BY LOTID DESC) WHERE ROWNUM = 1";
                DataTable dataTable2 = Common.DB_Connection(last_LOTID);
                LAST_LOTID = dataTable2.Rows[0][0].ToString();

                Inquiry_Lot();
                Inquiry_Woid();
                EQPTDATA_TEMP();
                EQPTDATA_PRESS();

                //온도, 압력 값 확인 후 불량처리
                string Select_Temp = $"SELECT EQPTITEMVALUE FROM EQPTDATACOLLECT WHERE LOTID = '{LAST_LOTID}' AND EQPTITEMID = 'ED001'";
                DataTable dataTable3 = Common.DB_Connection(Select_Temp);
                int select_temp =Convert.ToInt32(dataTable3.Rows[0][0].ToString());

                string Select_Press = $"SELECT EQPTITEMVALUE FROM EQPTDATACOLLECT WHERE LOTID = '{LAST_LOTID}' AND EQPTITEMID = 'ED002'";
                DataTable dataTable4 = Common.DB_Connection(Select_Press);
                int select_press = Convert.ToInt32(dataTable4.Rows[0][0].ToString());

                if (select_temp > 240 || select_press > 1000)
                {
                    string[] error = new string[] { "DF001", "DF002" , "DF003" , "DF004" , "DF005" , "DF006", "DF007" };
                    Random rand = new Random();
                    int index_num = rand.Next(1, 7);
                    string DEFECTID = error[index_num];
                    
                    string add_defectlot = $"INSERT INTO DEFECTLOT(DEFECT_LOTID,DEFECT_QTY,DEFECT_DTTM,DEFECTID)" +
                                           $" VALUES ('{LAST_LOTID}'" +
                                           $",1,TO_CHAR(SYSDATE" +
                                           $",'YY/MM/DD HH24:MI:SS')" +
                                           $",'{DEFECTID}')";
                    Common.DB_Connection(add_defectlot);
                }

                Create_Lot_Label.BackColor = Color.Yellow;
                Create_Lot_Label.Visible = true;
                //딜레이 // 시작 시간과 완료 시간에 텀을 주기위한 딜레이
                Delay(1000);

                //LOT EDDTTM 업데이트

                string UPDATE_LOT_EDDTTM = $"UPDATE LOT SET LOTEDDTTM = TO_CHAR(SYSDATE,'YY/MM/DD HH24:MI:SS'), LOTSTAT = 'E' WHERE LOTID = '{LAST_LOTID}'";
                Common.DB_Connection(UPDATE_LOT_EDDTTM);

                //금일 생산량 IM@_PRODQTY_VALUE를 업데이트함.
                string IM_PRODQTY_VALUE = $"SELECT COUNT(*) FROM LOT WHERE EQPTID = '{EQPTID}' AND " +
                                          $"SUBSTR(LOTCRDTTM,1,8) = TO_CHAR(SYSDATE, 'YY/MM/DD') AND" +
                                          $" WOID = '{Selected_woid}'";
                DataTable dataTable5 = Common.DB_Connection(IM_PRODQTY_VALUE);

                if (EQPTID == "IM001")
                {
                    IM1_ProdQty_Value.Text = $"{dataTable5.Rows[0][0].ToString()} EA";
                    IM1_4.BackColor = Color.FromArgb(51, 153, 255);
                }
                else if (EQPTID == "IM002")
                {
                    IM2_ProdQty_Value.Text = $"{dataTable5.Rows[0][0].ToString()} EA";
                    IM2_4.BackColor = Color.FromArgb(51, 153, 255);
                }
                //DB에 WORKORDER_PRODQTY 업데이트
                string UPDATE_WO_PRODQTY = $"UPDATE WORKORDER SET " +
                                           $"(PRODQTY) = (SELECT NVL(COUNT(LOTID),0) " +
                                           $"FROM LOT WHERE WOID ='{Selected_woid}' AND LOTSTAT <> 'D' " +
                                           $"AND LOTID NOT IN(SELECT DEFECT_LOTID FROM DEFECTLOT)) " +
                                           $"WHERE WOID = '{Selected_woid}'";
                
                Common.DB_Connection(UPDATE_WO_PRODQTY);

                //제품생산중 label 숨김
                Create_Lot_Label.Visible = false;
                //LOTGRID 재조회 및 버튼과 라벨 표시
                Inquiry_Lot();
                Inquiry_Woid();

                if (SL010_QTY < need_siloQty)
                {
                    MessageBox.Show("배합량이 부족합니다.");
                    Timer_Stop();
                }

                timer_check();
                IM1_Run.Visible = false;
                IM2_Run.Visible = false;
            }
        }
        private void timer_check()
        {
            if (stop_timer_flag == 1)
            {
                Timer_Stop();
                STBTN_Visible();
            }
        }
        private void B_Backcolor(Button a, Button b, Button c, Button d)
        {
            Button[] buttons = new Button[4] {a, b, c, d};
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        buttons[j].BackColor = Color.FromArgb(255, 128, 0);
                        Delay(500);
                    }
                    else
                    {
                        buttons[i].BackColor = Color.FromArgb(51, 153, 255);
                    }
                }
                buttons[2].BackColor = Color.FromArgb(51, 153, 255);
            }
            buttons[3].BackColor = Color.FromArgb(255, 128, 0);
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
        private void clear_Color(PictureBox pBox)
        {
            pBox.Width = 0;
            pBox.Height = 0;
        }

        private void clear_Color_all()
        {
            clear_Color(sm1_1);
            clear_Color(sm1_2);
            clear_Color(sm1_3);
            clear_Color(sm2_1);
            clear_Color(sm2_2);
            clear_Color(sm2_3);
        }
        private void DrawLeftToRight(PictureBox PBox, Size sz)
        {
            PBox.Height = sz.Height;
            for (int i = 0; i < sz.Width; i++)
            {
                PBox.Width = i;
                Delay(3);
            }
        }
        private void UpToDown(PictureBox PBox, Size sz)
        {
            PBox.Width = sz.Width;

            for (int i = 0; i < sz.Height; i++)
            {
                PBox.Height = i;
                Delay(3);
            }
        }

        private void IM1_Ani_()
        {
            clear_Color_all();

            UpToDown(sm1_1, orj_sm1_1);

            DrawLeftToRight(sm1_2, orj_sm1_2);

            UpToDown(sm1_3, orj_sm1_3);

            clear_Color_all();

        }
        private void IM2_Ani_()
        {
            clear_Color_all();

            UpToDown(sm2_1, orj_sm2_1);

            DrawLeftToRight(sm2_2, orj_sm2_2);

            UpToDown(sm2_3, orj_sm2_3);

            clear_Color_all();

        }
    }
}

