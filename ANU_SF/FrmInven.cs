using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace ANU_SF
{
    public partial class FrmInven : Form
    {

        public DataSet ds = new DataSet();
        private string[] aParam = null;
        private string mySql = "";

        public FrmInven()
        {
            InitializeComponent();
        }

        private void FrmInven_Load(object sender, EventArgs e)
        {
            getCode();
        }

        private void getCode()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DCODE2", typeof(string));
            dt.Columns.Add("DDESC2", typeof(string));

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '06' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboINVEN_ITEMCD.ValueMember = "DCODE2";
            cboINVEN_ITEMCD.DisplayMember = "DDESC2";
            cboINVEN_ITEMCD.DataSource = dt;
           

            dgINVEN_Itemcode.ValueMember = "DCODE2";
            dgINVEN_Itemcode.DisplayMember = "DDESC2";
            dgINVEN_Itemcode.DataSource = dt.Copy();

            dgINVEN_Itemcode2.ValueMember = "DCODE2";
            dgINVEN_Itemcode2.DisplayMember = "DDESC2";
            dgINVEN_Itemcode2.DataSource = dt.Copy();

            dg3INVEN_ITEMCODE.ValueMember = "DCODE2";
            dg3INVEN_ITEMCODE.DisplayMember = "DDESC2";
            dg3INVEN_ITEMCODE.DataSource = dt.Copy();




            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '05' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboINVEN_CUST.ValueMember = "DCODE2";
            cboINVEN_CUST.DisplayMember = "DDESC2";
            cboINVEN_CUST.DataSource = dt;

            cboINVEN_CUST2.ValueMember = "DCODE2";
            cboINVEN_CUST2.DisplayMember = "DDESC2";
            cboINVEN_CUST2.DataSource = dt.Copy();

            dgINVEN_CUST.ValueMember = "DCODE2";
            dgINVEN_CUST.DisplayMember = "DDESC2";
            dgINVEN_CUST.DataSource = dt.Copy();

            dgINVEN_Cust2.ValueMember = "DCODE2";
            dgINVEN_Cust2.DisplayMember = "DDESC2";
            dgINVEN_Cust2.DataSource = dt.Copy();




            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '07' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            dgINVEN_RS.ValueMember = "DCODE2";
            dgINVEN_RS.DisplayMember = "DDESC2";
            dgINVEN_RS.DataSource = dt;
            dgINVEN_RS2.ValueMember = "DCODE2";
            dgINVEN_RS2.DisplayMember = "DDESC2";
            dgINVEN_RS2.DataSource = dt.Copy();

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '01' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboINVEN_ITEMCD2.ValueMember = "DCODE2";
            cboINVEN_ITEMCD2.DisplayMember = "DDESC2";
            cboINVEN_ITEMCD2.DataSource = dt;
            
            dgINVEN_Itemcode2.ValueMember = "DCODE2";
            dgINVEN_Itemcode2.DisplayMember = "DDESC2";
            dgINVEN_Itemcode2.DataSource = dt.Copy();
            dg4INVEN_ITEMCODE.ValueMember = "DCODE2";
            dg4INVEN_ITEMCODE.DisplayMember = "DDESC2";
            dg4INVEN_ITEMCODE.DataSource = dt.Copy(); 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getMst();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            getMst2(cboINVEN_ITEMCD2.SelectedValue.ToString(),
                   cboINVEN_CUST2.SelectedValue.ToString(),
                   dtINVEN_ORDATE2.Value.ToShortDateString(),
                   dtINVEN_INDATE2.Value.ToShortDateString());
        }
        private void getMst()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT*FROM( ";
                mySql += " SELECT M.SALE_NO,SALE_INDATE,SALE_SHIPPING,SALE_ITEMCD,SALE_CUST,SALE_CNT,D.SALE_NOTE ";
                mySql += "  FROM HR.SF_SALE_M M , HR.SF_SALE_D D ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND M.SALE_NO = D.SALE_NO ";
                mySql += "   AND M.SALE_CUST LIKE '" + cboINVEN_CUST.SelectedValue.ToString() + "%' ";
                mySql += "   AND D.SALE_ITEMCD LIKE '" + cboINVEN_ITEMCD.SelectedValue.ToString() + "%' ";
                mySql += "   AND M.SALE_INDATE BETWEEN '" + dtINVEN_ORDATE.Value.ToShortDateString() + "' AND '" + dtINVEN_INDATE.Value.ToShortDateString() + "' ";
                mySql += " UNION ";
                mySql += " SELECT SEQ,ENDDT,RCV,ITEMCODE,FACTORY,CNT,QCCHK ";
                mySql += "  FROM SF_PROD ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND FACTORY LIKE '" + cboINVEN_CUST.SelectedValue.ToString() + "%' ";
                mySql += "   AND ITEMCODE LIKE '" + cboINVEN_ITEMCD.SelectedValue.ToString() + "%' ";
                mySql += "   AND ENDDT BETWEEN '" + dtINVEN_ORDATE.Value.ToShortDateString() + "' AND '" + dtINVEN_INDATE.Value.ToShortDateString() + "' ";
                mySql += " ) ";
                mySql += " ORDER BY SALE_INDATE ";


                aParam = new string[] { "", "", "" };
                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                //dataGridView2.DtaSource = null;
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = (dataGridView1.Rows.Count - 1); i >= 0; i--)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
                if (oraDS != null && oraDS.Tables.Count > 0)
                {
                    dataGridView1.DataSource = oraDS.Tables[0];
                    SF_Global.dgvSort(dataGridView1);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 144");
            }

        }
        private void getMst2(string mstItem, string mstCust, string ordDt, string inDt)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT*FROM( ";
                mySql += " SELECT M.SUPP_NO,SUPP_INDATE,SUPP_RCV,SUPP_ITEMCD,SUPP_CUST,SUPP_CNT,D.SUPP_NOTE ";
                mySql += "  FROM HR.SF_SUPP_M M , HR.SF_SUPP_D D ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND M.SUPP_NO = D.SUPP_NO ";
                mySql += "   AND M.SUPP_CUST LIKE '" + mstCust + "%' ";
                mySql += "   AND D.SUPP_ITEMCD LIKE '" + mstItem + "%' ";
                mySql += "   AND M.SUPP_ORDATE BETWEEN '" + ordDt + "' AND '" + inDt + "' ";
                mySql += " UNION ";
                mySql += " SELECT SEQ,ENDDT,SHIP,ROUT,FACTORY,CNT,QCCHK ";
                mySql += "  FROM SF_PROD ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND FACTORY LIKE '" + mstCust + "%' ";
                mySql += "   AND ROUT LIKE '" + mstItem + "%' ";
                mySql += "   AND ENDDT BETWEEN '" + ordDt + "' AND '" + inDt + "' ";
                mySql += " ) ";
                mySql += " ORDER BY SUPP_INDATE ";


                aParam = new string[] { "", "", "" };
                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                //dataGridView2.DtaSource = null;
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = (dataGridView2.Rows.Count - 1); i >= 0; i--)
                    {
                        dataGridView2.Rows.RemoveAt(i);
                    }
                }
                if (oraDS != null && oraDS.Tables.Count > 0)
                {
                    dataGridView2.DataSource = oraDS.Tables[0];
                    SF_Global.dgvSort(dataGridView1);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 144");
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                cboINVEN_ITEMCD.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cboINVEN_CUST.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                getDtlM();
            }
        }

        private void getDtlM()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += "SELECT INVEN_ITEMCODE,INVEN_CNT ";
                mySql += "  FROM SF_INVENTORY ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND INVEN_ITEMCODE = '" + cboINVEN_ITEMCD.SelectedValue + "' ";

                aParam = new string[] { "", "", "" };
                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                if (dataGridView3.Rows.Count > 0)
                {
                    for (int i = (dataGridView3.Rows.Count - 1); i >= 0; i--)
                    {
                        dataGridView3.Rows.RemoveAt(i);
                    }
                }
                if (oraDS != null && oraDS.Tables.Count > 0)
                {
                    dataGridView3.DataSource = oraDS.Tables[0];
                    SF_Global.dgvSort(dataGridView3);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 251");
            }

        }
        private void getDtlM2()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += "SELECT INVEN2_ITEMCODE,INVEN2_CNT ";
                mySql += "  FROM SF_INVENTORY2 ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND INVEN2_ITEMCODE = '" + cboINVEN_ITEMCD2.SelectedValue + "' ";

                aParam = new string[] { "", "", "" };
                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                if (dataGridView4.Rows.Count > 0)
                {
                    for (int i = (dataGridView4.Rows.Count - 1); i >= 0; i--)
                    {
                        dataGridView4.Rows.RemoveAt(i);
                    }
                }
                if (oraDS != null && oraDS.Tables.Count > 0)
                {
                    dataGridView4.DataSource = oraDS.Tables[0];
                    SF_Global.dgvSort(dataGridView3);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 251");
            }

        }
        private void dataGridView2_Click(object sender, EventArgs e)
        {
            cboINVEN_ITEMCD2.SelectedValue = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            cboINVEN_CUST2.SelectedValue = dataGridView2.CurrentRow.Cells[4].Value.ToString();

            getDtlM2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtM = new DataTable("MST");
            DataTable dtD = new DataTable("DTL");
            DataTable dtm2 = new DataTable("MST");

            foreach (DataGridViewColumn column in dataGridView1.Columns)
                dtM.Columns.Add(column.Name); //, column.CellType); //better to have cell type
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    dtM.Rows.Add();
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dtM.Rows[0][j] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }
            }
            dtD = (DataTable)(dataGridView3.DataSource);
            dtD = (DataTable)(dataGridView3.DataSource);

            ds.Tables.Add(dtM);
            ds.Tables.Add(dtD.Copy());
            ds.Tables.Add(dtm2.Copy());

            frmReport2 childForm = new frmReport2(ds);
            childForm.Show();
        }
    }
}
