using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;

namespace ObjectCache
{
    public class CustomerCache
    {
        private CustomerCache()
        {
            lock (dummy)
            {
                customers.Clear();
                Customer customer;
                DBFunctions.GetInstance().OpenConnection();
                OleDbDataReader reader = DBFunctions.GetInstance().GetReader(
                    "Select ID, CustomerName, PhoneNumber, CustomerAddress from Customers");
                while (reader.Read())
                {
                    customer = new Customer();
                    customer.ID = (int)reader[0];
                    customer.Name = reader[1].ToString();
                    customer.Phone = reader[2].ToString();
                    customer.Address = reader[3].ToString();
                    customers.Add(customer);
                }
            }
        }
        private List<Customer> customers = new List<Customer>();
        public List<Customer> Customers
        {
            get
            {
                return customers;
            }
        }
        private object dummy = new object();
        private static CustomerCache instance;
        public static CustomerCache GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerCache();
            }
            return instance;
        }

        private void InsertNewCustomerToDb(Customer customer)
        {
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Insert Into Customers " +
                "(CustomerName, CustomerAddress, PhoneNumber, LastUpdatedTime) Values (LCase(?),?,?,Now())");
            command.Parameters.AddWithValue("CustomerName", customer.Name);
            command.Parameters.AddWithValue("CustomerAddress", customer.Address);
            command.Parameters.AddWithValue("PhoneNumber", customer.Phone);
            command.ExecuteNonQuery();
        }

        public void InsertNewCustomer(Customer customer)
        {
            InsertNewCustomerToDb(customer);
            customers.Add(GetCustomerFromDbByName(customer.Name));
        }

        private Customer GetCustomerFromDbByName(string name)
        {
            Customer customer = null;
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Select ID, CustomerAddress, PhoneNumber From Customers" +
                    " Where CustomerName = LCase(?)");
            command.Parameters.AddWithValue("CustomerName", name);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                customer = new Customer();
                customer.ID = int.Parse(reader[0].ToString());
                customer.Name = name;
                customer.Address = reader[1].ToString();
                customer.Phone = reader[2].ToString();
            }
            return customer;
        }

        public Customer GetCustomerByName(string name)
        {
            Customer customer = customers.Find(delegate(Customer p) { return p.Name == name; });
            if (customer == null)
            {
                customer = GetCustomerFromDbByName(name);
                if (customer!=null)
                {
                    customers.Add(customer);
                }
            }
            return customer;
        }

        public Customer GetCustomerById(int ID)
        {
            Customer customer = customers.Find(delegate(Customer p) { return p.ID == ID; });
            if (customer == null)
            {
                customer = GetCustomerFromDbById(ID);
                if (customer != null)
                {
                    customers.Add(customer);
                }
            }
            return customer;
        }
        private Customer GetCustomerFromDbById(int ID)
        {
            Customer customer = new Customer();
            DBFunctions.GetInstance().OpenConnection();
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader("Select CustomerName, CustomerAddress, PhoneNumber From Customers" +
                    " Where ID=" + ID.ToString());
            if (reader.Read())
            {
                customer.ID = ID;
                customer.Name = reader[0].ToString();
                customer.Address = reader[1].ToString();
                customer.Phone = reader[2].ToString();
            }
            return customer;
        }

        public double GetPendingAmountBefore(int customerID, DateTime beforeDate)
        {
            double paymentBefore = 0.0;
            double saleBefore = 0.0;
            double doubleVar=0.0;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select Sum(S.SaleQuantity*S.SaleRate) From Sales As S, Transactions As T " +
                "Where T.Customer=? And S.TransactionId=T.ID And T.TransactionTime<?");
            command.Parameters.AddWithValue("CustomerId", customerID);
            command.Parameters.Add("TransactionTime", OleDbType.Date).Value = beforeDate.Date;
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                if (double.TryParse(reader[0].ToString(), out doubleVar))
                {
                    saleBefore = doubleVar;
                }
            }
            command = DBFunctions.GetInstance().GetCommand(
                "Select Sum(P.Amount) From Payments As P, Transactions As T " +
                "Where P.TransactionId=T.ID And T.Customer=? And T.TransactionTime<?");
            command.Parameters.AddWithValue("ID", customerID);
            command.Parameters.Add("TransactionTime", OleDbType.Date).Value = beforeDate.Date;
            reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                if (double.TryParse(reader[0].ToString(), out doubleVar))
                {
                    paymentBefore = doubleVar;
                }
            }
            return saleBefore - paymentBefore;
        }

        public void Clear()
        {
            if (customers != null)
            {
                customers.Clear();
            }
            instance = null;
        }
    }
}
