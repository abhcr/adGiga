using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Business;
using System.Reflection;

namespace ShopKeeper
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            versionInfo.Text = Assembly.GetExecutingAssembly().GetName().Name + " Version " +
                Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public bool VerifyAndConnect()
        {
            if (Properties.Settings.Default.DataFilePath == Properties.Settings.Default.NotSet)
            {
                Properties.Settings.Default.DataFilePath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                    Properties.Settings.Default.DataFileName);
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.Password == Properties.Settings.Default.NotSet)
            {
                //if password not set, get a password from the user and set it.
                Properties.Settings.Default.Password = (new Password()).GetNewPassword();
            }
            if (Properties.Settings.Default.DataFilePath.Contains(".mdb"))
            {
                if (File.Exists(Properties.Settings.Default.DataFilePath))
                {
                    openFileDialog.FileName = Properties.Settings.Default.DataFilePath;
                    dataSelect.Text = Properties.Settings.Default.DataFilePath;
                    ok.Enabled = true;
                    message.Text = string.Empty;
                }
                else
                {
                    dataSelect.Text = "Click here to select a data file";
                    ok.Enabled = false;
                    message.Text = "(I tried but failed connecting: " + Properties.Settings.Default.DataFilePath  + ")";
                }
            }
            this.ShowDialog();



            if (textBox1.Text == Properties.Settings.Default.Password && CheckFile() && !cancelled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DataFilePath = dataSelect.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void dataSelect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = "mdb";
            openFileDialog.Multiselect = false;
            openFileDialog.AddExtension = true;
            //openFileDialog.AutoUpgradeEnabled = true;
            PropertyInfo property = typeof(FileDialog).GetProperty("AutoUpgradeEnabled");
            if (property != null) { property.SetValue(openFileDialog, false, null); }
            if (ok.Enabled)
            {
                openFileDialog.FileName = Path.GetFileName(dataSelect.Text);
                openFileDialog.InitialDirectory = Path.GetDirectoryName(dataSelect.Text);
            }
            else
            {
                if (Directory.Exists(Path.Combine("C:", "Data")))
                {
                    openFileDialog.InitialDirectory = Path.Combine("C:", "Data");
                }
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CheckFile();
            }
        }
        private bool CheckFile()
        {
            bool retry = true;
            while (retry)
            {
                try
                {
                    (new CommonManager()).SetDataLocation(openFileDialog.FileName);
                    retry = false;
                    if ((new CommonManager().IsDataValid()))
                    {
                        message.Text = string.Empty;
                        dataSelect.Text = openFileDialog.FileName;
                        ok.Enabled = true;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("File selected is invalid", "Please select a valid file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    if (DialogResult.Retry == MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException.Message,
                        "Please select a valid file", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
                    {
                        retry = true;
                    }
                    else
                    {
                        retry = false;
                    }
                }
            }
            return false;//dummy return statement to satisfy visual studio
        }
        bool cancelled = false;
        private void cancel_Click(object sender, EventArgs e)
        {
            cancelled = true;
            this.Close();
        }

    }

}