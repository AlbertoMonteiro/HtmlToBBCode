using System;
using System.Windows.Forms;

namespace HtmlToBBCode.UI
{
    public partial class Form1 : Form
    {
	//Funfou doido 3
        private readonly HtmlToBBCode htmlToBBCode;

        public Form1()
        {
            InitializeComponent();
            htmlToBBCode = new HtmlToBBCode();
        }

        private void TxtHtmlTextChanged(object sender, EventArgs e)
        {
            txtBBCode.Text = htmlToBBCode.Convert(txtHtml.Text, Environment.CurrentDirectory);
        }

        private void TxtBBCodeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                var txt = (TextBox)sender;
                txt.SelectAll();
            }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBCode.Text);
            MessageBox.Show("BB Code copiado com sucesso", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
