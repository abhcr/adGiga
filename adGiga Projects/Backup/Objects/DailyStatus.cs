using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class DailyStatus
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime openDate;

        public DateTime OpenDate
        {
            get { return openDate; }
            set { openDate = value; }
        }
        private double dayStartCash;

        public double DayStartCash
        {
            get { return dayStartCash; }
            set { dayStartCash = value; }
        }
        private double dayEndCash;

        public double DayEndCash
        {
            get { return dayEndCash; }
            set { dayEndCash = value; }
        }

    }
}
