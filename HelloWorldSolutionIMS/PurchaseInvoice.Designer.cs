
namespace HelloWorldSolutionIMS
{
    partial class PurchaseInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseInvoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label16 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnReset = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtRemainingAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPayingAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtDated = new System.Windows.Forms.TextBox();
            this.txtInvoiceType = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvPurchaseItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSupplierInvoiceID = new System.Windows.Forms.Label();
            this.lblSupplierLedgerID = new System.Windows.Forms.Label();
            this.lblPurchaseID = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtInvoice = new System.Windows.Forms.DateTimePicker();
            this.txtStockInfo = new System.Windows.Forms.TextBox();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.cboInvoiceType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSaleRates = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.txtProductTot = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtPurchaseRate = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.PcodeGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseRateGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleRateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label16.Location = new System.Drawing.Point(134, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 21);
            this.label16.TabIndex = 1;
            this.label16.Text = "Date";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(818, 555);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(136, 38);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "&PREVIEW";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnFinalize
            // 
            this.btnFinalize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnFinalize.FlatAppearance.BorderSize = 0;
            this.btnFinalize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalize.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFinalize.ForeColor = System.Drawing.Color.White;
            this.btnFinalize.Location = new System.Drawing.Point(12, 552);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(265, 45);
            this.btnFinalize.TabIndex = 11;
            this.btnFinalize.Text = "&FINALIZE";
            this.btnFinalize.UseVisualStyleBackColor = false;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label18.Location = new System.Drawing.Point(3, 227);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 21);
            this.label18.TabIndex = 1;
            this.label18.Text = "Paying Amount";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(818, 506);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(136, 38);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "&RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label19.Location = new System.Drawing.Point(3, 287);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(142, 21);
            this.label19.TabIndex = 1;
            this.label19.Text = "Remaining Balance";
            // 
            // txtRemainingAmount
            // 
            this.txtRemainingAmount.Enabled = false;
            this.txtRemainingAmount.Location = new System.Drawing.Point(7, 311);
            this.txtRemainingAmount.Name = "txtRemainingAmount";
            this.txtRemainingAmount.Size = new System.Drawing.Size(198, 23);
            this.txtRemainingAmount.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label17.Location = new System.Drawing.Point(3, 163);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 21);
            this.label17.TabIndex = 1;
            this.label17.Text = "Total Amount";
            // 
            // txtPayingAmount
            // 
            this.txtPayingAmount.Location = new System.Drawing.Point(7, 251);
            this.txtPayingAmount.Name = "txtPayingAmount";
            this.txtPayingAmount.Size = new System.Drawing.Size(198, 23);
            this.txtPayingAmount.TabIndex = 0;
            this.txtPayingAmount.Text = "0";
            this.txtPayingAmount.TextChanged += new System.EventHandler(this.txtPayingAmount_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label15.Location = new System.Drawing.Point(3, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 21);
            this.label15.TabIndex = 1;
            this.label15.Text = "Invoice Type";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(7, 187);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(198, 23);
            this.txtTotalAmount.TabIndex = 0;
            this.txtTotalAmount.Text = "0";
            // 
            // txtDated
            // 
            this.txtDated.Enabled = false;
            this.txtDated.Location = new System.Drawing.Point(138, 123);
            this.txtDated.Name = "txtDated";
            this.txtDated.Size = new System.Drawing.Size(237, 23);
            this.txtDated.TabIndex = 0;
            // 
            // txtInvoiceType
            // 
            this.txtInvoiceType.Enabled = false;
            this.txtInvoiceType.Location = new System.Drawing.Point(7, 123);
            this.txtInvoiceType.Name = "txtInvoiceType";
            this.txtInvoiceType.Size = new System.Drawing.Size(110, 23);
            this.txtInvoiceType.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label14.Location = new System.Drawing.Point(3, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 21);
            this.label14.TabIndex = 1;
            this.label14.Text = "Supplier Name";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Enabled = false;
            this.txtSupplierName.Location = new System.Drawing.Point(7, 73);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(368, 23);
            this.txtSupplierName.TabIndex = 0;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.label16);
            this.guna2GroupBox2.Controls.Add(this.label19);
            this.guna2GroupBox2.Controls.Add(this.label18);
            this.guna2GroupBox2.Controls.Add(this.txtRemainingAmount);
            this.guna2GroupBox2.Controls.Add(this.label17);
            this.guna2GroupBox2.Controls.Add(this.txtPayingAmount);
            this.guna2GroupBox2.Controls.Add(this.label15);
            this.guna2GroupBox2.Controls.Add(this.txtTotalAmount);
            this.guna2GroupBox2.Controls.Add(this.txtDated);
            this.guna2GroupBox2.Controls.Add(this.txtInvoiceType);
            this.guna2GroupBox2.Controls.Add(this.label14);
            this.guna2GroupBox2.Controls.Add(this.txtSupplierName);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(960, 252);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.Parent = this.guna2GroupBox2;
            this.guna2GroupBox2.Size = new System.Drawing.Size(400, 417);
            this.guna2GroupBox2.TabIndex = 10;
            this.guna2GroupBox2.Text = "SUPPLIER PAYMENT";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(386, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "&CALCULATE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtGrandTotal.ForeColor = System.Drawing.Color.Red;
            this.txtGrandTotal.Location = new System.Drawing.Point(132, 516);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(248, 30);
            this.txtGrandTotal.TabIndex = 14;
            this.txtGrandTotal.Text = "0";
            this.txtGrandTotal.TextChanged += new System.EventHandler(this.txtGrandTotal_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(11, 519);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 25);
            this.label13.TabIndex = 8;
            this.label13.Text = "Grand Total";
            // 
            // dgvPurchaseItems
            // 
            this.dgvPurchaseItems.AllowUserToAddRows = false;
            this.dgvPurchaseItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPurchaseItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseItems.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPurchaseItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchaseItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPurchaseItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchaseItems.ColumnHeadersHeight = 21;
            this.dgvPurchaseItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PcodeGVC,
            this.ProductNameGVC,
            this.WarehouseID,
            this.WarehouseGVC,
            this.QtyGVC,
            this.UnitID,
            this.UnitGVC,
            this.PurchaseRateGVC,
            this.TotalGV,
            this.SaleRateGV,
            this.TypeGV,
            this.BtnRemove});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPurchaseItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseItems.EnableHeadersVisualStyles = false;
            this.dgvPurchaseItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPurchaseItems.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchaseItems.Name = "dgvPurchaseItems";
            this.dgvPurchaseItems.ReadOnly = true;
            this.dgvPurchaseItems.RowHeadersVisible = false;
            this.dgvPurchaseItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseItems.Size = new System.Drawing.Size(948, 250);
            this.dgvPurchaseItems.TabIndex = 0;
            this.dgvPurchaseItems.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvPurchaseItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPurchaseItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPurchaseItems.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPurchaseItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPurchaseItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPurchaseItems.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPurchaseItems.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPurchaseItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPurchaseItems.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPurchaseItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPurchaseItems.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPurchaseItems.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPurchaseItems.ThemeStyle.HeaderStyle.Height = 21;
            this.dgvPurchaseItems.ThemeStyle.ReadOnly = true;
            this.dgvPurchaseItems.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPurchaseItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPurchaseItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPurchaseItems.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvPurchaseItems.ThemeStyle.RowsStyle.Height = 22;
            this.dgvPurchaseItems.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPurchaseItems.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPurchaseItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseItems_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.lblSupplierInvoiceID);
            this.panel1.Controls.Add(this.lblSupplierLedgerID);
            this.panel1.Controls.Add(this.lblPurchaseID);
            this.panel1.Controls.Add(this.lblInvoice);
            this.panel1.Controls.Add(this.guna2HtmlLabel2);
            this.panel1.Controls.Add(this.dtInvoice);
            this.panel1.Controls.Add(this.txtStockInfo);
            this.panel1.Controls.Add(this.cboSupplier);
            this.panel1.Controls.Add(this.cboInvoiceType);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblSaleRates);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.guna2GroupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 244);
            this.panel1.TabIndex = 6;
            // 
            // lblSupplierInvoiceID
            // 
            this.lblSupplierInvoiceID.AutoSize = true;
            this.lblSupplierInvoiceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSupplierInvoiceID.ForeColor = System.Drawing.Color.White;
            this.lblSupplierInvoiceID.Location = new System.Drawing.Point(921, 29);
            this.lblSupplierInvoiceID.Name = "lblSupplierInvoiceID";
            this.lblSupplierInvoiceID.Size = new System.Drawing.Size(117, 17);
            this.lblSupplierInvoiceID.TabIndex = 17;
            this.lblSupplierInvoiceID.Text = "SupplierInvoiceID";
            this.lblSupplierInvoiceID.Visible = false;
            // 
            // lblSupplierLedgerID
            // 
            this.lblSupplierLedgerID.AutoSize = true;
            this.lblSupplierLedgerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSupplierLedgerID.ForeColor = System.Drawing.Color.White;
            this.lblSupplierLedgerID.Location = new System.Drawing.Point(921, 49);
            this.lblSupplierLedgerID.Name = "lblSupplierLedgerID";
            this.lblSupplierLedgerID.Size = new System.Drawing.Size(118, 17);
            this.lblSupplierLedgerID.TabIndex = 18;
            this.lblSupplierLedgerID.Text = "SupplierLedgerID";
            this.lblSupplierLedgerID.Visible = false;
            // 
            // lblPurchaseID
            // 
            this.lblPurchaseID.AutoSize = true;
            this.lblPurchaseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPurchaseID.ForeColor = System.Drawing.Color.White;
            this.lblPurchaseID.Location = new System.Drawing.Point(921, 12);
            this.lblPurchaseID.Name = "lblPurchaseID";
            this.lblPurchaseID.Size = new System.Drawing.Size(81, 17);
            this.lblPurchaseID.TabIndex = 19;
            this.lblPurchaseID.Text = "PurchaseID";
            this.lblPurchaseID.Visible = false;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblInvoice.ForeColor = System.Drawing.Color.White;
            this.lblInvoice.Location = new System.Drawing.Point(921, 73);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(74, 17);
            this.lblInvoice.TabIndex = 20;
            this.lblInvoice.Text = "lblInvocien";
            this.lblInvoice.Visible = false;
            this.lblInvoice.TextChanged += new System.EventHandler(this.lblInvoice_TextChanged);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 40F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(491, 13);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(392, 73);
            this.guna2HtmlLabel2.TabIndex = 16;
            this.guna2HtmlLabel2.Text = "Purchase Invoice";
            // 
            // dtInvoice
            // 
            this.dtInvoice.CustomFormat = "dd/MM/yyyy";
            this.dtInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvoice.Location = new System.Drawing.Point(105, 12);
            this.dtInvoice.Name = "dtInvoice";
            this.dtInvoice.Size = new System.Drawing.Size(95, 20);
            this.dtInvoice.TabIndex = 0;
            this.dtInvoice.ValueChanged += new System.EventHandler(this.dtInvoice_ValueChanged);
            // 
            // txtStockInfo
            // 
            this.txtStockInfo.Enabled = false;
            this.txtStockInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtStockInfo.ForeColor = System.Drawing.Color.Red;
            this.txtStockInfo.Location = new System.Drawing.Point(1233, 67);
            this.txtStockInfo.Name = "txtStockInfo";
            this.txtStockInfo.Size = new System.Drawing.Size(127, 30);
            this.txtStockInfo.TabIndex = 14;
            // 
            // cboSupplier
            // 
            this.cboSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(105, 73);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(211, 21);
            this.cboSupplier.TabIndex = 2;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
            this.cboSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSupplier_KeyDown);
            // 
            // cboInvoiceType
            // 
            this.cboInvoiceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboInvoiceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInvoiceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboInvoiceType.FormattingEnabled = true;
            this.cboInvoiceType.Items.AddRange(new object[] {
            "---Select---",
            "Cash",
            "Credit"});
            this.cboInvoiceType.Location = new System.Drawing.Point(106, 44);
            this.cboInvoiceType.Name = "cboInvoiceType";
            this.cboInvoiceType.Size = new System.Drawing.Size(211, 21);
            this.cboInvoiceType.TabIndex = 1;
            this.cboInvoiceType.SelectedIndexChanged += new System.EventHandler(this.cboInvoiceType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1113, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Remaining Stock";
            // 
            // lblSaleRates
            // 
            this.lblSaleRates.AutoSize = true;
            this.lblSaleRates.Location = new System.Drawing.Point(1221, 9);
            this.lblSaleRates.Name = "lblSaleRates";
            this.lblSaleRates.Size = new System.Drawing.Size(59, 13);
            this.lblSaleRates.TabIndex = 1;
            this.lblSaleRates.Text = "Sale Rates";
            this.lblSaleRates.Visible = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(1319, 49);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(31, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "Total";
            this.lblID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Supplier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Invoice Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Invoice Date";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.button2);
            this.guna2GroupBox1.Controls.Add(this.btnAddToCart);
            this.guna2GroupBox1.Controls.Add(this.txtProductTot);
            this.guna2GroupBox1.Controls.Add(this.txtUnit);
            this.guna2GroupBox1.Controls.Add(this.txtPurchaseRate);
            this.guna2GroupBox1.Controls.Add(this.txtQuantity);
            this.guna2GroupBox1.Controls.Add(this.label8);
            this.guna2GroupBox1.Controls.Add(this.label10);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.label9);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.cboType);
            this.guna2GroupBox1.Controls.Add(this.cboWarehouse);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.cboProductName);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 28, 0, 0);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 102);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(1364, 142);
            this.guna2GroupBox1.TabIndex = 3;
            this.guna2GroupBox1.Text = "Add Purchase Item";
            this.guna2GroupBox1.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1031, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 38);
            this.button2.TabIndex = 30;
            this.button2.Text = "&VIEW INVOICES";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnAddToCart.FlatAppearance.BorderSize = 0;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(748, 80);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(265, 45);
            this.btnAddToCart.TabIndex = 5;
            this.btnAddToCart.Text = "&ADD TO CART";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddCart_Click);
            // 
            // txtProductTot
            // 
            this.txtProductTot.Enabled = false;
            this.txtProductTot.Location = new System.Drawing.Point(786, 44);
            this.txtProductTot.Name = "txtProductTot";
            this.txtProductTot.Size = new System.Drawing.Size(227, 25);
            this.txtProductTot.TabIndex = 4;
            this.txtProductTot.TextChanged += new System.EventHandler(this.txtProductTot_TextChanged);
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(386, 84);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(138, 25);
            this.txtUnit.TabIndex = 4;
            // 
            // txtPurchaseRate
            // 
            this.txtPurchaseRate.Enabled = false;
            this.txtPurchaseRate.Location = new System.Drawing.Point(581, 84);
            this.txtPurchaseRate.Name = "txtPurchaseRate";
            this.txtPurchaseRate.Size = new System.Drawing.Size(141, 25);
            this.txtPurchaseRate.TabIndex = 4;
            this.txtPurchaseRate.TextChanged += new System.EventHandler(this.txtPurchaseRate_TextChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(581, 49);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(141, 25);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Unit Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(744, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(539, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(543, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "QTY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Warehouse";
            // 
            // cboType
            // 
            this.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboType.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.ForeColor = System.Drawing.Color.White;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Base",
            "Default",
            "Sub"});
            this.cboType.Location = new System.Drawing.Point(386, 49);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(138, 25);
            this.cboType.TabIndex = 2;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboUnitType_SelectedIndexChanged);
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWarehouse.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboWarehouse.ForeColor = System.Drawing.Color.White;
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(94, 84);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(206, 25);
            this.cboWarehouse.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Product";
            // 
            // cboProductName
            // 
            this.cboProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProductName.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cboProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProductName.ForeColor = System.Drawing.Color.White;
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Location = new System.Drawing.Point(94, 52);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(206, 25);
            this.cboProductName.TabIndex = 0;
            this.cboProductName.SelectedIndexChanged += new System.EventHandler(this.cboProductName_SelectedIndexChanged);
            this.cboProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboProductName_KeyDown);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.dgvPurchaseItems);
            this.guna2Panel1.Location = new System.Drawing.Point(6, 250);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(948, 250);
            this.guna2Panel1.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(388, 567);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Discount";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Location = new System.Drawing.Point(466, 567);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.Size = new System.Drawing.Size(97, 20);
            this.txtDiscountAmount.TabIndex = 16;
            this.txtDiscountAmount.Text = "0";
            this.txtDiscountAmount.TextChanged += new System.EventHandler(this.txtDiscountAmount_TextChanged);
            // 
            // PcodeGVC
            // 
            this.PcodeGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PcodeGVC.HeaderText = "Pcode";
            this.PcodeGVC.Name = "PcodeGVC";
            this.PcodeGVC.ReadOnly = true;
            this.PcodeGVC.Visible = false;
            // 
            // ProductNameGVC
            // 
            this.ProductNameGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductNameGVC.HeaderText = "Product Name";
            this.ProductNameGVC.Name = "ProductNameGVC";
            this.ProductNameGVC.ReadOnly = true;
            // 
            // WarehouseID
            // 
            this.WarehouseID.HeaderText = "WarehouseID";
            this.WarehouseID.Name = "WarehouseID";
            this.WarehouseID.ReadOnly = true;
            this.WarehouseID.Visible = false;
            // 
            // WarehouseGVC
            // 
            this.WarehouseGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WarehouseGVC.HeaderText = "Warehouse";
            this.WarehouseGVC.Name = "WarehouseGVC";
            this.WarehouseGVC.ReadOnly = true;
            // 
            // QtyGVC
            // 
            this.QtyGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QtyGVC.HeaderText = "QTY";
            this.QtyGVC.Name = "QtyGVC";
            this.QtyGVC.ReadOnly = true;
            // 
            // UnitID
            // 
            this.UnitID.HeaderText = "UnitID";
            this.UnitID.Name = "UnitID";
            this.UnitID.ReadOnly = true;
            this.UnitID.Visible = false;
            // 
            // UnitGVC
            // 
            this.UnitGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnitGVC.HeaderText = "Unit";
            this.UnitGVC.Name = "UnitGVC";
            this.UnitGVC.ReadOnly = true;
            // 
            // PurchaseRateGVC
            // 
            this.PurchaseRateGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PurchaseRateGVC.HeaderText = "Purchase Rate";
            this.PurchaseRateGVC.Name = "PurchaseRateGVC";
            this.PurchaseRateGVC.ReadOnly = true;
            // 
            // TotalGV
            // 
            this.TotalGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalGV.HeaderText = "Total";
            this.TotalGV.Name = "TotalGV";
            this.TotalGV.ReadOnly = true;
            // 
            // SaleRateGV
            // 
            this.SaleRateGV.HeaderText = "Sale Rate";
            this.SaleRateGV.Name = "SaleRateGV";
            this.SaleRateGV.ReadOnly = true;
            this.SaleRateGV.Visible = false;
            // 
            // TypeGV
            // 
            this.TypeGV.HeaderText = "Type";
            this.TypeGV.Name = "TypeGV";
            this.TypeGV.ReadOnly = true;
            this.TypeGV.Visible = false;
            // 
            // BtnRemove
            // 
            this.BtnRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BtnRemove.HeaderText = "Action";
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.ReadOnly = true;
            this.BtnRemove.Text = "REMOVE";
            this.BtnRemove.UseColumnTextForButtonValue = true;
            // 
            // PurchaseInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1364, 675);
            this.ControlBox = false;
            this.Controls.Add(this.txtDiscountAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnFinalize);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "PurchaseInvoice";
            this.Text = "PurchaseInvoice";
            this.Load += new System.EventHandler(this.PurchaseInvoice_Load);
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.Label label18;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private System.Windows.Forms.TextBox txtStockInfo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSaleRates;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.TextBox txtProductTot;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtPurchaseRate;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cboProductName;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox cboSupplier;
        public System.Windows.Forms.TextBox txtSupplierName;
        public System.Windows.Forms.Label lblSupplierInvoiceID;
        public System.Windows.Forms.Label lblSupplierLedgerID;
        public System.Windows.Forms.Label lblPurchaseID;
        public System.Windows.Forms.Label lblInvoice;
        public System.Windows.Forms.TextBox txtInvoiceType;
        public System.Windows.Forms.ComboBox cboInvoiceType;
        public System.Windows.Forms.TextBox txtDated;
        public System.Windows.Forms.DateTimePicker dtInvoice;
        public Guna.UI2.WinForms.Guna2DataGridView dgvPurchaseItems;
        public System.Windows.Forms.TextBox txtTotalAmount;
        public System.Windows.Forms.TextBox txtPayingAmount;
        public System.Windows.Forms.TextBox txtRemainingAmount;
        public System.Windows.Forms.TextBox txtGrandTotal;
        public System.Windows.Forms.TextBox txtDiscountAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PcodeGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseRateGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleRateGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeGV;
        private System.Windows.Forms.DataGridViewButtonColumn BtnRemove;
    }
}