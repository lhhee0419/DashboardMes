﻿using System;
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
            
            Dashboard();
        }

        public void Dashboard()
        {
            string select_mtrl1 = "SELECT * FROM STORE_STORAGE WHERE STORID = 'SL001'";
            Common.DB_Connection(select_mtrl1, MtrlGrid1);
            Grid_Text(MtrlGrid1);
            string select_mtrl2 = "SELECT * FROM STORE_STORAGE WHERE STORID = 'SL002'";
            Common.DB_Connection(select_mtrl2, MtrlGrid2);
            Grid_Text(MtrlGrid2);
            string select_mtrl3 = "SELECT * FROM STORE_STORAGE WHERE STORID = 'SL003'";
            Common.DB_Connection(select_mtrl3, MtrlGrid3);
            Grid_Text(MtrlGrid3);
        }
        public void Grid_Text(DataGridView dataGridView)
        {
            Common.SetGridDesign(dataGridView);
            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Columns[0].HeaderText = "저장소코드";
                dataGridView.Columns[1].HeaderText = "저장소명";
                dataGridView.Columns[2].HeaderText = "최대저장량";
                dataGridView.Columns[3].HeaderText = "최소저장량";
                dataGridView.Columns[4].HeaderText = "현재량";
            }
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
