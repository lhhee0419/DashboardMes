using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    public partial class Stopworking : Form
    {
        //작업중지요인 값 저장
        string rad = "";
        //woid
        string woid;
        string lotID;

        public Stopworking(string woid_data, string lotid)
        {
            InitializeComponent();
            this.woid = woid_data;
            this.lotID = lotid;
        }

        private void Stopworking_Load(object sender, EventArgs e)
        {

        }
        private void RadClick(object sender, EventArgs e, string name, string code)
        {
            //라디오버튼 클릭 함수 NAME = 요인 CODE = 코드
            RadioButton Rbtn = sender as RadioButton;

            if (Rbtn.Checked == true)
            {
                MessageBox.Show(name);
                rad = code;
            }
            else if (Rbtn.Checked == false)
                return;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기 버튼
            this.Close();
        }

        //라디오버튼 클릭
        private void STW_RT_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "쉬는시간", "SF001");
        }
        private void STW_MEAL_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "식사시간", "SF002");
        }
        private void SWF_ERROR_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "설비오류", "SF003");
        }
        private void SWF_CHECK_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "설비점검", "SF004");
        }
        private void SWF_ACCIDENT_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "사고", "SF005");
        }
        private void SWF_ETC_Click(object sender, EventArgs e)
        {
            RadClick(sender, e, "기타", "SF006");
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {

            // STOPWK INSERT EQPTID , TIMESTAMP , STOPWKID
            string Update_StopWorking = $"INSERT INTO STOPWK select L.EQPTID,TO_CHAR(SYSDATE, 'YY/MM/DD HH:MI:SS'), F.STOPWKID " +
                                        $"from lot L, STOPWKFACTOR F, EQUIPMENT E where lotid = '{lotID}' AND E.EQPTID = L.EQPTID AND F.STOPWKID='{rad}'";
            Common.DB_Connection(Update_StopWorking);

            //WORKORDER WOSTAT 상태 변경
            string update_Wostat = $"UPDATE WORKORDER W SET W.WOSTAT='P' WHERE W.WOID = '{woid}'";
            Common.DB_Connection(update_Wostat);

            //EQPTSTATS 변경
            string update_EQPTStats = $"UPDATE EQUIPMENT E SET E.EQPTSTATS = 'DOWN' WHERE EQPTID IN (SELECT EQPTID FROM LOT WHERE LOTID='{rad}')";
            Common.DB_Connection(update_EQPTStats);
            MessageBox.Show("등록되었습니다.");
            this.Close();
        }
    }
}
