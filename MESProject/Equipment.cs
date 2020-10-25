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
    public partial class Equipment : Form
    {
        private MainForm mainForm;
        public string EQPTID;
        public string woidto;

        public static string woid { get; set; }
        private TabControl maintab;
        public static string Mainform_PROC_COMBOBOX { get; set; }
        public Equipment()
        {
            InitializeComponent();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            Common.SetGridDesign(EquipmentGrid);
            string Selected_Equipment = $"SELECT * FROM EQUIPMENT WHERE EQPTID LIKE '%{Mainform_PROC_COMBOBOX}%'";
            Common.DB_Connection(Selected_Equipment, EquipmentGrid);

            if (EquipmentGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "설비코드", "설비명", "공정코드", "설비상태" };
                for (int i = 0; i < header.Length; i++)
                {
                    EquipmentGrid.Columns[i].HeaderText = $"{header[i]}";
                }
            }
        }

        private void EquipmentGrid_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < EquipmentGrid.Rows.Count - 1; i++)
            {

                if (EquipmentGrid.Rows[i].Selected == true)
                {
                    EQPTID = EquipmentGrid.Rows[i].Cells[0].Value.ToString();
                    //mainform에 EQPTID 전달
                    MainForm.Equipment_EQPTID = EQPTID;
                    EquipmentGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        private void CheckBtn_Click(object sender, EventArgs e)
        {
            //확인버튼
            if (EQPTID != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("설비선택");
            }
        }
        public void Form_closing(object sender, FormClosedEventArgs e)
        {
            maintab.TabPages.Remove(maintab.SelectedTab);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //닫기 버튼
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
