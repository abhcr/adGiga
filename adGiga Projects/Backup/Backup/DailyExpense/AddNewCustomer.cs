using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataObjects;
using Business;

namespace ShopKeeper
{
    public partial class AddNewCustomer : Form
    {
        public AddNewCustomer()
        {
            InitializeComponent();
        }
        Customer customer;
        public Customer AddCustomer(string custName)
        {
            name.Text = custName;
            name.Focus();
            name.SelectAll();

            this.ShowDialog();

            return customer;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            customer = new Customer();
            customer.Name = name.Text.ToLower();
            customer.Phone = phone.Text;
            customer.Address = address.Text;

            //insert customer to db
            CustomerManager cm = new CustomerManager();
            customer = cm.SyncCustomer(customer);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            customer = (new CustomerManager()).GetCustomerByID(0);//get empty customer
            this.Close();
        }

    }
}