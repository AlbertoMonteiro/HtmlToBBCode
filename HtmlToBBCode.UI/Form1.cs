using System;
using System.Windows.Forms;

namespace HtmlToBBCode.UI
{
    public partial class Form1 : Form
    {
        private HtmlToBBCode htmlToBBCode;

        public Form1()
        {
            InitializeComponent();
            htmlToBBCode = new HtmlToBBCode();
        }

        private void txtHtml_TextChanged(object sender, EventArgs e)
        {
            txtBBCode.Text = htmlToBBCode.Convert(txtHtml.Text);
        }

        private void txtBBCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                var txt = (TextBox)sender;
                txt.SelectAll();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBCode.Text);
            MessageBox.Show("BB Code copiado com sucesso", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
