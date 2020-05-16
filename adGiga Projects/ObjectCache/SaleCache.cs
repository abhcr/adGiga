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
        public SalePurchase SyncSale(SalePurchase sale)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID, SaleQuantity From Sales Where ID=?");
            command.Parameters.AddWithValue("ID", sale.ID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                //sale present. So update it
                //moving average rate of items incorporated. 25.8.2014

                //stock management incorporated. 24.9.2010
                //sale purchase modes incorporated. 1/4/2011
                if (sale.Transaction.IsPurchase)
                {
                    //subtract the previous purchase qtty to stock, then add new purchace qtty.
                    sale.Item.Stock = sale.Item.Stock - double.Parse(reader[1].ToString()) + sale.Quantity;
                    //in case of updating a purchase, revert the average changed due to
                    //previous item rate, apply change in average due to new rate.
                    //this has to be done before updating DB with new purchase rate.
                    //Get the previous purchase object from db and pass it on to the calculator.
                    SalePurchase prevPurchase = GetSaleBySaleIDFromDB(sale.ID);
                    sale.Item.MovingAvgRate = MovingAvgCache.GetInstance().GetMovingAvgRate(sale, prevPurchase);
                    MovingAvgCache.GetInstance().UpdateMovingAvgRate(sale.Item);
                }
                else
                {
                    //add the previous salequantity to item's stock, then subtract the new salequantity
                    sale.Item.Stock = sale.Item.Stock + double.Parse(reader[1].ToString()) - sale.Quantity;
                    //if not a purchase, do not bother updating moving avg
                }
                StockCache.GetInstance().UpdateStock(sale.Item);

                command = DBFunctions.GetInstance().GetCommand(
                    "Update Sales Set TransactionId=?, Item=?, SaleRate=?, SaleQuantity=?, Tax=?, SaleNumber=?,SaleUnit=?, LastUpdatedTime=Now() Where ID=?");
                command.Parameters.AddWithValue("Transaction", sale.Transaction.ID);
                command.Parameters.AddWithValue("Item", sale.Item.ID);
                command.Parameters.AddWithValue("SaleRate", sale.SaleRate);
                command.Parameters.AddWithValue("SaleQuantity", sale.Quantity);
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
                command.Parameters.AddWithValue("SaleQuantity", sale.Quantity);
                command.Parameters.AddWithValue("Tax", sale.SaleTax);
                command.Parameters.AddWithValue("SaleNumber", sale.Number);
                command.Parameters.AddWithValue("SaleUnit", sale.SaleUnit.ID);
                command.Parameters.Add("LastUpdatedTime", OleDbType.Date).Value = DateTime.Now;
                command.ExecuteNonQuery();
                //stock management incorporated. 24.9.2010
                //sale/purchace incorporated 1.4.2011
                if (sale.Transaction.IsPurchase)
                {
                    //add new sale's sale qtty to the item stock.
                    sale.Item.Stock = sale.Item.Stock + sale.Quantity;
                    //incorporating moving avg rate of item 25.8.2014
                    //while inserting a new purchase, update moving averate rate.
                    sale.Item.MovingAvgRate = MovingAvgCache.GetInstance().GetMovingAvgRate(sale);
                    MovingAvgCache.GetInstance().UpdateMovingAvgRate(sale.Item);
                } 
                else 
                {
                    //subtract new sale's sale qtty from the item stock.
                    sale.Item.Stock = sale.Item.Stock - sale.Quantity;
                }
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

        private SalePurchase GetSaleBySaleIDFromDB(int salePurchaseID)
        {
            SalePurchase saleInDb = new SalePurchase();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID, Item, SaleRate, SaleQuantity, Tax, SaleNumber, SaleUnit, TransactionId " +
                "From Sales Where ID=?");
            command.Parameters.AddWithValue("ID", salePurchaseID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                saleInDb.ID = int.Parse(reader[0].ToString());
                saleInDb.SaleRate = double.Parse(reader[2].ToString());
                saleInDb.Quantity = double.Parse(reader[3].ToString());
                saleInDb.SaleTax = double.Parse(reader[4].ToString());
                saleInDb.Number = int.Parse(reader[5].ToString());
                saleInDb.SaleUnit = new Unit();
                if (reader[6].ToString() == string.Empty)
                {
                    saleInDb.SaleUnit.ID = -1;
                }
                else
                {
                    saleInDb.SaleUnit.ID = int.Parse(reader[6].ToString());
                }
                saleInDb.Item = new Item();
                saleInDb.Item.ID = int.Parse(reader[1].ToString());
            }
            //fill up child objects
            saleInDb.Item = ItemCache.GetInstance()
               .GetItemById(saleInDb.Item.ID);
            if (saleInDb.SaleUnit.ID < 0)
            {
                saleInDb.SaleUnit = saleInDb.Item.Unit;
            }
            else
            {
                saleInDb.SaleUnit = UnitCache.GetInstance().GetUnitById(saleInDb.SaleUnit.ID);
            }
            return saleInDb;
        }

        public List<SalePurchase> GetSalesByTransactionId(int transactionID)
        {
            Transaction transaction = TransactionCache.GetInstance()
                .GetTransactionById(transactionID);
            SalePurchase sale;
            List<SalePurchase> sales = new List<SalePurchase>();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID, Item, SaleRate, SaleQuantity, Tax, SaleNumber, SaleUnit " +
                "From Sales Where TransactionId=? Order By SaleNumber");
            command.Parameters.AddWithValue("Transaction", transactionID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                sale = new SalePurchase();
                sale.ID = int.Parse(reader[0].ToString());
                sale.Transaction = transaction;
                sale.SaleRate = double.Parse(reader[2].ToString());
                sale.Quantity = double.Parse(reader[3].ToString());
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
            foreach (SalePurchase s in sales)
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
        /// <param name="purchases">New list of purchases/sales in the transaction</param>
        public void MarkRemovals(List<SalePurchase> sales, int transactionId, bool updateStock)
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
                    markedSales.Add(intVar, sales.FindIndex(delegate(SalePurchase p) { return p.ID == intVar; }) >= 0);
                }
            }
            reader.Close();

            foreach (KeyValuePair<int, bool> markedSale in markedSales)
            {
                if (!markedSale.Value) //if the dictionary item is marked as false
                {
                    DeleteSale(markedSale.Key, updateStock);
                }
            }
        }

        public void DeleteSale(int saleID, bool updateStock)
        {

            Transaction tx;
            OleDbCommand command;
            OleDbDataReader reader;
            double saleQuantity = 0.0;
            
            if (updateStock)
            {
                // Update stock if the sale has to be deleted. Stock management. 24.9.2010

                command = DBFunctions.GetInstance().GetCommand(
                    "select Item, SaleQuantity, TransactionId from Sales Where ID=?");
                command.Parameters.AddWithValue("ID", saleID);
                reader = DBFunctions.GetInstance().GetReader(command);
                if (reader.Read())
                {
                    Item item = ItemCache.GetInstance().GetItemById(int.Parse(reader[0].ToString()));
                    saleQuantity = double.Parse(reader[1].ToString());
                    tx = TransactionCache.GetInstance().GetTransactionById(int.Parse(reader[2].ToString()));
                    if (tx.IsPurchase)
                    {
                        //qtty of deleted purchase will be subtracted from the stock
                        item.Stock -= saleQuantity;
                        //Update moving avg cost of items before deleting purchase item. 25.8.2014.
                        MovingAvgCache.GetInstance().GetSuppressedMovingAvgRate(GetSaleBySaleIDFromDB(saleID));
                    }
                    else
                    {
                        //qtty of deleted sale will be added to the stock
                        item.Stock += saleQuantity;
                    }
                    StockCache.GetInstance().UpdateStock(item);
                }
            }
            //then delete sale from the db
            command = DBFunctions.GetInstance().GetCommand(
                "Delete From Sales Where ID = ?");
            command.Parameters.AddWithValue("ID", saleID);
            

            if (command.ExecuteNonQuery() > 1)
            {//to confirm that only one sale got deleted for that single ID.. this error will roll back everything
                throw new ApplicationException("Error while deleting sales. Sale ID:" + saleID); 
            }
        }

        public void Clear()
        {
            //nothing to clear in instance
            instance = null;
        }
    }
}
