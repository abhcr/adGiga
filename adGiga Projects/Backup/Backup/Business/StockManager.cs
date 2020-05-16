using System;
using System.Collections.Generic;
using System.Text;
using ObjectCache;
using DataObjects;

namespace Business
{
    public class StockManager
    {

        public void UpdateStock(Item item, double newStockValue)
        {
            item.Stock = newStockValue;
            StockCache.GetInstance().UpdateStock(item);
        }
    }
}
