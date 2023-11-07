
namespace HelloWorldSolutionIMS
{
    partial class OpeniningExport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.DGVBills = new Guna.UI2.WinForms.Guna2DataGridView();
            this.VoucherDateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonNameGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillBookNoGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNoGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueAmountGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidAmountGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTypeFilter = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbonameFilter = new System.Windows.Forms.ComboBox();
            this.txtBillNoFilter = new System.Windows.Forms.TextBox();
            this.txtBillBookFilter = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBills)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.DGVBills);
            this.panel2.Controls.Add(this.cboTypeFilter);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cbonameFilter);
            this.panel2.Controls.Add(this.txtBillNoFilter);
            this.panel2.Controls.Add(this.txtBillBookFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1300, 480);
            this.panel2.TabIndex = 2;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Teal;
            this.btnView.FlatAppearance.BorderSize = 2;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(526, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(87, 39);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "&VIEW";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MidnightBlue;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1115, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 39);
            this.button3.TabIndex = 7;
            this.button3.Text = "&PDF";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(944, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "SHOW  &UNPAID";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnShow.FlatAppearance.BorderSize = 2;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(774, 25);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(165, 39);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "&SHOW ALL PAID";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.IndianRed;
            this.btnClear.FlatAppearance.BorderSize = 2;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(619, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(149, 39);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "CLEA&R and ALL";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // DGVBills
            // 
            this.DGVBills.AllowUserToAddRows = false;
            this.DGVBills.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.DGVBills.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVBills.BackgroundColor = System.Drawing.Color.White;
            this.DGVBills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVBills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVBills.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVBills.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVBills.ColumnHeadersHeight = 30;
            this.DGVBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VoucherDateGV,
            this.PersonNameGV,
            this.BillBookNoGV,
            this.BillNoGV,
            this.DueAmountGV,
            this.PaidAmountGV,
            this.AddressGV});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVBills.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGVBills.EnableHeadersVisualStyles = false;
            this.DGVBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVBills.Location = new System.Drawing.Point(10, 67);
            this.DGVBills.Name = "DGVBills";
            this.DGVBills.ReadOnly = true;
            this.DGVBills.RowHeadersVisible = false;
            this.DGVBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVBills.Size = new System.Drawing.Size(1337, 283);
            this.DGVBills.TabIndex = 8;
            this.DGVBills.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.DGVBills.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVBills.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVBills.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVBills.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVBills.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVBills.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVBills.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVBills.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGVBills.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVBills.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVBills.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVBills.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVBills.ThemeStyle.HeaderStyle.Height = 30;
            this.DGVBills.ThemeStyle.ReadOnly = true;
            this.DGVBills.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVBills.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVBills.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVBills.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVBills.ThemeStyle.RowsStyle.Height = 22;
            this.DGVBills.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVBills.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // VoucherDateGV
            // 
            this.VoucherDateGV.HeaderText = "Date";
            this.VoucherDateGV.Name = "VoucherDateGV";
            this.VoucherDateGV.ReadOnly = true;
            // 
            // PersonNameGV
            // 
            this.PersonNameGV.HeaderText = "Name";
            this.PersonNameGV.Name = "PersonNameGV";
            this.PersonNameGV.ReadOnly = true;
            // 
            // BillBookNoGV
            // 
            this.BillBookNoGV.HeaderText = "Bill Book No";
            this.BillBookNoGV.Name = "BillBookNoGV";
            this.BillBookNoGV.ReadOnly = true;
            // 
            // BillNoGV
            // 
            this.BillNoGV.HeaderText = "Bill No";
            this.BillNoGV.Name = "BillNoGV";
            this.BillNoGV.ReadOnly = true;
            // 
            // DueAmountGV
            // 
            this.DueAmountGV.HeaderText = "Due Amount";
            this.DueAmountGV.Name = "DueAmountGV";
            this.DueAmountGV.ReadOnly = true;
            // 
            // PaidAmountGV
            // 
            this.PaidAmountGV.HeaderText = "Paid Amount";
            this.PaidAmountGV.Name = "PaidAmountGV";
            this.PaidAmountGV.ReadOnly = true;
            // 
            // AddressGV
            // 
            this.AddressGV.HeaderText = "Address";
            this.AddressGV.Name = "AddressGV";
            this.AddressGV.ReadOnly = true;
            // 
            // cboTypeFilter
            // 
            this.cboTypeFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTypeFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTypeFilter.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cboTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeFilter.ForeColor = System.Drawing.Color.White;
            this.cboTypeFilter.FormattingEnabled = true;
            this.cboTypeFilter.Location = new System.Drawing.Point(121, 11);
            this.cboTypeFilter.Name = "cboTypeFilter";
            this.cboTypeFilter.Size = new System.Drawing.Size(225, 21);
            this.cboTypeFilter.TabIndex = 0;
            this.cboTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cboTypeFilter_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(21, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Person Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(352, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 17;
            this.label13.Text = "Bill No";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(352, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Bill Book ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(21, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "Person Name";
            // 
            // cbonameFilter
            // 
            this.cbonameFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbonameFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbonameFilter.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cbonameFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbonameFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbonameFilter.ForeColor = System.Drawing.Color.White;
            this.cbonameFilter.FormattingEnabled = true;
            this.cbonameFilter.Location = new System.Drawing.Point(121, 40);
            this.cbonameFilter.Name = "cbonameFilter";
            this.cbonameFilter.Size = new System.Drawing.Size(225, 21);
            this.cbonameFilter.TabIndex = 1;
            // 
            // txtBillNoFilter
            // 
            this.txtBillNoFilter.Location = new System.Drawing.Point(424, 41);
            this.txtBillNoFilter.Name = "txtBillNoFilter";
            this.txtBillNoFilter.Size = new System.Drawing.Size(63, 20);
            this.txtBillNoFilter.TabIndex = 3;
            // 
            // txtBillBookFilter
            // 
            this.txtBillBookFilter.Location = new System.Drawing.Point(424, 9);
            this.txtBillBookFilter.Name = "txtBillBookFilter";
            this.txtBillBookFilter.Size = new System.Drawing.Size(63, 20);
            this.txtBillBookFilter.TabIndex = 3;
            // 
            // OpeniningExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 480);
            this.Controls.Add(this.panel2);
            this.Name = "OpeniningExport";
            this.Text = "OpeniningExport";
            this.Load += new System.EventHandler(this.OpeniningExport_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClear;
        private Guna.UI2.WinForms.Guna2DataGridView DGVBills;
        private System.Windows.Forms.ComboBox cboTypeFilter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbonameFilter;
        private System.Windows.Forms.TextBox txtBillNoFilter;
        private System.Windows.Forms.TextBox txtBillBookFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherDateGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonNameGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillBookNoGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNoGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueAmountGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmountGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressGV;
    }
}