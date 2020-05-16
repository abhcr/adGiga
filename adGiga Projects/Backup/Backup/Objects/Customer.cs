using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class Customer
    {
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
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

    }
}
