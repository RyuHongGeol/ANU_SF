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
    public partial class frmReport : Form
    {
        DataSet aDs = new DataSet();

        public frmReport(DataSet ds)
        {
            InitializeComponent();
            aDs = ds;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            RptBOM();
            //rptTest();
            this.reportViewer2.RefreshReport();
          
        }
        private void rptTest()
        {
            string mySql = " SELECT MCODE1, MDESC1, DCODE2, DDESC2";
            mySql += " FROM SF_CODE1 M, SF_CODE2 D WHERE M.MCODE1 = D.DCODE1 ";
            string[] aParam = new string[] { "", "", "" };
            DataSet oraDS = SF_Global.getDataSet(aParam, mySql);
            int rCnt = oraDS.Tables[0].Rows.Count;
            if(rCnt > 0)
            {
                this.DataSet1.DataTable1.Clear();
                for(int i =0; i < rCnt; i++)
                {
                    this.DataSet1.DataTable1.ImportRow(oraDS.Tables[0].Rows[i]);
                }
            }
        }

        private void RptBOM()
        {
            int rCnt = aDs.Tables[0].Rows.Count;
            if (rCnt > 0)
            {
                this.DataSet1.DataTable2.Clear();
                for (int i = 0; i < rCnt; i++)
                {
                    this.DataSet1.DataTable2.ImportRow(aDs.Tables[0].Rows[i]);
                }
            }
            rCnt = aDs.Tables[1].Rows.Count;
            if (rCnt > 0)
            {
                this.DataSet1.DataTable3.Clear();
                for (int i = 0; i < rCnt; i++)
                {
                    this.DataSet1.DataTable3.ImportRow(aDs.Tables[1].Rows[i]);
                }



            }
        }

     
    }
}
