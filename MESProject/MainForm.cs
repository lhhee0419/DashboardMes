using System;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Microsoft.SqlServer.Server;

namespace MESProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // this.Style = MetroFramework.MetroColorStyle.White;

        }

        static public void SetGridDesign(DataGridView Grid)
        {

            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            Grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Grid.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            Grid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            Grid.BackgroundColor = Color.White;
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            ProcCombo.SelectedIndex = 0; //콤보박스 초기값설정

            SetGridDesign(WoGrid);


        }






 

        private void ProcCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //콤보박스 선택시 이벤트

            if (ProcCombo.SelectedIndex == 0)
            {
                //배합 콤보박스 선택

            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                //사출 콤보박스 선택
            }
        }

        private void InquiryBtn_Click(object sender, EventArgs e)
        {
            //조회버튼 클릭시 
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            //MessageBox.Show(Convert.ToString(date1));            //string sql = $"select * from workorder where plandttm >={Convert.ToString(date1)} and  plandttm <={Convert.ToString(date2)}";
            string sql = $"select * from workorder where plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}'";
            OracleDataAdapter adapter = new OracleDataAdapter(sql, DBHelper.DBconn);
            DataTable data_table = new DataTable();
            adapter.Fill(data_table);
            WoGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            WoGrid.DataSource = data_table;

            /* WoGrid.Columns[0].HeaderText = "작업지시코드";
             WoGrid.Columns[1].HeaderText = "제품코드";
            WoGrid.Columns[2].HeaderText = "제품명";
            WoGrid.Columns[3].HeaderText = "작업상태";
            WoGrid.Columns[4].HeaderText = "계획수량";
            WoGrid.Columns[5].HeaderText = "생산수량";
            WoGrid.Columns[6].HeaderText = "불량수량";
            WoGrid.Columns[7].HeaderText = "비고" */
        }

        private void WostBtn_Click(object sender, EventArgs e)
        {
            //작업시작 버튼
            Startworking startworkingForm = new Startworking();
            startworkingForm.TopLevel = false;
            maintab.TabPages.Add((maintab.TabPages.Count + 1).ToString());
            maintab.TabPages[maintab.TabPages.Count - 1].Controls.Add(startworkingForm);
            maintab.SelectedIndex = maintab.TabPages.Count - 1;
            maintab.SelectedTab.Text = "작업시작";
            //maintab.TabPages[maintab.TabPages.Count - 1].Controls.Add(startworkingForm);
            startworkingForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            startworkingForm.Show();
            startworkingForm.FormClosed += Form_closing;
           
        }
        public void Form_closing(object sender, FormClosedEventArgs e)
        {
            maintab.TabPages.Remove(maintab.SelectedTab);
        }
        bool isMove;
        Point fpt;
        private void maintab_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);
        }

        private void maintab_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }

        private void maintab_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            //로그아웃버튼
            this.Close();
        }
    }
}
