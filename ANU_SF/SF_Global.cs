using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;

namespace ANU_SF
{
    public class SF_Global
    {
        public SF_Global()
        {
        }

        public static string RegKey = @"Software\My_0913";
        public static string gSiteID = "1";
        public static string gFactory = "2";
        public static string gUserID = "";
        public static string gUserNm = "";
        public static string gUserPW = "";
        //public static string gLoginIP = "192.168.0.15";
        //public static string gLoginIP = "192.168.110.78";
        public static string gLoginIP = "127.0.0.1";
        public static string gPort = "3306";
        public static string gServerId = "ssang";
        public static string gServerPw = "ssang";

        //public static string gConStr = "Server=" + SF_Global.gLoginIP + ":1521/XE;User Id=HR;Password=1234;";
        public static string gConStr = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", gLoginIP, gPort,"ssang",gServerId, gServerPw);
        public static int gAcc = 0;

        private static MySqlConnection myConn;
        public static void dgvSort(DataGridView gv)
        {
            gv.RowHeadersWidth = 55;
            int iMod = 0;
            for (int i = 0; i < gv.RowCount; i++)
            {
                gv.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);

                iMod = i % 2;
                if (iMod == 0)
                    gv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
            }
        }

        public static void oraOpen()
        {
            if (myConn != null && myConn.State == ConnectionState.Open)
                myConn.Close();

            myConn = new MySqlConnection(SF_Global.gConStr);
            myConn.Open();
        }   // open

        public static void oraClose()
        {
            if (myConn.State == ConnectionState.Open)
                myConn.Close();
        }   // close

        public static DataSet getDataSet(string[] param, string sql)
        {
            myConn = new MySqlConnection(SF_Global.gConStr);
            oraOpen();
            MySqlDataAdapter oraAdapter = new MySqlDataAdapter();
            oraAdapter.SelectCommand = new MySqlCommand(sql, myConn);

            DataSet ds = new DataSet();
            oraAdapter.Fill(ds);
            oraClose();

            return ds;
        }   // get_DataSet 

        public static DataTable getDataTable(string mySql)
        {
            myConn = new MySqlConnection(SF_Global.gConStr);
            myConn.Open();
            MySqlCommand sc;
            MySqlDataReader reader;
            DataTable dt = new DataTable();
            sc = new MySqlCommand(mySql, myConn);
            reader = sc.ExecuteReader();
            dt.Load(reader);
            oraClose();

            return dt;
        }

        public static bool saveData(string mySql)
        {
            bool rtn = false;
            try
            {
                myConn = new MySqlConnection(SF_Global.gConStr);
                var cmd = new MySqlCommand();
                cmd.Connection = myConn;
                cmd.CommandText = mySql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                MessageBox.Show("저장되었습니다.", "확인 - 102");
                return rtn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "저장 오류 - 102");
                return rtn;
            }
        }

        #region 폼 호출
        /*
        private string[] aParam = null;
        aParam = new string[] { "","" };
        frmErrorMsg newForm = new frmErrorMsg(aParam);


        string[] gParm;
        public frmErrorMsg(string[] Parm)
        {
        InitializeComponent();
        gParm = Parm;
        }
        */
        #endregion
    }
}
