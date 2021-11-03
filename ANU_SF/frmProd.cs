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
    public partial class frmProd : Form
    {
        public DataSet ds = new DataSet();
        private string[] aParam = null;
        private string mySql = "";

        public frmProd()
        {
            InitializeComponent();
            panel3.Enabled = false;
        }

        private void frmProd_Load(object sender, EventArgs e)
        {
            getCode2();
            //txtFTY2.Text = SF_Global.gFactory; // 실패, 로그인정보 띄우기
           
        }

        private void getCode2()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("DCODE2", typeof(string));
            dt.Columns.Add("DDESC2", typeof(string));

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '06' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboITEMCODE.ValueMember = "DCODE2";
            cboITEMCODE.DisplayMember = "DDESC2";
            cboITEMCODE.DataSource = dt;
            cboITEMCODE2.ValueMember = "DCODE2";
            cboITEMCODE2.DisplayMember = "DDESC2";
            cboITEMCODE2.DataSource = dt.Copy();
            dgITEMCODE.ValueMember = "DCODE2";
            dgITEMCODE.DisplayMember = "DDESC2";
            dgITEMCODE.DataSource = dt.Copy();

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '01' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboSTD.ValueMember = "DCODE2";
            cboSTD.DisplayMember = "DDESC2";
            cboSTD.DataSource = dt;
            cboSTD2.ValueMember = "DCODE2";
            cboSTD2.DisplayMember = "DDESC2";
            cboSTD2.DataSource = dt.Copy();
            dgSTD.ValueMember = "DCODE2";
            dgSTD.DisplayMember = "DDESC2";
            dgSTD.DataSource = dt.Copy();

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '03' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboROUT.ValueMember = "DCODE2";
            cboROUT.DisplayMember = "DDESC2";
            cboROUT.DataSource = dt;
            cboROUT2.ValueMember = "DCODE2";
            cboROUT2.DisplayMember = "DDESC2";
            cboROUT2.DataSource = dt.Copy();
            dgROUT.ValueMember = "DCODE2";
            dgROUT.DisplayMember = "DDESC2";
            dgROUT.DataSource = dt.Copy();

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '04' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboEMP.ValueMember = "DCODE2";
            cboEMP.DisplayMember = "DDESC2";
            cboEMP.DataSource = dt;
            cboEMP2.ValueMember = "DCODE2";
            cboEMP2.DisplayMember = "DDESC2";
            cboEMP2.DataSource = dt.Copy();
            dgEMP.ValueMember = "DCODE2";
            dgEMP.DisplayMember = "DDESC2";
            dgEMP.DataSource = dt.Copy();

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '07' AND DUSEYN = 'True' AND DCODE2 > 2 ";

            dt = SF_Global.getDataTable(mySql);

            cboRCV.ValueMember = "DCODE2";
            cboRCV.DisplayMember = "DDESC2";
            cboRCV.DataSource = dt;
            dgRCV.ValueMember = "DCODE2";
            dgRCV.DisplayMember = "DDESC2";
            dgRCV.DataSource = dt.Copy();


            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '05' AND DUSEYN = 'True' AND DCODE2 >= 0007  ";

            dt = SF_Global.getDataTable(mySql);

            cboFACTORY.ValueMember = "DCODE2";
            cboFACTORY.DisplayMember = "DDESC2";
            cboFACTORY.DataSource = dt;
            dgFTY.ValueMember = "DCODE2";
            dgFTY.DisplayMember = "DDESC2";
            dgFTY.DataSource = dt.Copy();


            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '08' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);
            cboShip.ValueMember = "DCODE2";
            cboShip.DisplayMember = "DDESC2";
            cboShip.DataSource = dt;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtSEQ.Text = "";
            panel3.Enabled = true;
          
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtSEQ.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            Clear2();
            panel3.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if(txtCNT.Text == "" )
            {
                MessageBox.Show("수량을 입력하세요");
                txtCNT.Focus();
            }

            saveData();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                txtSEQ.Text = dr.Cells[0].Value.ToString();
                dtSTDT.Value = Convert.ToDateTime(dr.Cells[1].Value);
                dtENDDT.Value = Convert.ToDateTime(dr.Cells[2].Value);
                cboITEMCODE.SelectedValue = dr.Cells[3].Value.ToString();
                cboSTD.SelectedValue = dr.Cells[4].Value.ToString();
                txtCNT.Text = dr.Cells[5].Value.ToString();
                cboROUT.SelectedValue = dr.Cells[6].Value.ToString();
                cboEMP.SelectedValue = dr.Cells[7].Value.ToString();
                txtQCCHK.Text = dr.Cells[8].Value.ToString();
                chkQCRLT.Checked = Convert.ToBoolean(dr.Cells[9].Value);
                cboFACTORY.SelectedValue = dr.Cells[10].Value.ToString();
                cboRCV.SelectedValue = dr.Cells[11].Value.ToString();
            }
        }

        private void getData()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT ";
                mySql += "   SEQ , ";
                mySql += "   STDT , ";
                mySql += "   ENDDT , ";
                mySql += "   ITEMCODE , ";
                mySql += "   STD , ";
                mySql += "   CNT , ";
                mySql += "   ROUT , ";
                mySql += "   EMP , ";
                mySql += "   QCCHK , ";
                mySql += "   QCRLT , ";
                mySql += "   FACTORY, ";
                mySql += "   RCV ";
                mySql += " FROM SF_PROD ";
                mySql += "WHERE 1 = 1 ";
                mySql += "  AND ITEMCODE LIKE '" + cboITEMCODE2.SelectedValue.ToString() + "%' ";
                mySql += "  AND STD LIKE '" + cboSTD2.SelectedValue.ToString() + "%' ";
                mySql += "  AND ROUT LIKE '" + cboROUT2.SelectedValue.ToString() + "%' ";
                mySql += "  AND EMP LIKE '" + cboEMP2.SelectedValue.ToString() + "%' ";
                mySql += "  AND ENDDT BETWEEN '" + dtSTDT2.Value.ToShortDateString() + "' ";
                mySql += "                AND '" + dtENDDT2.Value.ToShortDateString() + "'";
                mySql += "ORDER BY SEQ DESC ";

                aParam = new string[] { "", "", "" };

                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

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

        private void saveData()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //CREATE SEQUENCE SF_PROD_SEQ START WITH 1; 
                mySql = "";
                mySql += " BEGIN ";
                mySql += " INSERT INTO SF_PROD ( ";
                mySql += "         SEQ,STDT,ENDDT,ITEMCODE,STD,CNT,ROUT,EMP,QCCHK,QCRLT,FACTORY,RCV,SHIP";
                mySql += "     ) ";
                mySql += "         SELECT SF_PROD_SEQ.nextval, ";
                mySql += "                '" + dtSTDT.Value.ToShortDateString() + "', ";
                mySql += "                '" + dtENDDT.Value.ToShortDateString() + "', ";
                mySql += "                '" + cboITEMCODE.SelectedValue.ToString() + "', ";
                mySql += "                '" + cboSTD.SelectedValue.ToString() + "', ";
                mySql += "                '" + txtCNT.Text.ToString() + "', ";
                mySql += "                '" + cboROUT.SelectedValue.ToString() + "', ";
                mySql += "                '" + cboEMP.SelectedValue.ToString() + "', ";
                mySql += "                '" + txtQCCHK.Text.ToString() + "', ";
                mySql += "                '" + chkQCRLT.Checked.ToString() + "', ";
                mySql += "                '" + cboFACTORY.SelectedValue.ToString() + "', ";
                mySql += "                '" + cboRCV.SelectedValue.ToString() + "', ";
                mySql += "                '" + cboShip.SelectedValue.ToString() + "' ";
                mySql += "             FROM DUAL ";
                mySql += "             WHERE NOT EXISTS (SELECT * ";
                mySql += "                         FROM SF_PROD ";
                mySql += "                         WHERE SEQ = '" + txtSEQ.Text + "'); ";

                mySql += "  UPDATE SF_PROD ";
                mySql += "     SET STDT = '" + dtSTDT.Value.ToShortDateString() + "',  ";
                mySql += "         ENDDT = '" + dtENDDT.Value.ToShortDateString() + "',  ";
                mySql += "         ITEMCODE = '" + cboITEMCODE.SelectedValue.ToString() + "',  ";
                mySql += "         STD = '" + cboSTD.SelectedValue.ToString() + "',  ";
                mySql += "         CNT = '" + txtCNT.Text.ToString() + "',  ";
                mySql += "         ROUT = '" + cboROUT.SelectedValue.ToString() + "',  ";
                mySql += "         EMP = '" + cboEMP.SelectedValue.ToString() + "',  ";
                mySql += "         QCCHK = '" + txtQCCHK.Text.ToString() + "',  ";
                mySql += "         QCRLT = '" + chkQCRLT.Checked.ToString() + "',  ";
                mySql += "         FACTORY = '" + cboFACTORY.SelectedValue.ToString() + "',  ";
                mySql += "         RCV = '" + cboRCV.SelectedValue.ToString() + "' , ";
                mySql += "         SHIP = '" + cboShip.SelectedValue.ToString() + "'  ";
                mySql += "   WHERE SEQ = '" + txtSEQ.Text + "'; ";

                mySql += " UPDATE SF_INVENTORY ";
                mySql += " SET INVEN_ITEMCODE = '" + cboITEMCODE.SelectedValue.ToString() + "',  ";
                mySql += " INVEN_CNT = INVEN_CNT + '" + txtCNT.Text.ToString() + "'  ";
                mySql += " WHERE INVEN_ITEMCODE = '" + cboITEMCODE.SelectedValue.ToString() + "' ; ";

                mySql += " INSERT INTO SF_INVENTORY (INVEN_ITEMCODE, INVEN_CNT)";
                mySql += "SELECT ";
                mySql += " '" + cboITEMCODE.SelectedValue.ToString() + "', ";
                mySql += " '" + txtCNT.Text.ToString() + "' ";
                mySql += "             FROM DUAL ";
                mySql += "             WHERE NOT EXISTS (SELECT * ";
                mySql += "                         FROM SF_INVENTORY ";
                mySql += "                         WHERE INVEN_ITEMCODE = '" + cboITEMCODE.SelectedValue.ToString() + "'); ";


                mySql += " UPDATE SF_INVENTORY2 ";
                mySql += " SET INVEN2_ITEMCODE = '" + cboROUT.SelectedValue.ToString() + "',  ";
                mySql += " INVEN2_CNT = INVEN2_CNT - '" + txtCNT.Text.ToString() + "'  ";
                mySql += " WHERE INVEN2_ITEMCODE = '" + cboROUT.SelectedValue.ToString() + "' ; ";

                mySql += " INSERT INTO SF_INVENTORY2 (INVEN2_ITEMCODE, INVEN2_CNT)";
                mySql += "SELECT ";
                mySql += " '" + cboROUT.SelectedValue.ToString() + "', ";
                mySql += " '" + txtCNT.Text.ToString() + "' ";
                mySql += "             FROM DUAL ";
                mySql += "             WHERE NOT EXISTS (SELECT * ";
                mySql += "                         FROM SF_INVENTORY2 ";
                mySql += "                         WHERE INVEN2_ITEMCODE = '" + cboROUT.SelectedValue.ToString() + "'); ";
    
                mySql += " END; ";
                 
                if (SF_Global.saveData(mySql))
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "확인 201");
                //MstbtnCancel();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            getData();
            Clear();
        }

        private void Clear()
        {

            dtSTDT.Value = DateTime.Now;
            dtENDDT.Value = DateTime.Now;
            cboITEMCODE.SelectedIndex = 0;
            cboSTD.SelectedIndex = 0;
            txtCNT.Text = "";
            cboROUT.SelectedIndex = 0;
            cboEMP.SelectedIndex = 0;
            chkQCRLT.Checked = false;
            txtQCCHK.Text = "";
            cboRCV.SelectedIndex = 0;
            txtSEQ.Text = "";
            cboFACTORY.SelectedIndex = 0;
            cboShip.SelectedIndex = 0;

        }
        private void Clear2()
        {

            dtSTDT2.Value = DateTime.Now;
            dtENDDT2.Value = DateTime.Now;

            cboITEMCODE2.SelectedIndex = 0;
            cboSTD2.SelectedIndex = 0;
            cboROUT2.SelectedIndex = 0;
            cboEMP2.SelectedIndex = 0;
        }
    }
}

        

