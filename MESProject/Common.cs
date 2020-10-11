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
            Grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grid.Font = new Font("Fixsys", 14, FontStyle.Regular);

        }

        static public void DB_Connection(string sql, DataGridView gridView)
        {
            OracleDataAdapter adapter = new OracleDataAdapter(sql, DBHelper.DBconn);
            DataTable data_table = new DataTable();
            adapter.Fill(data_table);
            gridView.DataSource = data_table;
        }
    }
}
