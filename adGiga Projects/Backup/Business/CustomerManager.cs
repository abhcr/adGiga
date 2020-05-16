using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;
using ObjectCache;

namespace Business
{
    public class CustomerManager
    {
        public string[] GetNamesOfCustomers()
        {
            List<string> nameList = new List<string>();
            foreach (Customer customer in CustomerCache.GetInstance().Customers)
            {
                nameList.Add(customer.Name);
            }
            return nameList.ToArray();
        }
        public Customer GetCustomerByID(int ID)
        {
            return CustomerCache.GetInstance().GetCustomerById(ID);
        }
        public Customer GetCustomerByName(string name)
        {
            return CustomerCache.GetInstance().GetCustomerByName(name);
        }

        public double GetPendingAmountTill(int customerID, DateTime tillDate)
        {
            return CustomerCache.GetInstance().GetPendingAmountBefore(customerID, tillDate);
        }
        public Customer SyncCustomer(Customer customer)
        {
            if (GetCustomerByName(customer.Name) == null)
            {
                CustomerCache.GetInstance().InsertNewCustomer(customer);
            }
            return GetCustomerByName(customer.Name);
        }

        public double GetTotalPayment(int customerId, DateTime startDate)
        {
            return (new PaymentManager()).GetPaymentTotalByCustomerId(customerId, startDate); 
        }

        public double GetTotalPurchase(int customerId, DateTime startDate)
        {
            return (new TransactionManager()).GetTransactionSumTotalByCustomerId(customerId, startDate);
        }

        internal void RefreshCache()
        {
            CustomerCache.GetInstance().Clear();
            CustomerCache.GetInstance();
        }
    }
}
