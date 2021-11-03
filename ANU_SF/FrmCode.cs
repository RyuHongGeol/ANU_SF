using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ANU_SF
{
    public partial class FrmCode : Form
    {
        public DataSet ds = new DataSet();
        private string[] aParam = null;
        private string mySql = "";

        public FrmCode()
        {
            InitializeComponent();
        }

        private void FrmCode_Load(object sender, EventArgs e)
        {
            DtlbtnCancel();
        }

        #region MyRegion
        private void Data_Mst_Select()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT MCODE1, ";
                mySql += "        MDESC1, ";
                mySql += "        MUSEYN, ";
                mySql += "        MNOTE ";
                mySql += "   FROM SF_CODE1 ";

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
                    panel1.Enabled = true;

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

        private void Data_Mst_Check()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT MCODE1, ";
                mySql += "        MDESC1, ";
                mySql += "        MUSEYN, ";
                mySql += "        MNOTE ";
                mySql += "   FROM SF_CODE1 ";
                mySql += "WHERE MCODE1 = '"+txt_mCode1.Text+"';";
                
                aParam = new string[] { "", "", "" };

                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                //dataGridView1.DataSource = null;
                if (oraDS != null && dataGridView1.Rows.Count > 0)
                {
                    if (MessageBox.Show("수정하시겠습니까?", "Exist Data", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Data_Mst_Update();
                    }

                }
                else
                {
                    Data_Mst_Save();
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

        private void Data_Mst_Save()
        {
            if (txt_mCode1.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 155");
                return;
            }
            if (txt_mDesc1.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 160");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                mySql = "";
                mySql += " INSERT INTO SF_CODE1 (MCODE1, MDESC1 , MNOTE, MUSEYN) ";
                mySql += " VALUES(";
                mySql += "'" + txt_mCode1.Text + "', ";
                mySql += "'" + txt_mDesc1.Text + "', ";
                mySql += "'" + txt_mNote.Text + "', ";
                mySql += "'" + chk_mUseYN.Checked.ToString() + "' ";
                mySql += ");";
                //mySql += "  UPDATE SF_CODE1 ";
                //mySql += "     SET MDESC1 = '" + txt_mDesc1.Text + "', MNOTE = '" + txt_mNote.Text + "', MUSEYN = '" + chk_mUseYN.Checked.ToString() + "' ";
                //mySql += "   WHERE MCODE1 = '" + txt_mCode1.Text + "'; ";
                //mySql += " END; ";

                //if (SF_Global.saveData(mySql))
                //{
                //    mySql = "";
                //    mySql += "  UPDATE SF_CODE1 ";
                //    mySql += "     SET MDESC1 = '" + txt_mDesc1.Text + "', MNOTE = '" + txt_mNote.Text + "', MUSEYN = '" + chk_mUseYN.Checked.ToString() + "' ";
                //    mySql += "   WHERE MCODE1 = '" + txt_mCode1.Text + "'; ";
                //    SF_Global.saveData(mySql);
                //}
                SF_Global.saveData(mySql);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "확인 201");
                //MstbtnCancel();
            }

            Data_Mst_Select();
        }

        private void Data_Mst_Update()
        {
            mySql = "";
            mySql += "  UPDATE SF_CODE1 ";
            mySql += "     SET MDESC1 = '" + txt_mDesc1.Text + "', MNOTE = '" + txt_mNote.Text + "', MUSEYN = '" + chk_mUseYN.Checked.ToString() + "' ";
            mySql += "   WHERE MCODE1 = '" + txt_mCode1.Text + "'; ";
            SF_Global.saveData(mySql);

            this.Cursor = Cursors.Default;
        }

        private void Data_Mst_Delete()
        {
            if (txt_mCode1.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 423");
                return;
            }

            if (MessageBox.Show("입력하신 내용이 삭제 됩니다.\r계속 하시겠습니까?", "삭제 - 435", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                mySql = "";
                mySql += " DELETE FROM SF_CODE1 ";
                mySql += "  WHERE MCODE1 = '" + txt_mCode1.Text + "' ";

                if (SF_Global.saveData(mySql))
                {
                    MessageBox.Show("삭제되었습니다.", "확인 - 469");
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "확인 473");
            }

            Data_Mst_Select();
        }

        private void Data_Dtl_Select()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                mySql = "";
                mySql += " SELECT DCODE2, ";
                mySql += "        DDESC2, ";
                mySql += "        DUSEYN, ";
                mySql += "        DNOTE ";
                mySql += "   FROM SF_CODE2 ";
                mySql += "  WHERE DCODE1 = '" + txt_mCode1.Text.Trim() + "'  ";

                aParam = new string[] { "", "", "" };

                DataSet oraDS = SF_Global.getDataSet(aParam, mySql);

                //dataGridView2.DataSource = null;
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
                    panel2.Enabled = true;

                    SF_Global.dgvSort(dataGridView2);
                }
                else
                {
                    MessageBox.Show("No Data", "확인 - 276");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "확인 - 282");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Data_Dtl_Save()
        {
            if (txt_mCode1.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 294");
                return;
            }
            if (txt_mDesc1.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 299");
                return;
            }
            if (txt_dDesc2.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 304");
                return;
            }
            if (txt_dDesc2.Text == "")
            {
                MessageBox.Show("입력 오류", "확인 - 309");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                mySql = "";
                mySql += " BEGIN ";
                mySql += " INSERT INTO SF_CODE2 ( ";
                mySql += "         DCODE1, DCODE2, DDESC2 , DNOTE, DUSEYN";
                mySql += "     ) ";
                mySql += "         SELECT '" + txt_mCode1.Text + "', ";
                mySql += "                '" + txt_dCode2.Text + "', ";
                mySql += "                '" + txt_dDesc2.Text + "', ";
                mySql += "                '" + txt_dNote.Text + "', ";
                mySql += "                '" + chk_dUseYN.Checked.ToString() + "' ";
                mySql += "             FROM DUAL ";
                mySql += "             WHERE NOT EXISTS (SELECT * ";
                mySql += "                         FROM SF_CODE2 ";
                mySql += "                         WHERE DCODE1 = '" + txt_mCode1.Text + "' AND DCODE2 = '" + txt_dCode2.Text + "'); ";

                mySql += "  UPDATE SF_CODE2 ";
                mySql += "     SET DDESC2 = '" + txt_dDesc2.Text + "', DNOTE = '" + txt_dNote.Text + "', DUSEYN = '" + chk_dUseYN.Checked.ToString() + "' ";
                mySql += "   WHERE DCODE1 = '" + txt_mCode1.Text + "' AND DCODE2 = '" + txt_dCode2.Text + "'; ";
                mySql += " END; ";


                if (SF_Global.saveData(mySql))
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "확인 351");
            }

            Data_Dtl_Select();
        }

        #endregion

        private void Loadbtn()
        {
            btnSearch.Enabled = true;
            btnAdd.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;

            panel1.Enabled = false;
            panel2.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
        }

        private void MstbtnSearch()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }

            btnEdit.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void MstbtnAdd()
        {
            panel1.Enabled = false;
            panel2.Enabled = false;

            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;

            btnSearch.Enabled = false;
            btnAdd.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            txt_mCode1.Enabled = true;
            txt_mCode1.Focus();
        }

        private void MstbtnEdit()
        {
            panel1.Enabled = false;
            panel2.Enabled = false;

            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;

            btnSearch.Enabled = false;
            btnAdd.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            txt_mCode1.Enabled = false;
            txt_mDesc1.Focus();
        }

        private void MstbtnEnableEdit()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                groupBox3.Enabled = true;
                btnEdit.Enabled = true;
                btn_dAdd.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btn_dAdd.Enabled = false;
            }
            btn_dEdit.Enabled = false;
            btn_dCancel.Enabled = false;
            btn_dSave.Enabled = false;
        }

        private void MstbtnCancel()
        {
            panel1.Enabled = true;
            panel2.Enabled = false;

            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;

            btnSearch.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }

        private void MstbtnSave()
        {

        }

        private void MstTextClear()
        {
            txt_mCode1.Text = "";
            txt_mDesc1.Text = "";
            chk_mUseYN.Checked = true;
            txt_mNote.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Data_Mst_Select();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MstbtnAdd();
            MstTextClear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MstbtnEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MstbtnCancel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Data_Mst_Save();
            Data_Mst_Check();
            MstbtnCancel();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            DtlTextClear();

            if (dataGridView1.Rows.Count > 0)
            {
                MstbtnEnableEdit();

                txt_mCode1.Text = dataGridView1.CurrentRow.Cells["mCode1"].Value.ToString();
                txt_mDesc1.Text = dataGridView1.CurrentRow.Cells["mDesc1"].Value.ToString();
                chk_mUseYN.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["mUseYN"].Value);
                txt_mNote.Text = dataGridView1.CurrentRow.Cells["mNote"].Value.ToString();

                Data_Dtl_Select();
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            SF_Global.dgvSort(dataGridView1);
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                txt_dCode2.Text = dataGridView2.CurrentRow.Cells["dCode2"].Value.ToString();
                txt_dDesc2.Text = dataGridView2.CurrentRow.Cells["dDesc2"].Value.ToString();
                chk_dUseYN.Checked = Convert.ToBoolean(dataGridView2.CurrentRow.Cells["dUseYN"].Value);
                txt_dNote.Text = dataGridView2.CurrentRow.Cells["dNote"].Value.ToString();

                DtlbtnEdit();
            }
        }

        private void dataGridView2_Sorted(object sender, EventArgs e)
        {
            SF_Global.dgvSort(dataGridView2);
        }

        private void btn_dAdd_Click(object sender, EventArgs e)
        {
            DtlbtnAdd();
            DtlTextClear();
        }

        private void btn_dEdit_Click(object sender, EventArgs e)
        {
            DtlbtnAdd();
            //txt_dCode2.Enabled = false;
        }

        private void btn_dCancel_Click(object sender, EventArgs e)
        {
            DtlbtnCancel();
        }

        private void btn_dSave_Click(object sender, EventArgs e)
        {
            Data_Dtl_Save();
            DtlbtnCancel();
            DtlTextClear();
        }

        private void DtlbtnSearch()
        {
            if (dataGridView2.Rows.Count > 0)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }

            btn_dEdit.Enabled = false;
        }

        private void DtlbtnAdd()
        {
            panel1.Enabled = false;
            panel2.Enabled = false;

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox4.Enabled = true;

            btn_dAdd.Enabled = false;
            btn_dEdit.Enabled = false;
            btn_dCancel.Enabled = true;
            btn_dSave.Enabled = true;
        }

        private void DtlbtnEdit()
        {
            btn_dEdit.Enabled = true;
        }

        private void DtlbtnCancel()
        {
            panel1.Enabled = true;
            panel2.Enabled = true;

            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;

            btn_dAdd.Enabled = true;
            btn_dEdit.Enabled = false;
            btn_dCancel.Enabled = false;
            btn_dSave.Enabled = false;
        }

        private void DtlbtnSave()
        {
        }

        private void DtlTextClear()
        {
            txt_dCode2.Text = "";
            txt_dDesc2.Text = "";
            chk_dUseYN.Checked = true;
            txt_dNote.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridViewRow row = dataGridView1.CurrentRow;
            //string a = row.Cells[0].Value.ToString();
        }
    }
}
