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
    public partial class Debtors : Form
    {
        public Debtors()
        {
            InitializeComponent();
            this.Text = "Select a customer below";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //set title text
            this.Text = "Double Click on customer for details";
        }

        private void customerGrid_DoubleClick(object sender, EventArgs e)
        {
            if (customerGrid.SelectedRows.Count == 1)
            {
                int selectedId = int.Parse(customerGrid.SelectedRows[0].Cells[0].Value.ToString());
                SalesHistory salesHistoryForm = new SalesHistory();
                salesHistoryForm.ShowHistory(selectedId, customerGrid.SelectedRows[0].Cells[1].Value.ToString(),
                    startDate);
                salesHistoryForm.Dispose();
            }
        }

        private void Creditors_Load(object sender, EventArgs e)
        {
            //load data
            
            CustomerManager cm = new CustomerManager();
            int id = 0;
            string[] customers = cm.GetNamesOfCustomers();
            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i].Length > 0 && customers[i].ToLower() != "cash")
                {
                    id = cm.GetCustomerByName(customers[i]).ID;
                    customerGrid.Rows.Add(
                        id,
                        customers[i],
                        cm.GetPendingAmountTill(id, DateTime.Now.AddDays(1.0)).ToString("0.00"));
                }
            }
        }
        //int selectedId;
        DateTime startDate;
        public void ShowDebtorsAndGetId(DateTime startDate)
        {
            this.startDate = startDate;
            this.ShowDialog();
            //return selectedId;
        }
    }
}