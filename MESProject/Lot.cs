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
    public partial class Lot : Form
    {
        bool isMove;
        Point fpt;
        string woid="";
        string Userid;
        string EQPTid;
        private Startworking startworkingForm = null;
        public Lot(Startworking startworkingForm)
        {
            InitializeComponent();
            this.startworkingForm = startworkingForm;
            this.FormClosing += Lot_FormClosing;

        }
        private void Lot_Load(object sender, EventArgs e)
        {
            woid = startworkingForm.Selected_woid;
            Userid = MainForm.User_ID;
            EQPTid = Startworking.EQPTID;

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기버튼
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            //추가버튼
            int Qty = (LotAdd_tb.Text=="")? 0: Convert.ToInt32(LotAdd_tb.Text);
            
            if (woid != "")
            {
                for (int i = 0; i < Qty; i++)
                {
                    string add_lot = $"INSERT INTO LOT( \n" +
                                         $"LOTID  \n" +
                                         $", LOTSTAT \n" +
                                         $", LOTCRDTTM \n" +
                                         $", LOTSTDTTM \n" +
                                         $", LOTEDDTTM \n" +
                                         $", WOID \n" +
                                         $", LOTCRQTY \n" +
                                         $", LOTQTY \n" +
                                         $", EQPTID \n" +
                                         $", PROCID \n" +
                                         $", INSUSER \n" +
                                         $", INSDTTM) \n" +
                                        $"VALUES \n" +
                                        $"((SELECT 'L' || TO_CHAR(TO_NUMBER(TO_CHAR(SYSDATE, 'YYYYMMDD') || NVL(TO_CHAR(MAX(SUBSTR(LOTID, 10))), 'FM0000')) + 1) FROM LOT) \n" +
                                        $",'C' \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS') \n" +
                                        $",'{woid}' \n" +
                                        $",1 \n" +
                                        $",1 \n" +
                                        $",'{EQPTid}' \n" +
                                        $",(SELECT PROCID FROM WORKORDER WHERE WOID = '{woid}') \n" +
                                        $",'{Userid}' \n" +
                                        $",TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS')) \n";
                            Common.DB_Connection(add_lot);
                            }
                        }    
            this.Close();


        }

        private void Lot_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);
        }

        private void Lot_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void Lot_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }



        private void Lot_FormClosing(object sender, FormClosingEventArgs e)
        {
            startworkingForm.Inquiry_Lot();
            startworkingForm.Inquiry_Woid();
        }

        private void LotAdd_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



