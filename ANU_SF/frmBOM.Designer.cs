namespace ANU_SF
{
    partial class frmBOM
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgBOM_ITEMCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBOM_ITEMNM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBOM_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dg2BOM_ITEMCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg2BOM_ITEMNM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg2BOM_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg2BOM_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg2BOM_FROM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboITEMCODE = new System.Windows.Forms.ComboBox();
            this.cboMCODE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Mdgpanel = new System.Windows.Forms.Panel();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.txtCODE = new System.Windows.Forms.TextBox();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.txtPRICE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMCODE = new System.Windows.Forms.TextBox();
            this.txtMNAME = new System.Windows.Forms.TextBox();
            this.txtMQTY = new System.Windows.Forms.TextBox();
            this.txtMPRICE = new System.Windows.Forms.TextBox();
            this.txtMFROM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MPanel = new System.Windows.Forms.Panel();
            this.PPanel = new System.Windows.Forms.Panel();
            this.btn_Madd = new System.Windows.Forms.Button();
            this.btn_MSAVE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Mdgpanel.SuspendLayout();
            this.MPanel.SuspendLayout();
            this.PPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgBOM_ITEMCODE,
            this.dgBOM_ITEMNM,
            this.dgBOM_PRICE});
            this.dataGridView1.Location = new System.Drawing.Point(27, 119);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(390, 195);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // dgBOM_ITEMCODE
            // 
            this.dgBOM_ITEMCODE.DataPropertyName = "P_ITEMCODE";
            this.dgBOM_ITEMCODE.HeaderText = "CODE";
            this.dgBOM_ITEMCODE.Name = "dgBOM_ITEMCODE";
            this.dgBOM_ITEMCODE.ReadOnly = true;
            // 
            // dgBOM_ITEMNM
            // 
            this.dgBOM_ITEMNM.DataPropertyName = "P_ITEMNM";
            this.dgBOM_ITEMNM.HeaderText = "NAME";
            this.dgBOM_ITEMNM.Name = "dgBOM_ITEMNM";
            this.dgBOM_ITEMNM.ReadOnly = true;
            // 
            // dgBOM_PRICE
            // 
            this.dgBOM_PRICE.DataPropertyName = "P_PRICE";
            this.dgBOM_PRICE.HeaderText = "PRICE";
            this.dgBOM_PRICE.Name = "dgBOM_PRICE";
            this.dgBOM_PRICE.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg2BOM_ITEMCODE,
            this.dg2BOM_ITEMNM,
            this.dg2BOM_QTY,
            this.dg2BOM_PRICE,
            this.dg2BOM_FROM,
            this.Column7});
            this.dataGridView2.Location = new System.Drawing.Point(6, 94);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(622, 285);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // dg2BOM_ITEMCODE
            // 
            this.dg2BOM_ITEMCODE.DataPropertyName = "M_ITEMCODE2";
            this.dg2BOM_ITEMCODE.HeaderText = "CODE";
            this.dg2BOM_ITEMCODE.Name = "dg2BOM_ITEMCODE";
            this.dg2BOM_ITEMCODE.ReadOnly = true;
            this.dg2BOM_ITEMCODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dg2BOM_ITEMNM
            // 
            this.dg2BOM_ITEMNM.DataPropertyName = "M_ITEMNM";
            this.dg2BOM_ITEMNM.HeaderText = "NAME";
            this.dg2BOM_ITEMNM.Name = "dg2BOM_ITEMNM";
            this.dg2BOM_ITEMNM.ReadOnly = true;
            // 
            // dg2BOM_QTY
            // 
            this.dg2BOM_QTY.DataPropertyName = "M_QTY";
            this.dg2BOM_QTY.HeaderText = "QTY";
            this.dg2BOM_QTY.Name = "dg2BOM_QTY";
            this.dg2BOM_QTY.ReadOnly = true;
            // 
            // dg2BOM_PRICE
            // 
            this.dg2BOM_PRICE.DataPropertyName = "M_PRICE";
            this.dg2BOM_PRICE.HeaderText = "PRICE";
            this.dg2BOM_PRICE.Name = "dg2BOM_PRICE";
            this.dg2BOM_PRICE.ReadOnly = true;
            // 
            // dg2BOM_FROM
            // 
            this.dg2BOM_FROM.DataPropertyName = "M_FROM";
            this.dg2BOM_FROM.HeaderText = "FROM";
            this.dg2BOM_FROM.Name = "dg2BOM_FROM";
            this.dg2BOM_FROM.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // cboITEMCODE
            // 
            this.cboITEMCODE.FormattingEnabled = true;
            this.cboITEMCODE.Location = new System.Drawing.Point(27, 66);
            this.cboITEMCODE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboITEMCODE.Name = "cboITEMCODE";
            this.cboITEMCODE.Size = new System.Drawing.Size(138, 23);
            this.cboITEMCODE.TabIndex = 2;
            // 
            // cboMCODE
            // 
            this.cboMCODE.FormattingEnabled = true;
            this.cboMCODE.Location = new System.Drawing.Point(6, 41);
            this.cboMCODE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMCODE.Name = "cboMCODE";
            this.cboMCODE.Size = new System.Drawing.Size(138, 23);
            this.cboMCODE.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(29, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "완제품";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "부품";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(14, 518);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(86, 29);
            this.btn_Search.TabIndex = 6;
            this.btn_Search.Text = "조회";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(233, 518);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(86, 29);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "저장";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(487, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 47);
            this.label3.TabIndex = 8;
            this.label3.Text = "BOM";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 518);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(338, 518);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 29);
            this.button2.TabIndex = 10;
            this.button2.Text = "수정";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.Mdgpanel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboITEMCODE);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(7, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1098, 429);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 392);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 29);
            this.button3.TabIndex = 30;
            this.button3.Text = "인쇄";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Mdgpanel
            // 
            this.Mdgpanel.Controls.Add(this.label2);
            this.Mdgpanel.Controls.Add(this.cboMCODE);
            this.Mdgpanel.Controls.Add(this.dataGridView2);
            this.Mdgpanel.Location = new System.Drawing.Point(431, 18);
            this.Mdgpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Mdgpanel.Name = "Mdgpanel";
            this.Mdgpanel.Size = new System.Drawing.Size(654, 404);
            this.Mdgpanel.TabIndex = 12;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(438, 518);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(86, 29);
            this.Btn_Cancel.TabIndex = 11;
            this.Btn_Cancel.Text = "취소";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // txtCODE
            // 
            this.txtCODE.Location = new System.Drawing.Point(87, 30);
            this.txtCODE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCODE.Name = "txtCODE";
            this.txtCODE.Size = new System.Drawing.Size(114, 25);
            this.txtCODE.TabIndex = 12;
            // 
            // txtNAME
            // 
            this.txtNAME.Location = new System.Drawing.Point(87, 96);
            this.txtNAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(114, 25);
            this.txtNAME.TabIndex = 13;
            // 
            // txtPRICE
            // 
            this.txtPRICE.Location = new System.Drawing.Point(87, 154);
            this.txtPRICE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPRICE.Name = "txtPRICE";
            this.txtPRICE.Size = new System.Drawing.Size(114, 25);
            this.txtPRICE.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(17, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "CODE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(17, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "NAME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(17, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "PRICE";
            // 
            // txtMCODE
            // 
            this.txtMCODE.Location = new System.Drawing.Point(78, 30);
            this.txtMCODE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMCODE.Name = "txtMCODE";
            this.txtMCODE.Size = new System.Drawing.Size(114, 25);
            this.txtMCODE.TabIndex = 18;
            // 
            // txtMNAME
            // 
            this.txtMNAME.Location = new System.Drawing.Point(78, 80);
            this.txtMNAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMNAME.Name = "txtMNAME";
            this.txtMNAME.Size = new System.Drawing.Size(114, 25);
            this.txtMNAME.TabIndex = 19;
            // 
            // txtMQTY
            // 
            this.txtMQTY.Location = new System.Drawing.Point(78, 139);
            this.txtMQTY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMQTY.Name = "txtMQTY";
            this.txtMQTY.Size = new System.Drawing.Size(114, 25);
            this.txtMQTY.TabIndex = 20;
            // 
            // txtMPRICE
            // 
            this.txtMPRICE.Location = new System.Drawing.Point(327, 139);
            this.txtMPRICE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMPRICE.Name = "txtMPRICE";
            this.txtMPRICE.Size = new System.Drawing.Size(114, 25);
            this.txtMPRICE.TabIndex = 21;
            // 
            // txtMFROM
            // 
            this.txtMFROM.Location = new System.Drawing.Point(327, 82);
            this.txtMFROM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMFROM.Name = "txtMFROM";
            this.txtMFROM.Size = new System.Drawing.Size(114, 25);
            this.txtMFROM.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(14, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "CODE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(17, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "NAME";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(17, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "QTY";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(246, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "FROM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(248, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "PRICE";
            // 
            // MPanel
            // 
            this.MPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MPanel.Controls.Add(this.label11);
            this.MPanel.Controls.Add(this.label10);
            this.MPanel.Controls.Add(this.label9);
            this.MPanel.Controls.Add(this.label8);
            this.MPanel.Controls.Add(this.label7);
            this.MPanel.Controls.Add(this.txtMFROM);
            this.MPanel.Controls.Add(this.txtMPRICE);
            this.MPanel.Controls.Add(this.txtMQTY);
            this.MPanel.Controls.Add(this.txtMNAME);
            this.MPanel.Controls.Add(this.txtMCODE);
            this.MPanel.Location = new System.Drawing.Point(438, 572);
            this.MPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MPanel.Name = "MPanel";
            this.MPanel.Size = new System.Drawing.Size(667, 221);
            this.MPanel.TabIndex = 28;
            // 
            // PPanel
            // 
            this.PPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PPanel.Controls.Add(this.label6);
            this.PPanel.Controls.Add(this.label5);
            this.PPanel.Controls.Add(this.label4);
            this.PPanel.Controls.Add(this.txtPRICE);
            this.PPanel.Controls.Add(this.txtNAME);
            this.PPanel.Controls.Add(this.txtCODE);
            this.PPanel.Location = new System.Drawing.Point(8, 572);
            this.PPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PPanel.Name = "PPanel";
            this.PPanel.Size = new System.Drawing.Size(429, 221);
            this.PPanel.TabIndex = 29;
            // 
            // btn_Madd
            // 
            this.btn_Madd.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Madd.Location = new System.Drawing.Point(544, 511);
            this.btn_Madd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Madd.Name = "btn_Madd";
            this.btn_Madd.Size = new System.Drawing.Size(103, 39);
            this.btn_Madd.TabIndex = 11;
            this.btn_Madd.Text = "부품 추가";
            this.btn_Madd.UseVisualStyleBackColor = true;
            this.btn_Madd.Click += new System.EventHandler(this.btn_Madd_Click_1);
            // 
            // btn_MSAVE
            // 
            this.btn_MSAVE.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_MSAVE.Location = new System.Drawing.Point(653, 511);
            this.btn_MSAVE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MSAVE.Name = "btn_MSAVE";
            this.btn_MSAVE.Size = new System.Drawing.Size(110, 41);
            this.btn_MSAVE.TabIndex = 11;
            this.btn_MSAVE.Text = "부품 저장";
            this.btn_MSAVE.UseVisualStyleBackColor = true;
            this.btn_MSAVE.Click += new System.EventHandler(this.btn_MSAVE_Click_1);
            // 
            // frmBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(1113, 829);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.btn_MSAVE);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.PPanel);
            this.Controls.Add(this.MPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Madd);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBOM";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmBOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Mdgpanel.ResumeLayout(false);
            this.Mdgpanel.PerformLayout();
            this.MPanel.ResumeLayout(false);
            this.MPanel.PerformLayout();
            this.PPanel.ResumeLayout(false);
            this.PPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cboITEMCODE;
        private System.Windows.Forms.ComboBox cboMCODE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCODE;
        private System.Windows.Forms.TextBox txtNAME;
        private System.Windows.Forms.TextBox txtPRICE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMCODE;
        private System.Windows.Forms.TextBox txtMNAME;
        private System.Windows.Forms.TextBox txtMQTY;
        private System.Windows.Forms.TextBox txtMPRICE;
        private System.Windows.Forms.TextBox txtMFROM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel MPanel;
        private System.Windows.Forms.Panel PPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg2BOM_ITEMCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg2BOM_ITEMNM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg2BOM_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg2BOM_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg2BOM_FROM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Panel Mdgpanel;
        private System.Windows.Forms.Button btn_MSAVE;
        private System.Windows.Forms.Button btn_Madd;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBOM_ITEMCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBOM_ITEMNM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBOM_PRICE;
    }
}