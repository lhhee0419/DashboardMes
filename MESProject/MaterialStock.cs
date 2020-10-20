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
    public partial class MaterialStock : Form
    {
        public MaterialStock()
        {
            InitializeComponent();
            
        }
        private void MaterialStock_Load(object sender, EventArgs e)
        {   

            silo1.Image = Properties.Resources.silo;
            silo1.SizeMode = PictureBoxSizeMode.StretchImage;
            silo2.Image = Properties.Resources.silo;
            silo2.SizeMode = PictureBoxSizeMode.StretchImage;
            silo3.Image = Properties.Resources.silo;
            silo3.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        bool isMove;
        Point fpt;
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

        private void ExitBtn_Click(object sender, EventArgs e)
        {   
            //닫기 버튼
            this.Close();
        }
    }
}
