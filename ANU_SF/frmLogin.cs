using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
//using Oracle.ManagedDataAccess.Client;

namespace ANU_SF
{
    public partial class frmLogin : Form
    {
        //private OracleConnection oraConn;
        private string mySql = "";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            GetFromRegistry();

            if (txtSiteID.Text == "")
                txtSiteID.Focus();
            else if (txtFactory.Text == "")
                txtFactory.Focus();
            else if (txtUserID.Text == "")
                txtUserID.Focus();
            else
                txtPassword.Focus();

        }

        private bool chkLogin()
        {
            bool rtn = false;
            mySql = "";
            mySql += "SELECT USERID ";
            mySql += "  FROM SF_USERS ";
            mySql += " WHERE 1 = 1 ";
            mySql += "   AND SITE = '" + txtSiteID.Text + "' ";
            mySql += "   AND FACTORY = '" + txtFactory.Text + "'  ";
            mySql += "   AND USERID = '" + txtUserID.Text + "' ";
            mySql += "   AND USERPW = '" + txtPassword.Text + "' ";


            //oraConn = new OracleConnection(SF_Global.gConStr);
            //oraConn.Open();
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = oraConn;
            //cmd.CommandText = oraStr;
            //cmd.CommandType = CommandType.Text;
            //OracleDataReader dr = cmd.ExecuteReader();

            try
            {
                DataTable dt = SF_Global.getDataTable(mySql);

                if (dt.Rows.Count > 0)
                {
                    //SF_Global.gUserNm = dt.Rows[0][0].ToString();
                    rtn = true;
                }
                //while (dr.Read())
                //{
                //    //Console.WriteLine(dr.GetInt32(0) + ", " + dr.GetString(1));

                //    SF_Global.gUserNm = dr.GetString(0);
                //}
                //oraConn.Close();
                //oraConn.Dispose();

                return rtn;
            }
            catch (Exception ex)
            {
                //if (oraConn.State == ConnectionState.Open)
                //{
                //    oraConn.Close();
                //    oraConn.Dispose();
                //}
                MessageBox.Show(ex.Message.ToString(), "Error(131)");
                //Console.WriteLine("Error(132) : {0}", ex);
                return rtn;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("비밀번호를 입력하세요.");
                return;
            }

            if (checkBox1.Checked)
            {
                SetToRegistry(txtSiteID.Text, txtFactory.Text, txtUserID.Text, "", checkBox1.CheckState.ToString());
            }
            else
            {
                SetToRegistry("", "", "", "", "");
            }

            if (chkLogin())
            {
                MessageBox.Show("로그인 완료");
                //MessageBox.Show("OK","Test");
                //데이터베이스 조회

                //로그인 값 확인
                //if 승인 메인창 오픈
                SF_Global.gSiteID = txtSiteID.Text;
                SF_Global.gFactory = txtFactory.Text;
                SF_Global.gUserID = txtUserID.Text;
                SF_Global.gUserPW = txtPassword.Text;
                SF_Global.gUserNm = "";
                //메인창으로 이동
                Program.logOK = true;

                //this.Hide();
                this.Close();
                //else 메세지
            }
            else
            {
                MessageBox.Show("로그인하지 못했습니다.\r\n아이디와 비밀번호를 확인하세요.", "사용자 로그인 에러(97)", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Registry
        private void GetFromRegistry()
        {
            try
            {
                RegistryKey mykey = Registry.CurrentUser.OpenSubKey(SF_Global.RegKey);
                if (mykey != null)
                {
                    if (mykey.GetValue("SiteID") != null)
                        txtSiteID.Text = mykey.GetValue("SiteID").ToString();
                    if (mykey.GetValue("Factory") != null)
                        txtFactory.Text = mykey.GetValue("Factory").ToString();
                    if (mykey.GetValue("UserID") != null)
                        txtUserID.Text = mykey.GetValue("UserID").ToString();
                    
                    if (mykey.GetValue("UserPW") != null)
                        txtPassword.Text = mykey.GetValue("UserPW").ToString();
                    if (mykey.GetValue("Chk") != null)
                    {
                        if (mykey.GetValue("Chk").ToString() == "Checked")
                            checkBox1.Checked = true;
                        else checkBox1.Checked = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show(this.Text + " \r\n 프로그램을 다시 시작하세요.", this.Text + " 86", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        private void SetToRegistry(string a, string b, string c, string d, string e)
        {
            RegistryKey myKey = Registry.CurrentUser.CreateSubKey(SF_Global.RegKey);
            myKey.SetValue("SiteID", a);
            myKey.SetValue("Factory", b);
            myKey.SetValue("UserID", c);
           
            myKey.SetValue("UserPW", d);// txtPassword.Text);// 
            myKey.SetValue("Chk", e);// txtPassword.Text);// 
        }

        #endregion

        private void txtSiteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFactory.Focus();
            }
        }

        private void txtFactory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUserID.Focus();
            }
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSignUp Up = new FrmSignUp();
            Up.Show();
        }

        private void txtFactory_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

