using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoftwareLocker
{
    public partial class RegistrationForm : Form
    {
        private string _Pass;

        public RegistrationForm(string BaseString,
            string Password,int DaysToEnd,int ran, string info)
        {
            InitializeComponent();
            _Pass = Password;
            lblDays.Text = DaysToEnd.ToString() + " Day(s)";
            lblTimes.Text = ran.ToString() + " Time(s)";
            lblText.Text = info;
            if (DaysToEnd <= 0 || ran <= 0)
            {
                lblDays.Text = "Finished";
                lblTimes.Text = "Finished";
                btnTrial.Enabled = false;
            }

            //sebPassword.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (true)//_Pass == sebPassword.Text)
            {
                MessageBox.Show("Password is correct", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Password is incorrect", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }
    }
}