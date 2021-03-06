﻿using System;
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
    public partial class Login : Form
    {
       
        public string ID,Password;
        public Login()
        {
            InitializeComponent();
        }

        //textbox에 Enter가 입력될 때 LoginButton_Click함수 호출
        private void Enter_key(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoginButton_Click(sender, e);

            }
        }

        //textbox에 Enter가 입력되면 Enter_key함수 호출
        private void PwdTextbox_Enter(object sender, KeyEventArgs e)
        {
            Enter_key(sender, e);
        }
        private void IDTextbox_Enter(object sender, KeyEventArgs e)
        {
            Enter_key(sender, e);
        }

        //로그인 버튼을 클릭
        private void LoginButton_Click(object sender, EventArgs e)
        {
            ID = IDtextBox.Text;
            Password = PWDtextBox.Text;
            //textbox가 빈 값일 경우 나타나는 메세지
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("아이디를 입력해주세요.");
            }
            else if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("비밀번호를 입력해주세요");
            }

            //select_ID에 쿼리문을 저장
            string select_ID = $"select count(*) from employee where EMPLOYEEID = '" + ID + "' and EMPLOYEEPASSWORD='" + Password + "'";

            //select_ID로 조회된 결과를 data_Table에 return값을 저장함
            DataTable data_Table = Common.DB_Connection(select_ID);

            try
            {
                //조회된 결과가 1일 경우 로그인 성공, login창 닫음.
                if (data_Table.Rows[0][0].ToString() == "1")
                {
                    this.DialogResult = DialogResult.OK;
                    MainForm.User_ID = ID;
                    this.Close();
                }

                //정보가 일치하지 않을경우 ID,PWDtextbox를 초기화하고 IDtextbox에 커서를 이동.
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

        //나가기 버튼
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool isMove;
        Point fpt;
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }
    }
}
