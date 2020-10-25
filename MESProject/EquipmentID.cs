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
    public partial class EquipmentID : Form
    {
        private MainForm mainForm;
        string EQPTID = "";
        public string woid;
        private TabControl maintab;

        public EquipmentID()
        {
            InitializeComponent();
        }

        public EquipmentID(MainForm mainForm, string e_woid)
        {
            this.mainForm = mainForm;
            this.woid = e_woid;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EquipmentID_Load(object sender, EventArgs e)
        {
            Common.SetGridDesign(EquipmentGrid);
            string Selected_Equipment = $"SELECT * FROM EQUIPMENT";
            Common.DB_Connection(Selected_Equipment, EquipmentGrid);

            if (EquipmentGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "설비코드","설비명","공정코드","설비상태" };
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
                    EquipmentGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            //체크버튼
            Startworking startworking = new Startworking(woid, EQPTID);
            startworking.ShowDialog();

            Startworking startworkingForm = new Startworking();
            if (woid != "")
            {
                startworkingForm.Selected_woid = woid;
                Common.Create_Tab("startworking", "작업시작", startworkingForm, maintab);
            }
            startworkingForm.FormClosed += Form_closing;
        }
        public void Form_closing(object sender, FormClosedEventArgs e)
        {
            maintab.TabPages.Remove(maintab.SelectedTab);
        }
    }
}
