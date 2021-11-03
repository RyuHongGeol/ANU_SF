using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANU_SF
{
    public partial class frmMain : Form
    {

        DataSet aDs = new DataSet();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = SF_Global.gSiteID + ", " + SF_Global.gFactory + ", " + SF_Global.gUserID;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            #region

            #region Form1
            frmProd childForm = new frmProd();
            #endregion
            if (formIsExist(childForm.GetType()))
            {
                childForm.Dispose();     // 창 리소스 제거

                //MessageBox.Show("이미 창이 열려있습니다.");
            }
            else
            {
                childForm.MdiParent = this;
                childForm.Show();
            }
            #endregion
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmSupp childForm = new frmSupp();
            if (formIsExist(childForm.GetType()))
            {
                childForm.Dispose();     // 창 리소스 제거

                //MessageBox.Show("이미 창이 열려있습니다.");
            }
            else
            {
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FrmInven childForm = new FrmInven();
            if (formIsExist(childForm.GetType()))
            {
                childForm.Dispose();     // 창 리소스 제거

                //MessageBox.Show("이미 창이 열려있습니다.");
            }
            else
            {
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void 생산ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmProd newMDIChild = new frmProd();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void 생산ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmProd newMDIChild = new frmProd();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }
        // 자식 폼 중복 여부
        private bool formIsExist(Type tp)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == tp)
                {
                    form.Activate();
                    return true;
                }
            }
            return false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmSignUp childForm = new FrmSignUp();
            if (formIsExist(childForm.GetType()))
            {
                childForm.Dispose();     // 창 리소스 제거

                //MessageBox.Show("이미 창이 열려있습니다.");
            }
            else
            {
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FrmCode childForm = new FrmCode();
            if (formIsExist(childForm.GetType()))
            {
                childForm.Dispose();     // 창 리소스 제거

                //MessageBox.Show("이미 창이 열려있습니다.");
            }
            else
            {
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmSale childForm = new frmSale();
            if (formIsExist(childForm.GetType()))
            {
                childForm.Dispose();     // 창 리소스 제거

                //MessageBox.Show("이미 창이 열려있습니다.");
            }
            else
            {
                childForm.MdiParent = this;
                childForm.Show();
            }
        }


        private void BOM_Click(object sender, EventArgs e)
        {
            frmBOM childForm = new frmBOM();
            if (formIsExist(childForm.GetType()))
            {
                childForm.Dispose();     // 창 리소스 제거

                //MessageBox.Show("이미 창이 열려있습니다.");
            }
            else
            {
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void Report_Click(object sender, EventArgs e)
        {
            frmReport childForm = new frmReport(aDs);
            if (formIsExist(childForm.GetType()))
            {
                childForm.Dispose();     // 창 리소스 제거

                //MessageBox.Show("이미 창이 열려있습니다.");
            }
            else
            {
                childForm.MdiParent = this;
                childForm.Show();
            }
        }
    }
}
