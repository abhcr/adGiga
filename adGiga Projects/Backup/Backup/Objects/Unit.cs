using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class Unit
    {
        public Unit()
        {
            id = -1;
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
