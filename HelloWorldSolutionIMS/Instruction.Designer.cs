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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nutritionistname = new Guna.UI2.WinForms.Guna2TextBox();
            this.instructionname = new Guna.UI2.WinForms.Guna2TextBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.instructionbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.nodgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructionnamedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nutritionistnamedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datedgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.New = new Guna.UI2.WinForms.Guna2Button();
            this.Search = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(18, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nutritionist Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(28, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Instruction Name";
            // 
            // nutritionistname
            // 
            this.nutritionistname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nutritionistname.DefaultText = "";
            this.nutritionistname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nutritionistname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nutritionistname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nutritionistname.DisabledState.Parent = this.nutritionistname;
            this.nutritionistname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nutritionistname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nutritionistname.FocusedState.Parent = this.nutritionistname;
            this.nutritionistname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nutritionistname.ForeColor = System.Drawing.Color.Black;
            this.nutritionistname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nutritionistname.HoverState.Parent = this.nutritionistname;
            this.nutritionistname.Location = new System.Drawing.Point(188, 102);
            this.nutritionistname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nutritionistname.Name = "nutritionistname";
            this.nutritionistname.PasswordChar = '\0';
            this.nutritionistname.PlaceholderText = "";
            this.nutritionistname.SelectedText = "";
            this.nutritionistname.ShadowDecoration.Parent = this.nutritionistname;
            this.nutritionistname.Size = new System.Drawing.Size(268, 38);
            this.nutritionistname.TabIndex = 20;
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
            this.instructionname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.instructionname.ForeColor = System.Drawing.Color.Black;
            this.instructionname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.instructionname.HoverState.Parent = this.instructionname;
            this.instructionname.Location = new System.Drawing.Point(188, 52);
            this.instructionname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.instructionname.Name = "instructionname";
            this.instructionname.PasswordChar = '\0';
            this.instructionname.PlaceholderText = "";
            this.instructionname.SelectedText = "";
            this.instructionname.ShadowDecoration.Parent = this.instructionname;
            this.instructionname.Size = new System.Drawing.Size(268, 38);
            this.instructionname.TabIndex = 19;
            // 
            // date
            // 
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(546, 118);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(268, 22);
            this.date.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(492, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 42;
            this.label5.Text = "Date";
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
            this.instructionbox.Location = new System.Drawing.Point(188, 163);
            this.instructionbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.instructionbox.Multiline = true;
            this.instructionbox.Name = "instructionbox";
            this.instructionbox.PasswordChar = '\0';
            this.instructionbox.PlaceholderText = "";
            this.instructionbox.SelectedText = "";
            this.instructionbox.ShadowDecoration.Parent = this.instructionbox;
            this.instructionbox.Size = new System.Drawing.Size(889, 187);
            this.instructionbox.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(77, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 24);
            this.label3.TabIndex = 45;
            this.label3.Text = "Instruction";
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
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
            this.guna2DataGridView1.ColumnHeadersHeight = 27;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nodgv,
            this.instructionnamedgv,
            this.nutritionistnamedgv,
            this.datedgv});
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
            this.guna2DataGridView1.Location = new System.Drawing.Point(188, 422);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Size = new System.Drawing.Size(889, 398);
            this.guna2DataGridView1.TabIndex = 46;
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
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 27;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(221)))), ((int)(((byte)(160)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // nodgv
            // 
            this.nodgv.FillWeight = 104.2909F;
            this.nodgv.HeaderText = "NO";
            this.nodgv.MinimumWidth = 6;
            this.nodgv.Name = "nodgv";
            this.nodgv.ReadOnly = true;
            // 
            // instructionnamedgv
            // 
            this.instructionnamedgv.FillWeight = 95.2524F;
            this.instructionnamedgv.HeaderText = "INSTRUCTION NAME";
            this.instructionnamedgv.MinimumWidth = 6;
            this.instructionnamedgv.Name = "instructionnamedgv";
            this.instructionnamedgv.ReadOnly = true;
            // 
            // nutritionistnamedgv
            // 
            this.nutritionistnamedgv.FillWeight = 95.2524F;
            this.nutritionistnamedgv.HeaderText = "NUTRITIONIST NAME";
            this.nutritionistnamedgv.MinimumWidth = 6;
            this.nutritionistnamedgv.Name = "nutritionistnamedgv";
            this.nutritionistnamedgv.ReadOnly = true;
            // 
            // datedgv
            // 
            this.datedgv.FillWeight = 95.2524F;
            this.datedgv.HeaderText = "DATE";
            this.datedgv.MinimumWidth = 6;
            this.datedgv.Name = "datedgv";
            this.datedgv.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 52);
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
            // New
            // 
            this.New.AutoRoundedCorners = true;
            this.New.BorderRadius = 21;
            this.New.CausesValidation = false;
            this.New.CheckedState.Parent = this.New;
            this.New.CustomImages.Parent = this.New;
            this.New.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.New.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.New.ForeColor = System.Drawing.Color.White;
            this.New.HoverState.Parent = this.New;
            this.New.Location = new System.Drawing.Point(188, 356);
            this.New.Name = "New";
            this.New.ShadowDecoration.Parent = this.New;
            this.New.Size = new System.Drawing.Size(220, 45);
            this.New.TabIndex = 48;
            this.New.Text = "Save Instruction";
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // Search
            // 
            this.Search.AutoRoundedCorners = true;
            this.Search.BorderRadius = 21;
            this.Search.CheckedState.Parent = this.Search;
            this.Search.CustomImages.Parent = this.Search;
            this.Search.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.Search.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Search.ForeColor = System.Drawing.Color.White;
            this.Search.HoverState.Parent = this.Search;
            this.Search.Location = new System.Drawing.Point(857, 357);
            this.Search.Name = "Search";
            this.Search.ShadowDecoration.Parent = this.Search;
            this.Search.Size = new System.Drawing.Size(220, 45);
            this.Search.TabIndex = 49;
            this.Search.Text = "Search Instruction";
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Instruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 832);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.New);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.instructionbox);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nutritionistname);
            this.Controls.Add(this.instructionname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Instruction";
            this.Text = "Instruction";
            this.Load += new System.EventHandler(this.Instruction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox nutritionistname;
        private Guna.UI2.WinForms.Guna2TextBox instructionname;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox instructionbox;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button New;
        private Guna.UI2.WinForms.Guna2Button Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructionnamedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn nutritionistnamedgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn datedgv;
    }
}