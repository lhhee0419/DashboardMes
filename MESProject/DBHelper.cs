using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    class DBHelper
    {
        public DBHelper() { }



        private static OracleConnection conn = null;
        public static string DBconnString
        {
            get;
            private set;
        }

        public static bool bDBConnCheck = false;

        private static int errorBoxCount = 0;




        public static OracleConnection DBconn
        {
            get
            {
                if (!ConnectToDB())
                {
                    return null;
                }
                return conn;
            }
        }
        public static bool ConnectToDB()
        {
            if (conn == null)
            {
                DBconnString = string.Format("Data Source=(DESCRIPTION="
                    + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.169)"
                    + "(PORT=1521)))(CONNECT_DATA= (SERVER = DEDICATED)"
                    + "(SERVICE_NAME = xe))); User Id = sys; Password = smart123; ");
                conn = new OracleConnection(DBconnString);
            }
            try
            {
                if (!IsDBConnected)
                {
                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        bDBConnCheck = true;
                    }
                    else
                    {
                        bDBConnCheck = false;
                    }
                }
            }
            catch (Exception e)
            {
                errorBoxCount++;
                if (errorBoxCount == 1)
                {
                    MessageBox.Show(e.Message, "DBHelper - connectToDB");
                }
                return false;
            }
            return true;
        }
        public static bool IsDBConnected
        {
            get
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    return false;
                }
                return true;
            }
        }
        public static void Close()
        {
            if (IsDBConnected)
            {
                DBconn.Close();
            }

        }
    }
}
