using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class Item
    {
        private double taxRate;

        public double TaxRate
        {
            get { return taxRate; }
            set { taxRate = value; }
        }

        public Item()
        {
            this.id = -1;
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
        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        private Unit unit;

        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Item(string name, double rate, Unit unit)
        {
            this.name = name;
            this.rate = rate;
            this.unit = unit;
        }

        private double stock;
        public double Stock
        {
            get
            {
                return stock;
            }
            set
            {
                stock = value;
            }
        }
    }
}
