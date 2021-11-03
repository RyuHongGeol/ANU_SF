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

namespace ANU_SF
{
    public partial class frmSupp : Form
    {
        public DataSet ds = new DataSet();
        private string[] aParam = null;
        private string mySql = "";

        public frmSupp()
        {
            InitializeComponent();
        }

        private void frmSupp_Load(object sender, EventArgs e)
        {
            getCode();
        }

        private void getCode()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DCODE2", typeof(string));
            dt.Columns.Add("DDESC2", typeof(string));

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '01' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboSUPP_ITEMCD.ValueMember = "DCODE2";
            cboSUPP_ITEMCD.DisplayMember = "DDESC2";
            cboSUPP_ITEMCD.DataSource = dt;
            cboSUPP_ITEMCD2.ValueMember = "DCODE2";
            cboSUPP_ITEMCD2.DisplayMember = "DDESC2";
            cboSUPP_ITEMCD2.DataSource = dt.Copy();
            dgSUPP_ITEMCD.ValueMember = "DCODE2";
            dgSUPP_ITEMCD.DisplayMember = "DDESC2";
            dgSUPP_ITEMCD.DataSource = dt.Copy();
            dgSUPP_ITEMCD2.ValueMember = "DCODE2";
            dgSUPP_ITEMCD2.DisplayMember = "DDESC2";
            dgSUPP_ITEMCD2.DataSource = dt.Copy();

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '05' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboSUPP_CUST.ValueMember = "DCODE2";
            cboSUPP_CUST.DisplayMember = "DDESC2";
            cboSUPP_CUST.DataSource = dt;
            cboSUPP_CUST2.ValueMember = "DCODE2";
            cboSUPP_CUST2.DisplayMember = "DDESC2";
            cboSUPP_CUST2.DataSource = dt.Copy();
            dgSUPP_CUST2.ValueMember = "DCODE2";
            dgSUPP_CUST2.DisplayMember = "DDESC2";
            dgSUPP_CUST2.DataSource = dt.Copy();
            dgSUPP_CUST.ValueMember = "DCODE2";
            dgSUPP_CUST.DisplayMember = "DDESC2";
            dgSUPP_CUST.DataSource = dt.Copy();

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '07' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);
            cboSUPP_RCV.ValueMember = "DCODE2";
            cboSUPP_RCV.DisplayMember = "DDESC2";
            cboSUPP_RCV.DataSource = dt;
            dgSUPP_RCV.ValueMember = "DCODE2";
            dgSUPP_RCV.DisplayMember = "DDESC2";
            dgSUPP_RCV.DataSource = dt.Copy();




        }

        private string getSuppNo()
        {
            //구매발주 채번
            this.Cursor = Cursors.WaitCursor;
            string rtn = "";
            string suppNo = DateTime.Now.ToString("yyyyMMdd");

            try
            {
                mySql = "";
                mySql += "SELECT MAX(SUPP_NO) AS SUPP_NO ";
                mySql += "  FROM HR.SF_SUPP_M ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND SUPP_NO LIKE '" + suppNo + "%' ";

                aParam = new string[] { "", "", "" };
                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                if (oraDS != null && oraDS.Tables.Count > 0)
                {
                    if (oraDS.Tables[0].Rows.Count > 0)
                    {
                        string s = oraDS.Tables[0].Rows[0][0].ToString();
                        if (s != "")
                        {
                            string[] words = s.Split('-');
                            int seq = Convert.ToInt16(words[1]);
                            rtn = suppNo + "-" + (seq + 1001).ToString().Substring(1, 3);
                        }
                    }
                }

                if (rtn == "")
                {
                    rtn = suppNo + "-001";
                }

                this.Cursor = Cursors.Default;
                return rtn;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 121");
                return rtn;
            }

        }

        private void getMst(string mstItem, string mstCust, string ordDt, string inDt)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT DISTINCT M.SUPP_NO,SUPP_CUST,SUPP_ORDATE,SUPP_INDATE,SUPP_REF,SUPP_TEL,SUPP_FAX,M.SUPP_NOTE ";
                mySql += "  FROM HR.SF_SUPP_M M , HR.SF_SUPP_D D ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND M.SUPP_NO = D.SUPP_NO ";
                mySql += "   AND M.SUPP_CUST LIKE '" + mstCust + "%' ";
                mySql += "   AND D.SUPP_ITEMCD LIKE '" + mstItem + "%' ";
                mySql += "   AND M.SUPP_ORDATE BETWEEN '" + ordDt + "' AND '" + inDt + "' ";
                mySql += " ORDER BY M.SUPP_NO DESC ";

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
                    SF_Global.dgvSort(dataGridView2);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 144");
            }

        }

        private void getMst(string mstCust, string ordDt, string inDt)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT DISTINCT M.SUPP_NO,SUPP_CUST,SUPP_ORDATE,SUPP_INDATE,SUPP_REF,SUPP_TEL,SUPP_FAX,M.SUPP_NOTE ";
                mySql += "  FROM HR.SF_SUPP_M M ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND M.SUPP_CUST LIKE '" + mstCust + "%' ";
                mySql += "   AND M.SUPP_ORDATE BETWEEN '" + ordDt + "' AND '" + inDt + "' ";
                mySql += " ORDER BY M.SUPP_NO DESC ";

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
                    SF_Global.dgvSort(dataGridView4);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 144");
            }

        }

        private void getDtl(string mstCode)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += "SELECT SUPP_ITEMCD,SUPP_CNT,SUPP_PRICE,SUPP_AMT,SUPP_TAX,SUPP_NOTE ";
                mySql += "  FROM HR.SF_SUPP_D ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND SUPP_NO = '" + mstCode + "' ";

                aParam = new string[] { "", "", "" };
                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                //dataGridView3.DataSource = null;
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

        private void getDtlM(string mstCode)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += "SELECT SUPP_ITEMCD,SUPP_CNT,SUPP_PRICE,SUPP_AMT,SUPP_TAX,SUPP_NOTE,SUPP_RCV,SUPP_NO ";
                mySql += "  FROM HR.SF_SUPP_D ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND SUPP_NO = '" + mstCode + "' ";

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

                this.Cursor = Cursors.Default;
            }

            
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 251");
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
                if (txtSUPP_NO.Text == "0")
                {
                    mySql += " INSERT INTO SF_SUPP_M ( ";
                    mySql += "         SUPP_NO,SUPP_CUST,SUPP_ORDATE,SUPP_INDATE,SUPP_REF,SUPP_TEL,SUPP_FAX,SUPP_NOTE";
                    mySql += "     ) ";
                    mySql += "  VALUES ( ";
                    mySql += "                (SELECT NVL(MAX(SUPP_NO), 0) + 1 FROM HR.SF_SUPP_M ), ";
                    //mySql += "                '" + txtSUPP_NO.Text + "', ";
                    mySql += "                '" + cboSUPP_CUST.SelectedValue.ToString() + "', ";
                    mySql += "                '" + dtSUPP_ORDATE.Value.ToShortDateString() + "', ";
                    mySql += "                '" + dtSUPP_INDATE.Value.ToShortDateString() + "', ";
                    mySql += "                '" + txtSUPP_REF.Text.ToString() + "', ";
                    mySql += "                '" + txtSUPP_TEL.Text.ToString() + "', ";
                    mySql += "                '" + txtSUPP_FAX.Text.ToString() + "', ";
                    mySql += "                '" + txtSUPP_NOTE.Text.ToString() + "' ";
                    mySql += "          ); ";
                }
                else
                {
                    mySql += " UPDATE SF_SUPP_M SET ";
                    mySql += "        SUPP_ORDATE = '" + dtSUPP_ORDATE.Value.ToShortDateString() + "', ";
                    mySql += "        SUPP_INDATE = '" + dtSUPP_INDATE.Value.ToShortDateString() + "', ";
                    mySql += "        SUPP_REF = '" + txtSUPP_REF.Text.ToString() + "', ";
                    mySql += "        SUPP_TEL = '" + txtSUPP_TEL.Text.ToString() + "', ";
                    mySql += "        SUPP_FAX = '" + txtSUPP_FAX.Text.ToString() + "', ";
                    mySql += "        SUPP_NOTE = '" + txtSUPP_NOTE.Text.ToString() + "' ";
                    mySql += "   WHERE SUPP_NO = '" + txtSUPP_NO.Text + "'; ";
                }

                mySql += "  DELETE SF_SUPP_D ";
                if (txtSUPP_NO.Text == "0")
                {
                    mySql += "   WHERE SUPP_NO = (SELECT MAX(SUPP_NO) FROM HR.SF_SUPP_M ); ";
                }
                else
                {
                    mySql += "   WHERE SUPP_NO = '" + txtSUPP_NO.Text + "'; ";
                }
                //mySql += "   WHERE SUPP_NO = '" + txtSUPP_NO.Text + "'; ";

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    mySql += " INSERT INTO SF_SUPP_D ( ";
                    mySql += "        SUPP_NO, SUPP_ITEMCD,SUPP_CNT,SUPP_PRICE,SUPP_AMT,SUPP_TAX,SUPP_NOTE,SUPP_RCV";
                    mySql += "     ) ";
                    mySql += "  VALUES ( ";
                    if (txtSUPP_NO.Text == "0")
                    {
                        mySql += "                (SELECT MAX(SUPP_NO) FROM HR.SF_SUPP_M ), ";
                    }
                    else
                    {
                        mySql += "                '" + txtSUPP_NO.Text.ToString() + "', ";
                    }
                    mySql += "                '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[1].Value.ToString().Replace(",", "") + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[2].Value.ToString().Replace(",", "") + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[3].Value.ToString().Replace(",", "") + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[4].Value.ToString().Replace(",", "") + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "' ";
                    mySql += "          ); ";

                    mySql += "INSERT INTO SF_INVENTORY2 (INVEN2_ITEMCODE, INVEN2_CNT)";
                    mySql += "SELECT ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[1].Value.ToString().Replace(",", "") + "' ";
                    mySql += "  FROM DUAL ";
                    mySql += "  WHERE NOT EXISTS (SELECT * ";
                    mySql += "  FROM SF_INVENTORY2 ";
                    mySql += "  WHERE INVEN2_ITEMCODE = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'); ";

                    mySql += " UPDATE SF_INVENTORY2 ";
                    mySql += " SET INVEN2_ITEMCODE = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "',  ";
                    mySql += " INVEN2_CNT = INVEN2_CNT + '" + dataGridView1.Rows[i].Cells[1].Value.ToString().Replace(",", "") + "' ";
                    mySql += " WHERE INVEN2_ITEMCODE = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' ; ";
                }
                mySql += " END; ";

                if (SF_Global.saveData(mySql))
                {
                    clearMst();
                    clearDtl();
                }

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

        }

        private void clearMst()
        {
            dtSUPP_ORDATE.Value = DateTime.Now;
            dtSUPP_INDATE.Value = DateTime.Now;
            cboSUPP_CUST.SelectedIndex = 0;
            txtSUPP_NO.Text = "";
            txtSUPP_REF.Text = "";
            txtSUPP_TEL.Text = "";
            txtSUPP_FAX.Text = "";
            txtSUPP_NOTE.Text = "";
        }

        private void clearDtl()
        {
            cboSUPP_ITEMCD.SelectedIndex = 0;
            txtSUPP_CNT.Text = "0";
            txtSUPP_PRICE.Text = "0";
            txtSUPP_AMT.Text = "0";
            txtSUPP_TAX.Text = "0";
            txtSUPP_NOTE2.Text = "";
        }

        private void txtChanged()
        {
            int cnt = 0, price = 0;
            if (txtSUPP_CNT.Text == "" || txtSUPP_CNT.Text == "0")
            {
                return;
            }
            if (txtSUPP_PRICE.Text == "" || txtSUPP_PRICE.Text == "0")
            {
                return;
            }

            cnt = Convert.ToInt32(txtSUPP_CNT.Text.Replace(",", ""));
            price = Convert.ToInt32(txtSUPP_PRICE.Text.Replace(",", ""));
            txtSUPP_AMT.Text = String.Format("{0:#,##0}", Convert.ToDouble(cnt * price));
            txtSUPP_TAX.Text = String.Format("{0:#,###}", Convert.ToDouble(cnt * price / 10));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearMst();
            clearDtl();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = (dataGridView1.Rows.Count - 1); i >= 0; i--)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }

            txtSUPP_NO.Text = "0";// getSuppNo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = (dataGridView1.Rows.Count - 1); i >= 0; i--)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
        }

        private void btnAdddRow_Click(object sender, EventArgs e)
        {
            if (cboSUPP_CUST.SelectedIndex <= 0)
            {
                MessageBox.Show("거래처를 선택하세요.", "거래처 입력 오류");
                cboSUPP_CUST.Focus();
                return;
            }
            if (cboSUPP_ITEMCD.SelectedIndex <= 0)
            {
                cboSUPP_ITEMCD.Focus();
                MessageBox.Show("품목을 선택하세요.", "품목 입력 오류");
                return;
            }
            if (txtSUPP_CNT.Text == "" || txtSUPP_CNT.Text == "0")
            {
                MessageBox.Show("수량을 입력하세요.", "수량 입력 오류");
                txtSUPP_CNT.Focus();
                return;
            }
            if (txtSUPP_PRICE.Text == "" || txtSUPP_PRICE.Text == "0")
            {
                MessageBox.Show("가격을 입력하세요.", "가격 입력 오류");
                txtSUPP_PRICE.Focus();
                return;
            }
            if (cboSUPP_RCV.SelectedIndex <= 0)
            {
                cboSUPP_RCV.Focus();
                MessageBox.Show("품목을 선택하세요.", "품목 입력 오류");
                return;
            }


            //Check Item
            bool chk = false;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string str = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (cboSUPP_ITEMCD.SelectedValue.ToString() == str)
                    {
                        chk = true;
                        break;
                    }
                }
            }

            if (!chk)
            {
                DataTable dt = (DataTable)(dataGridView1.DataSource);
                DataRow newRow = dt.NewRow();

                newRow[7] = txtSUPP_NO.Text;
                newRow[0] = cboSUPP_ITEMCD.SelectedValue.ToString();
                newRow[1] = txtSUPP_CNT.Text;
                newRow[2] = txtSUPP_PRICE.Text;
                newRow[3] = txtSUPP_AMT.Text;
                newRow[4] = txtSUPP_TAX.Text;
                newRow[5] = txtSUPP_NOTE2.Text;
                newRow[6] = cboSUPP_RCV.SelectedValue.ToString();
                dt.Rows.Add(newRow);

                dataGridView1.DataSource = dt;

                //dataGridView1.Rows.Add(cboSUPP_ITEMCD.SelectedValue.ToString(),
                //                        txtSUPP_CNT.Text,
                //                        txtSUPP_PRICE.Text,
                //                        txtSUPP_AMT.Text,
                //                        txtSUPP_TAX.Text,
                //                        txtSUPP_NOTE2.Text);
                clearDtl();
            }
            else
            {
                MessageBox.Show("이미 등록된 품목입니다.", "행 추가 에러");
            }

        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getMst(cboSUPP_CUST.SelectedValue.ToString(), dtSUPP_ORDATE.Value.ToShortDateString(), dtSUPP_INDATE.Value.ToShortDateString());
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                for (int i = (dataGridView3.Rows.Count - 1); i >= 0; i--)
                {
                    dataGridView3.Rows.RemoveAt(i);
                }
            }
            getMst(cboSUPP_ITEMCD2.SelectedValue.ToString(),
                    cboSUPP_CUST2.SelectedValue.ToString(),
                    dtSUPP_ORDATE2.Value.ToShortDateString(),
                    dtSUPP_INDATE2.Value.ToShortDateString());
        }

        private void txtSUPP_CNT_TextChanged(object sender, EventArgs e)
        {
            txtChanged();
            txtSUPP_CNT.Text = String.Format("{0:#,##0}", Convert.ToDouble(txtSUPP_CNT.Text.Replace(",", "")));
            txtSUPP_CNT.SelectionStart = txtSUPP_CNT.TextLength; //** 캐럿을 맨 뒤로 보낸다...
            txtSUPP_CNT.SelectionLength = 0;
        }

        private void txtSUPP_PRICE_TextChanged(object sender, EventArgs e)
        {
            txtChanged();
            txtSUPP_PRICE.Text = String.Format("{0:#,##0}", Convert.ToDouble(txtSUPP_PRICE.Text.Replace(",", "")));
            txtSUPP_PRICE.SelectionStart = txtSUPP_PRICE.TextLength; //** 캐럿을 맨 뒤로 보낸다...
            txtSUPP_PRICE.SelectionLength = 0;
        }

        private void txtSUPP_CNT_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSUPP_CNT.Text))
            {
                txtSUPP_CNT.SelectionStart = 0;
                txtSUPP_CNT.SelectionLength = txtSUPP_CNT.Text.Length;
            }
        }

        private void txtSUPP_PRICE_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSUPP_PRICE.Text))
            {
                txtSUPP_PRICE.SelectionStart = 0;
                txtSUPP_PRICE.SelectionLength = txtSUPP_PRICE.Text.Length;
            }
        }

        private void txtSUPP_CNT_MouseClick(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSUPP_CNT.Text))
            {
                txtSUPP_CNT.SelectionStart = 0;
                txtSUPP_CNT.SelectionLength = txtSUPP_CNT.Text.Length;
            }
        }

        private void txtSUPP_PRICE_MouseClick(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSUPP_PRICE.Text))
            {
                txtSUPP_PRICE.SelectionStart = 0;
                txtSUPP_PRICE.SelectionLength = txtSUPP_PRICE.Text.Length;
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                getDtl(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
            {
                txtSUPP_NO.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                cboSUPP_CUST.SelectedValue = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                dtSUPP_ORDATE.Value = Convert.ToDateTime(dataGridView4.CurrentRow.Cells[2].Value.ToString());
                dtSUPP_INDATE.Value = Convert.ToDateTime(dataGridView4.CurrentRow.Cells[3].Value.ToString());
                txtSUPP_REF.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
                txtSUPP_TEL.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
                txtSUPP_FAX.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
                txtSUPP_NOTE.Text = dataGridView4.CurrentRow.Cells[7].Value.ToString();

                getDtlM(dataGridView4.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            SF_Global.dgvSort(dataGridView1);
        }

        private void dataGridView2_Sorted(object sender, EventArgs e)
        {
            SF_Global.dgvSort(dataGridView2);
        }

        private void dataGridView3_Sorted(object sender, EventArgs e)
        {
            SF_Global.dgvSort(dataGridView4);
        }

        private void dataGridView4_Sorted(object sender, EventArgs e)
        {
            SF_Global.dgvSort(dataGridView4);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                cboSUPP_ITEMCD.SelectedValue = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtSUPP_CNT.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSUPP_PRICE.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtSUPP_AMT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtSUPP_TAX.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtSUPP_NOTE2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                cboSUPP_RCV.SelectedValue = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }
    }
}
