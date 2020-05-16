using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DataObjects;

namespace ObjectCache
{
    public class CommonCache
    {
        //private List<DailyStatus> dailyStatuses;
        private static CommonCache instance;
        public static CommonCache GetInstance()
        {
            if (instance==null)
            {
                instance = new CommonCache();
            }
            return instance;
        }
        private CommonCache()
        {
            //dailyStatuses = new List<DailyStatus>();
            //DailyStatus dayStat;
            //OleDbCommand command = DBFunctions.GetInstance().GetCommand(
            //    "Select ID, OpenDate, DayStartCash, DayEndCash From DailyStatus"); //Where OpenDate=?");
            ////command.Parameters.AddWithValue("OpenDate", day.ToString("MM/dd/yyyy ") + "12:00:00 AM");
            //OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            //while(reader.Read())
            //{
            //    dayStat = new DailyStatus();
            //    dayStat.ID = int.Parse(reader[0].ToString());
            //    dayStat.OpenDate = DateTime.Parse(reader[1].ToString());
            //    dayStat.DayStartCash = double.Parse(reader[2].ToString());
            //    dailyStatuses.Add(dayStat);
            //}
        }


        public DailyStatus GetDayStat(DateTime day)
        {
            DailyStatus dayStat=null;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID, OpenDate, DayStartCash, DayEndCash From DailyStatus Where OpenDate=?");
            command.Parameters.Add("OpenDate", OleDbType.Date).Value = day.Date;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if(reader.Read())
            {
                dayStat = new DailyStatus();
                dayStat.ID = int.Parse(reader[0].ToString());
                dayStat.OpenDate = DateTime.Parse(reader[1].ToString());
                dayStat.DayStartCash = double.Parse(reader[2].ToString());
            }

            return dayStat;
        }

