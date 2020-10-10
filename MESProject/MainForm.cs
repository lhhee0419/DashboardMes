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

namespace MESProject
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Style = MetroFramework.MetroColorStyle.White;
            
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



        }
    }
}
