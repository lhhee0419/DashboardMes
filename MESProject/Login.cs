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
        public Login()
        {
            InitializeComponent();
            this.Style = MetroFramework.MetroColorStyle.White;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST = 192.168.0.169)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=b1s4;Password=smart123;";
            
            OracleConnection conn = new OracleConnection(strConn);

            conn.Open();

            
            OracleDataAdapter odr = new OracleDataAdapter("select count(*) from employee where 1=1", conn);
            
            DataTable dataTable = new DataTable();

            odr.Fill(dataTable);
            MessageBox.Show(dataTable.Rows[0][0].ToString());
            
            if (dataTable.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("로그인되었습니다.");
                    MainForm mainform = new MainForm();
                    mainform.Show();
                }
                else
                {
                    MessageBox.Show("로그인 정보가 일치하지 않습니다.");
                    IDtextBox.Clear();
                    PWDtextBox.Clear();
                    IDtextBox.Focus();
                }

            //로그인 버튼을 클릭
        }
    }
}
