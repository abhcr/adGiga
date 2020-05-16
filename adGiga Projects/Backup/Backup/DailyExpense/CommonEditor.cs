using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ShopKeeper
{
    public partial class CommonEditor : Form
    {
        public CommonEditor()
        {
            InitializeComponent();
        }
        Type _t;
        string _backUpDefault = string.Empty;
        public string GetValue(string subject, Type t, string defaultValue, bool allowCancel)
        {
            this.Text = subject;
            valueTextBox.Text = defaultValue;
            _backUpDefault = defaultValue;
            _t = t;
            cancelButton.Visible = allowCancel;
            this.ShowDialog();

            return valueTextBox.Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            valueTextBox.Text = _backUpDefault;
            this.Invalidate();
            Thread.Sleep(25);//display to user for an instant that the value is reverted.
            this.Close();
        }

        private void valueTextBox_Validating(object sender, CancelEventArgs e)
        {
            int intVar;
            double doubleVar;
            if (_t == typeof(int))
            {
                if (!Int32.TryParse(valueTextBox.Text, out intVar))
                {
                    e.Cancel = true;
                }
            }
            else if (_t == typeof(double))
            {
                if (!double.TryParse(valueTextBox.Text, out doubleVar))
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
