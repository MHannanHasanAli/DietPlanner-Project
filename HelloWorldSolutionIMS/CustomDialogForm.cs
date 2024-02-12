using System;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class CustomDialogForm : Form
    {
        public CustomDialogForm()
        {
            InitializeComponent();
        }

        public string ConfirmationMessage
        {
            get { return labelMessage.Text; }
            set { labelMessage.Text = value; }
        }

        public DialogResult ShowDialogWithCustomButtons(string yesButtonText, string noButtonText)
        {
            buttonYes.Text = yesButtonText;
            buttonNo.Text = noButtonText;
            return this.ShowDialog();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
