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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
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
                MessageBox.Show("배합");
            }
            else if(ProcCombo.SelectedIndex ==1 )
            {
                MessageBox.Show("사출");
            }    


        }

    }
}
