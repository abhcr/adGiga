using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataObjects;
using Business;

namespace ShopKeeper
{
    public partial class AddNewProject : Form
    {
        public AddNewProject()
        {
            InitializeComponent();
        }
        Project p;
        internal Project GetNewProject(string name, DateTime startDate)
        {
            projectName.Text = name;
            datePicker.Value = startDate;

            ok.Focus();
            this.ShowDialog();

            return p;

        }

        private void ok_Click(object sender, EventArgs e)
        {
            p = new Project();
            p.Name = projectName.Text;
            p.StartDate = datePicker.Value;
            p.Comment = comment.Text;

            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            p = (new ProjectManager()).GetProject(string.Empty);
            this.Close();
        }
    }
}
