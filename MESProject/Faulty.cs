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

        public Faulty(string woid_data)
        {
            InitializeComponent();
            //Startworking 폼에서 woid_data 가져오기
            this.woid = woid_data;
            
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Faulty_Load(object sender, EventArgs e)
        {
            Common.SetGridDesign(LotID_Grid);
            Common.SetGridDesign(Defect_Grid);
            MessageBox.Show(woid);
            
            string LotId_Grid_Data = $"SELECT LOTID, LOTSTDTTM, LOTEDDTTM FROM LOT L, WORKORDER W WHERE W.WOID = '{woid}' AND W.WOID=L.WOID";
            Common.DB_Connection(LotId_Grid_Data, LotID_Grid);
            LotID_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string Defect_Grid_Data = $"SELECT * FROM DEFECT";
            Common.DB_Connection(Defect_Grid_Data, Defect_Grid);
            Defect_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (LotID_Grid.Rows.Count > 0)
            {
                LotID_Grid.Columns[0].HeaderText = "LOT코드";
                LotID_Grid.Columns[1].HeaderText = "시작시간";
                LotID_Grid.Columns[2].HeaderText = "종료시간";
            }
            if (Defect_Grid.Rows.Count > 0)
            {
                Defect_Grid.Columns[0].HeaderText = "불량코드";
                Defect_Grid.Columns[1].HeaderText = "불량요인";
            }

        }
        
        private void Defect_Grid_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Defect_Grid.Rows.Count - 1; i++)
            {

                if (Defect_Grid.Rows[i].Selected == true)
                {
                    defect_code = Defect_Grid.Rows[i].Cells[0].Value.ToString();
                    MessageBox.Show(defect_code);
                }
            }
            
            
        }

        private void LotID_Grid_MouseClick(object sender, MouseEventArgs e)
        {
            //불량을 등록할 LOTID 선택
            for (int i = 0; i < LotID_Grid.Rows.Count - 1; i++)
            {

                if (LotID_Grid.Rows[i].Selected == true)
                {
                    defect_lotid = LotID_Grid.Rows[i].Cells[0].Value.ToString();
                    MessageBox.Show(defect_lotid);
                }
            }
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            // defect_lotid , 1 , 1 , defect_code를 defectlot에 추가
            string add_lot = $" INSERT INTO LOT(LOTID, WOID, EQPTID,PROCID) VALUES((SELECT 'L' || TO_CHAR(TO_NUMBER(TO_CHAR(SYSDATE, 'YYYYMMDD') || NVL(TO_CHAR(MAX(SUBSTR(LOTID, 10))), 'FM0000')) + 1) FROM LOT), '{woid}',(SELECT EQPTID FROM EQUIPMENT WHERE EQPTSTATS = 'DOWN'),(SELECT PROCID FROM WORKORDER WHERE WOID = '{woid}'))";
            Common.DB_Connection(add_lot);
        }
    }
}
