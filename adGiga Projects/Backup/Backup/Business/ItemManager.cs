using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;
using ObjectCache;

namespace Business
{
    public class ItemManager
    {

        public string[] GetNamesOfItems()
        {
            List<string> nameList = new List<string>();
            foreach (Item item in ItemCache.GetInstance().Items)
            {
                nameList.Add(item.Name);
            }
            
            return nameList.ToArray();
        }

        //public Item InsertItem(Item item)
        //{
        //    item.Unit = (new UnitManager()).SyncUnit(item.Unit);
        //    DBFunctions.GetInstance().OpenConnection();
        //    OleDbCommand command = DBFunctions.GetInstance().GetCommand("Insert Into Items " +
        //        "(ItemName, RetailRate, ItemUnit, WholesaleRate, TaxRate, LastUpdatedTime) " +
        //        "Values(?,?,?,?,?,Now())");
        //    command.Parameters.AddWithValue("ItemName", item.Name);
        //    command.Parameters.AddWithValue("RetailRate", item.Rate);
        //    command.Parameters.AddWithValue("ItemUnit", item.Unit.ID);
        //    return null;//id
        //}
        public Item GetItemByID(int id)
        {
            return ItemCache.GetInstance().GetItemById(id);
        }
        public Item GetItemByName(string name)
        {
            return ItemCache.GetInstance().GetItemByName(name);
            //Item item = new Item();
            //item.Unit = new Unit();
            //DBFunctions.GetInstance().OpenConnection();
            //OleDbDataReader reader = DBFunctions.GetInstance().GetReader("Select I.ID, I.RetailRate, U.UnitName From Items as I, Units as U" +
            //        " Where I.ItemName = '" + name + "' AND U.ID=I.ItemUnit");//TODO: modify to left join
            //if (reader.Read())
            //{
            //    item.ID = int.Parse(reader[0].ToString());
            //    item.Name = name;
            //    item.Rate = double.Parse(reader[1].ToString());
            //    item.Unit.Name = reader[2].ToString();
            //}
            //DBFunctions.GetInstance().EndDbAction(reader);
            //return item;
        }


        public Item SyncItem(Item item, bool updateItem)
        {
            //update child objects
            //update unit
            item.Unit = (new UnitManager()).SyncUnit(item.Unit);
            //insert if not present
            if (ItemCache.GetInstance().GetItemByName(item.Name) == null)
            {
                ItemCache.GetInstance().InsertItem(item);
            }
            else if (updateItem)//if user opts to update, update
            {
                //check if rate,unit or tax updated
                if (ItemCache.GetInstance().CheckIfRateChanged(item)||
                    ItemCache.GetInstance().CheckIfTaxChanged(item)||
                    ItemCache.GetInstance().CheckIfUnitChanged(item))
                {
                    ItemCache.GetInstance().UpdateItem(item);
                }
            }
            return ItemCache.GetInstance().GetItemByName(item.Name);
        }

        internal void RefreshCache()
        {
            ItemCache.GetInstance().Clear();
            ItemCache.GetInstance();
        }
    }
}
