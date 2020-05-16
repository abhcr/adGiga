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
    public partial class CustomerEditor : Form
    {
        public CustomerEditor()
        {
            InitializeComponent();
        }
        List<Customer> allCustomers = new List<Customer>();
        CustomerManager cm;
        private void CustomerEditor_Load(object sender, EventArgs e)
        {
            cm = new CustomerManager();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            itemGrid.Rows.Clear();
            allCustomers.Clear();
            allCustomers = cm.GetAllCustomers();
            allCustomers.Remove(cm.GetCustomerByName(string.Empty)); //do not allow editing default customer
            foreach (Customer customer in allCustomers)
            {
                itemGrid.Rows.Add(customer.ID, customer.Name);
            }
            itemGrid.Refresh();
            if (itemGrid.Rows.Count > 0)
            {
                itemGrid.Rows[0].Selected = true;
            }
            DisplayCustomerDetails();
            //refresh autocomplete source of text box
            searchBox.AutoCompleteMode = AutoCompleteMode.Append;
            searchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchBox.AutoCompleteCustomSource.Clear();
            searchBox.AutoCompleteCustomSource.AddRange(cm.GetNamesOfCustomers());
        }

        private void customerGrid_SelectionChanged(object sender, EventArgs e)
        {
            DisplayCustomerDetails();
        }

        int selectedCustomerID = -1;
        private void DisplayCustomerDetails()
        {
            Customer selectedCustomer;
            if (itemGrid.SelectedCells.Count > 0)
            {
                selectedCustomerID = (int)(itemGrid[0, itemGrid.SelectedCells[0].RowIndex].Value);
                selectedCustomer = cm.GetCustomerByID(selectedCustomerID);
                if (selectedCustomer == null)
                {
                    selectedCustomer = new Customer();
                }
                
            }
            else
            {
                selectedCustomer = new Customer();
                selectedCustomer.Name = string.Empty;
                selectedCustomer.Address = string.Empty;
                selectedCustomer.Phone = string.Empty;
                selectedCustomer.ID = -1;
                selectedCustomerID = -1;
            }

            customerName.Text = selectedCustomer.Name;
            customerAddress.Text = selectedCustomer.Address;
            phoneNumber.Text = selectedCustomer.Phone;
        }

        private void cancelEdit_Click(object sender, EventArgs e)
        {
            DisplayCustomerDetails();
        }
        //searchIndex for marking current search result and navigating to "next" search result
        static int searchIndex = 0;
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            searchIndex = 0;
            SearchAndLocate();
        }
        private void SearchAndLocate()
        {
            string string1;
            string string2 = searchBox.Text.ToLower();
            //search inside grid and select the row containing first match
            foreach (DataGridViewRow row in itemGrid.Rows)
            {
                if (row.Cells.Count > 0 && row.Index > searchIndex && !row.IsNewRow)
                {
                    string1 = row.Cells[1].Value.ToString().ToLower();
                    if (startsWith.Checked)
                    {
                        if (string1.StartsWith(string2))
                        {
                            row.Selected = true;
                            itemGrid.FirstDisplayedScrollingRowIndex = row.Index;
                            searchIndex = row.Index;
                            break;
                        }
                    }
                    else if (contains.Checked)
                    {
                        if (string1.Contains(string2))
                        {
                            row.Selected = true;
                            itemGrid.FirstDisplayedScrollingRowIndex = row.Index;
                            searchIndex = row.Index;
                            break;
                        }
                    }
                    else if (exactly.Checked)
                    {
                        if (string1.Equals(string2))
                        {
                            row.Selected = true;
                            itemGrid.FirstDisplayedScrollingRowIndex = row.Index;
                            searchIndex = row.Index;
                            break;
                        }
                    }
                }
            }

        }

        private void nextResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchAndLocate();
        }

        private void saveCustomer_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                if (MessageBox.Show("Save changes?", "DailyExpense: Customer Manager",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    (new CommonManager()).BeginBatchOperation();
                    Customer changedCustomer = new Customer();
                    changedCustomer.Name = customerName.Text;
                    changedCustomer.Address = customerAddress.Text;
                    changedCustomer.Phone = phoneNumber.Text;
                    changedCustomer.ID = selectedCustomerID;
                    cm.UpdateCustomerByID(changedCustomer);

                    MessageBox.Show("Saved!", "DailyExpense: Customer Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                    searchBox.Text = changedCustomer.Name;
                    searchIndex = 0;
                    exactly.Checked = true;
                    SearchAndLocate();
                    (new CommonManager()).ConfirmBatchOperation();
                }
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customerNameBox_Validating(object sender, CancelEventArgs e)
        {
            if (cm.GetCustomerByName(customerName.Text) != null)
            {
                if (cm.GetCustomerByName(customerName.Text).ID != selectedCustomerID)
                {
                    errorProvider.SetError(customerName, "A customer with same name already exists");
                    e.Cancel = true;
                }
            }
            else if (customerName.Text.Trim().Length == 0)
            {
                errorProvider.SetError(customerName, "Name cannot be blank for the customer");
                e.Cancel = true;
            }
        }

        private void customerNameBox_Validated(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void addressRateBox_Validating(object sender, CancelEventArgs e)
        {
            //validate address
        }

        private void addressRateBox_Validated(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        
        private void deleteCustomer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete selected customer?", "DailyExpense:Customer Manager", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {

                (new CommonManager()).BeginBatchOperation();
                if (cm.GetPendingAmountTill(selectedCustomerID, DateTime.Now) > 0.0)
                {
                    if (MessageBox.Show("This customer has " + cm.GetPendingAmountTill(selectedCustomerID, DateTime.Now).ToString()
                        + " pending till now. If you proceed, records will be lost. Sure to continue?",
                        "DailyExpense:Customer Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == System.Windows.Forms.DialogResult.Yes)
                    {
                        cm.DeleteCustomer(selectedCustomerID);

                        MessageBox.Show("Customer Deleted", "DailyExpense:Customer Manager", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                }
                else
                {
                    cm.DeleteCustomer(selectedCustomerID);
                    MessageBox.Show("Customer Deleted", "DailyExpense:Customer Manager", MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
                }
                RefreshGrid();
                searchBox.Clear();
                (new CommonManager()).ConfirmBatchOperation();
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            selectedCustomerID = -1;
            itemGrid.ClearSelection();
            DisplayCustomerDetails();
            customerName.Focus();
        }

        private void customerName_TextChanged(object sender, EventArgs e)
        {
            this.Text = "Customer Manager - " + customerName.Text;
        }

        private void itemGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<itemGrid.RowCount)
            {
                int customerId = int.Parse(itemGrid[0, e.RowIndex].Value.ToString());
                this.Cursor = Cursors.WaitCursor;
                SalesHistory saleHistory = new SalesHistory();
                saleHistory.ShowHistory(customerId, itemGrid[1, e.RowIndex].Value.ToString(), DateTime.Now);
                saleHistory.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

    }
}