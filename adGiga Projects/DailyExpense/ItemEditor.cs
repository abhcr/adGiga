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
    public partial class ItemEditor : Form
    {
        public ItemEditor()
        {
            InitializeComponent();
        }
        List<Item> allItems;
        ItemManager im;
        UnitManager um;
        private void ItemEditor_Load(object sender, EventArgs e)
        {
            um = new UnitManager();
            im = new ItemManager();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            itemGrid.Rows.Clear();
            allItems = im.GetAllItems();
            foreach (Item item in allItems)
            {
                itemGrid.Rows.Add(item.ID, item.Name);
            }
            itemGrid.Refresh();
            if (itemGrid.RowCount > 0)
            {
                itemGrid.Rows[0].Selected = true;
                DisplayItemDetails();
            }
            //refresh autocomplete source of text box
            searchBox.AutoCompleteMode = AutoCompleteMode.Append;
            searchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchBox.AutoCompleteCustomSource.Clear();
            searchBox.AutoCompleteCustomSource.AddRange(im.GetNamesOfItems());
        }

        private void itemGrid_SelectionChanged(object sender, EventArgs e)
        {
            DisplayItemDetails();
        }

        int selectedItemID = -1;
        private void DisplayItemDetails()
        {
            Item selectedItem;
            if (itemGrid.SelectedCells.Count > 0)
            {
                selectedItemID = (int)(itemGrid[0, itemGrid.SelectedCells[0].RowIndex].Value);
                selectedItem = im.GetItemByID(selectedItemID);
                if (selectedItem == null)
                {
                    selectedItem = new Item();
                    selectedItem.Unit = new Unit();
                }
            }
            else
            {
                selectedItemID = -1;
                selectedItem = new Item(string.Empty, 0.0, new Unit());
                selectedItem.Unit.Name = string.Empty;
            }
            itemNameBox.Text = selectedItem.Name;
            saleRateBox.Text = selectedItem.Rate.ToString();
            taxRateBox.Text = selectedItem.TaxRate.ToString();
            stockTextBox.Text = selectedItem.Stock.ToString();
            unitBox.Text = selectedItem.Unit.Name;
            unitBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            unitBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            unitBox.AutoCompleteCustomSource.Clear();
            unitBox.AutoCompleteCustomSource.AddRange(um.GetNamesOfUnits());
        }

        private void cancelEdit_Click(object sender, EventArgs e)
        {
            DisplayItemDetails();
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
                }
            }

        }

        private void nextResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchAndLocate();
        }

        private void saveItem_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                if (MessageBox.Show("Save changes?", "DailyExpense: Item Manager",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    (new CommonManager()).BeginBatchOperation();
                    Item itemToSave = new Item();
                    itemToSave.Unit = new Unit();
                    itemToSave.Unit.Name = unitBox.Text;
                    itemToSave.Name = itemNameBox.Text;
                    itemToSave.Rate = double.Parse(saleRateBox.Text);
                    itemToSave.Stock = double.Parse(stockTextBox.Text);
                    itemToSave.TaxRate = double.Parse(taxRateBox.Text);
                    itemToSave.ID = selectedItemID;
                    im.UpdateItemWithID(itemToSave);

                    (new StockManager()).UpdateStock(itemToSave, itemToSave.Stock);

                    MessageBox.Show("Saved.", "DailyExpense: Item Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                    searchBox.Text = itemToSave.Name;
                    searchIndex = 0;
                    SearchAndLocate();
                    (new CommonManager()).ConfirmBatchOperation();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void itemNameBox_Validating(object sender, CancelEventArgs e)
        {
            if (im.GetItemByName(itemNameBox.Text.ToLower()) != null)
            {
                if (im.GetItemByName(itemNameBox.Text.Trim().ToLower()).ID != selectedItemID)
                {
                    errorProvider.SetError(itemNameBox, "An item with same name already exists");
                    e.Cancel = true;
                }
            }
            else if (itemNameBox.Text.Trim().Length == 0)
            {
                errorProvider.SetError(itemNameBox, "A name for the item is required");
                e.Cancel = true;
            }
        }

        private void itemNameBox_Validated(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void saleRateBox_Validating(object sender, CancelEventArgs e)
        {
            double outDouble;
            if (!double.TryParse(saleRateBox.Text, out outDouble))
            {
                errorProvider.SetError(saleRateBox, "Entry invalid");
                e.Cancel = true;
            }
        }

        private void saleRateBox_Validated(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void taxRateBox_Validating(object sender, CancelEventArgs e)
        {
            double outDouble;
            if (!double.TryParse(taxRateBox.Text, out outDouble))
            {
                errorProvider.SetError(taxRateBox, "Entry invalid");
                e.Cancel = true;
            }
        }

        private void taxRateBox_Validated(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void stockTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void stockTextBox_Validating(object sender, CancelEventArgs e)
        {
            double outDouble;
            if (!double.TryParse(stockTextBox.Text, out outDouble))
            {
                errorProvider.SetError(stockTextBox, "Entry invalid");
                e.Cancel = true;
            }
        }

        private void deleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete " + itemNameBox.Text +"?", "DailyExpense:Item Manager", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {

                (new CommonManager()).BeginBatchOperation();
                List<Transaction> transactionsWithItem = im.DeleteItem(selectedItemID);
                if (transactionsWithItem.Count == 0)
                {
                    MessageBox.Show("Item Deleted", "DailyExpense:Item Manager", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
                else
                {
                    StringBuilder message = new StringBuilder(
                        "The selected item cannot be deleted since it is sold on the following dates:");
                    message.AppendLine("Total " + transactionsWithItem.Count.ToString() + " transaction(s).");
                    message.AppendLine(string.Empty);
                    transactionsWithItem.Reverse();
                    foreach (Transaction tx in transactionsWithItem)
                    {
                        message.AppendLine(tx.TransactionTime.ToString("MMM/dd/yyyy") + " " + tx.TransactionTime.ToLongTimeString() 
                            + "   ID:" + tx.ID.ToString());
                        if (transactionsWithItem.IndexOf(tx) > 30)
                        {
                            message.AppendLine("Showing only last 30.");
                            break;
                        }
                    }
                    MessageBox.Show(message.ToString(), "DailyExpense:Item Manager", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
                (new CommonManager()).ConfirmBatchOperation(); 
                RefreshGrid();
                searchBox.Clear();
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            selectedItemID = -1;
            itemGrid.ClearSelection();
            DisplayItemDetails();
            itemNameBox.Focus();
        }

        private void itemNameBox_TextChanged(object sender, EventArgs e)
        {
            this.Text = "Item Manager - " + itemNameBox.Text;
        }

    }
}
