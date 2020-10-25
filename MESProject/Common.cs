using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    class Common
    {
        static public void SetGridDesign(DataGridView Grid)
        {

            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            Grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Grid.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            Grid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            Grid.BackgroundColor = Color.White;
            Grid.EnableHeadersVisualStyles = false;
            Grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grid.Font = new Font("Fixsys", 15, FontStyle.Regular);

        }

        static public void DB_Connection(string sql, DataGridView gridView)
        {
            OracleDataAdapter adapter = new OracleDataAdapter(sql, DBHelper.DBconn);
            DataTable data_table = new DataTable();
            adapter.Fill(data_table);
            gridView.DataSource = data_table;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        static public DataTable DB_Connection(string sql)
        {
            OracleDataAdapter adapter = new OracleDataAdapter(sql, DBHelper.DBconn);
            DataTable data_table = new DataTable();
            adapter.Fill(data_table);
            return data_table;
        }

        static public void Create_Tab(string name, string text, Form form, TabControl tab)
        {

            if (tab.TabPages.Count > 1)
            {
                for (int i = 0; i < tab.TabPages.Count; i++)
                {
                    if (tab.TabPages[i].Name == $"{name}")
                    {
                        tab.SelectedIndex = i;
                        return;
                    }
                }
                form.TopLevel = false;
                tab.TabPages.Add((tab.TabPages.Count + 1).ToString());
                tab.TabPages[tab.TabPages.Count - 1].Controls.Add(form);
                tab.SelectedIndex = tab.TabPages.Count - 1;
                tab.SelectedTab.Text = $"{text}";
                tab.SelectedTab.Name = $"{name}";
                tab.TabPages[tab.TabPages.Count - 1].Controls.Add(form);
                form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                form.Show();
            }
            else
            {

                form.TopLevel = false;
                tab.TabPages.Add((tab.TabPages.Count + 1).ToString());
                tab.TabPages[tab.TabPages.Count - 1].Controls.Add(form);
                tab.SelectedIndex = tab.TabPages.Count - 1;
                tab.SelectedTab.Text = $"{text}";
                tab.SelectedTab.Name = $"{name}";
                tab.TabPages[tab.TabPages.Count - 1].Controls.Add(form);
                form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                form.Show();
            }
        }
    }
}
