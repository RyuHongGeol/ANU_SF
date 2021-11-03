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
    public partial class frmBOM : Form
    {

        public DataSet ds = new DataSet();
        private string[] aParam = null;
        private string mySql = "";



        public frmBOM()
        {
            InitializeComponent();
        }
        private void frmBOM_Load(object sender, EventArgs e)
        {
            Getcbo();
            //Getcbo2();
            PPanel.Enabled = false;
            MPanel.Enabled = false;
        }
        private void Getcbo()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("P_ITEMCODE", typeof(string));
            dt.Columns.Add("P_ITEMNM", typeof(string));

            mySql = " SELECT NULL AS P_ITEMCODE, NULL AS P_ITEMNM FROM DUAL UNION ALL ";
            mySql += " SELECT P_ITEMCODE,P_ITEMNM FROM SF_PRODUCT ";

            dt = SF_Global.getDataTable(mySql);
            cboITEMCODE.ValueMember = "P_ITEMCODE";
            cboITEMCODE.DisplayMember = "P_ITEMNM";
            cboITEMCODE.DataSource = dt;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("M_ITEMCODE2", typeof(string));
            dt2.Columns.Add("M_ITEMNM", typeof(string));

            mySql = " SELECT NULL AS M_ITEMCODE2, NULL AS M_ITEMNM FROM DUAL UNION ALL ";
            mySql += " SELECT M_ITEMCODE2,M_ITEMNM FROM SF_MATERIAL ";
            //mySql += "WHERE 1=1 AND M_ITEMCODE LIKE '" + cboITEMCODE.ValueMember + "%' ";

            dt2 = SF_Global.getDataTable(mySql);
            cboMCODE.ValueMember = "M_ITEMCODE2";
            cboMCODE.DisplayMember = "M_ITEMNM";
            cboMCODE.DataSource = dt2;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            BOM_Select(cboITEMCODE.SelectedValue.ToString());
        }
        private void BOM_Select(string mstItem)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT P_ITEMCODE, ";
                mySql += "        P_ITEMNM, ";
                mySql += "        P_PRICE ";
                mySql += "   FROM SF_PRODUCT ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND P_ITEMCODE LIKE '" + mstItem + "%' ";
                mySql += " ORDER BY P_ITEMCODE ";

                aParam = new string[] { "", "", "" };

                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                //dataGridView1.DataSource = null;
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
                    //panel1.Enabled = true;

                    SF_Global.dgvSort(dataGridView1);
                }
                else
                {
                    MessageBox.Show("No Data", "확인 - 138");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 144");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                cboITEMCODE.SelectedValue = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtCODE.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNAME.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPRICE.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                GetM(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }

        }
        private void GetM(string mstCode)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += "SELECT M_ITEMCODE2,M_ITEMNM,M_QTY,M_PRICE,M_FROM ";
                mySql += "  FROM SF_MATERIAL ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND M_ITEMCODE = '" + mstCode + "' ";

                aParam = new string[] { "", "", "" };
                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

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
                    SF_Global.dgvSort(dataGridView2);
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
            if (dataGridView1.Rows.Count > 0)
            {
                cboMCODE.SelectedValue = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtMCODE.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtMNAME.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                txtMQTY.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                txtMPRICE.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                txtMFROM.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PPanel.Enabled = true;
            MPanel.Enabled = false;
            PMClear();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = (dataGridView1.Rows.Count - 1); i >= 0; i--)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = (dataGridView2.Rows.Count - 1); i >= 0; i--)
                {
                    dataGridView2.Rows.RemoveAt(i);
                }
            }
        }

        private void PMClear()
        {
            txtCODE.Text = "";
            txtNAME.Text = "";
            txtPRICE.Text = "";
            txtMCODE.Text = "";
            txtMNAME.Text = "";
            txtMQTY.Text = "";
            txtMPRICE.Text = "";
            txtMFROM.Text = "";




        }

        private void Data_Mst_Save()
        {
            if (txtCODE.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 155");
                txtCODE.Focus();
            }
            if (txtNAME.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 160");
                txtNAME.Focus();
               
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                mySql = "";
                mySql += " BEGIN ";
                mySql += " INSERT INTO SF_PRODUCT ( ";
                mySql += "         P_ITEMCODE, P_ITEMNM ,P_PRICE ";
                mySql += "     ) ";
                mySql += "         SELECT '" + txtCODE.Text + "', ";
                mySql += "                '" + txtNAME.Text + "', ";
                mySql += "                '" + txtPRICE.Text + "' ";
                mySql += "             FROM DUAL ";
                mySql += "             WHERE NOT EXISTS (SELECT * ";
                mySql += "                         FROM SF_PRODUCT ";
                mySql += "                         WHERE P_ITEMCODE = '" + txtCODE.Text + "'); ";

                mySql += "  UPDATE SF_PRODUCT ";
                mySql += "     SET P_ITEMCODE = '" + txtCODE.Text + "', ";
                mySql += "           P_ITEMNM = '" + txtNAME.Text + "', ";
                mySql += "            P_PRICE = '" + txtPRICE.Text + "' ";
                mySql += "   WHERE P_ITEMCODE = '" + txtCODE.Text + "'; ";
                mySql += " END; ";

                if (SF_Global.saveData(mySql))
                { }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "확인 201");
                //MstbtnCancel();
            }

            Data_Mst_Select();
        }
        private void Data_Mst_Select()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT P_ITEMCODE, ";
                mySql += "        P_ITEMNM, ";
                mySql += "        P_PRICE ";
                mySql += "   FROM SF_PRODUCT ";

                aParam = new string[] { "", "", "" };

                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                //dataGridView1.DataSource = null;
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
                else
                {
                    MessageBox.Show("No Data", "확인 - 138");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 144");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void btn_MSAVE_Click(object sender, EventArgs e)
        {
            Data_D_Save();
        }

        private void Data_D_Save()
        {
            if (txtMCODE.Text == "")
            {
                MessageBox.Show("부품코드를 입력해주세요");
                txtMCODE.Focus();
            }
            if (txtNAME.Text == "")
            {
                MessageBox.Show("부품명을 입력해주세요");
                txtMNAME.Focus();

            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                mySql = "";
                mySql += " BEGIN ";
                mySql += " INSERT INTO SF_MATERIAL ( ";
                mySql += "         M_ITEMCODE, M_ITEMCODE2, M_ITEMNM , M_QTY , M_PRICE, M_FROM ";

                mySql += "     ) ";
                mySql += "         SELECT '" + txtCODE.Text + "', ";
                mySql += "                '" + txtMCODE.Text + "', ";
                mySql += "                '" + txtMNAME.Text + "', ";
                mySql += "                '" + txtMQTY.Text + "', ";
                mySql += "                '" + txtMPRICE.Text + "', ";
                mySql += "                '" + txtMFROM.Text + "' ";
                mySql += "             FROM DUAL ";
                mySql += "             WHERE NOT EXISTS (SELECT * ";
                mySql += "                         FROM SF_MATERIAL ";
                mySql += "                         WHERE 1=1  ";
                mySql += "                          AND     M_ITEMCODE = '" + txtCODE.Text + "' ";
                mySql += "                          AND     M_ITEMCODE2 = '" + txtMCODE.Text + "'); ";
                mySql += "  UPDATE SF_MATERIAL ";
                mySql += "     SET M_ITEMCODE = '" + txtCODE.Text + "', ";
                mySql += "          M_ITEMCODE2 = '" + txtMCODE.Text + "',";
                mySql += "           M_ITEMNM = '" + txtMNAME.Text + "', ";
                mySql += "           M_QTY = '" + txtMQTY.Text + "', ";
                mySql += "           M_PRICE = '" + txtMPRICE.Text + "', ";
                mySql += "            M_FROM = '" + txtMFROM.Text + "' ";
                mySql += "                         WHERE 1 = 1  ";
                mySql += "                          AND     M_ITEMCODE = '" + txtCODE.Text + "' ";
                mySql += "                          AND     M_ITEMCODE2 = '" + txtMCODE.Text + "' ; ";
                mySql += " END; ";

                if (SF_Global.saveData(mySql))
                { }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "확인 201");
                //MstbtnCancel();
            }

            Data_D_Select();
        }
        private void Data_D_Select()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += "         SELECT M_ITEMCODE2, ";
                mySql += "                M_ITEMNM, ";
                mySql += "                M_QTY, ";
                mySql += "                M_PRICE, ";
                mySql += "                M_FROM ";
                mySql += "         FROM SF_MATERIAL ";
                mySql += "                         WHERE 1 = 1  ";
                mySql += "                          AND     M_ITEMCODE = '" + txtCODE.Text + "' ";

                aParam = new string[] { "", "", "" };

                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                //dataGridView1.DataSource = null;
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

                    SF_Global.dgvSort(dataGridView2);
                }
                else
                {
                    MessageBox.Show("No Data", "확인 - 138");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 144");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            PMClear();
        }

        private void btn_Madd_Click_1(object sender, EventArgs e)
        {
            MPanel.Enabled = true;

            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = (dataGridView2.Rows.Count - 1); i >= 0; i--)
                {
                    dataGridView2.Rows.RemoveAt(i);
                }
            }

            txtMCODE.Text = "";
            txtMNAME.Text = "";
            txtMQTY.Text = "";
            txtMPRICE.Text = "";
            txtMFROM.Text = "";
        }

        private void btn_MSAVE_Click_1(object sender, EventArgs e)
        {
            Data_D_Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PPanel.Enabled = true;
            MPanel.Enabled = true;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            PPanel.Enabled = false;
            MPanel.Enabled = false;
            PMClear();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = (dataGridView1.Rows.Count - 1); i >= 0; i--)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }

            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = (dataGridView2.Rows.Count - 1); i >= 0; i--)
                {
                    dataGridView2.Rows.RemoveAt(i);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtM = new DataTable("MST");
            DataTable dtD = new DataTable("DTL");

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
            dtD = (DataTable)(dataGridView2.DataSource);
            ds.Tables.Add(dtM);
            ds.Tables.Add(dtD.Copy());

            frmReport childForm = new frmReport(ds);
            childForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
 }


