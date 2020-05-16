using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business;

namespace ShopKeeper
{
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        public string GetExpenseItemFromUser(DateTime startTime, DateTime endTime)
        {
            string[] reportLines = (new CommonManager()).GetExpenseSummary(startTime, endTime).Split('\n');

            for (int i = 1; i < reportLines.Length; i++)
            {
                string[] reportCells = reportLines[i].Split('\t');
                if (reportCells.Length == 2)
                {
                    expenseGrid.Rows.Add(i + 1, reportCells[0], reportCells[1]);
                }
                else
                {
                    continue;
                }
            }
            expenseGrid.Refresh();

            this.Refresh();
            this.ShowDialog();
            if (expenseGrid.SelectedRows.Count == 1)
            {
                return expenseGrid.SelectedRows[0].Cells[1].Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (expenseGrid.SelectedRows.Count == 1)
            {
                this.Close();
            }
        }
    }
}