namespace HelloWorldSolutionIMS
{
    partial class Instruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instruction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nutritionistname = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Search = new Guna.UI2.WinForms.Guna2Button();
            this.New = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.nodgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructionnamedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nutritionistnamedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.instructionbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.instructionname = new Guna.UI2.WinForms.Guna2TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.nutritionistname);
            this.panel1.Controls.Add(this.Search);
            this.panel1.Controls.Add(this.New);
            this.panel1.Controls.Add(this.guna2DataGridView1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.instructionbox);
            this.panel1.Controls.Add(this.date);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.instructionname);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // nutritionistname
            // 
            this.nutritionistname.BackColor = System.Drawing.Color.Transparent;
            this.nutritionistname.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.nutritionistname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nutritionistname.FocusedColor = System.Drawing.Color.Empty;
            this.nutritionistname.FocusedState.Parent = this.nutritionistname;
            resources.ApplyResources(this.nutritionistname, "nutritionistname");
            this.nutritionistname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.nutritionistname.FormattingEnabled = true;
            this.nutritionistname.HoverState.Parent = this.nutritionistname;
            this.nutritionistname.ItemsAppearance.Parent = this.nutritionistname;
            this.nutritionistname.Name = "nutritionistname";
            this.nutritionistname.ShadowDecoration.Parent = this.nutritionistname;
            // 
            // Search
            // 
            this.Search.AutoRoundedCorners = true;
            this.Search.BorderRadius = 21;
            this.Search.CheckedState.Parent = this.Search;
            this.Search.CustomImages.Parent = this.Search;
            this.Search.FillColor = System.Drawing.Color.MediumSeaGreen;
            resources.ApplyResources(this.Search, "Search");
            this.Search.ForeColor = System.Drawing.Color.White;
            this.Search.HoverState.Parent = this.Search;
            this.Search.Name = "Search";
            this.Search.ShadowDecoration.Parent = this.Search;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // New
            // 
            this.New.AutoRoundedCorners = true;
            this.New.BorderRadius = 21;
            this.New.CausesValidation = false;
            this.New.CheckedState.Parent = this.New;
            this.New.CustomImages.Parent = this.New;
            this.New.FillColor = System.Drawing.Color.MediumSeaGreen;
            resources.ApplyResources(this.New, "New");
            this.New.ForeColor = System.Drawing.Color.White;
            this.New.HoverState.Parent = this.New;
            this.New.Name = "New";
            this.New.ShadowDecoration.Parent = this.New;
            this.New.Click += new System.EventHandler(this.New_Click);
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
            resources.ApplyResources(this.guna2DataGridView1, "guna2DataGridView1");
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nodgv,
            this.instructionnamedgv,
            this.nutritionistnamedgv,
            this.datedgv});
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
            this.guna2DataGridView1.ReadOnly = true;
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
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 27;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // nodgv
            // 
            this.nodgv.FillWeight = 104.2909F;
            resources.ApplyResources(this.nodgv, "nodgv");
            this.nodgv.Name = "nodgv";
            this.nodgv.ReadOnly = true;
            // 
            // instructionnamedgv
            // 
            this.instructionnamedgv.FillWeight = 95.2524F;
            resources.ApplyResources(this.instructionnamedgv, "instructionnamedgv");
            this.instructionnamedgv.Name = "instructionnamedgv";
            this.instructionnamedgv.ReadOnly = true;
            // 
            // nutritionistnamedgv
            // 
            this.nutritionistnamedgv.FillWeight = 95.2524F;
            resources.ApplyResources(this.nutritionistnamedgv, "nutritionistnamedgv");
            this.nutritionistnamedgv.Name = "nutritionistnamedgv";
            this.nutritionistnamedgv.ReadOnly = true;
            // 
            // datedgv
            // 
            this.datedgv.FillWeight = 95.2524F;
            resources.ApplyResources(this.datedgv, "datedgv");
            this.datedgv.Name = "datedgv";
            this.datedgv.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // instructionbox
            // 
            this.instructionbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.instructionbox.DefaultText = "";
            this.instructionbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.instructionbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.instructionbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.instructionbox.DisabledState.Parent = this.instructionbox;
            this.instructionbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.instructionbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.instructionbox.FocusedState.Parent = this.instructionbox;
            this.instructionbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.instructionbox.HoverState.Parent = this.instructionbox;
            resources.ApplyResources(this.instructionbox, "instructionbox");
            this.instructionbox.Multiline = true;
            this.instructionbox.Name = "instructionbox";
            this.instructionbox.PasswordChar = '\0';
            this.instructionbox.PlaceholderText = "";
            this.instructionbox.SelectedText = "";
            this.instructionbox.ShadowDecoration.Parent = this.instructionbox;
            // 
            // date
            // 
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.date, "date");
            this.date.Name = "date";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // instructionname
            // 
            this.instructionname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.instructionname.DefaultText = "";
            this.instructionname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.instructionname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.instructionname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.instructionname.DisabledState.Parent = this.instructionname;
            this.instructionname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.instructionname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.instructionname.FocusedState.Parent = this.instructionname;
            resources.ApplyResources(this.instructionname, "instructionname");
            this.instructionname.ForeColor = System.Drawing.Color.Black;
            this.instructionname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.instructionname.HoverState.Parent = this.instructionname;
            this.instructionname.Name = "instructionname";
            this.instructionname.PasswordChar = '\0';
            this.instructionname.PlaceholderText = "";
            this.instructionname.SelectedText = "";
            this.instructionname.ShadowDecoration.Parent = this.instructionname;
            // 
            // Instruction
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Instruction";
            this.Load += new System.EventHandler(this.Instruction_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button Search;
        private Guna.UI2.WinForms.Guna2Button New;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructionnamedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn nutritionistnamedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn datedgv;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox instructionbox;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox instructionname;
        private Guna.UI2.WinForms.Guna2ComboBox nutritionistname;
    }
}