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
    public partial class frmSale : Form
    {
        public DataSet ds = new DataSet();
        private string[] aParam = null;
        private string mySql = "";

        public frmSale()
        {
            InitializeComponent();
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            getCode();
        }

        private void getCode()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DCODE2", typeof(string));
            dt.Columns.Add("DDESC2", typeof(string));

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '06' AND DUSEYN = 'True' AND DCODE2 < 7";

            dt = SF_Global.getDataTable(mySql);

            cboSale_ITEMCD.ValueMember = "DCODE2";
            cboSale_ITEMCD.DisplayMember = "DDESC2";
            cboSale_ITEMCD.DataSource = dt;
            cboSale_ITEMCD2.ValueMember = "DCODE2";
            cboSale_ITEMCD2.DisplayMember = "DDESC2";
            cboSale_ITEMCD2.DataSource = dt.Copy();
            dgSale_ITEMCD.ValueMember = "DCODE2";
            dgSale_ITEMCD.DisplayMember = "DDESC2";
            dgSale_ITEMCD.DataSource = dt.Copy();
            dgSale_ITEMCD2.ValueMember = "DCODE2";
            dgSale_ITEMCD2.DisplayMember = "DDESC2";
            dgSale_ITEMCD2.DataSource = dt.Copy();

            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '05' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);

            cboSale_CUST.ValueMember = "DCODE2";
            cboSale_CUST.DisplayMember = "DDESC2";
            cboSale_CUST.DataSource = dt;
            cboSale_CUST2.ValueMember = "DCODE2";
            cboSale_CUST2.DisplayMember = "DDESC2";
            cboSale_CUST2.DataSource = dt.Copy();
            dgSale_CUST2.ValueMember = "DCODE2";
            dgSale_CUST2.DisplayMember = "DDESC2";
            dgSale_CUST2.DataSource = dt.Copy();
            dgSale_CUST.ValueMember = "DCODE2";
            dgSale_CUST.DisplayMember = "DDESC2";
            dgSale_CUST.DataSource = dt.Copy();


            mySql = " SELECT NULL AS DCODE2, NULL AS DDESC2 FROM DUAL UNION ALL ";
            mySql += " SELECT DCODE2,DDESC2 FROM SF_CODE2 WHERE DCODE1 = '07' AND DUSEYN = 'True' ";

            dt = SF_Global.getDataTable(mySql);
            cboSale_SHIP.ValueMember = "DCODE2";
            cboSale_SHIP.DisplayMember = "DDESC2";
            cboSale_SHIP.DataSource = dt;
            dgSHIPPING.ValueMember = "DCODE2";
            dgSHIPPING.DisplayMember = "DDESC2";
            dgSHIPPING.DataSource = dt.Copy();
        }

        private string getSaleNo()
        {
            //구매발주 채번
            this.Cursor = Cursors.WaitCursor;
            string rtn = "";
            string SaleNo = DateTime.Now.ToString("yyyyMMdd");

            try
            {
                mySql = "";
                mySql += "SELECT MAX(Sale_NO) AS Sale_NO ";
                mySql += "  FROM HR.SF_Sale_M ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND Sale_NO LIKE '" + SaleNo + "%' ";

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
                            rtn = SaleNo + "-" + (seq + 1001).ToString().Substring(1, 3);
                        }
                    }
                }

                if (rtn == "")
                {
                    rtn = SaleNo + "-001";
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
                mySql += " SELECT DISTINCT M.Sale_NO,Sale_CUST,Sale_ORDATE,Sale_INDATE,Sale_REF,Sale_TEL,Sale_FAX,M.Sale_NOTE ";
                mySql += "  FROM HR.SF_Sale_M M , HR.SF_Sale_D D ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND M.Sale_NO = D.Sale_NO ";
                mySql += "   AND M.Sale_CUST LIKE '" + mstCust + "%' ";
                mySql += "   AND D.Sale_ITEMCD LIKE '" + mstItem + "%' ";
                mySql += "   AND M.Sale_ORDATE BETWEEN '" + ordDt + "' AND '" + inDt + "' ";
                mySql += " ORDER BY M.Sale_NO DESC ";

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
                mySql += " SELECT DISTINCT M.Sale_NO,Sale_CUST,Sale_ORDATE,Sale_INDATE,Sale_REF,Sale_TEL,Sale_FAX,M.Sale_NOTE ";
                mySql += "  FROM HR.SF_Sale_M M ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND M.Sale_CUST LIKE '" + mstCust + "%' ";
                mySql += "   AND M.Sale_ORDATE BETWEEN '" + ordDt + "' AND '" + inDt + "' ";
                mySql += " ORDER BY M.Sale_NO DESC ";

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
                mySql += "SELECT Sale_ITEMCD,Sale_CNT,Sale_PRICE,Sale_AMT,Sale_TAX,Sale_NOTE ";
                mySql += "  FROM HR.SF_Sale_D ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND Sale_NO = '" + mstCode + "' ";

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
                mySql += "SELECT Sale_ITEMCD,Sale_CNT,Sale_PRICE,Sale_AMT,Sale_TAX,Sale_NOTE,Sale_SHIPPING,Sale_NO ";
                mySql += "  FROM HR.SF_Sale_D ";
                mySql += " WHERE 1 = 1 ";
                mySql += "   AND Sale_NO = '" + mstCode + "' ";

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
                if (txtSale_NO.Text == "0")
                {
                    mySql += " INSERT INTO SF_SALE_M ( ";
                    mySql += "         SALE_NO,SALE_CUST,SALE_ORDATE,SALE_INDATE,SALE_REF,SALE_TEL,SALE_FAX,SALE_NOTE";
                    mySql += "     ) ";
                    mySql += "  VALUES ( ";
                    mySql += "                (SELECT NVL(MAX(Sale_NO), 0) + 1 FROM HR.SF_Sale_M ), ";
                    //mySql += "                '" + txtSale_NO.Text + "', ";
                    mySql += "                '" + cboSale_CUST.SelectedValue.ToString() + "', ";
                    mySql += "                '" + dtSale_ORDATE.Value.ToShortDateString() + "', ";
                    mySql += "                '" + dtSale_INDATE.Value.ToShortDateString() + "', ";
                    mySql += "                '" + txtSale_REF.Text.ToString() + "', ";
                    mySql += "                '" + txtSale_TEL.Text.ToString() + "', ";
                    mySql += "                '" + txtSale_FAX.Text.ToString() + "', ";
                    mySql += "                '" + txtSale_NOTE.Text.ToString() + "' ";
                    mySql += "          ); ";
                }
                else
                {
                    mySql += " UPDATE SF_Sale_M SET ";
                    mySql += "        Sale_ORDATE = '" + dtSale_ORDATE.Value.ToShortDateString() + "', ";
                    mySql += "        Sale_INDATE = '" + dtSale_INDATE.Value.ToShortDateString() + "', ";
                    mySql += "        Sale_REF = '" + txtSale_REF.Text.ToString() + "', ";
                    mySql += "        Sale_TEL = '" + txtSale_TEL.Text.ToString() + "', ";
                    mySql += "        Sale_FAX = '" + txtSale_FAX.Text.ToString() + "', ";
                    mySql += "        Sale_NOTE = '" + txtSale_NOTE.Text.ToString() + "' ";
                    mySql += "   WHERE Sale_NO = '" + txtSale_NO.Text + "'; ";
                }

                mySql += "  DELETE SF_Sale_D ";
                if (txtSale_NO.Text == "0")
                {
                    mySql += "   WHERE Sale_NO = (SELECT MAX(Sale_NO) FROM HR.SF_Sale_M ); ";
                }
                else
                {
                    mySql += "   WHERE Sale_NO = '" + txtSale_NO.Text + "'; ";
                }
                //mySql += "   WHERE Sale_NO = '" + txtSale_NO.Text + "'; ";

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    mySql += " INSERT INTO SF_Sale_D ( ";
                    mySql += "         Sale_NO,Sale_ITEMCD,Sale_CNT,Sale_PRICE,Sale_AMT,Sale_TAX,Sale_NOTE,Sale_SHIPPING";
                    mySql += "     ) ";
                    mySql += "  VALUES ( ";
                    if (txtSale_NO.Text == "0")
                    {
                        mySql += "                (SELECT MAX(Sale_NO) FROM HR.SF_Sale_M ), ";
                    }
                    else
                    {
                        mySql += "                '" + txtSale_NO.Text.ToString() + "', ";
                    }
                    mySql += "                '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[1].Value.ToString().Replace(",", "") + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[2].Value.ToString().Replace(",", "") + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[3].Value.ToString().Replace(",", "") + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[4].Value.ToString().Replace(",", "") + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "' ";
                    mySql += "          ); ";
                
         
                    mySql += "INSERT INTO SF_INVENTORY (INVEN_ITEMCODE, INVEN_CNT)";
                    mySql += "SELECT ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "', ";
                    mySql += "                '" + dataGridView1.Rows[i].Cells[1].Value.ToString().Replace(",", "") + "' ";
                    mySql += "  FROM DUAL ";
                    mySql += "  WHERE NOT EXISTS (SELECT * ";
                    mySql += "  FROM SF_INVENTORY ";
                    mySql += "  WHERE INVEN_ITEMCODE = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'); ";

                    mySql += " UPDATE SF_INVENTORY ";
                    mySql += " SET INVEN_ITEMCODE = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "',  ";
                    mySql += " INVEN_CNT = INVEN_CNT - '" + dataGridView1.Rows[i].Cells[1].Value.ToString().Replace(",", "") + "' ";
                    mySql += " WHERE INVEN_ITEMCODE = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' ; ";
                    
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
            dtSale_ORDATE.Value = DateTime.Now;
            dtSale_INDATE.Value = DateTime.Now;
            cboSale_CUST.SelectedIndex = 0;
            txtSale_NO.Text = "";
            txtSale_REF.Text = "";
            txtSale_TEL.Text = "";
            txtSale_FAX.Text = "";
            txtSale_NOTE.Text = "";
        }

        private void clearDtl()
        {
            cboSale_ITEMCD.SelectedIndex = 0;
            txtSale_CNT.Text = "0";
            txtSale_PRICE.Text = "0";
            txtSale_AMT.Text = "0";
            txtSale_TAX.Text = "0";
            txtSale_NOTE2.Text = "";
        }

        private void txtChanged()
        {
            int cnt = 0, price = 0;
            if (txtSale_CNT.Text == "" || txtSale_CNT.Text == "0")
            {
                return;
            }
            if (txtSale_PRICE.Text == "" || txtSale_PRICE.Text == "0")
            {
                return;
            }

            cnt = Convert.ToInt32(txtSale_CNT.Text.Replace(",", ""));
            price = Convert.ToInt32(txtSale_PRICE.Text.Replace(",", ""));
            txtSale_AMT.Text = String.Format("{0:#,##0}", Convert.ToDouble(cnt * price));
            txtSale_TAX.Text = String.Format("{0:#,###}", Convert.ToDouble(cnt * price / 10));
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

            txtSale_NO.Text = "0";// getSaleNo();
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
            if (cboSale_CUST.SelectedIndex <= 0)
            {
                MessageBox.Show("거래처를 선택하세요.", "거래처 입력 오류");
                cboSale_CUST.Focus();
                return;
            }
            if (cboSale_ITEMCD.SelectedIndex <= 0)
            {
                cboSale_ITEMCD.Focus();
                MessageBox.Show("품목을 선택하세요.", "품목 입력 오류");
                return;
            }
            if (txtSale_CNT.Text == "" || txtSale_CNT.Text == "0")
            {
                MessageBox.Show("수량을 입력하세요.", "수량 입력 오류");
                txtSale_CNT.Focus();
                return;
            }
            if (txtSale_PRICE.Text == "" || txtSale_PRICE.Text == "0")
            {
                MessageBox.Show("가격을 입력하세요.", "가격 입력 오류");
                txtSale_PRICE.Focus();
                return;

            }
            if (cboSale_SHIP.SelectedIndex <= 0)
            {
                MessageBox.Show("출고여부를 선택하세요.", "출고 입력 오류");
                cboSale_SHIP.Focus();
                return;
            }

                //Check Item
                bool chk = false;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string str = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (cboSale_ITEMCD.SelectedValue.ToString() == str)
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

                
                newRow[0] = cboSale_ITEMCD.SelectedValue.ToString();
                newRow[1] = txtSale_CNT.Text;
                newRow[2] = txtSale_PRICE.Text;
                newRow[3] = txtSale_AMT.Text;
                newRow[4] = txtSale_TAX.Text;
                newRow[5] = txtSale_NOTE2.Text;
                newRow[6] = cboSale_SHIP.SelectedValue.ToString();
                newRow[7] = txtSale_NO.Text;
                dt.Rows.Add(newRow);

                dataGridView1.DataSource = dt;

                //dataGridView1.Rows.Add(cboSale_ITEMCD.SelectedValue.ToString(),
                //                        txtSale_CNT.Text,
                //                        txtSale_PRICE.Text,
                //                        txtSale_AMT.Text,
                //                        txtSale_TAX.Text,
                //                        txtSale_NOTE2.Text);
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
            getMst(cboSale_CUST.SelectedValue.ToString(), dtSale_ORDATE.Value.ToShortDateString(), dtSale_INDATE.Value.ToShortDateString());
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
            getMst(cboSale_ITEMCD2.SelectedValue.ToString(),
                    cboSale_CUST2.SelectedValue.ToString(),
                    dtSale_ORDATE2.Value.ToShortDateString(),
                    dtSale_INDATE2.Value.ToShortDateString());
        }

        private void txtSale_CNT_TextChanged(object sender, EventArgs e)
        {
            txtChanged();
            txtSale_CNT.Text = String.Format("{0:#,##0}", Convert.ToDouble(txtSale_CNT.Text.Replace(",", "")));
            txtSale_CNT.SelectionStart = txtSale_CNT.TextLength; //** 캐럿을 맨 뒤로 보낸다...
            txtSale_CNT.SelectionLength = 0;
        }

        private void txtSale_PRICE_TextChanged(object sender, EventArgs e)
        {
            txtChanged();
            txtSale_PRICE.Text = String.Format("{0:#,##0}", Convert.ToDouble(txtSale_PRICE.Text.Replace(",", "")));
            txtSale_PRICE.SelectionStart = txtSale_PRICE.TextLength; //** 캐럿을 맨 뒤로 보낸다...
            txtSale_PRICE.SelectionLength = 0;
        }

        private void txtSale_CNT_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSale_CNT.Text))
            {
                txtSale_CNT.SelectionStart = 0;
                txtSale_CNT.SelectionLength = txtSale_CNT.Text.Length;
            }
        }

        private void txtSale_PRICE_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSale_PRICE.Text))
            {
                txtSale_PRICE.SelectionStart = 0;
                txtSale_PRICE.SelectionLength = txtSale_PRICE.Text.Length;
            }
        }

        private void txtSale_CNT_MouseClick(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSale_CNT.Text))
            {
                txtSale_CNT.SelectionStart = 0;
                txtSale_CNT.SelectionLength = txtSale_CNT.Text.Length;
            }
        }

        private void txtSale_PRICE_MouseClick(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSale_PRICE.Text))
            {
                txtSale_PRICE.SelectionStart = 0;
                txtSale_PRICE.SelectionLength = txtSale_PRICE.Text.Length;
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
                txtSale_NO.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                cboSale_CUST.SelectedValue = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                dtSale_ORDATE.Value = Convert.ToDateTime(dataGridView4.CurrentRow.Cells[2].Value.ToString());
                dtSale_INDATE.Value = Convert.ToDateTime(dataGridView4.CurrentRow.Cells[3].Value.ToString());
                txtSale_REF.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
                txtSale_TEL.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
                txtSale_FAX.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
                txtSale_NOTE.Text = dataGridView4.CurrentRow.Cells[7].Value.ToString();

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
            cboSale_ITEMCD.SelectedValue = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtSale_CNT.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSale_PRICE.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSale_AMT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSale_TAX.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSale_NOTE2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cboSale_SHIP.SelectedValue = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
