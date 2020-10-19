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
    public partial class Faulty : Form
    {
        string woid;
        //불량요인을 저장
        string defect_code;
        //불량 등록할 Lot_id 저장
        string defect_lotid;
        //라디오버튼
        string rad = "미선택";

        private void RadClick(object sender, EventArgs e, string name, string code)
        {
            //라디오버튼 클릭 함수
            RadioButton Rbtn = sender as RadioButton;

            if (Rbtn.Checked == true)
            {
                MessageBox.Show(name);
                rad = code;
            }
            else if (Rbtn.Checked == false)
                return;
        }

        public Faulty(string woid_data)
        {
            InitializeComponent();
            //Startworking 폼에서 woid_data 가져오기
            this.woid = woid_data;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기 버튼
            this.Close();
        }

        private void Faulty_Load(object sender, EventArgs e)
        {
            //DataGridView 디자인
            Common.SetGridDesign(LotID_Grid);
            
            //LotID_Grid 쿼리
            string LotId_Grid_Data = $"SELECT LOTID, LOTSTDTTM, LOTEDDTTM FROM LOT L, WORKORDER W WHERE W.WOID = '{woid}' AND W.WOID=L.WOID";
            Common.DB_Connection(LotId_Grid_Data, LotID_Grid);
            LotID_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //컬럼명
            if (LotID_Grid.Rows.Count > 0)
            {
                LotID_Grid.Columns[0].HeaderText = "체크확인";
                LotID_Grid.Columns[1].HeaderText = "LOT코드";
                LotID_Grid.Columns[2].HeaderText = "시작시간";
                LotID_Grid.Columns[3].HeaderText = "종료시간";
            }

        }

        private void LotID_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //LotID_Grid 셀선택
            for (int i = 0; i < LotID_Grid.Rows.Count - 1; i++)
            {
                if (LotID_Grid.Rows[i].Cells[0].Selected == true)
                {
                    
                    defect_lotid = LotID_Grid.Rows[i].Cells[1].Value.ToString();
                    MessageBox.Show($"{defect_lotid} 체크되었습니다.");

                    //체크박스 활성화
                    LotID_Grid[0, i].Value = true;
                  
                }
                else
                {
                    if((e.RowIndex>-1) && LotID_Grid.Columns[1]is DataGridViewCheckBoxColumn)
                    {
                        MessageBox.Show("확");
                    }
                }
            }
        }
        

        //각 라디오버튼 클릭함수
        private void D_color_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "색상불량", "DF004");
        }
       
        private void D_Crack_Click(object sender, EventArgs e)
        {
            RadClick(sender,e,"갈라짐","DF001");
        }

        private void D_STED_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "시작/종료", "DF002");
        }

        private void D_Scratch_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "기스", "DF003");
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            //확인 버튼 클릭
            //for(int i=0; i < LotID_Grid.Rows.GetRowState; i++)
            {

            }
            string add_defectlot = $"insert into defectlot values('{defect_lotid}',1,'','{rad}')";
            Common.DB_Connection(add_defectlot);
            MessageBox.Show("불량 등록이 완료되었습니다.");
            this.Close();

        }
    }
}
