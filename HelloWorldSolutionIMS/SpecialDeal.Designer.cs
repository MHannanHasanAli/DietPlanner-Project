﻿namespace HelloWorldSolutionIMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialDeal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nutritionist = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Backtodeal = new Guna.UI2.WinForms.Guna2Button();
            this.save = new Guna.UI2.WinForms.Guna2Button();
            this.branch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
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
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Add
            // 
            this.Add.AutoRoundedCorners = true;
            this.Add.BorderRadius = 21;
            this.Add.CausesValidation = false;
            this.Add.CheckedState.Parent = this.Add;
            this.Add.CustomImages.Parent = this.Add;
            this.Add.FillColor = System.Drawing.Color.MediumSeaGreen;
            resources.ApplyResources(this.Add, "Add");
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.HoverState.Parent = this.Add;
            this.Add.Name = "Add";
            this.Add.ShadowDecoration.Parent = this.Add;
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
            resources.ApplyResources(this.search, "search");
            this.search.ForeColor = System.Drawing.Color.White;
            this.search.HoverState.Parent = this.search;
            this.search.Name = "search";
            this.search.ShadowDecoration.Parent = this.search;
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
            resources.ApplyResources(this.promotionnamesearch, "promotionnamesearch");
            this.promotionnamesearch.ForeColor = System.Drawing.Color.Black;
            this.promotionnamesearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionnamesearch.HoverState.Parent = this.promotionnamesearch;
            this.promotionnamesearch.Name = "promotionnamesearch";
            this.promotionnamesearch.PasswordChar = '\0';
            this.promotionnamesearch.PlaceholderText = "";
            this.promotionnamesearch.SelectedText = "";
            this.promotionnamesearch.ShadowDecoration.Parent = this.promotionnamesearch;
            this.promotionnamesearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.promotionnamesearch_KeyPress);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            resources.ApplyResources(this.promotioncodesearch, "promotioncodesearch");
            this.promotioncodesearch.ForeColor = System.Drawing.Color.Black;
            this.promotioncodesearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotioncodesearch.HoverState.Parent = this.promotioncodesearch;
            this.promotioncodesearch.Name = "promotioncodesearch";
            this.promotioncodesearch.PasswordChar = '\0';
            this.promotioncodesearch.PlaceholderText = "";
            this.promotioncodesearch.SelectedText = "";
            this.promotioncodesearch.ShadowDecoration.Parent = this.promotioncodesearch;
            this.promotioncodesearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.promotioncodesearch_KeyPress);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.guna2DataGridView1, "guna2DataGridView1");
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.EnableHeadersVisualStyles = false;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WhiteGrid;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 52;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // iddgv
            // 
            resources.ApplyResources(this.iddgv, "iddgv");
            this.iddgv.Name = "iddgv";
            this.iddgv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // promotionnamedgv
            // 
            resources.ApplyResources(this.promotionnamedgv, "promotionnamedgv");
            this.promotionnamedgv.Name = "promotionnamedgv";
            this.promotionnamedgv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // promotioncodedgv
            // 
            resources.ApplyResources(this.promotioncodedgv, "promotioncodedgv");
            this.promotioncodedgv.Name = "promotioncodedgv";
            this.promotioncodedgv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // promotionpercentagedgv
            // 
            resources.ApplyResources(this.promotionpercentagedgv, "promotionpercentagedgv");
            this.promotionpercentagedgv.Name = "promotionpercentagedgv";
            this.promotionpercentagedgv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // startdatedgv
            // 
            resources.ApplyResources(this.startdatedgv, "startdatedgv");
            this.startdatedgv.Name = "startdatedgv";
            this.startdatedgv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // enddatedgv
            // 
            resources.ApplyResources(this.enddatedgv, "enddatedgv");
            this.enddatedgv.Name = "enddatedgv";
            this.enddatedgv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nutritionistdgv
            // 
            resources.ApplyResources(this.nutritionistdgv, "nutritionistdgv");
            this.nutritionistdgv.Name = "nutritionistdgv";
            this.nutritionistdgv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // branchdgv
            // 
            resources.ApplyResources(this.branchdgv, "branchdgv");
            this.branchdgv.Name = "branchdgv";
            this.branchdgv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.nutritionist);
            this.panel2.Controls.Add(this.Backtodeal);
            this.panel2.Controls.Add(this.save);
            this.panel2.Controls.Add(this.branch);
            this.panel2.Controls.Add(this.label3);
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
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // nutritionist
            // 
            this.nutritionist.BackColor = System.Drawing.Color.Transparent;
            this.nutritionist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.nutritionist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nutritionist.FocusedColor = System.Drawing.Color.Empty;
            this.nutritionist.FocusedState.Parent = this.nutritionist;
            resources.ApplyResources(this.nutritionist, "nutritionist");
            this.nutritionist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.nutritionist.FormattingEnabled = true;
            this.nutritionist.HoverState.Parent = this.nutritionist;
            this.nutritionist.ItemsAppearance.Parent = this.nutritionist;
            this.nutritionist.Name = "nutritionist";
            this.nutritionist.ShadowDecoration.Parent = this.nutritionist;
            // 
            // Backtodeal
            // 
            this.Backtodeal.AutoRoundedCorners = true;
            this.Backtodeal.BorderRadius = 21;
            this.Backtodeal.CausesValidation = false;
            this.Backtodeal.CheckedState.Parent = this.Backtodeal;
            this.Backtodeal.CustomImages.Parent = this.Backtodeal;
            this.Backtodeal.FillColor = System.Drawing.Color.MediumSeaGreen;
            resources.ApplyResources(this.Backtodeal, "Backtodeal");
            this.Backtodeal.ForeColor = System.Drawing.Color.White;
            this.Backtodeal.HoverState.Parent = this.Backtodeal;
            this.Backtodeal.Name = "Backtodeal";
            this.Backtodeal.ShadowDecoration.Parent = this.Backtodeal;
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
            resources.ApplyResources(this.save, "save");
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.HoverState.Parent = this.save;
            this.save.Name = "save";
            this.save.ShadowDecoration.Parent = this.save;
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
            resources.ApplyResources(this.branch, "branch");
            this.branch.ForeColor = System.Drawing.Color.Black;
            this.branch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.branch.HoverState.Parent = this.branch;
            this.branch.Name = "branch";
            this.branch.PasswordChar = '\0';
            this.branch.PlaceholderText = "";
            this.branch.SelectedText = "";
            this.branch.ShadowDecoration.Parent = this.branch;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
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
            resources.ApplyResources(this.promotiondetails, "promotiondetails");
            this.promotiondetails.Multiline = true;
            this.promotiondetails.Name = "promotiondetails";
            this.promotiondetails.PasswordChar = '\0';
            this.promotiondetails.PlaceholderText = "";
            this.promotiondetails.SelectedText = "";
            this.promotiondetails.ShadowDecoration.Parent = this.promotiondetails;
            // 
            // enddate
            // 
            this.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.enddate, "enddate");
            this.enddate.Name = "enddate";
            // 
            // startdate
            // 
            this.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.startdate, "startdate");
            this.startdate.Name = "startdate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
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
            resources.ApplyResources(this.promotionname, "promotionname");
            this.promotionname.ForeColor = System.Drawing.Color.Black;
            this.promotionname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionname.HoverState.Parent = this.promotionname;
            this.promotionname.Name = "promotionname";
            this.promotionname.PasswordChar = '\0';
            this.promotionname.PlaceholderText = "";
            this.promotionname.SelectedText = "";
            this.promotionname.ShadowDecoration.Parent = this.promotionname;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
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
            resources.ApplyResources(this.promotioncode, "promotioncode");
            this.promotioncode.ForeColor = System.Drawing.Color.Black;
            this.promotioncode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotioncode.HoverState.Parent = this.promotioncode;
            this.promotioncode.Name = "promotioncode";
            this.promotioncode.PasswordChar = '\0';
            this.promotioncode.PlaceholderText = "";
            this.promotioncode.SelectedText = "";
            this.promotioncode.ShadowDecoration.Parent = this.promotioncode;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
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
            resources.ApplyResources(this.promotionpercentage, "promotionpercentage");
            this.promotionpercentage.ForeColor = System.Drawing.Color.Black;
            this.promotionpercentage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.promotionpercentage.HoverState.Parent = this.promotionpercentage;
            this.promotionpercentage.Name = "promotionpercentage";
            this.promotionpercentage.PasswordChar = '\0';
            this.promotionpercentage.PlaceholderText = "";
            this.promotionpercentage.SelectedText = "";
            this.promotionpercentage.ShadowDecoration.Parent = this.promotionpercentage;
            this.promotionpercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.promotionpercentage_KeyPress);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // SpecialDeal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpecialDeal";
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
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox promotiondetails;
        private Guna.UI2.WinForms.Guna2Button Backtodeal;
        private Guna.UI2.WinForms.Guna2Button save;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2TextBox promotionnamesearch;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox promotioncodesearch;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button Add;
        private Guna.UI2.WinForms.Guna2Button search;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ComboBox nutritionist;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn promotionnamedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn promotioncodedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn promotionpercentagedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn startdatedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn enddatedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn nutritionistdgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchdgv;
    }
}