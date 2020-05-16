using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ObjectCache
{
    class MovingAvgCache
    {
        object dummy = new object();

        private static MovingAvgCache instance;
         private MovingAvgCache()
        {
            lock (dummy)
            {
                if (!DBFunctions.GetInstance().CheckIfColumnExistsInTable("AvgCost", "Items"))
                {
                    //db needs to be upgraded for stock management
                    DBFunctions.GetInstance().OpenConnection();
                    OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                        "ALTER TABLE Items ADD COLUMN AvgCost NUMBER");
                    command.ExecuteNonQuery();
                    //now default all values to zero
                    command = DBFunctions.GetInstance().GetCommand("Update Items " +
                        "Set AvgCost=?");
                    command.Parameters.AddWithValue("Stock", 0);
                    command.ExecuteNonQuery();
                }
            }
        }
        public static MovingAvgCache GetInstance()
        {
            if (instance == null)
            {
                instance = new MovingAvgCache();
            }
            return instance;
        }
        public double GetMovingAvgRate(SalePurchase purchase)
        {
            double newAverage = purchase.Item.MovingAvgRate;
            //modify movingavg only if this is a purchase.
            if (purchase.Transaction.IsPurchase & purchase.Quantity>0.0)
            {
                double n;
               
                //this is a new purchase.
                //in this case, need to update with the new purchase rate and quantity
                n = (purchase.Item.Stock/* + purchase.Quantity (is already added)*/) / purchase.Quantity;
                newAverage = purchase.Item.MovingAvgRate - (purchase.Item.MovingAvgRate / n);
                newAverage += (purchase.SaleRate / n);
            }
            return newAverage;
        }

        internal void UpdateMovingAvgRate(Item item)
        {
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Update Items Set AvgCost=? Where ID=?");
            command.Parameters.AddWithValue("AvgCost", item.MovingAvgRate);
            command.Parameters.AddWithValue("ID", item.ID);
            command.ExecuteNonQuery();
        }

        internal double GetMovingAvgRate(SalePurchase purchase, SalePurchase prevPurchase)
        {

            //Step 1. Get the unmodified purchase item from db.
            //prevPurchase
            //step 2. Suppress the change in moving average introduced by this purchase item.
            double oldMovingAvg = GetSuppressedMovingAvgRate(prevPurchase);
            //step 3. apply this value only if new item and old item in this purchase line has not changed.
            if (prevPurchase.Item.ID == purchase.Item.ID)
            {
                purchase.Item.MovingAvgRate = oldMovingAvg;
            }
            //step 3. Introduce change in moving average for the modified purchase from cache.
            return GetMovingAvgRate(purchase);
        }

        internal double GetSuppressedMovingAvgRate(SalePurchase purchaseToDelete)
        {

            //Suppress the change in moving average introduced by this purchase item.
            double oldMovingAvg = ((purchaseToDelete.Item.MovingAvgRate * purchaseToDelete.Item.Stock)
                - (purchaseToDelete.SaleRate * purchaseToDelete.Quantity)) / (purchaseToDelete.Item.Stock - purchaseToDelete.Quantity);
            if (double.IsNaN(oldMovingAvg))
                return 0;
            return oldMovingAvg;
        }
    }
}
