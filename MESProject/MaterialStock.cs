using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    public partial class MaterialStock : Form
    {
        bool isMove;
        Point fpt;
        string select_store;
        public MaterialStock()
        {
            InitializeComponent();

        }
        private void MaterialStock_Load(object sender, EventArgs e)
        {          
            Dashboard();
            SetProcessBar();
            timer1.Interval = 1000;
            timer1.Start();
 
        }
        public void SetProcessBar()
        {
            progressBar1.Minimum = 0;
            progressBar2.Minimum = 0;
            progressBar3.Minimum = 0;
            progressBar4.Minimum = 0;
            progressBar1.Maximum = 10000;
            progressBar2.Maximum = 10000;
            progressBar3.Maximum = 10000;
            progressBar4.Maximum = 10000;
            progressBar1.Value = Convert.ToInt32(Lb_Currqty1.Text);
            progressBar2.Value = Convert.ToInt32(Lb_Currqty2.Text);
            progressBar3.Value = Convert.ToInt32(Lb_Currqty3.Text);
            progressBar4.Value = Convert.ToInt32(Lb_Currqty4.Text);
        }

        
        public void Dashboard()
        {
            string[] storid = new string[] { "SL001","SL002","SL003","SL010"};
            for(int i=0;i<storid.Length;i++)
            {
                select_store = "SELECT \n" +
                                       "M.MTRLNAME \n" +
                                       ",S.CURRQTY \n" +
                                       ",S.MINLEVEL \n" +
                                       ",S.MAXLEVEL \n" +
                                  "FROM MATERIAL M \n" +
                                       "INNER JOIN STORE_STORAGE S ON M.STORID = S.STORID \n" +
                                   $"WHERE S.STORID = '{storid[i]}' \n";
                DataTable dataTable = Common.DB_Connection(select_store);
                if(i==0)
                {
                    Label[] Storid = new Label[] { Lb_MtrlName1, Lb_Currqty1, Lb_Minqty1, Lb_Maxqty1 };
                    for (int j = 0; j < Storid.Length; j++)
                    {
                        Storid[j].Text = dataTable.Rows[0][j].ToString();
                    }
                    
                }
                else if (i == 1)
                {
                    Label[] Storid = new Label[] { Lb_MtrlName2, Lb_Currqty2, Lb_Minqty2, Lb_Maxqty2 };
                    for (int j = 0; j < Storid.Length; j++)
                    {
                        Storid[j].Text = dataTable.Rows[0][j].ToString();
                    }
                }
                else if (i == 2)
                {
                    Label[] Storid = new Label[] { Lb_MtrlName3, Lb_Currqty3, Lb_Minqty3, Lb_Maxqty3 };
                    for (int j = 0; j < Storid.Length; j++)
                    {
                        Storid[j].Text = dataTable.Rows[0][j].ToString();
                    }
                }
                else if (i == 3)
                {
                    Label[] Storid = new Label[] { Lb_MtrlName4, Lb_Currqty4, Lb_Minqty4, Lb_Maxqty4 };
                    for (int j = 0; j < Storid.Length; j++)
                    {
                        Storid[j].Text = dataTable.Rows[0][j].ToString();
                    }
                }


            }


        }

 

   
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기 버튼
            this.Close();
        }
   



        private void MaterialStock_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);
        }

        private void MaterialStock_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }

        private void MaterialStock_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

    }
}
