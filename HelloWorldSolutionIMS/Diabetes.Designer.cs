﻿namespace HelloWorldSolutionIMS
{
    partial class Diabetes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.weight = new Guna.UI2.WinForms.Guna2TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.bloodsuger = new Guna.UI2.WinForms.Guna2TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.bolusinsulin = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.insulincharb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totalinsulin = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.baselineinsulin = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Add = new Guna.UI2.WinForms.Guna2Button();
            this.search = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.typedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insulindgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carbsdgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2DataGridView2 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dob = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.familyname = new Guna.UI2.WinForms.Guna2TextBox();
            this.firstname = new Guna.UI2.WinForms.Guna2TextBox();
            this.fileno = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // weight
            // 
            this.weight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.weight.DefaultText = "";
            this.weight.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.weight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.weight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.weight.DisabledState.Parent = this.weight;
            this.weight.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.weight.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.weight.FocusedState.Parent = this.weight;
            this.weight.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.weight.ForeColor = System.Drawing.Color.Black;
            this.weight.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.weight.HoverState.Parent = this.weight;
            this.weight.Location = new System.Drawing.Point(201, 124);
            this.weight.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.weight.Name = "weight";
            this.weight.PasswordChar = '\0';
            this.weight.PlaceholderText = "";
            this.weight.SelectedText = "";
            this.weight.ShadowDecoration.Parent = this.weight;
            this.weight.Size = new System.Drawing.Size(232, 32);
            this.weight.TabIndex = 277;
            this.weight.TextChanged += new System.EventHandler(this.weight_TextChanged);
            this.weight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatlock);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label28.Location = new System.Drawing.Point(42, 124);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 24);
            this.label28.TabIndex = 276;
            this.label28.Text = "Weight";
            // 
            // bloodsuger
            // 
            this.bloodsuger.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bloodsuger.DefaultText = "";
            this.bloodsuger.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.bloodsuger.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.bloodsuger.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bloodsuger.DisabledState.Parent = this.bloodsuger;
            this.bloodsuger.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bloodsuger.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bloodsuger.FocusedState.Parent = this.bloodsuger;
            this.bloodsuger.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bloodsuger.ForeColor = System.Drawing.Color.Black;
            this.bloodsuger.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bloodsuger.HoverState.Parent = this.bloodsuger;
            this.bloodsuger.Location = new System.Drawing.Point(201, 168);
            this.bloodsuger.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bloodsuger.Name = "bloodsuger";
            this.bloodsuger.PasswordChar = '\0';
            this.bloodsuger.PlaceholderText = "";
            this.bloodsuger.SelectedText = "";
            this.bloodsuger.ShadowDecoration.Parent = this.bloodsuger;
            this.bloodsuger.Size = new System.Drawing.Size(232, 32);
            this.bloodsuger.TabIndex = 275;
            this.bloodsuger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatlock);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label29.Location = new System.Drawing.Point(42, 168);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(115, 24);
            this.label29.TabIndex = 274;
            this.label29.Text = "Blood Suger";
            // 
            // bolusinsulin
            // 
            this.bolusinsulin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bolusinsulin.DefaultText = "";
            this.bolusinsulin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.bolusinsulin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.bolusinsulin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bolusinsulin.DisabledState.Parent = this.bolusinsulin;
            this.bolusinsulin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bolusinsulin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bolusinsulin.FocusedState.Parent = this.bolusinsulin;
            this.bolusinsulin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bolusinsulin.ForeColor = System.Drawing.Color.Black;
            this.bolusinsulin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bolusinsulin.HoverState.Parent = this.bolusinsulin;
            this.bolusinsulin.Location = new System.Drawing.Point(836, 219);
            this.bolusinsulin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bolusinsulin.Name = "bolusinsulin";
            this.bolusinsulin.PasswordChar = '\0';
            this.bolusinsulin.PlaceholderText = "";
            this.bolusinsulin.SelectedText = "";
            this.bolusinsulin.ShadowDecoration.Parent = this.bolusinsulin;
            this.bolusinsulin.Size = new System.Drawing.Size(232, 32);
            this.bolusinsulin.TabIndex = 281;
            this.bolusinsulin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatlock);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(677, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 280;
            this.label1.Text = "Bolus Insulin";
            // 
            // insulincharb
            // 
            this.insulincharb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.insulincharb.DefaultText = "";
            this.insulincharb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.insulincharb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.insulincharb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.insulincharb.DisabledState.Parent = this.insulincharb;
            this.insulincharb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.insulincharb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.insulincharb.FocusedState.Parent = this.insulincharb;
            this.insulincharb.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.insulincharb.ForeColor = System.Drawing.Color.Black;
            this.insulincharb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.insulincharb.HoverState.Parent = this.insulincharb;
            this.insulincharb.Location = new System.Drawing.Point(836, 263);
            this.insulincharb.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.insulincharb.Name = "insulincharb";
            this.insulincharb.PasswordChar = '\0';
            this.insulincharb.PlaceholderText = "";
            this.insulincharb.SelectedText = "";
            this.insulincharb.ShadowDecoration.Parent = this.insulincharb;
            this.insulincharb.Size = new System.Drawing.Size(232, 32);
            this.insulincharb.TabIndex = 279;
            this.insulincharb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatlock);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(677, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 278;
            this.label2.Text = "Insulin: Charb";
            // 
            // totalinsulin
            // 
            this.totalinsulin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.totalinsulin.DefaultText = "";
            this.totalinsulin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.totalinsulin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.totalinsulin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.totalinsulin.DisabledState.Parent = this.totalinsulin;
            this.totalinsulin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.totalinsulin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.totalinsulin.FocusedState.Parent = this.totalinsulin;
            this.totalinsulin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.totalinsulin.ForeColor = System.Drawing.Color.Black;
            this.totalinsulin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.totalinsulin.HoverState.Parent = this.totalinsulin;
            this.totalinsulin.Location = new System.Drawing.Point(836, 131);
            this.totalinsulin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.totalinsulin.Name = "totalinsulin";
            this.totalinsulin.PasswordChar = '\0';
            this.totalinsulin.PlaceholderText = "";
            this.totalinsulin.SelectedText = "";
            this.totalinsulin.ShadowDecoration.Parent = this.totalinsulin;
            this.totalinsulin.Size = new System.Drawing.Size(232, 32);
            this.totalinsulin.TabIndex = 285;
            this.totalinsulin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatlock);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(677, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 24);
            this.label3.TabIndex = 284;
            this.label3.Text = "Total Insulin/Day";
            // 
            // baselineinsulin
            // 
            this.baselineinsulin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.baselineinsulin.DefaultText = "";
            this.baselineinsulin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.baselineinsulin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.baselineinsulin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.baselineinsulin.DisabledState.Parent = this.baselineinsulin;
            this.baselineinsulin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.baselineinsulin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.baselineinsulin.FocusedState.Parent = this.baselineinsulin;
            this.baselineinsulin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.baselineinsulin.ForeColor = System.Drawing.Color.Black;
            this.baselineinsulin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.baselineinsulin.HoverState.Parent = this.baselineinsulin;
            this.baselineinsulin.Location = new System.Drawing.Point(836, 175);
            this.baselineinsulin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.baselineinsulin.Name = "baselineinsulin";
            this.baselineinsulin.PasswordChar = '\0';
            this.baselineinsulin.PlaceholderText = "";
            this.baselineinsulin.SelectedText = "";
            this.baselineinsulin.ShadowDecoration.Parent = this.baselineinsulin;
            this.baselineinsulin.Size = new System.Drawing.Size(232, 32);
            this.baselineinsulin.TabIndex = 283;
            this.baselineinsulin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatlock);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(677, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 24);
            this.label4.TabIndex = 282;
            this.label4.Text = "Baseline Insulin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(441, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 24);
            this.label5.TabIndex = 286;
            this.label5.Text = "Kg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(441, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 24);
            this.label6.TabIndex = 287;
            this.label6.Text = "ML/L";
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
            this.Add.Location = new System.Drawing.Point(275, 250);
            this.Add.Name = "Add";
            this.Add.ShadowDecoration.Parent = this.Add;
            this.Add.Size = new System.Drawing.Size(199, 45);
            this.Add.TabIndex = 289;
            this.Add.Text = "Calculate By Carbs";
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
            this.search.Location = new System.Drawing.Point(49, 250);
            this.search.Name = "search";
            this.search.ShadowDecoration.Parent = this.search;
            this.search.Size = new System.Drawing.Size(199, 45);
            this.search.TabIndex = 288;
            this.search.Text = "Calculate By Insulin";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
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
            this.guna2DataGridView1.ColumnHeadersHeight = 27;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typedgv,
            this.insulindgv,
            this.carbsdgv});
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
            this.guna2DataGridView1.Location = new System.Drawing.Point(49, 326);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1019, 341);
            this.guna2DataGridView1.TabIndex = 290;
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
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 27;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellValueChanged);
            // 
            // typedgv
            // 
            this.typedgv.HeaderText = "TYPE";
            this.typedgv.MinimumWidth = 6;
            this.typedgv.Name = "typedgv";
            // 
            // insulindgv
            // 
            this.insulindgv.HeaderText = "INSULIN UNIT";
            this.insulindgv.MinimumWidth = 6;
            this.insulindgv.Name = "insulindgv";
            // 
            // carbsdgv
            // 
            this.carbsdgv.HeaderText = "CARBS (GRAMS)";
            this.carbsdgv.MinimumWidth = 6;
            this.carbsdgv.Name = "carbsdgv";
            // 
            // guna2DataGridView2
            // 
            this.guna2DataGridView2.AllowUserToAddRows = false;
            this.guna2DataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView2.ColumnHeadersHeight = 27;
            this.guna2DataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView2.DefaultCellStyle = dataGridViewCellStyle7;
            this.guna2DataGridView2.EnableHeadersVisualStyles = false;
            this.guna2DataGridView2.GridColor = System.Drawing.Color.Black;
            this.guna2DataGridView2.Location = new System.Drawing.Point(46, 326);
            this.guna2DataGridView2.Name = "guna2DataGridView2";
            this.guna2DataGridView2.RowHeadersVisible = false;
            this.guna2DataGridView2.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.guna2DataGridView2.RowTemplate.Height = 24;
            this.guna2DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView2.Size = new System.Drawing.Size(1019, 341);
            this.guna2DataGridView2.TabIndex = 291;
            this.guna2DataGridView2.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WhiteGrid;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.Height = 27;
            this.guna2DataGridView2.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.guna2DataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView2_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "TYPE";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "CARBS (GRAMS)";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "INSULIN UNIT";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dob
            // 
            this.dob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dob.Location = new System.Drawing.Point(836, 81);
            this.dob.Name = "dob";
            this.dob.Size = new System.Drawing.Size(232, 22);
            this.dob.TabIndex = 296;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(677, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 24);
            this.label7.TabIndex = 301;
            this.label7.Text = "D.O.B";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label9.Location = new System.Drawing.Point(677, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 24);
            this.label9.TabIndex = 299;
            this.label9.Text = "Family Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label10.Location = new System.Drawing.Point(45, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 24);
            this.label10.TabIndex = 298;
            this.label10.Text = "First Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label11.Location = new System.Drawing.Point(45, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 24);
            this.label11.TabIndex = 297;
            this.label11.Text = "File No.";
            // 
            // familyname
            // 
            this.familyname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.familyname.DefaultText = "";
            this.familyname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.familyname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.familyname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.familyname.DisabledState.Parent = this.familyname;
            this.familyname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.familyname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.familyname.FocusedState.Parent = this.familyname;
            this.familyname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.familyname.ForeColor = System.Drawing.Color.Black;
            this.familyname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.familyname.HoverState.Parent = this.familyname;
            this.familyname.Location = new System.Drawing.Point(836, 27);
            this.familyname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.familyname.Name = "familyname";
            this.familyname.PasswordChar = '\0';
            this.familyname.PlaceholderText = "";
            this.familyname.SelectedText = "";
            this.familyname.ShadowDecoration.Parent = this.familyname;
            this.familyname.Size = new System.Drawing.Size(232, 38);
            this.familyname.TabIndex = 294;
            // 
            // firstname
            // 
            this.firstname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.firstname.DefaultText = "";
            this.firstname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.firstname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.firstname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.firstname.DisabledState.Parent = this.firstname;
            this.firstname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.firstname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.firstname.FocusedState.Parent = this.firstname;
            this.firstname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.firstname.ForeColor = System.Drawing.Color.Black;
            this.firstname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.firstname.HoverState.Parent = this.firstname;
            this.firstname.Location = new System.Drawing.Point(201, 74);
            this.firstname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.firstname.Name = "firstname";
            this.firstname.PasswordChar = '\0';
            this.firstname.PlaceholderText = "";
            this.firstname.SelectedText = "";
            this.firstname.ShadowDecoration.Parent = this.firstname;
            this.firstname.Size = new System.Drawing.Size(232, 38);
            this.firstname.TabIndex = 293;
            // 
            // fileno
            // 
            this.fileno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileno.DefaultText = "";
            this.fileno.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.fileno.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.fileno.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fileno.DisabledState.Parent = this.fileno;
            this.fileno.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fileno.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fileno.FocusedState.Parent = this.fileno;
            this.fileno.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.fileno.ForeColor = System.Drawing.Color.Black;
            this.fileno.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fileno.HoverState.Parent = this.fileno;
            this.fileno.Location = new System.Drawing.Point(201, 24);
            this.fileno.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.fileno.Name = "fileno";
            this.fileno.PasswordChar = '\0';
            this.fileno.PlaceholderText = "";
            this.fileno.SelectedText = "";
            this.fileno.ShadowDecoration.Parent = this.fileno;
            this.fileno.Size = new System.Drawing.Size(232, 38);
            this.fileno.TabIndex = 292;
            this.fileno.TextChanged += new System.EventHandler(this.fileno_TextChanged);
            this.fileno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intlock);
            // 
            // Diabetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1122, 794);
            this.Controls.Add(this.dob);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.familyname);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.fileno);
            this.Controls.Add(this.guna2DataGridView2);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalinsulin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baselineinsulin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bolusinsulin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.insulincharb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.weight);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.bloodsuger);
            this.Controls.Add(this.label29);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Diabetes";
            this.Text = "Diabetes";
            this.Load += new System.EventHandler(this.Diabetes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox weight;
        private System.Windows.Forms.Label label28;
        private Guna.UI2.WinForms.Guna2TextBox bloodsuger;
        private System.Windows.Forms.Label label29;
        private Guna.UI2.WinForms.Guna2TextBox bolusinsulin;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox insulincharb;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox totalinsulin;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox baselineinsulin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button Add;
        private Guna.UI2.WinForms.Guna2Button search;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn insulindgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn carbsdgv;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DateTimePicker dob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox familyname;
        private Guna.UI2.WinForms.Guna2TextBox firstname;
        private Guna.UI2.WinForms.Guna2TextBox fileno;
    }
}