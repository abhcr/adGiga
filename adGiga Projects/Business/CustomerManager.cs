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
            return CustomerCache.GetInstance().GetCustomerByName(name.Trim().ToLower());
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="startDate"></param>
        /// <param name="paymtMadeOrReceived">true for paymt made, false for paymt rcvd</param>
        /// <returns></returns>
        public double GetTotalPayment(int customerId, DateTime startDate, bool paymtMadeOrReceived)
        {
            return (new PaymentManager()).GetPaymentTotalByCustomerId(customerId, startDate, paymtMadeOrReceived); 
        }

        public double GetTotalPurchase(int customerId, DateTime startDate, bool purchase)
        {
            return (new TransactionManager()).GetTransactionSumTotalByCustomerId(customerId, startDate, purchase);
        }

        internal void RefreshCache()
        {
            CustomerCache.GetInstance().Clear();
            CustomerCache.GetInstance();
        }

        public List<Customer> GetAllCustomers()
        {
            return CustomerCache.GetInstance().Customers;
        }

        public void UpdateCustomerByID(Customer changedCustomer)
        {
            if (changedCustomer.ID < 0)
            {
                CustomerCache.GetInstance().InsertNewCustomer(changedCustomer);
            }
            else
            {
                CustomerCache.GetInstance().UpdateCustomer(changedCustomer);
                //force cache reload on next access
                CustomerCache.GetInstance().Clear();
            }
        }

        public void DeleteCustomer(int selectedCustomerID)
        {
            CustomerCache.GetInstance().DeleteCustomer(selectedCustomerID);
            //>>replace the deleted customer's id with empty customer id
            //1. find the empty customer
            Customer defaultCustomer = GetCustomerByName(string.Empty);
            if (defaultCustomer != null)
            {
                //use the id to replace deleted Customer's ID in all transactions.
                (new TransactionManager()).ReplaceCustomer(selectedCustomerID, defaultCustomer.ID);
            }

            //force cache reload on next access
            CustomerCache.GetInstance().Clear();
        }
    }
}
