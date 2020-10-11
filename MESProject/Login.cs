using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Oracle.ManagedDataAccess.Client;

namespace MESProject
{
    public partial class Login : MetroForm
    {
        private static MainForm mainform = new MainForm();
        public Login()
        {
            InitializeComponent();
            this.Style = MetroFramework.MetroColorStyle.White;
        }

        //로그인 버튼을 클릭
        private void LoginButton_Click(object sender, EventArgs e)
        {
            //select_ID에 쿼리문을 저장
            string select_ID = $"select count(*) from employee where EMPLOYEEID = '" + IDtextBox.Text + "' and EMPLOYEEPASSWORD='" + PWDtextBox.Text + "'";
            
            //select_ID로 조회된 결과를 data_Table에 return값을 저장함
            DataTable data_Table = Common.DB_Connection(select_ID);
            
            try
            {
                //조회된 결과가 1일 경우 로그인 성공, login창 숨김.
                if (data_Table.Rows[0][0].ToString() == "1")
                {
                    //MessageBox.Show("로그인되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                //textbox이 빈 값일 경우 나타나는 메세지
                else if(IDtextBox.Text =="" || PWDtextBox.Text=="")
                {
                    MessageBox.Show("아이디 혹은 패스워드를 입력하세요.");
                }

                //정보가 일치하지 않을경우 textbox를 초기화하고 IDtextbox에 커서를 맞춤.
                else
                {
                    MessageBox.Show("로그인 정보가 일치하지 않습니다.");
                    IDtextBox.Text = string.Empty;
                    PWDtextBox.Text = string.Empty;
                    IDtextBox.Focus();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("예외 발생");
            }
        }
    }
}
