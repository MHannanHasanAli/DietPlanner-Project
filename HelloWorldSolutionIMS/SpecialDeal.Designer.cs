namespace HelloWorldSolutionIMS
{
    partial class SpecialDeal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Add = new Guna.UI2.WinForms.Guna2Button();
            this.search = new Guna.UI2.WinForms.Guna2Button();
            this.promotionnamesearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.promotioncodesearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.iddgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promotionnamedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promotioncodedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promotionpercentagedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startdatedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enddatedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nutritionistdgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchdgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Backtodeal = new Guna.UI2.WinForms.Guna2Button();
            this.save = new Guna.UI2.WinForms.Guna2Button();
            this.branch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nutritionist = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.promotiondetails = new Guna.UI2.WinForms.Guna2TextBox();
            this.enddate = new System.Windows.Forms.DateTimePicker();
            this.startdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.promotionname = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.promotioncode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.promotionpercentage = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1145, 629);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1137, 600);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.search);
            this.panel1.Controls.Add(this.promotionnamesearch);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.promotioncodesearch);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.guna2DataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 594);
            this.panel1.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.AutoRoundedCorners = true;
            this.Add.BorderRadius = 21;
            this.Add.CausesValidation = false;
            this.Add.CheckedState.Parent = this.Add;
            this.Add.CustomImages.Parent = this.Add;
            this.Add.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.Add.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.HoverState.Parent = this.Add;
            this.Add.Location = new System.Drawing.Point(905, 86);
            this.Add.Name = "Add";
            this.Add.ShadowDecoration.Parent = this.Add;
            this.Add.Size = new System.Drawing.Size(199, 45);
            this.Add.TabIndex = 269;
            this.Add.Text = "Add";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // search
            // 
            this.search.AutoRoundedCorners = true;
            this.search.BorderRadius = 21;
            this.search.CausesValidation = false;
            this.search.CheckedState.Parent = this.search;
            this.search.CustomImages.Parent = this.search;
            this.search.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.search.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.search.ForeColor = System.Drawing.Color.White;
            this.search.HoverState.Parent = this.search;
            this.search.Location = new System.Drawing.Point(554, 86);
            this.search.Name = "search";
            this.search.ShadowDecoration.Parent = this.search;
            this.search.Size = new System.Drawing.Size(199, 45);
            this.search.TabIndex = 268;
            this.search.Text = "Search";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // promotionnamesearch
            // 
            this.promotionnamesearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.promotionnamesearch.DefaultText = "";
            this.promotionnamesearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.promotionnamesearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.promotionnamesearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotionnamesearch.DisabledState.Parent = this.promotionnamesearch;
            this.promotionnamesearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotionnamesearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionnamesearch.FocusedState.Parent = this.promotionnamesearch;
            this.promotionnamesearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.promotionnamesearch.ForeColor = System.Drawing.Color.Black;
            this.promotionnamesearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionnamesearch.HoverState.Parent = this.promotionnamesearch;
            this.promotionnamesearch.Location = new System.Drawing.Point(239, 55);
            this.promotionnamesearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.promotionnamesearch.Name = "promotionnamesearch";
            this.promotionnamesearch.PasswordChar = '\0';
            this.promotionnamesearch.PlaceholderText = "";
            this.promotionnamesearch.SelectedText = "";
            this.promotionnamesearch.ShadowDecoration.Parent = this.promotionnamesearch;
            this.promotionnamesearch.Size = new System.Drawing.Size(284, 32);
            this.promotionnamesearch.TabIndex = 267;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(32, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 24);
            this.label5.TabIndex = 266;
            this.label5.Text = "Promotion Name";
            // 
            // promotioncodesearch
            // 
            this.promotioncodesearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.promotioncodesearch.DefaultText = "";
            this.promotioncodesearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.promotioncodesearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.promotioncodesearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotioncodesearch.DisabledState.Parent = this.promotioncodesearch;
            this.promotioncodesearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotioncodesearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotioncodesearch.FocusedState.Parent = this.promotioncodesearch;
            this.promotioncodesearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.promotioncodesearch.ForeColor = System.Drawing.Color.Black;
            this.promotioncodesearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotioncodesearch.HoverState.Parent = this.promotioncodesearch;
            this.promotioncodesearch.Location = new System.Drawing.Point(239, 99);
            this.promotioncodesearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.promotioncodesearch.Name = "promotioncodesearch";
            this.promotioncodesearch.PasswordChar = '\0';
            this.promotioncodesearch.PlaceholderText = "";
            this.promotioncodesearch.SelectedText = "";
            this.promotioncodesearch.ShadowDecoration.Parent = this.promotioncodesearch;
            this.promotioncodesearch.Size = new System.Drawing.Size(284, 32);
            this.promotioncodesearch.TabIndex = 265;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(32, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 24);
            this.label6.TabIndex = 264;
            this.label6.Text = "Promotion Code";
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(239)))), ((int)(((byte)(212)))));
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 52;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iddgv,
            this.promotionnamedgv,
            this.promotioncodedgv,
            this.promotionpercentagedgv,
            this.startdatedgv,
            this.enddatedgv,
            this.nutritionistdgv,
            this.branchdgv});
            this.guna2DataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(221)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.EnableHeadersVisualStyles = false;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(238)))), ((int)(((byte)(208)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(31, 158);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1073, 385);
            this.guna2DataGridView1.TabIndex = 0;
            this.guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Emerald;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(239)))), ((int)(((byte)(212)))));
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(238)))), ((int)(((byte)(208)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 52;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(221)))), ((int)(((byte)(160)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // iddgv
            // 
            this.iddgv.HeaderText = "ID";
            this.iddgv.MinimumWidth = 6;
            this.iddgv.Name = "iddgv";
            // 
            // promotionnamedgv
            // 
            this.promotionnamedgv.HeaderText = "PROMOTION NAME";
            this.promotionnamedgv.MinimumWidth = 6;
            this.promotionnamedgv.Name = "promotionnamedgv";
            // 
            // promotioncodedgv
            // 
            this.promotioncodedgv.HeaderText = "PROMOTION CODE";
            this.promotioncodedgv.MinimumWidth = 6;
            this.promotioncodedgv.Name = "promotioncodedgv";
            // 
            // promotionpercentagedgv
            // 
            this.promotionpercentagedgv.HeaderText = "PROMOTION PERCENTAGE";
            this.promotionpercentagedgv.MinimumWidth = 6;
            this.promotionpercentagedgv.Name = "promotionpercentagedgv";
            // 
            // startdatedgv
            // 
            this.startdatedgv.HeaderText = "START DATE";
            this.startdatedgv.MinimumWidth = 6;
            this.startdatedgv.Name = "startdatedgv";
            // 
            // enddatedgv
            // 
            this.enddatedgv.HeaderText = "END DATE";
            this.enddatedgv.MinimumWidth = 6;
            this.enddatedgv.Name = "enddatedgv";
            // 
            // nutritionistdgv
            // 
            this.nutritionistdgv.HeaderText = "NUTRITIONIST";
            this.nutritionistdgv.MinimumWidth = 6;
            this.nutritionistdgv.Name = "nutritionistdgv";
            // 
            // branchdgv
            // 
            this.branchdgv.HeaderText = "BRANCH";
            this.branchdgv.MinimumWidth = 6;
            this.branchdgv.Name = "branchdgv";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.printToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 76);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1137, 600);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Backtodeal);
            this.panel2.Controls.Add(this.save);
            this.panel2.Controls.Add(this.branch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.nutritionist);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.promotiondetails);
            this.panel2.Controls.Add(this.enddate);
            this.panel2.Controls.Add(this.startdate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.promotionname);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.promotioncode);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.promotionpercentage);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 594);
            this.panel2.TabIndex = 0;
            // 
            // Backtodeal
            // 
            this.Backtodeal.AutoRoundedCorners = true;
            this.Backtodeal.BorderRadius = 21;
            this.Backtodeal.CausesValidation = false;
            this.Backtodeal.CheckedState.Parent = this.Backtodeal;
            this.Backtodeal.CustomImages.Parent = this.Backtodeal;
            this.Backtodeal.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.Backtodeal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Backtodeal.ForeColor = System.Drawing.Color.White;
            this.Backtodeal.HoverState.Parent = this.Backtodeal;
            this.Backtodeal.Location = new System.Drawing.Point(22, 293);
            this.Backtodeal.Name = "Backtodeal";
            this.Backtodeal.ShadowDecoration.Parent = this.Backtodeal;
            this.Backtodeal.Size = new System.Drawing.Size(199, 45);
            this.Backtodeal.TabIndex = 9;
            this.Backtodeal.Text = "Back To Deals";
            this.Backtodeal.Click += new System.EventHandler(this.Backtodeal_Click);
            // 
            // save
            // 
            this.save.AutoRoundedCorners = true;
            this.save.BorderRadius = 21;
            this.save.CausesValidation = false;
            this.save.CheckedState.Parent = this.save;
            this.save.CustomImages.Parent = this.save;
            this.save.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.save.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.HoverState.Parent = this.save;
            this.save.Location = new System.Drawing.Point(877, 302);
            this.save.Name = "save";
            this.save.ShadowDecoration.Parent = this.save;
            this.save.Size = new System.Drawing.Size(199, 45);
            this.save.TabIndex = 8;
            this.save.Text = "Save Deal";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // branch
            // 
            this.branch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.branch.DefaultText = "";
            this.branch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.branch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.branch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.branch.DisabledState.Parent = this.branch;
            this.branch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.branch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.branch.FocusedState.Parent = this.branch;
            this.branch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.branch.ForeColor = System.Drawing.Color.Black;
            this.branch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.branch.HoverState.Parent = this.branch;
            this.branch.Location = new System.Drawing.Point(776, 47);
            this.branch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.branch.Name = "branch";
            this.branch.PasswordChar = '\0';
            this.branch.PlaceholderText = "";
            this.branch.SelectedText = "";
            this.branch.ShadowDecoration.Parent = this.branch;
            this.branch.Size = new System.Drawing.Size(300, 32);
            this.branch.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(550, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 273;
            this.label3.Text = "Branch";
            // 
            // nutritionist
            // 
            this.nutritionist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nutritionist.DefaultText = "";
            this.nutritionist.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nutritionist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nutritionist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nutritionist.DisabledState.Parent = this.nutritionist;
            this.nutritionist.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nutritionist.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nutritionist.FocusedState.Parent = this.nutritionist;
            this.nutritionist.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nutritionist.ForeColor = System.Drawing.Color.Black;
            this.nutritionist.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nutritionist.HoverState.Parent = this.nutritionist;
            this.nutritionist.Location = new System.Drawing.Point(776, 91);
            this.nutritionist.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nutritionist.Name = "nutritionist";
            this.nutritionist.PasswordChar = '\0';
            this.nutritionist.PlaceholderText = "";
            this.nutritionist.SelectedText = "";
            this.nutritionist.ShadowDecoration.Parent = this.nutritionist;
            this.nutritionist.Size = new System.Drawing.Size(300, 32);
            this.nutritionist.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(550, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 24);
            this.label4.TabIndex = 271;
            this.label4.Text = "Nutritionist";
            // 
            // promotiondetails
            // 
            this.promotiondetails.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.promotiondetails.DefaultText = "";
            this.promotiondetails.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.promotiondetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.promotiondetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotiondetails.DisabledState.Parent = this.promotiondetails;
            this.promotiondetails.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotiondetails.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotiondetails.FocusedState.Parent = this.promotiondetails;
            this.promotiondetails.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotiondetails.HoverState.Parent = this.promotiondetails;
            this.promotiondetails.Location = new System.Drawing.Point(776, 133);
            this.promotiondetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.promotiondetails.Multiline = true;
            this.promotiondetails.Name = "promotiondetails";
            this.promotiondetails.PasswordChar = '\0';
            this.promotiondetails.PlaceholderText = "";
            this.promotiondetails.SelectedText = "";
            this.promotiondetails.ShadowDecoration.Parent = this.promotiondetails;
            this.promotiondetails.Size = new System.Drawing.Size(300, 119);
            this.promotiondetails.TabIndex = 7;
            // 
            // enddate
            // 
            this.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.enddate.Location = new System.Drawing.Point(243, 230);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(276, 22);
            this.enddate.TabIndex = 4;
            // 
            // startdate
            // 
            this.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startdate.Location = new System.Drawing.Point(243, 182);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(276, 22);
            this.startdate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(36, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 269;
            this.label1.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(36, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 268;
            this.label2.Text = "Start Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label13.Location = new System.Drawing.Point(550, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 24);
            this.label13.TabIndex = 264;
            this.label13.Text = "Promotion Details";
            // 
            // promotionname
            // 
            this.promotionname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.promotionname.DefaultText = "";
            this.promotionname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.promotionname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.promotionname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotionname.DisabledState.Parent = this.promotionname;
            this.promotionname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotionname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionname.FocusedState.Parent = this.promotionname;
            this.promotionname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.promotionname.ForeColor = System.Drawing.Color.Black;
            this.promotionname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionname.HoverState.Parent = this.promotionname;
            this.promotionname.Location = new System.Drawing.Point(243, 43);
            this.promotionname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.promotionname.Name = "promotionname";
            this.promotionname.PasswordChar = '\0';
            this.promotionname.PlaceholderText = "";
            this.promotionname.SelectedText = "";
            this.promotionname.ShadowDecoration.Parent = this.promotionname;
            this.promotionname.Size = new System.Drawing.Size(284, 32);
            this.promotionname.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label12.Location = new System.Drawing.Point(36, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 24);
            this.label12.TabIndex = 262;
            this.label12.Text = "Promotion Name";
            // 
            // promotioncode
            // 
            this.promotioncode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.promotioncode.DefaultText = "";
            this.promotioncode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.promotioncode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.promotioncode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotioncode.DisabledState.Parent = this.promotioncode;
            this.promotioncode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotioncode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotioncode.FocusedState.Parent = this.promotioncode;
            this.promotioncode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.promotioncode.ForeColor = System.Drawing.Color.Black;
            this.promotioncode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotioncode.HoverState.Parent = this.promotioncode;
            this.promotioncode.Location = new System.Drawing.Point(243, 87);
            this.promotioncode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.promotioncode.Name = "promotioncode";
            this.promotioncode.PasswordChar = '\0';
            this.promotioncode.PlaceholderText = "";
            this.promotioncode.SelectedText = "";
            this.promotioncode.ShadowDecoration.Parent = this.promotioncode;
            this.promotioncode.Size = new System.Drawing.Size(284, 32);
            this.promotioncode.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label11.Location = new System.Drawing.Point(36, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 24);
            this.label11.TabIndex = 260;
            this.label11.Text = "Promotion Code";
            // 
            // promotionpercentage
            // 
            this.promotionpercentage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.promotionpercentage.DefaultText = "";
            this.promotionpercentage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.promotionpercentage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.promotionpercentage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotionpercentage.DisabledState.Parent = this.promotionpercentage;
            this.promotionpercentage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.promotionpercentage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionpercentage.FocusedState.Parent = this.promotionpercentage;
            this.promotionpercentage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.promotionpercentage.ForeColor = System.Drawing.Color.Black;
            this.promotionpercentage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionpercentage.HoverState.Parent = this.promotionpercentage;
            this.promotionpercentage.Location = new System.Drawing.Point(243, 131);
            this.promotionpercentage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.promotionpercentage.Name = "promotionpercentage";
            this.promotionpercentage.PasswordChar = '\0';
            this.promotionpercentage.PlaceholderText = "";
            this.promotionpercentage.SelectedText = "";
            this.promotionpercentage.ShadowDecoration.Parent = this.promotionpercentage;
            this.promotionpercentage.Size = new System.Drawing.Size(284, 32);
            this.promotionpercentage.TabIndex = 2;
            this.promotionpercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.promotionpercentage_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label10.Location = new System.Drawing.Point(36, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 24);
            this.label10.TabIndex = 258;
            this.label10.Text = "Promotion Percentage";
            // 
            // SpecialDeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1170, 788);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpecialDeal";
            this.Text = "SpecialDeal";
            this.Load += new System.EventHandler(this.SpecialDeal_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox promotionname;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox promotioncode;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox promotionpercentage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker enddate;
        private System.Windows.Forms.DateTimePicker startdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox branch;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox nutritionist;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox promotiondetails;
        private Guna.UI2.WinForms.Guna2Button Backtodeal;
        private Guna.UI2.WinForms.Guna2Button save;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn promotionnamedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn promotioncodedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn promotionpercentagedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn startdatedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn enddatedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn nutritionistdgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchdgv;
        private Guna.UI2.WinForms.Guna2TextBox promotionnamesearch;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox promotioncodesearch;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button Add;
        private Guna.UI2.WinForms.Guna2Button search;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    }
}