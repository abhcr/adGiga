using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business;
using DataObjects;
using System.Text.RegularExpressions;
using System.Drawing.Printing;

namespace ShopKeeper
{
    public partial class EstimateForm : Form
    {
        Transaction transaction;
        List<Sale> sales = new List<Sale>();
        CustomerManager cm = new CustomerManager();
        SaleManager sm = new SaleManager();
        PaymentManager pm = new PaymentManager();
        ItemManager im = new ItemManager();
        UnitManager um = new UnitManager();
        TransactionManager tm = new TransactionManager();
        CommonManager comm = new CommonManager();
        Payment payment;
        Customer customer;
        double currTotal;
        public EstimateForm()
        {
            InitializeComponent();
            customerName.AutoCompleteCustomSource.Clear();
            customerName.AutoCompleteCustomSource.AddRange(cm.GetNamesOfCustomers());
            customerName.Text = string.Empty;
            currentPayment.Enabled = false;
        }

        public void CreateNewSale(DateTime saleTime)
        {
            this.Text = "New Estimate";
            //create new transaction object
            transaction = new Transaction();
            transaction.ID = -1;
            transaction.Remark = string.Empty;
            estimateDatePicker.Value = saleTime;
            currentTotal.Text = "0";
            currentPayment.Text = "0";
            totalBalance.Text = "0";
            this.ShowDialog();
        }
        private int transactionId = -1;
        public void UpdateSale(int transactionID)
        {
            this.transactionId = transactionID;
            this.Text = "Update Estimate";
            LoadControls();
            this.ShowDialog();

        }
        private void LoadControls()
        {
            if (!this.Text.ToLower().Contains("new"))
            {
                transaction = tm.GetTransactionByID(this.transactionId);
                estimateDatePicker.Value = transaction.TransactionTime;
                //retrieve purchases
                sales = sm.GetSalesByTransactionID(transaction.ID);
                currTotal = 0.0;
                purchaseGrid.Rows.Clear();
                foreach (Sale sale in sales)
                {
                    currTotal += sale.SaleTotal;
                    purchaseGrid.Rows.Add(sale.Number, sale.Item.Name, sale.SaleQuantity,
                        sale.SaleRate, sale.SaleUnit.Name, sale.SaleTotal, sale.ID, sale.Item.ID);
                }
                purchaseGrid.Refresh();
                //retrieve payment
                payment = pm.GetPaymentByTransactionID(transaction.ID);
                currentPayment.Text = payment.Amount.ToString();
                eMoney.Checked = payment.BankMoney;
                //get transaction
                transaction = payment.Transaction;
                //get customer
                customer = transaction.Customer;
                ShowPendingAmount();
                UpdateCustomerDisplay();
                currentTotal.Text = currTotal.ToString();
                remark.Text = transaction.Remark;
            }
            else
            {
                //just update pending amount if the current operation is a new sale 
                ShowPendingAmount();
            }
        }

        private void UpdateCustomerDisplay()
        {
            customerName.Text = customer.Name;
            customerDetail.Text = customer.Address;
            phoneNo.Text = customer.Phone;
            
        }

        private void NewSale_Load(object sender, EventArgs e)
        {

        }

        private void customerName_Leave(object sender, EventArgs e)
        {
            customerName.BackColor = Color.White;
            //check if new customer
            if (customerName.AutoCompleteCustomSource.IndexOf(customerName.Text.ToLower()) < 0)
            {
                AddNewCustomer getNewCustomerForm = new AddNewCustomer();
                customer = getNewCustomerForm.AddCustomer(customerName.Text.ToLower());
                customerName.Text = customer.Name;
                if (customer.ID == 0) //if empty customer...
                {
                    customerDetail.Text = "Cash Purchase";
                    customerName.Text = string.Empty;
                    customerName.Focus();
                }
                else
                {
                    totalBalance.Text = "0";
                    customerName.AutoCompleteCustomSource.Add(customer.Name);
                }
                getNewCustomerForm.Dispose();
            }
            else
            {
                //get complete customer object
                customer = cm.GetCustomerByName(customerName.Text.ToLower());
                if (customer != null)
                {
                    ShowPendingAmount();
                    UpdateCustomerDisplay();
                }
                else
                {
                    throw new DataException("Could not retrieve customer details");
                }
            }
            transaction.Customer = customer;//assign the retrieved customer object to transaction
        }

