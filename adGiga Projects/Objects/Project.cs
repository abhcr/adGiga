using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class Project
    {
        public enum ProjectStatus
        {
            Started,
            InProgress,
            Completed,
            OnHold,
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Transaction> Children { get; set; }
        public ProjectStatus Status { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Comment { get; set; }
    }
}
