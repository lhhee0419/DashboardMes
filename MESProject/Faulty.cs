using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    public partial class Faulty : Form
    {
        string woid;
        //불량 등록할 Lot_id 저장
        string Checked_defect_Lotid;
        string Unchecked_defect_Lotid;
        //라디오버튼
        string rad = "미선택";
        //List 선언
        List<string> lotid = new List<string>();
        Startworking startworking = new Startworking();
        StartWorkingFormIM startWorkingFormIM = new StartWorkingFormIM();
        string procid;

        public Faulty(string workid)
        {
            InitializeComponent();
            //Startworking 폼에서 woid_data 가져오기
            woid = workid;  
        }

        private void Faulty_Load(object sender, EventArgs e)
        {   
            //DataGridView 디자인
            Common.SetGridDesign(LotID_Grid);

            string select_procid = $"SELECT PROCID FROM WORKORDER WHERE WOID='{woid}'";
            DataTable dataTable=Common.DB_Connection(select_procid);
            procid = dataTable.Rows[0][0].ToString();
            if (procid == "P0001")
            {
                D_Name3.Text = "원재료불량";
                D_Name4.Text = "설비 오작동";
            }
            //LotID_Grid 쿼리
            string LotId_Grid_Data = $"SELECT " +
                                        $"LOTID" +
                                        $",EQPTID" +
                                        $",LOTSTDTTM" +
                                        $",LOTEDDTTM " +
                                     $"FROM LOT L, WORKORDER W " +
                                     $"WHERE W.WOID = '{woid}' " +
                                         $"AND W.WOID=L.WOID " +
                                         $"AND L.LOTID NOT IN (SELECT DEFECT_LOTID FROM DEFECTLOT) " +
                                         $"AND LOTSTAT <>'D'";
            Common.DB_Connection(LotId_Grid_Data, LotID_Grid);

            // Common.SetColumnWidth(LotID_Grid, 3, 130);
            //컬럼명
            if (LotID_Grid.Rows.Count > 0)
            {
                LotID_Grid.Columns[0].HeaderText = "LOT코드";
                LotID_Grid.Columns[1].HeaderText = "설비코드";
                LotID_Grid.Columns[2].HeaderText = "시작시간";
                LotID_Grid.Columns[3].HeaderText = "종료시간";
            }
            // datagridview 첫 번째 위치에 checkbox 추가
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 3;
            checkBoxColumn.Name = "checkBoxColumn";
            LotID_Grid.Columns.Insert(0, checkBoxColumn);
            Common.SetColumnWidth(LotID_Grid, 0, 30);
        }
        private void RadClick(object sender, EventArgs e, string name, string code)
        {
            //라디오버튼 클릭 함수
            RadioButton Rbtn = sender as RadioButton;

            if (Rbtn.Checked == true)
            {
                rad = code;
            }
            else if (Rbtn.Checked == false)
                return;
        }
        private void LotID_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CheckBox 행이 클릭되었는지 확인함.
            if (e.RowIndex >=0 && e.ColumnIndex >= 0)
            {
                // GridView 행을 참조함.
                DataGridViewRow row = LotID_Grid.Rows[e.RowIndex];

                // CheckBox 선택을 설정함.
                row.Cells["checkBoxColumn"].Value = !Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue);

                if (Convert.ToBoolean(row.Cells["checkBoxColumn"].Value) == true)
                {
                    //defect_lotid에 체크된 lotid를 저장함.
                    Checked_defect_Lotid = Convert.ToString(row.Cells[1].Value);
                    lotid.Add(Checked_defect_Lotid);
                }
                else if(Convert.ToBoolean(row.Cells["checkBoxColumn"].Value) == false)
                {
                    Unchecked_defect_Lotid = Convert.ToString(row.Cells[1].Value);
                    lotid.Remove(Unchecked_defect_Lotid);
                }
            }
        }

        //각 라디오버튼 클릭함수
        private void D_Name1_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "갈라짐", "DF001");
        }

        private void D_Name2_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "시작/종료", "DF002");
        }

        private void D_Name3_Click(object sender, EventArgs e)
        {
            if(procid == "P0001")
                RadClick(sender, e, "원재료 불량", "DF005");
            else
                RadClick(sender, e, "기스", "DF003");
        }

        private void D_Name4_Click(object sender, EventArgs e)
        {
            if (procid == "P0001")
                RadClick(sender, e, "색상", "DF004");
            else
                RadClick(sender, e, "설비오작동", "DF006");
        }

        private void D_Name5_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "기타", "DF007");
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기 버튼
            this.Close();
        }
        private void CheckBtn_Click(object sender, EventArgs e)
        {
            //확인 버튼 클릭
            try
            {
                //lotid에 저장된 defect_lotid 를 출력
                foreach (string D_Lotid in lotid)
                {
                    string add_defectlot = $"insert into defectlot values('{D_Lotid}',1,TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'),'{rad}')";
                    Common.DB_Connection(add_defectlot);
                }
                MessageBox.Show("불량 등록이 완료되었습니다.");
                this.Close();
            }
            //예외 발생
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }


        }
        bool isMove;
        Point fpt;
        private void Faulty_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }

        private void Faulty_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void Faulty_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);

        }

        private void Faulty_FormClosing(object sender, FormClosingEventArgs e)
        {
            startworking.Inquiry_Lot();
            startworking.Inquiry_Woid();
            startWorkingFormIM.Inquiry_Lot();
            startWorkingFormIM.Inquiry_Woid();
        }

    
    }
}