        private void ShowPendingAmount()
        {
            if (customerName.Text.Trim() == string.Empty || customerName.Text.ToLower() == "cash")
            {
                totalBalance.Text = "0";
            }
            else
            {
                if (transaction == null)
                {

                }
                else if (transaction.ID < 0)
                {
                    totalBalance.Text = (cm.GetPendingAmountTill(customer.ID, DateTime.Now.AddDays(1.0)) +
                        + double.Parse(currentTotal.Text) - double.Parse(currentPayment.Text)).ToString();
                }
                else
                {

                    totalBalance.Text = (cm.GetPendingAmountTill(customer.ID, DateTime.Now.AddDays(1.0)) +
                            - tm.GetTransactionByID(transaction.ID).TransactionSum + double.Parse(currentTotal.Text) 
                            + pm.GetPaymentByTransactionID(transaction.ID).Amount - double.Parse(currentPayment.Text)
                            ).ToString();
                }
            }
        }

        private void purchaseGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.CellStyle.BackColor == Color.Beige)
            {//itemcolumn
                TextBox itemInput = (TextBox)e.Control;
                itemInput.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                itemInput.AutoCompleteSource = AutoCompleteSource.CustomSource;
                itemInput.AutoCompleteCustomSource.Clear();
                itemInput.AutoCompleteCustomSource.AddRange(im.GetNamesOfItems());
            }
            else if (e.CellStyle.BackColor == Color.Lavender)
            {
                //unit column
                TextBox unitInput = (TextBox)e.Control;
                unitInput.AutoCompleteMode = AutoCompleteMode.Append;
                unitInput.AutoCompleteSource = AutoCompleteSource.CustomSource;
                unitInput.AutoCompleteCustomSource.Clear();
                unitInput.AutoCompleteCustomSource.AddRange(um.GetNamesOfUnits());
            }
            else
            {
                TextBox otherInput = (TextBox)e.Control;
                otherInput.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void purchaseGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)//if item changed
            {
                if (purchaseGrid[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    Item item = im.GetItemByName(purchaseGrid[e.ColumnIndex, e.RowIndex].Value.ToString());
                    //get rate and unit from memory...
                    if (item != null)
                    {
                        purchaseGrid["itemRate", e.RowIndex].Value = item.Rate;
                        purchaseGrid["itemUnit", e.RowIndex].Value = item.Unit.Name;
                        purchaseGrid["itemId", e.RowIndex].Value = item.ID;
                    }
                    //purchaseGrid[2, e.RowIndex].Selected = true; << caused error after adding contextmenu
                    item = null; //freeing up memry
                }
            }
        }

