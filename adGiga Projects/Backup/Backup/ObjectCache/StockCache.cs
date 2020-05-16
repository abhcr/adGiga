using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DataObjects;

namespace ObjectCache
{
    public class StockCache
    {
        object dummy = new object();

        private static StockCache instance;

        private StockCache()
        {
            lock (dummy)
            {
                if (!DBFunctions.GetInstance().CheckIfColumnExistsInTable("Stock", "Items"))
                {
                    //db needs to be upgraded for stock management
                    DBFunctions.GetInstance().OpenConnection();
                    OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                        "ALTER TABLE Items ADD COLUMN Stock NUMBER");
                    command.ExecuteNonQuery();
                    //now default all values to zero
                    command = DBFunctions.GetInstance().GetCommand("Update Items " +
                        "Set Stock=?");
                    command.Parameters.AddWithValue("Stock", 0);
                    command.ExecuteNonQuery();
                }
            }
        }
        public static StockCache GetInstance()
        {
            if (instance == null)
            {
                instance = new StockCache();
            }
            return instance;
        }

        public void UpdateStock(Item item)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Update Items Set Stock=? Where ID=?");
            command.Parameters.AddWithValue("Stock", item.Stock);
            command.Parameters.AddWithValue("ID", item.ID);
            command.ExecuteNonQuery();
        }
    }
}
