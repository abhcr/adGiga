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
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
        }

        public string GetItemNameFromUser(DateTime startDate, DateTime endDate)
        {
            string[] reportLines = (new CommonManager()).GetItemWiseSaleReport(startDate, endDate).Split('\n');

            for (int i = 1; i < reportLines.Length; i++)
            {
                string[] reportCells = reportLines[i].Split('\t');
                if (reportCells.Length == 4)
                {
                    itemGrid.Rows.Add(i + 1, reportCells[0], reportCells[2], reportCells[3], reportCells[1]);
                }
                else
                {
                    continue;
                }
            }
            itemGrid.Refresh();
            if (reportLines.Length == 0)
            {
                return "";
            }
            else
            {
                this.Refresh();
                this.ShowDialog();
                return itemGrid.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Items_Load(object sender, EventArgs e)
        {

        }
    }
}