        private void purchaseGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            ////calculate total

        }

        private void purchaseGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //fill default values to new editing row
            purchaseGrid[0, e.Row.Index - 1].Value = e.Row.Index;
            purchaseGrid["itemQuantity", e.Row.Index - 1].Value = 0;
            purchaseGrid["id", e.Row.Index - 1].Value = -1;
        }

        private void purchaseGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3) //if quantity or rate edited
                {
                    if (purchaseGrid[2, e.RowIndex].Value != null
                        && purchaseGrid[3, e.RowIndex].Value != null)
                    {
                        //calculate line total
                        purchaseGrid[5, e.RowIndex].Value = double.Parse(purchaseGrid[2, e.RowIndex].Value.ToString())
                            * double.Parse(purchaseGrid[3, e.RowIndex].Value.ToString());
                    }
                    else
                    {
                        purchaseGrid[5, e.RowIndex].Value = 0;
                    }
                }
                if (e.ColumnIndex == 5)//if line total changed
                {
                    FindSaleTotal();
                }
            }
        }

        private void FindSaleTotal()
        {
            //recalculate grand total
            currTotal = 0;
            foreach (DataGridViewRow row in purchaseGrid.Rows)
            {
                if (row.Cells[5].Value != null)
                {
                    currTotal += double.Parse(row.Cells[5].Value.ToString());
                }
            }
            currentTotal.Text = currTotal.ToString();
        }

        private bool SaveThisSale()
        {
            
            string titleBackUp = this.Text;
            this.Text = "Saving....";
            int transactionIdBackUp = transaction.ID;//need this in case of rollback
            //try
            //{
                comm.BeginBatchOperation();
                Sale sale;
                Item item;
                Unit unit;
                transaction.TransactionTime = DateTime.Parse(estimateDatePicker.Value.ToShortDateString() + " " 
                    + DateTime.Now.TimeOfDay.ToString());
                transaction = tm.SyncTransaction(transaction);
                sales = new List<Sale>();
                foreach (DataGridViewRow row in purchaseGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        unit = new Unit();
                        unit.Name = (string)row.Cells[4].Value;
                        item = new Item((string)row.Cells[1].Value, double.Parse(row.Cells[3].Value.ToString()), unit);
                        sale = new Sale();
                        sale.Number = (int)row.Cells[0].Value;
                        sale.ID = (int)row.Cells["id"].Value;
                        sale.SaleQuantity = double.Parse(row.Cells[2].Value.ToString());
                        sale.SaleRate = double.Parse(row.Cells[3].Value.ToString());
                        sale.Item = item;
                        sale.SaleUnit = unit;
                        sale.Transaction = transaction;
                        sales.Add(sale);
                    }
                }
                //create payment
                payment = new Payment();
                payment.Amount = double.Parse(currentPayment.Text);
                payment.BankMoney = eMoney.Checked;
                payment.Transaction = transaction;
                if (!paymentMode)
                {
                    sm.SyncSales(sales, updateItems.Checked, transaction.ID);
                }
                pm.SyncPayment(payment, estimateDatePicker.Value);
                comm.ConfirmBatchOperation();
                return true;
            //}
            //catch (Exception ex)
            //{
            //    cancelFormClose = true;
            //    comm.RollBackBatchOperation();
            //    transaction.ID = transactionIdBackUp;
            //    MessageBox.Show("Please try again." + Environment.NewLine + "Details:" + ex.Message, "Sorry! Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //finally
            //{
            //    this.Text = titleBackUp;
            //    titleBackUp = string.Empty;
            //}
        }

        private void purchaseGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            ////check if unit is entered
            //if (e.ColumnIndex == 4)
            //{
            //    if (purchaseGrid[e.ColumnIndex,e.RowIndex].Value == null
            //        && purchaseGrid[0,e.RowIndex].Value != null)
            //    {
            //        purchaseGrid.ClearSelection();
            //        purchaseGrid[e.ColumnIndex, e.RowIndex].Selected = true;
            //        throw va
            //    }
            //}
        }

        private void remark_TextChanged(object sender, EventArgs e)
        {
            transaction.Remark = remark.Text;
        }

        private void currentPayment_Leave(object sender, EventArgs e)
        {
            currentPayment.BackColor = Color.White;
            double doubleVar = 0;
            if (double.TryParse(currentPayment.Text, out doubleVar))
            {
                currentPayment.Text = doubleVar.ToString();
            }
            else
            {
                currentPayment.SelectAll();
            }
        }

        private void currentTotal_TextChanged(object sender, EventArgs e)
        {
            transaction.TransactionSum = currTotal;
            if (customerName.Text.Length == 0 || customerName.Text.ToLower() == "cash")
            {
                currentPayment.Enabled = false;
                currentPayment.Text = currentTotal.Text;
            }
            else
            {
                currentPayment.Enabled = true;
            }
            ShowPendingAmount();
        }

        private void purchaseGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double doubleVar;
            if (!purchaseGrid.Rows[e.RowIndex].IsNewRow)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        break;
                    case 1:
                        //item name. nothing to validate
                        break;
                    case 2:
                        //quantity
                        if (!double.TryParse(e.FormattedValue.ToString(), out doubleVar))
                        {
                            e.Cancel = true;
                            //MessageBox.Show("Enter a valid quantity", "Wrong Entry",
                            //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            purchaseGrid.CancelEdit();
                        }
                        //check if quantity exceeds stock
                        //get the item first....
                        Item item = im.GetItemByName(purchaseGrid[1, e.RowIndex].Value.ToString());
                        if (item.Stock < doubleVar)
                        {
                            purchaseGrid[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            purchaseGrid[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Black;
                        }
                        item = null;
                        break;
                    case 3:
                        //rate
                        if (!double.TryParse(e.FormattedValue.ToString(), out doubleVar))
                        {
                            e.Cancel = true;
                            //MessageBox.Show("Enter a valid rate", "Wrong Entry",
                                //MessageBoxButtons.OK, MessageBoxIcon.Error);
                            purchaseGrid.CancelEdit();
                        }
                        break;
                    case 4:
                        //unit
                        if (e.FormattedValue.ToString() == string.Empty)
                        {
                            e.Cancel = true;
                            purchaseGrid.CancelEdit();
                        }
                        //Regex r = new Regex("[^a-zA-Z]");
                        //if (r.IsMatch(e.FormattedValue.ToString()))
                        //{
                        //    e.Cancel = true;
                        //    MessageBox.Show("Enter a valid unit", "Wrong Entry",
                        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    purchaseGrid.CancelEdit();
                        //}
                        break;
                    default:
                        break;
                }
            }
        }

        private void savePrint_Click(object sender, EventArgs e)
        {
            confirmQuit = false;
            VerifySave(true);
            this.Close();
        }
        private bool printOnly = false;
        /// <summary>
        /// Print the current sale items
        /// </summary>
        /// <param name="transaction">False if need to print that this is just an estimate</param>
        private void PrintThisSale(bool transaction)
        {
            printOnly = !transaction;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                try
                {
                    linesPrinted = 0;
                    printDocument.Print();
                }
                catch (Exception e)
                {

                    MessageBox.Show("Please check if the printer or the connected computer is switched on and ready." +
                    Environment.NewLine + e.Message, 
                        "Cannot Print", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            confirmQuit = false;
            VerifySave(false);//dont print
        }
        private void VerifySave(bool print)
        {
            this.Enabled = false;

            if (currentPayment.Text.Length == 0)
            {
                currentPayment.Text = "0";
            }
            if (currentTotal.Text.Length == 0)
            {
                currentTotal.Text = "0";
            }
            if (double.Parse(currentPayment.Text) == 0 && purchaseGrid.RowCount == 1)
            {
                //nothing to save
                if (MessageBox.Show("No payment or purchase. Discard this transaction?", "Nothing to save",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cancelFormClose = false;
                    DeleteTransaction();
                    MessageBox.Show("This transaction has been deleted.", "For Your Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cancelFormClose = true;
                }
            }
            else
            {
                if (double.Parse(currentPayment.Text) < double.Parse(currentTotal.Text))
                {
                    if (MessageBox.Show(customerName.Text + " not paying full amount. Continue?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (SaveThisSale())
                        {
                            if (print)
                            {
                                PrintThisSale(true);
                            }
                            cancelFormClose = false;
                            this.Close();
                        }
                        else
                        {
                            cancelFormClose = true;
                        }
                    }
                    else
                    {
                        currentPayment.SelectAll();
                        currentPayment.Focus();
                        cancelFormClose = true;
                    }
                }
                else if (double.Parse(currentPayment.Text) > double.Parse(currentTotal.Text))
                {
                    if (MessageBox.Show(customerName.Text + " payed more than current sale total. Will be adjusted to account. Continue?",
                        "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (SaveThisSale())
                        {
                            if (print)
                            {
                                PrintThisSale(true);
                            }
                            cancelFormClose = false;
                            this.Close();
                        }
                        else
                        {
                            cancelFormClose = true;
                        }
                    }
                    else
                    {
                        currentPayment.SelectAll();
                        currentPayment.Focus();
                        cancelFormClose = true;
                    }
                }
                else
                {
                    //if paying exact amount..
                    if (SaveThisSale())
                    {
                        if (print)
                        {
                            PrintThisSale(true);
                        }
                        cancelFormClose = false;
                        this.Close();
                    }
                    else
                    {
                        cancelFormClose = true;
                    }
                }
            }
            this.Enabled = true;
        }

        private void DeleteTransaction()
        {
            try
            {
                comm.BeginBatchOperation();
                //delete the transaction
                if (transaction.ID > -1)
                {
                    tm.DeleteTransaction(transaction.ID);
                }
                comm.ConfirmBatchOperation();
                cancelFormClose = false;
            }
            catch (Exception e)
            {
                cancelFormClose = true;
                comm.RollBackBatchOperation();
                MessageBox.Show("Please Try Again", "Something went wrong." + Environment.NewLine + "Details:" + e.Message);
            }
        }

        private void justPrint_Click(object sender, EventArgs e)
        {
            PrintThisSale(false);//and show it as a 'just an estimate'
            cancelFormClose = true;
        }
        private int linesPrinted = 0;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //if (e.PageSettings.PaperSize.Kind == PaperKind.Custom)
            //{
            //    e.PageSettings.PaperSize.Height = 3 * 25 + 1 * 25 + purchaseGrid.Rows.Count * 25 + 1 * 40 + 100;
            //    e.PageSettings.PaperSize.Width = 800;
            //}
            e.PageSettings.Margins.Top = 30;
            e.PageSettings.Margins.Bottom = 30;
            e.PageSettings.Margins.Left = 30;
            e.PageSettings.Margins.Right = 30;
            int x = e.PageBounds.Left;
            int y = e.PageBounds.Top;//e.MarginBounds.Top;
            Brush brush = new SolidBrush(Color.Black);
            Font regular = new Font("Arial", 12.0f, FontStyle.Regular);
            Font boldFont = new Font("Arial", 12.0f, FontStyle.Bold);
            Font underscoreFont = new Font("Arial", 12.0f, FontStyle.Underline);
            if (linesPrinted == 0)
            {
                e.Graphics.DrawString(transaction.TransactionTime.ToString("dd/MM/yy hh:mm tt"), regular, brush, x, y);
                y += 25;
                e.Graphics.DrawString("Estimate For: " + customerName.Text, regular, brush, x, y);
                y += 25;
                //print remark
                e.Graphics.DrawString("Remark:" + remark.Text, regular, brush, x, y);
                y += 25;
                if (purchaseGrid.Rows.Count > 1)
                {
                    e.Graphics.DrawString("No.", underscoreFont, brush, x, y);
                    e.Graphics.DrawString("Item", underscoreFont, brush, x + 25, y);
                    e.Graphics.DrawString("Quantity", underscoreFont, brush, x + 250, y);
                    e.Graphics.DrawString("Rate", underscoreFont, brush, x + 330, y);
                    e.Graphics.DrawString("Total", underscoreFont, brush, x + 390, y);
                    y += 25;
                }
            }
            while (linesPrinted < purchaseGrid.Rows.Count - 1)
            {
                e.Graphics.DrawString(purchaseGrid[0, linesPrinted].Value.ToString(),
                     regular, brush, x, y);
                e.Graphics.DrawString(purchaseGrid[1, linesPrinted].Value.ToString(),
                                     regular, brush, x + 25, y);
                e.Graphics.DrawString(purchaseGrid[2, linesPrinted].Value.ToString() + " " +
                    purchaseGrid[4, linesPrinted].Value.ToString(),
                                     regular, brush, x + 250, y);
                e.Graphics.DrawString(purchaseGrid[3, linesPrinted].Value.ToString(),
                                     regular, brush, x + 330, y);
                e.Graphics.DrawString(string.Format("{0,10:0.00}",
                    purchaseGrid[5, linesPrinted].Value).Replace(' ', '_'), regular, brush, x + 390, y);
                y += 25;
                linesPrinted++;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }
            if (linesPrinted == purchaseGrid.Rows.Count - 1)
            {
                //print total
                y++; y++;
                e.Graphics.DrawLine(new Pen(brush, 1.0f), x, y, e.MarginBounds.Width, y);
                y++; y++; y++;
                e.Graphics.DrawString("Sale Total:", regular, brush, x, y);
                e.Graphics.DrawString(string.Format("{0,10:0.00}", double.Parse(currentTotal.Text)).Replace(' ', '_'),
                    boldFont, brush, x + 390, y);
                linesPrinted++;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }
            if (linesPrinted == purchaseGrid.Rows.Count)
            {
                //print current payment
                y += 25;
                e.Graphics.DrawString("Paid:" + currentPayment.Text, regular, brush, x, y);
                //print pending if pending
                if (double.Parse(totalBalance.Text) != 0.0)
                {
                    e.Graphics.DrawString("Pending: " + string.Format("{0,10:0.00}", double.Parse(totalBalance.Text)),
                        regular, brush, x + 250, y);
                }
            }
        }

        private bool paymentMode = false;
        internal void GetPayment(DateTime saleDate)
        {
            this.Text = "Payment Entry";
            estimateDatePicker.Value = saleDate;
            //create new transaction object
            transaction = new Transaction();
            transaction.ID = -1;
            transaction.Remark = string.Empty;
            totalBalance.Text = "0";
            currentPayment.Text = "0";
            currentTotal.Text = "0";
            purchaseGrid.Enabled = false;
            paymentMode = true;
            this.ShowDialog();
        }

        private void customerName_Enter(object sender, EventArgs e)
        {
            customerName.BackColor = Color.Yellow;
        }

        private void currentPayment_Enter(object sender, EventArgs e)
        {
            currentPayment.BackColor = Color.Yellow;
            currentPayment.SelectAll();
        }

        private void customerName_TextChanged(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (customerName.Text == string.Empty || customerName.Text.ToLower() == "cash")
            {
                currentPayment.Text = currentTotal.Text;
                currentPayment.Enabled = false;
            }
            else
            {
                currentPayment.Enabled = true;
            }
        }

        private void currentPayment_TextChanged(object sender, EventArgs e)
        {

        }

        private void currentPayment_Validating(object sender, CancelEventArgs e)
        {
            double doubleVar;
            if (currentPayment.Text == string.Empty)
            {
                currentPayment.Text = "0";
            }
            if (!double.TryParse(currentPayment.Text, out doubleVar))
            {
                e.Cancel = true;
            }
        }

        private void previousBalance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (customerName.Text != string.Empty && customerName.Text.ToLower() != "cash")
            {
                //get customer id and pass it to sales history form
                SalesHistory history = new SalesHistory();
                history.ShowHistory(customer.ID, customer.Name, estimateDatePicker.Value);
                history.Dispose();
                //transaction = tm.GetTransactionByID(transaction.ID);
                //if (transaction == null)
                //{
                //    transaction = new Transaction();
                //    transaction.ID = -1;
                //    transaction.Remark = string.Empty;
                //    estimateDatePicker.Value = estimateDatePicker.Value;
                //    currentTotal.Text = "0";
                //    currentPayment.Text = "0";
                //    totalBalance.Text = "0";
                //}
                LoadControls();
            }
        }

        private void EstimateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sales.Clear();
            transaction = null;
            payment = null;
            customer = null;
            currTotal = 0;
            sm = null;
            pm = null;
            tm = null;
            im = null;
            um = null;
        }

        private void purchaseGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            foreach (DataGridViewRow row in purchaseGrid.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
            }
            purchaseGrid.Refresh();
            FindSaleTotal();
            ShowPendingAmount();
        }

        private void currentPayment_Validated(object sender, EventArgs e)
        {
            ShowPendingAmount();
        }

        private void remark_Enter(object sender, EventArgs e)
        {
            remark.BackColor = Color.Yellow;
        }

        private void remark_Leave(object sender, EventArgs e)
        {
            remark.BackColor = Color.White;
        }

        private void estimateDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today.Date == estimateDatePicker.Value.Date)
            {
                //this.BackColor = Color.FromKnownColor(KnownColor.ButtonFace);
                //orderStatGroup.BackColor = Color.FromKnownColor(KnownColor.ButtonFace);
                save.ForeColor = Color.Black;
                estimateDatePicker.BackColor = Color.White;
                estimateDatePicker.Invalidate();
            }
            else
            {
                //this.BackColor = Color.FromKnownColor(KnownColor.ButtonShadow);
                //orderStatGroup.BackColor = Color.FromKnownColor(KnownColor.ButtonShadow);
                save.ForeColor = Color.Red;
                estimateDatePicker.BackColor = Color.Red;
                estimateDatePicker.Invalidate();
            }
        }

        private void eMoney_CheckedChanged(object sender, EventArgs e)
        {
            if (eMoney.Checked)
            {
                if (remark.Text != string.Empty)
                {
                    remark.Text = "Enter payment details (chq No etc.) for your reference";
                }
                remark.SelectAll();
                remark.Focus();
            }
            else
            {
                if (remark.Text == "Enter payment details (chq No etc.) for your reference")
                {
                    remark.Text = string.Empty;
                }
            }
        }

        private void ordered_CheckedChanged(object sender, EventArgs e)
        {
            if (ordered.Checked)
            {
                orderDate.Enabled = true;
                parcelAgent.Enabled = true;
                sent.Enabled = true;
                orderStatGroup.BackColor = Color.LightPink;
            }
            else
            {
                orderDate.Enabled = false;
                parcelAgent.Enabled = false;
                sent.Enabled = false;
                sent.Checked = false;
                orderStatGroup.BackColor = this.BackColor;
            }
        }

        private void packedAndSent_CheckedChanged(object sender, EventArgs e)
        {
            if (sent.Checked)
            {
                sentDate.Enabled = true;
                packedBy.Enabled = true;
                closeOrder.Enabled = true;
                orderStatGroup.BackColor = Color.Beige;
            }
            else
            {
                sentDate.Enabled = false;
                packedBy.Enabled = false;
                closeOrder.Enabled = false;
                closeOrder.Checked = false;
                orderStatGroup.BackColor = Color.LightPink;
            }
        }

        private void closeOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (closeOrder.Checked)
            {
                orderClosedBy.Enabled = true;
                receiptNo.Enabled = true;
                orderStatGroup.BackColor = Color.LightGreen;
            }
            else
            {
                orderClosedBy.Enabled = false;
                receiptNo.Enabled = false;
                orderStatGroup.BackColor = Color.Beige;
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ALL RECORDS in this page will be deleted. Continue?", "Confirm Please!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DeleteTransaction();
                MessageBox.Show("This transaction has been deleted from records", "For Your Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cancelFormClose = true;
            }
            confirmQuit = false;
            this.Close();
        }
        bool confirmQuit = false;
        private void EstimateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancelFormClose)
            {
                e.Cancel = true;
                return;
            }
            if (confirmQuit)
            {
                if (MessageBox.Show("Sure to quit?", "Confirm Please!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    //just close
                }
            }
            else if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
                save_Click(this, new EventArgs());
            }
            else if (e.CloseReason == CloseReason.TaskManagerClosing)
            {
                //just close
            }
        }
        bool cancelFormClose = false;
        private void quitButton_Click(object sender, EventArgs e)
        {
            if (purchaseGrid.RowCount == 1 && double.Parse(currentPayment.Text) == 0.0)
            {
                confirmQuit = false;
            }
            else
            {
                confirmQuit = true;
            }
            cancelFormClose = false;
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newStockValue = (new CommonEditor()).GetValue("Modify Stock: " + purchaseGrid.CurrentCell.Value.ToString()
                , typeof(int), stockToolStripMenuItem.Text.Substring(6), true);
            (new StockManager()).UpdateStock(im.GetItemByName(purchaseGrid.CurrentCell.Value.ToString()), double.Parse(newStockValue));
        }

        private void taxRateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void todaysSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void itemEditContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (purchaseGrid.SelectedCells.Count == 1)
            {
                if (purchaseGrid.SelectedCells[0].ColumnIndex == 1)
                {
                    if (purchaseGrid.SelectedCells[0].Value == null)
                        e.Cancel = true;
                    else if ((new ItemManager()).GetItemByName(purchaseGrid.SelectedCells[0].Value.ToString()) == null)
                        e.Cancel = true;
                    else
                    {
                        e.Cancel = false; //only condiction to show context menu for item is this
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void itemEditContextMenu_Opened(object sender, EventArgs e)
        {
            //load item details:
            Item item = im.GetItemByName(purchaseGrid.SelectedCells[0].Value.ToString());
            stockToolStripMenuItem.Text = "Stock:" + item.Stock.ToString();
            taxRateToolStripMenuItem.Text = "Tax @" + item.TaxRate.ToString() + "%";
            todaysSaleToolStripMenuItem.Text = "Sale on " + estimateDatePicker.Value.ToString("MMM/dd/yyyy") + ": "
                +comm.GetNumberOfItemsSold(item, estimateDatePicker.Value, estimateDatePicker.Value);
        }

        private void purchaseGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                purchaseGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
        }
    }
}
