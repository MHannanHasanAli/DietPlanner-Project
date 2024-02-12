namespace HelloWorldSolutionIMS
{
    partial class CustomDialogForm
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonNo = new Guna.UI2.WinForms.Guna2Button();
            this.buttonYes = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(37, 82);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(631, 32);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Are you sure you want to exit the application?";
            // 
            // buttonNo
            // 
            this.buttonNo.CheckedState.Parent = this.buttonNo;
            this.buttonNo.CustomImages.Parent = this.buttonNo;
            this.buttonNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonNo.ForeColor = System.Drawing.Color.White;
            this.buttonNo.HoverState.Parent = this.buttonNo;
            this.buttonNo.Location = new System.Drawing.Point(570, 239);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.ShadowDecoration.Parent = this.buttonNo;
            this.buttonNo.Size = new System.Drawing.Size(180, 45);
            this.buttonNo.TabIndex = 1;
            this.buttonNo.Text = "No";
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.CheckedState.Parent = this.buttonYes;
            this.buttonYes.CustomImages.Parent = this.buttonYes;
            this.buttonYes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonYes.ForeColor = System.Drawing.Color.White;
            this.buttonYes.HoverState.Parent = this.buttonYes;
            this.buttonYes.Location = new System.Drawing.Point(372, 239);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.ShadowDecoration.Parent = this.buttonYes;
            this.buttonYes.Size = new System.Drawing.Size(180, 45);
            this.buttonYes.TabIndex = 2;
            this.buttonYes.Text = "Yes";
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // CustomDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 308);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.labelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CstomDialogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private Guna.UI2.WinForms.Guna2Button buttonNo;
        private Guna.UI2.WinForms.Guna2Button buttonYes;
    }
}