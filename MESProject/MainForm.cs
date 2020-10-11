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

namespace MESProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
           // this.Style = MetroFramework.MetroColorStyle.White;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            //ProcCombo.SelectedIndex = 0; //콤보박스 초기값설정
        }
    

        private void ProcCombo_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //콤보박스 선택시 이벤트

            if (ProcCombo.SelectedIndex == 0)
            {
                //배합 콤보박스 선택
            }
            else if(ProcCombo.SelectedIndex ==1 )
            {
                //사출 콤보박스 선택
            }


        }

        private void InquiryBtn_Click(object sender, EventArgs e)
        {
            //조회 버튼 클릭시
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
           
            //MessageBox.Show(Convert.ToString(date1));            //string sql = $"select * from workorder where plandttm >={Convert.ToString(date1)} and  plandttm <={Convert.ToString(date2)}";
            string sql = $"select * from workorder where plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}'";
            OracleDataAdapter adapter = new OracleDataAdapter(sql, DBHelper.DBconn);
            DataTable data_table = new DataTable();
            adapter.Fill(data_table);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = data_table;



        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {   
            //로그아웃버튼
            this.Close();
        }







        bool isMove;
        Point fpt;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }
    }
}
