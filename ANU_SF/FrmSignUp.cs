using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;


namespace ANU_SF
{
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIgnUp_Save();
        }
        private void SIgnUp_Save()
        {
            {
                if (txt_SITE.Text == "")
                {
                    MessageBox.Show("SITE를 입력해주세요");
                    return;
                }
                if (text_Factory.Text == "")
                {
                    MessageBox.Show("Factory를 입력해주세요");
                    return;
                }
                if (text_ID.Text == "")
                {
                    MessageBox.Show("USER ID를 입력해주세요");
                    return;
                }

                if (text_Password.Text == "")
                {
                    MessageBox.Show("Password를 입력해주세요");
                    return;
                }
                if (text_PWC.Text == "")
                {
                    MessageBox.Show("Password를 한번 더 입력해주세요");
                    return;
                }



                this.Cursor = Cursors.WaitCursor;
                try
                {
                    string mySql = string.Format("INSERT INTO SF_USERS (SITE,FACTORY,USERID,USERPW) VALUES ('{0}','{1}','{2}','{3}');",
                         txt_SITE.Text, text_Factory.Text, text_ID.Text, text_Password.Text);
                    //mySql += " INSERT INTO SF_USERS ( ";
                    //mySql += "         SITE, FACTORY , USERID, USERPW";
                    //mySql += "     ) ";
                    //mySql += "         VALUES '" + txt_SITE.Text + "', ";
                    //mySql += "                '" + text_Factory.Text + "', ";
                    //mySql += "                '" + text_ID.Text + "', ";
                    //mySql += "                '" + text_Password + "' ";



                    string debug = SF_Global.gConStr;
                    Console.WriteLine(debug);

                    MySqlConnection myCon = new MySqlConnection(SF_Global.gConStr);
                    myCon.Open();
                    var cmd = new MySqlCommand();
                    cmd.Connection = myCon;
                    cmd.CommandText = mySql;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    MessageBox.Show("저장되었습니다.", "확인 - 197");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "확인 201");
                    //MstbtnCancel();
                }
            }
        }

    } 
}
