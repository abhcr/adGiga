using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;

namespace ObjectCache
{
    public class SaleCache
    {
        private static SaleCache instance;
        //private List<Sale> sales;
        private SaleCache()
        {
            //sales = new List<Sale>();
        }

        public static SaleCache GetInstance()
        {
            if (instance == null)
            {
                instance = new SaleCache();
            }
            return instance;
        }

        //modified to incorporate stock management on sale insert/update 24.9.2010
        public Sale SyncSale(Sale sale)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID, SaleQuantity From Sales Where ID=?");
            command.Parameters.AddWithValue("ID", sale.ID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                //sale present. So update it
                //stock management incorporated. 24.9.2010
                //add the previous salequantity to item's stock, then subtract the new salequantity
                sale.Item.Stock = sale.Item.Stock + double.Parse(reader[1].ToString()) - sale.SaleQuantity;
                StockCache.GetInstance().UpdateStock(sale.Item);

                command = DBFunctions.GetInstance().GetCommand(
                    "Update Sales Set TransactionId=?, Item=?, SaleRate=?, SaleQuantity=?, Tax=?, SaleNumber=?,SaleUnit=?, LastUpdatedTime=Now() Where ID=?");
                command.Parameters.AddWithValue("Transaction", sale.Transaction.ID);
                command.Parameters.AddWithValue("Item", sale.Item.ID);
                command.Parameters.AddWithValue("SaleRate", sale.SaleRate);
                command.Parameters.AddWithValue("SaleQuantity", sale.SaleQuantity);
                command.Parameters.AddWithValue("Tax", sale.SaleTax);
                command.Parameters.AddWithValue("SaleNumber", sale.Number);
                command.Parameters.AddWithValue("SaleUnit", sale.SaleUnit.ID);
                command.Parameters.AddWithValue("ID", sale.ID);
                command.ExecuteNonQuery();
            }
            else
            {
                //sale not present. so insert it
                command = DBFunctions.GetInstance().GetCommand(
                    "INSERT INTO SALES(TransactionId,Item,SaleRate,SaleQuantity,Tax,SaleNumber,SaleUnit,LastUpdatedTime) "
                    + "VALUES(?,?,?,?,?,?,?,?)");
                command.Parameters.AddWithValue("Transaction", sale.Transaction.ID);
                command.Parameters.AddWithValue("Item", sale.Item.ID);
                command.Parameters.AddWithValue("SaleRate", sale.SaleRate);
                command.Parameters.AddWithValue("SaleQuantity", sale.SaleQuantity);
                command.Parameters.AddWithValue("Tax", sale.SaleTax);
                command.Parameters.AddWithValue("SaleNumber", sale.Number);
                command.Parameters.AddWithValue("SaleUnit", sale.SaleUnit.ID);
                command.Parameters.Add("LastUpdatedTime", OleDbType.Date).Value = DateTime.Now;
                command.ExecuteNonQuery();
                //stock management incorporated. 24.9.2010
                //subtract new sale's sale qtty from the item stock.
                sale.Item.Stock = sale.Item.Stock - sale.SaleQuantity;
                StockCache.GetInstance().UpdateStock(sale.Item);
                
                //get back the id
                command = DBFunctions.GetInstance().GetCommand(
                    "Select ID From Sales Where SaleNumber=? And TransactionId=?");
                command.Parameters.AddWithValue("SaleNumber", sale.Number);
                command.Parameters.AddWithValue("Transaction", sale.Transaction.ID);
                reader = DBFunctions.GetInstance().GetReader(command);
                if (reader.Read())
                {
                    sale.ID = int.Parse(reader[0].ToString());
                }
            }
            return sale;
        }

        public List<Sale> GetSalesByTransactionId(int transactionID)
        {
            Transaction transaction = TransactionCache.GetInstance()
                .GetTransactionById(transactionID);
            Sale sale;
            List<Sale> sales = new List<Sale>();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID, Item, SaleRate, SaleQuantity, Tax, SaleNumber, SaleUnit " +
                "From Sales Where TransactionId=? Order By SaleNumber");
            command.Parameters.AddWithValue("Transaction", transactionID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                sale = new Sale();
                sale.ID = int.Parse(reader[0].ToString());
                sale.Transaction = transaction;
                sale.SaleRate = double.Parse(reader[2].ToString());
                sale.SaleQuantity = double.Parse(reader[3].ToString());
                sale.SaleTax = double.Parse(reader[4].ToString());
                sale.Number = int.Parse(reader[5].ToString());
                sale.SaleUnit = new Unit();
                if (reader[6].ToString() == string.Empty)
                {
                    sale.SaleUnit.ID = -1;
                }
                else
                {
                    sale.SaleUnit.ID = int.Parse(reader[6].ToString());
                }
                sale.Item = new Item();
                sale.Item.ID = int.Parse(reader[1].ToString());
                sales.Add(sale);
            }
            foreach (Sale s in sales)
            {
                s.Item = ItemCache.GetInstance()
                    .GetItemById(s.Item.ID);
                if (s.SaleUnit.ID < 0)
                {
                    s.SaleUnit = s.Item.Unit;
                }
                else
                {
                    s.SaleUnit = UnitCache.GetInstance().GetUnitById(s.SaleUnit.ID);
                }
            }
            return sales;
        }

        /// <summary>
        /// FInds out deleted purchases in transaction and delete them from db
        /// Then removes them from the cache.
        /// </summary>
        /// <param name="purchases">New list of purchases in the transaction</param>
        public void MarkRemovals(List<Sale> sales, int transactionId)
        {
            int intVar = 0;
            Dictionary<int, bool> markedSales = new Dictionary<int, bool>(sales.Count);
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select S.ID From Sales As S Where S.TransactionId = ?");
            command.Parameters.AddWithValue("Transaction", transactionId);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);

            while (reader.Read())
            {
                if (int.TryParse(reader[0].ToString(), out intVar))
                {
                    //search inside updated sales list and check if it is still present
                    //if not, mark its value as false.
                    markedSales.Add(intVar, sales.FindIndex(delegate(Sale p) { return p.ID == intVar; }) >= 0);
                }
            }
            reader.Close();

            foreach (KeyValuePair<int, bool> markedSale in markedSales)
            {
                if (!markedSale.Value) //if the dictionary item is marked as false
                {
                    DeleteSale(markedSale.Key);
                }
            }
        }

        public void DeleteSale(int saleId)
        {
            // Update stock if the sale has to be deleted. Stock management. 24.9.2010
            
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "select Item, SaleQuantity from Sales Where ID=?");
            command.Parameters.AddWithValue("ID", saleId);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                Item item = ItemCache.GetInstance().GetItemById(int.Parse(reader[0].ToString()));
                //qtty of deleted sale will be added to the stock
                item.Stock = item.Stock + double.Parse(reader[1].ToString());
                StockCache.GetInstance().UpdateStock(item);
            }
            //then delete sale from the db
            command = DBFunctions.GetInstance().GetCommand(
                "Delete From Sales Where ID = ?");
            command.Parameters.AddWithValue("ID", saleId);
            

            if (command.ExecuteNonQuery() > 1)
            {//to confirm that only one sale got deleted for that single ID.. this error will roll back everything
                throw new Exception("Error while deleting sales. Sale ID:" + saleId); 
            }
        }

        public void Clear()
        {
            //nothing to clear in instance
            instance = null;
        }
    }
}
