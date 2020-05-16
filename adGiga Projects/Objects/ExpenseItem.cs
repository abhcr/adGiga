using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class ExpenseItem
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

    }
}
