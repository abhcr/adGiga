using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;
using System.Diagnostics;

namespace ObjectCache
{
    public class ItemCache
    {
        List<Item> items = new List<Item>();

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        object dummy = new object();
        private ItemCache()
        {
            lock (dummy)
            {
                //upgrade db with stock column if not done already
                StockCache.GetInstance();
                items.Clear();
                Item item;
                double doubleVar;
                int intVar;
                DBFunctions.GetInstance().OpenConnection();
                OleDbDataReader reader = DBFunctions.GetInstance().GetReader("Select ID, ItemName, RetailRate, ItemUnit, TaxRate, Stock from Items");
                while (reader.Read())
                {
                    item = new Item();
                    item.ID = (int)reader[0];
                    item.Name = reader[1].ToString();
                    item.Rate = double.Parse(reader[2].ToString());
                    double.TryParse(reader[4].ToString(), out doubleVar);
                    item.TaxRate = doubleVar;
                    int.TryParse(reader[3].ToString(), out intVar);
                    item.Unit = new Unit();
                    item.Unit.ID = intVar;
                    //adding stock 24/9/2010
                    double.TryParse(reader[5].ToString(), out doubleVar);
                    item.Stock = doubleVar;
                    items.Add(item);
                }
                foreach (Item x in items)
                {
                    x.Unit = UnitCache.GetInstance().GetUnitById(x.Unit.ID);
                }
            }
        }
        private static ItemCache instance;
        public static ItemCache GetInstance()
        {
            if (instance == null)
            {
                instance = new ItemCache();
            }
            return instance;
        }

        public Item GetItemByName(string itemName)
        {
            return items.Find(delegate(Item p) { Debug.Print(p.Name +"\n\r"); return p.Name.Trim().ToLower() == itemName.Trim().ToLower(); });
        }

        public Item GetItemById(int id)
        {
            return items.Find(delegate(Item p) { return p.ID == id; });
        }

        public void InsertItem(Item item)
        {
            if (GetItemByName(item.Name) == null)
            {
                InsertItemToDb(item);
                //then add it to cache with db ID
                items.Add(GetItemFromDbByName(item.Name));
            }
        }

        private Item GetItemFromDbByName(string name)
        {
            Item item = new Item();
            item.Name = name;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Select ID,RetailRate,ItemUnit,TaxRate, Stock From Items Where ItemName = LCase(?)");
            command.Parameters.AddWithValue("ItemName", item.Name);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                item.ID = (int)reader[0];
                item.Rate = double.Parse(reader[1].ToString());
                item.Unit = UnitCache.GetInstance().GetUnitById((int)reader[2]);
                item.TaxRate = double.Parse(reader[3].ToString());
                item.Stock = double.Parse(reader[4].ToString());
            }
            else
            {
                item = null;
            }
            return item;
        }

        private void InsertItemToDb(Item item)
        {
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Insert Into Items " +
                "(ItemName,RetailRate,ItemUnit,TaxRate, Stock, LastUpdatedTime) Values(LCase(?),?,?,?,?,Now())");
            command.Parameters.AddWithValue("ItemName", item.Name);
            command.Parameters.AddWithValue("ItemRate", item.Rate);
            command.Parameters.AddWithValue("ItemUnit", item.Unit.ID);
            command.Parameters.AddWithValue("TaxRate", item.TaxRate);
            command.Parameters.AddWithValue("Stock", item.Stock);
            command.ExecuteNonQuery();
        }

        public bool CheckIfRateChanged(Item item)
        {
            return ! (GetItemByName(item.Name).Rate == item.Rate);
        }

        public void UpdateItem(Item item)
        {
            Item itemInCache = GetItemByName(item.Name);
            //get the id
            item.ID = itemInCache.ID;
            UpdateItemToDb(item);
            //update item to cache
            items[items.IndexOf(itemInCache)] = item;
        }

        private void UpdateItemToDb(Item item)
        {
            //do not update stock here.. it is updated by stock cache
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Update Items " +
                "Set ItemName=?, RetailRate=?,ItemUnit=?,TaxRate=? Where ID=?");
            command.Parameters.AddWithValue("ItemName", item.Name);
            command.Parameters.AddWithValue("ItemRate", item.Rate);
            command.Parameters.AddWithValue("ItemUnit", item.Unit.ID);
            command.Parameters.AddWithValue("TaxRate", item.TaxRate);
            command.Parameters.AddWithValue("Id", item.ID);
            command.ExecuteNonQuery();
        }

        public bool CheckIfUnitChanged(Item item)
        {
            return !(GetItemByName(item.Name).Unit.ID == item.Unit.ID);
        }

        public bool CheckIfTaxChanged(Item item)
        {
            return !(GetItemByName(item.Name).TaxRate == item.TaxRate);
        }

        public void Clear()
        {
            if (items!= null)
            {
                items.Clear();
            }
            instance = null;
        }
    }
}