        public DailyStatus SyncDayStatus(DailyStatus dailyStatus)
        {
            if (GetDayStat(dailyStatus.OpenDate) == null)
            {
                //insert
                OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                    "Insert Into DailyStatus(OpenDate, DayStartCash, DayEndCash) " +
                    "Values(?,?,?)");
                command.Parameters.AddWithValue("OpenDate", dailyStatus.OpenDate.Date.ToString());
                command.Parameters.AddWithValue("DayStartCash", dailyStatus.DayStartCash);
                command.Parameters.AddWithValue("DayEndCash", dailyStatus.DayEndCash);
                command.ExecuteNonQuery();
                //dailyStatuses.Add(dailyStatus);
            }
            else
            {
                //update
                OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                    "Update DailyStatus Set DayStartCash=?, DayEndCash=? Where OpenDate=?");
                command.Parameters.AddWithValue("startCash", dailyStatus.DayStartCash);
                command.Parameters.AddWithValue("endCash", dailyStatus.DayEndCash);
                command.Parameters.Add("openDate", OleDbType.Date).Value = dailyStatus.OpenDate.Date;
                command.ExecuteNonQuery();
                DailyStatus d = GetDayStat(dailyStatus.OpenDate);
                d = dailyStatus;
            }
            return dailyStatus;
        }

        public string GetItemsSold(DateTime startTime, DateTime endTime)
        {
            StringBuilder s = new StringBuilder();
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
            endTime = new DateTime(endTime.AddDays(1.0).Year, endTime.AddDays(1.0).Month, endTime.AddDays(1.0).Day, 0, 0, 0);
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select I.ItemName, S.SaleRate, Sum(SaleQuantity), S.SaleUnit From Items as I, Sales as S, Transactions as T " +
                "Where T.TransactionTime>=? And T.TransactionTime<? And T.ID=S.TransactionId And S.Item=I.ID Group By I.ItemName, S.SaleRate, S.SaleUnit");
            command.Parameters.Add("startTime", OleDbType.Date).Value = startTime;
            command.Parameters.Add("endTime", OleDbType.Date).Value = endTime;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                s.Append(" " + reader[0].ToString());
                s.Append("\t");
                s.Append(" " + reader[1].ToString());
                s.Append("\t");
                s.Append(" " + reader[2].ToString());
                s.Append("\t");
                s.Append(" " + reader[3].ToString());
                s.Append("\n");
            }
            return s.ToString();
        }

        public string GetItemSaleDetail(Item selectedItem, DateTime startTime, DateTime endTime)
        {
            StringBuilder s = new StringBuilder();
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
            endTime = new DateTime(endTime.AddDays(1.0).Year, endTime.AddDays(1.0).Month, endTime.AddDays(1.0).Day, 0, 0, 0);
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select I.ItemName, S.SaleRate, S.SaleQuantity, S.SaleRate*S.SaleQuantity, C.CustomerName, T.TransactionTime, S.SaleUnit " +
                "from Transactions T, Items I, Customers C, Sales S Where S.Item=? and TransactionTime>=? and TransactionTime<? and " +
                "I.ID=S.Item and T.ID=S.TransactionId and C.ID=T.Customer");
            command.Parameters.AddWithValue("itemId", selectedItem.ID);
            command.Parameters.Add("startTime", OleDbType.Date).Value = startTime;
            command.Parameters.AddWithValue("endTime", OleDbType.Date).Value = endTime;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                s.Append(" " + reader[0].ToString());
                s.Append("\t");
                s.Append(" " + reader[1].ToString());
                s.Append("\t");
                s.Append(" " + reader[2].ToString());
                s.Append("\t");
                s.Append(" " + reader[3].ToString());
                s.Append("\t");
                s.Append(" " + (reader[4].ToString().Trim()== string.Empty? "cash" : reader[4].ToString()));
                s.Append("\t");
                s.Append(" " + reader[5].ToString());
                s.Append("\t");
                s.Append(" " + reader[6].ToString());
                s.Append("\n");
            }
            return s.ToString();
        }

        public string GetExpenseSummary(DateTime startTime, DateTime endTime)
        {
            StringBuilder s = new StringBuilder();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select I.Item, Sum(E.Amount) From ExpenseItems I, Expenses E "+
                "Where E.LastUpdatedTime>=? And E.LastUpdatedTime<? And I.ID = E.ExpenseItem Group By I.Item ");
            command.Parameters.Add("startTime", OleDbType.Date).Value = startTime.Date;
            command.Parameters.Add("endTime", OleDbType.Date).Value = endTime.AddDays(1.0).Date;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                s.Append(" " + reader[0].ToString());
                s.Append("\t");
                s.Append(" " + reader[1].ToString());
                s.Append("\n");
            }
            return s.ToString();
        }

        public string GetExpenseDetail(string expenseName, DateTime startTime, DateTime endTime)
        {
            StringBuilder s = new StringBuilder();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select I.Item, E.LastUpdatedTime, E.Amount, E.Remark From ExpenseItems I, Expenses E " +
                "Where E.LastUpdatedTime>=? And E.LastUpdatedTime<? And I.ID = E.ExpenseItem And Trim(LCase(I.Item))=?");
            command.Parameters.Add("startTime", OleDbType.Date).Value = startTime.Date;
            command.Parameters.Add("endTime", OleDbType.Date).Value = endTime.AddDays(1.0).Date;
            command.Parameters.AddWithValue("item", expenseName.ToLower().Trim());
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                s.Append(" " + reader[0].ToString());
                s.Append("\t");
                s.Append(" " + reader[1].ToString());
                s.Append("\t");
                s.Append(" " + reader[2].ToString());
                s.Append("\t");
                s.Append(" " + reader[3].ToString());
                s.Append("\n");
            }
            return s.ToString();
        }

        public double GetTotalSaleForDay(DateTime date, bool isSale)
        {
            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime endTime = new DateTime(date.AddDays(1.0).Year, date.AddDays(1.0).Month, date.AddDays(1.0).Day, 0, 0, 0);

            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select Sum(TransactionSum) From Transactions Where TransactionTime>=? And TransactionTime<? And SaleOrPurchase=?");
            command.Parameters.Add("startTime", OleDbType.Date).Value = startTime;
            command.Parameters.Add("endTime", OleDbType.Date).Value = endTime;
            command.Parameters.AddWithValue("SaleOrPurchase", isSale ? 1 : 0);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                return double.Parse(reader[0].ToString()==string.Empty ? "0": reader[0].ToString());
            }
            else
            {
                throw new System.Data.DataException("Error while retrieving transaction sum total for day.");
            }
        }
        public string GetNumberOfItemsSold(Item item, DateTime startTime, DateTime endTime)
        {
            StringBuilder s = new StringBuilder();
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
            endTime = new DateTime(endTime.AddDays(1.0).Year, endTime.AddDays(1.0).Month, endTime.AddDays(1.0).Day, 0, 0, 0);
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select Sum(SaleQuantity), S.SaleUnit From Sales as S, Transactions as T " +
                "Where T.TransactionTime>=? And T.TransactionTime<? And T.ID=S.TransactionId And S.Item=? Group By S.ID, S.SaleUnit");
            command.Parameters.Add("startTime", OleDbType.Date).Value = startTime;
            command.Parameters.Add("endTime", OleDbType.Date).Value = endTime;
            command.Parameters.AddWithValue("ID", item.ID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            while (reader.Read())
            {
                s.Append(reader[0].ToString());
                s.Append(" ");
                s.Append(UnitCache.GetInstance().GetUnitById(int.Parse(reader[1].ToString())).Name);
                s.Append(". ");
            }
            return s.ToString();
        }
    }
}
