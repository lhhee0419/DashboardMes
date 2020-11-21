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
        string woid = "";
        string Userid,EQPTid;
        public Lot(string Selected_woid, string eqptid)
        {
            InitializeComponent();
            EQPTid = eqptid;
            woid = Selected_woid;
        }

        private void Lot_Load(object sender, EventArgs e)
        {
            Userid = MainForm.User_ID;
            if(EQPTid == null)
            {
                string lastlot_eqptid = $"SELECT EQPTID FROM LOT WHERE WOID = '{woid}' AND ROWNUM = 1 ORDER BY LOTID DESC ";
                DataTable dataTable1 = Common.DB_Connection(lastlot_eqptid);
                EQPTid = dataTable1.Rows[0][0].ToString();
            }

            string wo_proc= $"SELECT " +
                            $"PROCID " +
                            $"FROM WORKORDER " +
                            $"WHERE WOID = '{woid}'";
            DataTable dataTable =Common.DB_Connection(wo_proc);
            string procid =dataTable.Rows[0][0].ToString();
            if (procid == "P0001")
                lotQtyLB.Text = "LOT 중량 : ";
            else if(procid == "P0002")
                lotQtyLB.Text = "LOT 수량 : ";

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기버튼
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            //추가버튼
            int Qty = (LotAdd_tb.Text == "") ? 0 : Convert.ToInt32(LotAdd_tb.Text);

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
                                        $",'E' \n" +
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

    }
}
