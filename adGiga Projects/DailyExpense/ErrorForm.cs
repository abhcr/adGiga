using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShopKeeper
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        public void ShowError(string message)
        {
            errorText.Text = message;
            errorText.SelectAll();
            this.ShowDialog();
        }
        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please open again");
            Application.Exit();
        }
    }
}
