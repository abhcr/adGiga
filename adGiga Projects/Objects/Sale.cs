using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    public class SalePurchase
    {

        private Unit saleUnit;

        public Unit SaleUnit
        {
            get { return saleUnit; }
            set { saleUnit = value; }
        }

        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private Item item;

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }
        private Transaction transaction;

        public Transaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }
        private double saleRate;

        public double SaleRate
        {
            get { return saleRate; }
            set { saleRate = value; }
        }
        private double saleQuantity;

        /// <summary>
        /// quantity of item sold or purchased 
        /// </summary>
        public double Quantity
        {
            get { return saleQuantity; }
            set { saleQuantity = value; }
        }
        private double taxRate;

        public double SaleTax
        {
            get { return taxRate; }
            set { taxRate = value; }
        }
        /// <summary>
        /// Gets sale quantity x sale rate
        /// </summary>
        public double SaleTotal
        {
            get { return saleQuantity*saleRate; }
        }

        public SalePurchase()
        {

        }
        public SalePurchase(Transaction transaction, Item item, double saleRate, double saleQuantity, double saleTax)
        {
            this.transaction = transaction;
            this.item = item;
            this.saleRate = saleRate;
            this.saleQuantity = saleQuantity;
            this.taxRate = saleTax;
        }
    }
}
