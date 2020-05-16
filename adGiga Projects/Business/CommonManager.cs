using System;
using System.Collections.Generic;
using System.Text;
using ObjectCache;
using DataObjects;

namespace Business
{
    public class CommonManager
    {

        public bool CheckIfFirstTimeForDay(DateTime day)
        {
            //DailyStatus dayStat = CommonCache.GetInstance().GetDayStat(day);
            //if (dayStat == null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }

        //public double GetPreviousDayAmount(DateTime day)
        //{
        //    DateTime dayToLook;
        //    //look for atleast 7 days for previous amount
        //    for (int i = 0; i < 7; i++)
        //    {
        //        dayToLook = day.Subtract(new TimeSpan(i,0,0,0));
        //        DailyStatus dayStat = CommonCache.GetInstance().GetDayStat(dayToLook);
        //        if (dayStat == null)
        //        {
        //            continue;
        //        }
        //        return dayStat.DayEndCash;
        //    }
        //    return 0;
        //}

        public void MarkDayStart(DateTime day, double startingCash)
        {
            DailyStatus dayStat = new DailyStatus();
            dayStat.OpenDate = day.Date;
            dayStat.DayStartCash = startingCash;
            dayStat.DayEndCash = 0;
            CommonCache.GetInstance().SyncDayStatus(dayStat);
        }

        public DailyStatus SyncDayStatus(DailyStatus dayStat)
        {
            return CommonCache.GetInstance().SyncDayStatus(dayStat);
        }

        public double GetCashInTray(DateTime day)
        {
            //get day status
            //DailyStatus dayStat = CommonCache.GetInstance().GetDayStat(day);
            //get day's total hard money
            double totalPayment = (new PaymentManager()).GetTotalPaymentForDay(day, false, false)
                - (new PaymentManager()).GetTotalPaymentForDay(day, false, true);
            //get day's total expenses 
            double totalExpenses = (new ExpenseManager()).GetTotalExpenseForDay(day);

            return totalPayment - totalExpenses;
        }

        public double GetTotalPaymentForDay(DateTime day, bool isSale)
        {
            return (new PaymentManager()).GetTotalPaymentForDay(day, true, isSale) 
                + (new PaymentManager().GetTotalPaymentForDay(day, false, isSale));
        }

        public double GetTotalExpenseForDay(DateTime day)
        {
            return (new ExpenseManager()).GetTotalExpenseForDay(day);
        }

        public void CloseApplication(double remainingCash, string date)
        {
            //DateTime day = DateTime.Parse(date);
            //DailyStatus dayStat = null;
            //while (dayStat == null)
            //{
            //    dayStat = CommonCache.GetInstance().GetDayStat(day);
            //    day = day.Subtract(new TimeSpan(1, 0, 0, 0));
            //    //loop until getting the last entered day
            //}
            ////mark the day's remaining cash in daily status
            //dayStat.DayEndCash = remainingCash;
            //CommonCache.GetInstance().SyncDayStatus(dayStat);
            //release db connections
            ObjectCache.DBFunctions.GetInstance().EndDbAction();
        }

        public string GetItemWiseSaleReport(DateTime startTime, DateTime endTime)
        {
            StringBuilder report = new StringBuilder();
            report.Append(CommonCache.GetInstance().GetItemsSold(startTime, endTime));
            
            return report.ToString();
        }

        public string GetCompleteDBAsString()
        {
            StringBuilder completeString = new StringBuilder();
            //get customers table
            //completeString.AppendLine(CommonC
            //get transactions table
            //get expenseItems table
            //get expenses table
            //get sales table
            //get items table
            //get payments table
            //get units table
            return completeString.ToString();
        }

        public string GetCreditReport(int creditorId, DateTime startDate, DateTime endDate)
        {
            return "not implemented";
        }

        public string GetSaleDetailsForItem(Item selectedItem, DateTime startDate, DateTime endDate)
        {
            selectedItem = (new ItemManager()).GetItemByName(selectedItem.Name);
            //selectedItem.Unit = 
            string saleDetails = CommonCache.GetInstance().GetItemSaleDetail(selectedItem, startDate, endDate);
            if (saleDetails.Length == 0)
            {
                saleDetails = "0";
            }
            return saleDetails;
        }

        public string GetExpenseSummary(DateTime startDate, DateTime endDate)
        {
            return CommonCache.GetInstance().GetExpenseSummary(startDate, endDate);
        }

        public string GetExpenseDetail(string expenseName, DateTime startDate, DateTime endDate)
        {
            return CommonCache.GetInstance().GetExpenseDetail(expenseName, startDate, endDate);
        }

        public double GetTotalSaleCreditForDay(DateTime date)
        {
            return GetTotalSaleForDay(date) - GetTotalPaymentForDay(date, true);
        }

        public double GetTotalSaleForDay(DateTime date)
        {
            return CommonCache.GetInstance().GetTotalSaleForDay(date, true);
        }
        public double GetTotalPurchaseForDay(DateTime date)
        {
            return CommonCache.GetInstance().GetTotalSaleForDay(date, false);
        }
        public void BeginBatchOperation()
        {
            ObjectCache.DBFunctions.GetInstance().BeginBatchOperation();
        }
        public void ConfirmBatchOperation()
        {
            ObjectCache.DBFunctions.GetInstance().CommitBatchOperation();
        }
        public void RollBackBatchOperation()
        {
            ObjectCache.DBFunctions.GetInstance().RollBackBatchOperation();
        }

        public void SetDataLocation(string dataLocationFullPath)
        {
            try
            {
                DBFunctions.GetInstance().SetConnectionString(dataLocationFullPath);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not connect to the selected data file.", ex);
            }
        }

        public bool IsDataValid()
        {
            return DBFunctions.GetInstance().IsDataFileValid();
        }

        public void RefreshCache()
        {
            (new UnitManager()).RefreshCache();
            (new ItemManager()).RefreshCache();
            (new SaleManager()).RefreshCache();
            (new PaymentManager()).RefreshCache();
            (new TransactionManager()).RefreshCache();
            (new CustomerManager()).RefreshCache();
            (new ExpenseManager()).RefreshCache();
            (new AssemblyManager()).RefreshCache();
            (new ProjectManager()).RefreshCache();
        }

        public string GetNumberOfItemsSold(Item item, DateTime start, DateTime end)
        {
            return CommonCache.GetInstance().GetNumberOfItemsSold(item, start, end);
        }

        public string GetDBName()
        {
            return DBFunctions.GetInstance().GetDBName();
        }
    }
}
