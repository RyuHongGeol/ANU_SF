namespace ANU_SF
{
    partial class FrmInven
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.INVEN = new System.Windows.Forms.TabControl();
            this.SUPP_INVEN = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dg3INVEN_ITEMCODE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dg3INVEN_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.dtINVEN_ORDATE = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboINVEN_ITEMCD = new System.Windows.Forms.ComboBox();
            this.cboINVEN_CUST = new System.Windows.Forms.ComboBox();
            this.dtINVEN_INDATE = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PROD_INVEN = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dg4INVEN_ITEMCODE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dg4INVEN_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtINVEN_ORDATE2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboINVEN_ITEMCD2 = new System.Windows.Forms.ComboBox();
            this.cboINVEN_CUST2 = new System.Windows.Forms.ComboBox();
            this.dtINVEN_INDATE2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgINVEM_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgINVEN_RS2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgINVEN_Itemcode2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgINVEN_Cust2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgINVEN_CNT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgINVEN_NOTE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgSEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgINVEN_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgINVEN_RS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgINVEN_Itemcode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgINVEN_CUST = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgINVEN_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgINVEN_NOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVEN.SuspendLayout();
            this.SUPP_INVEN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PROD_INVEN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // INVEN
            // 
            this.INVEN.Controls.Add(this.SUPP_INVEN);
            this.INVEN.Controls.Add(this.PROD_INVEN);
            this.INVEN.Location = new System.Drawing.Point(13, 12);
            this.INVEN.Name = "INVEN";
            this.INVEN.SelectedIndex = 0;
            this.INVEN.Size = new System.Drawing.Size(955, 589);
            this.INVEN.TabIndex = 0;
            // 
            // SUPP_INVEN
            // 
            this.SUPP_INVEN.Controls.Add(this.button2);
            this.SUPP_INVEN.Controls.Add(this.dataGridView3);
            this.SUPP_INVEN.Controls.Add(this.label17);
            this.SUPP_INVEN.Controls.Add(this.dtINVEN_ORDATE);
            this.SUPP_INVEN.Controls.Add(this.label2);
            this.SUPP_INVEN.Controls.Add(this.label1);
            this.SUPP_INVEN.Controls.Add(this.cboINVEN_ITEMCD);
            this.SUPP_INVEN.Controls.Add(this.cboINVEN_CUST);
            this.SUPP_INVEN.Controls.Add(this.dtINVEN_INDATE);
            this.SUPP_INVEN.Controls.Add(this.btnSearch);
            this.SUPP_INVEN.Controls.Add(this.dataGridView1);
            this.SUPP_INVEN.Location = new System.Drawing.Point(4, 22);
            this.SUPP_INVEN.Name = "SUPP_INVEN";
            this.SUPP_INVEN.Padding = new System.Windows.Forms.Padding(3);
            this.SUPP_INVEN.Size = new System.Drawing.Size(947, 563);
            this.SUPP_INVEN.TabIndex = 0;
            this.SUPP_INVEN.Text = "판매재고";
            this.SUPP_INVEN.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg3INVEN_ITEMCODE,
            this.dg3INVEN_CNT});
            this.dataGridView3.Location = new System.Drawing.Point(658, 123);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(254, 127);
            this.dataGridView3.TabIndex = 45;
            // 
            // dg3INVEN_ITEMCODE
            // 
            this.dg3INVEN_ITEMCODE.DataPropertyName = "INVEN_ITEMCODE";
            this.dg3INVEN_ITEMCODE.HeaderText = "품목";
            this.dg3INVEN_ITEMCODE.Name = "dg3INVEN_ITEMCODE";
            this.dg3INVEN_ITEMCODE.ReadOnly = true;
            this.dg3INVEN_ITEMCODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dg3INVEN_ITEMCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dg3INVEN_CNT
            // 
            this.dg3INVEN_CNT.DataPropertyName = "INVEN_CNT";
            this.dg3INVEN_CNT.HeaderText = "재고현황";
            this.dg3INVEN_CNT.Name = "dg3INVEN_CNT";
            this.dg3INVEN_CNT.ReadOnly = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(250, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 16);
            this.label17.TabIndex = 42;
            this.label17.Text = "~";
            // 
            // dtINVEN_ORDATE
            // 
            this.dtINVEN_ORDATE.Location = new System.Drawing.Point(34, 21);
            this.dtINVEN_ORDATE.Name = "dtINVEN_ORDATE";
            this.dtINVEN_ORDATE.Size = new System.Drawing.Size(200, 21);
            this.dtINVEN_ORDATE.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(291, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "품목";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(31, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 37;
            this.label1.Text = "거래처";
            // 
            // cboINVEN_ITEMCD
            // 
            this.cboINVEN_ITEMCD.FormattingEnabled = true;
            this.cboINVEN_ITEMCD.Location = new System.Drawing.Point(336, 73);
            this.cboINVEN_ITEMCD.Name = "cboINVEN_ITEMCD";
            this.cboINVEN_ITEMCD.Size = new System.Drawing.Size(158, 20);
            this.cboINVEN_ITEMCD.TabIndex = 36;
            // 
            // cboINVEN_CUST
            // 
            this.cboINVEN_CUST.FormattingEnabled = true;
            this.cboINVEN_CUST.Location = new System.Drawing.Point(92, 73);
            this.cboINVEN_CUST.Name = "cboINVEN_CUST";
            this.cboINVEN_CUST.Size = new System.Drawing.Size(142, 20);
            this.cboINVEN_CUST.TabIndex = 35;
            // 
            // dtINVEN_INDATE
            // 
            this.dtINVEN_INDATE.Location = new System.Drawing.Point(294, 21);
            this.dtINVEN_INDATE.Name = "dtINVEN_INDATE";
            this.dtINVEN_INDATE.Size = new System.Drawing.Size(200, 21);
            this.dtINVEN_INDATE.TabIndex = 34;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(543, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 24);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSEQ,
            this.dgINVEN_DT,
            this.dgINVEN_RS,
            this.dgINVEN_Itemcode,
            this.dgINVEN_CUST,
            this.dgINVEN_CNT,
            this.dgINVEN_NOTE});
            this.dataGridView1.Location = new System.Drawing.Point(6, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(646, 374);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // PROD_INVEN
            // 
            this.PROD_INVEN.Controls.Add(this.dataGridView4);
            this.PROD_INVEN.Controls.Add(this.dtINVEN_ORDATE2);
            this.PROD_INVEN.Controls.Add(this.label3);
            this.PROD_INVEN.Controls.Add(this.label4);
            this.PROD_INVEN.Controls.Add(this.cboINVEN_ITEMCD2);
            this.PROD_INVEN.Controls.Add(this.cboINVEN_CUST2);
            this.PROD_INVEN.Controls.Add(this.dtINVEN_INDATE2);
            this.PROD_INVEN.Controls.Add(this.dataGridView2);
            this.PROD_INVEN.Controls.Add(this.button1);
            this.PROD_INVEN.Location = new System.Drawing.Point(4, 22);
            this.PROD_INVEN.Name = "PROD_INVEN";
            this.PROD_INVEN.Padding = new System.Windows.Forms.Padding(3);
            this.PROD_INVEN.Size = new System.Drawing.Size(947, 563);
            this.PROD_INVEN.TabIndex = 1;
            this.PROD_INVEN.Text = "구매재고";
            this.PROD_INVEN.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg4INVEN_ITEMCODE,
            this.dg4INVEN_CNT});
            this.dataGridView4.Location = new System.Drawing.Point(650, 115);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowTemplate.Height = 23;
            this.dataGridView4.Size = new System.Drawing.Size(254, 127);
            this.dataGridView4.TabIndex = 48;
            // 
            // dg4INVEN_ITEMCODE
            // 
            this.dg4INVEN_ITEMCODE.DataPropertyName = "INVEN2_ITEMCODE";
            this.dg4INVEN_ITEMCODE.HeaderText = "품목";
            this.dg4INVEN_ITEMCODE.Name = "dg4INVEN_ITEMCODE";
            this.dg4INVEN_ITEMCODE.ReadOnly = true;
            this.dg4INVEN_ITEMCODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dg4INVEN_ITEMCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dg4INVEN_CNT
            // 
            this.dg4INVEN_CNT.DataPropertyName = "INVEN2_CNT";
            this.dg4INVEN_CNT.HeaderText = "재고현황";
            this.dg4INVEN_CNT.Name = "dg4INVEN_CNT";
            this.dg4INVEN_CNT.ReadOnly = true;
            // 
            // dtINVEN_ORDATE2
            // 
            this.dtINVEN_ORDATE2.Location = new System.Drawing.Point(12, 23);
            this.dtINVEN_ORDATE2.Name = "dtINVEN_ORDATE2";
            this.dtINVEN_ORDATE2.Size = new System.Drawing.Size(200, 21);
            this.dtINVEN_ORDATE2.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(224, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "품목";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(9, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 43;
            this.label4.Text = "거래처";
            // 
            // cboINVEN_ITEMCD2
            // 
            this.cboINVEN_ITEMCD2.FormattingEnabled = true;
            this.cboINVEN_ITEMCD2.Location = new System.Drawing.Point(276, 72);
            this.cboINVEN_ITEMCD2.Name = "cboINVEN_ITEMCD2";
            this.cboINVEN_ITEMCD2.Size = new System.Drawing.Size(151, 20);
            this.cboINVEN_ITEMCD2.TabIndex = 42;
            // 
            // cboINVEN_CUST2
            // 
            this.cboINVEN_CUST2.FormattingEnabled = true;
            this.cboINVEN_CUST2.Location = new System.Drawing.Point(76, 72);
            this.cboINVEN_CUST2.Name = "cboINVEN_CUST2";
            this.cboINVEN_CUST2.Size = new System.Drawing.Size(136, 20);
            this.cboINVEN_CUST2.TabIndex = 41;
            // 
            // dtINVEN_INDATE2
            // 
            this.dtINVEN_INDATE2.Location = new System.Drawing.Point(227, 23);
            this.dtINVEN_INDATE2.Name = "dtINVEN_INDATE2";
            this.dtINVEN_INDATE2.Size = new System.Drawing.Size(200, 21);
            this.dtINVEN_INDATE2.TabIndex = 40;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgINVEM_NO,
            this.dataGridViewTextBoxColumn2,
            this.dgINVEN_RS2,
            this.dgINVEN_Itemcode2,
            this.dgINVEN_Cust2,
            this.dgINVEN_CNT2,
            this.dgINVEN_NOTE2});
            this.dataGridView2.Location = new System.Drawing.Point(6, 115);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(638, 356);
            this.dataGridView2.TabIndex = 36;
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // dgINVEM_NO
            // 
            this.dgINVEM_NO.DataPropertyName = "SUPP_NO";
            this.dgINVEM_NO.HeaderText = "번호";
            this.dgINVEM_NO.Name = "dgINVEM_NO";
            this.dgINVEM_NO.ReadOnly = true;
            this.dgINVEM_NO.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SUPP_INDATE";
            this.dataGridViewTextBoxColumn2.HeaderText = "처리날짜";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dgINVEN_RS2
            // 
            this.dgINVEN_RS2.DataPropertyName = "SUPP_RCV";
            this.dgINVEN_RS2.HeaderText = "구분";
            this.dgINVEN_RS2.Name = "dgINVEN_RS2";
            this.dgINVEN_RS2.ReadOnly = true;
            this.dgINVEN_RS2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgINVEN_RS2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgINVEN_Itemcode2
            // 
            this.dgINVEN_Itemcode2.DataPropertyName = "SUPP_ITEMCD";
            this.dgINVEN_Itemcode2.HeaderText = "품목";
            this.dgINVEN_Itemcode2.Name = "dgINVEN_Itemcode2";
            this.dgINVEN_Itemcode2.ReadOnly = true;
            this.dgINVEN_Itemcode2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgINVEN_Itemcode2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgINVEN_Cust2
            // 
            this.dgINVEN_Cust2.DataPropertyName = "SUPP_CUST";
            this.dgINVEN_Cust2.HeaderText = "거래처";
            this.dgINVEN_Cust2.Name = "dgINVEN_Cust2";
            this.dgINVEN_Cust2.ReadOnly = true;
            this.dgINVEN_Cust2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgINVEN_Cust2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgINVEN_CNT2
            // 
            this.dgINVEN_CNT2.DataPropertyName = "SUPP_CNT";
            this.dgINVEN_CNT2.HeaderText = "수량";
            this.dgINVEN_CNT2.Name = "dgINVEN_CNT2";
            this.dgINVEN_CNT2.ReadOnly = true;
            // 
            // dgINVEN_NOTE2
            // 
            this.dgINVEN_NOTE2.DataPropertyName = "SUPP_NOTE";
            this.dgINVEN_NOTE2.HeaderText = "비고";
            this.dgINVEN_NOTE2.Name = "dgINVEN_NOTE2";
            this.dgINVEN_NOTE2.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(543, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 26);
            this.button1.TabIndex = 34;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(642, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 24);
            this.button2.TabIndex = 46;
            this.button2.Text = "인쇄";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgSEQ
            // 
            this.dgSEQ.DataPropertyName = "SALE_NO";
            this.dgSEQ.HeaderText = "번호";
            this.dgSEQ.Name = "dgSEQ";
            this.dgSEQ.ReadOnly = true;
            this.dgSEQ.Visible = false;
            // 
            // dgINVEN_DT
            // 
            this.dgINVEN_DT.DataPropertyName = "SALE_INDATE";
            this.dgINVEN_DT.HeaderText = "처리날짜";
            this.dgINVEN_DT.Name = "dgINVEN_DT";
            this.dgINVEN_DT.ReadOnly = true;
            // 
            // dgINVEN_RS
            // 
            this.dgINVEN_RS.DataPropertyName = "SALE_SHIPPING";
            this.dgINVEN_RS.HeaderText = "구분";
            this.dgINVEN_RS.Name = "dgINVEN_RS";
            this.dgINVEN_RS.ReadOnly = true;
            this.dgINVEN_RS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgINVEN_RS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgINVEN_Itemcode
            // 
            this.dgINVEN_Itemcode.DataPropertyName = "SALE_ITEMCD";
            this.dgINVEN_Itemcode.HeaderText = "품목";
            this.dgINVEN_Itemcode.Name = "dgINVEN_Itemcode";
            this.dgINVEN_Itemcode.ReadOnly = true;
            this.dgINVEN_Itemcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgINVEN_Itemcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgINVEN_CUST
            // 
            this.dgINVEN_CUST.DataPropertyName = "SALE_CUST";
            this.dgINVEN_CUST.HeaderText = "거래처";
            this.dgINVEN_CUST.Name = "dgINVEN_CUST";
            this.dgINVEN_CUST.ReadOnly = true;
            this.dgINVEN_CUST.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgINVEN_CUST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgINVEN_CNT
            // 
            this.dgINVEN_CNT.DataPropertyName = "SALE_CNT";
            this.dgINVEN_CNT.HeaderText = "수량";
            this.dgINVEN_CNT.Name = "dgINVEN_CNT";
            this.dgINVEN_CNT.ReadOnly = true;
            // 
            // dgINVEN_NOTE
            // 
            this.dgINVEN_NOTE.DataPropertyName = "SALE_NOTE";
            this.dgINVEN_NOTE.HeaderText = "비고";
            this.dgINVEN_NOTE.Name = "dgINVEN_NOTE";
            this.dgINVEN_NOTE.ReadOnly = true;
            // 
            // FrmInven
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 638);
            this.Controls.Add(this.INVEN);
            this.Name = "FrmInven";
            this.Text = "재고";
            this.Load += new System.EventHandler(this.FrmInven_Load);
            this.INVEN.ResumeLayout(false);
            this.SUPP_INVEN.ResumeLayout(false);
            this.SUPP_INVEN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PROD_INVEN.ResumeLayout(false);
            this.PROD_INVEN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl INVEN;
        private System.Windows.Forms.TabPage SUPP_INVEN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage PROD_INVEN;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboINVEN_ITEMCD;
        private System.Windows.Forms.ComboBox cboINVEN_CUST;
        private System.Windows.Forms.DateTimePicker dtINVEN_INDATE;
        private System.Windows.Forms.DateTimePicker dtINVEN_ORDATE;
        private System.Windows.Forms.DateTimePicker dtINVEN_ORDATE2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboINVEN_ITEMCD2;
        private System.Windows.Forms.ComboBox cboINVEN_CUST2;
        private System.Windows.Forms.DateTimePicker dtINVEN_INDATE2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dg3INVEN_ITEMCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg3INVEN_CNT;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgINVEM_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgINVEN_RS2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgINVEN_Itemcode2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgINVEN_Cust2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgINVEN_CNT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgINVEN_NOTE2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dg4INVEN_ITEMCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg4INVEN_CNT;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgINVEN_DT;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgINVEN_RS;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgINVEN_Itemcode;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgINVEN_CUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgINVEN_CNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgINVEN_NOTE;
    }
}