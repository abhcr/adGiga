using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SoftwareLocker;

namespace ShopKeeper
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        internal string GetNewPassword()
        {
            if (Properties.Settings.Default.Password == Properties.Settings.Default.NotSet)
            {
                oldPassword.Enabled = false;
                oldPassword.Text = Properties.Settings.Default.Password;
            }
            this.ShowDialog();

            return repeat.Text;
        }


        private void repeat_TextChanged(object sender, EventArgs e)
        {
            if (repeat.Text != string.Empty && repeat.Text == newPassword.Text)
            {
                ok.Enabled = true;
            }
            else
            {
                ok.Enabled = false;
            }
        }

        private void newPassword_TextChanged(object sender, EventArgs e)
        {
            if (newPassword.Text != string.Empty && repeat.Text == newPassword.Text)
            {
                ok.Enabled = true;
            }
            else
            {
                ok.Enabled = false;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Password != oldPassword.Text)
            {
                MessageBox.Show("Incorrect old password", "adGiga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oldPassword.Text = string.Empty;
                oldPassword.Focus();
            }
            else
            {
                MessageBox.Show("New password saved", "adGiga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            repeat.Text = Properties.Settings.Default.Password;
        }
    }
}
