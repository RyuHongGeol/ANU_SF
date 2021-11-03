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
    public partial class frmReport2 : Form
    {

        DataSet aDs = new DataSet();

        public frmReport2(DataSet ds)
        {

            InitializeComponent();
            aDs = ds;
        }

        private void frmReport2_Load(object sender, EventArgs e)
        {
            RptINVEN();
            this.reportViewer1.RefreshReport();
        }


        private void RptINVEN()
        {
            int rCnt = aDs.Tables[0].Rows.Count;
            if (rCnt > 0)
            {
                this.DataSet1.DataTable4.Clear();
                for (int i = 0; i < rCnt; i++)
                {
                    this.DataSet1.DataTable4.ImportRow(aDs.Tables[0].Rows[i]);
                }
            }
            rCnt = aDs.Tables[1].Rows.Count;
            if (rCnt > 0)
            {
                this.DataSet1.DataTable5.Clear();
                for (int i = 0; i < rCnt; i++)
                {
                    this.DataSet1.DataTable5.ImportRow(aDs.Tables[1].Rows[i]);
                }



            }
        }
    }
}
