using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Pecunia.Entities;
using Pecunia.DAL;
using Pecunia.Exceptions;

namespace Pecunia.BL
{
    public class CustomerBL
    {
        public void ValidateCustomerID(string customerID)
        {
            if (Regex.IsMatch(customerID, "^[0-9]{14}$") == false)
            {
                throw new InvalidStringException("not a valid CustomerID");
            }
        }
        public void Validate(CustomerEntities cust)
        {
            if (Regex.IsMatch(cust.CustomerName, "^[a-zA-Z]$") == false)
            {
                throw new InvalidStringException("not a valid name");
            }

            if (Regex.IsMatch(cust.CustomerAddress, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$") == false)
            {
                throw new InvalidStringException("not a valid address");
            }

            if (Regex.IsMatch(cust.CustomerMobile, @"\+?[0-9]{10}") == false)
            {
                throw new InvalidStringException("not a valid mobile");
            }

            if (Regex.IsMatch(cust.CustomerEmail, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false)
            {
                throw new InvalidStringException("not a valid email");
            }

            if (Regex.IsMatch(cust.CustomerPan, @"^([A - Z]{ 5}\d{ 4}[A-Z]{1})$") == false)
            {
                throw new InvalidStringException("not a valid pan ");
            }

        }
        public bool AddCustomerBL(CustomerEntities cust)
        {
            CustomerBL customer = new CustomerBL();
            Validate(cust);
           
            CustomerDAL obj = new CustomerDAL();
            return obj.AddCustomerDAL(cust);

        }

        public bool RemoveCustomerBL(string customerID )
        {
            ValidateCustomerID( customerID);

            CustomerDAL obj = new CustomerDAL();
            return obj.RemoveCustomerDAL(customerID);

        }

        public  CustomerEntities GetCustomerByCustomerID_BL(string customerID)
        {
            ValidateCustomerID(customerID);
            CustomerDAL obj = new CustomerDAL();
            return obj.GetCustomerByCustomerID_DAL(customerID);

        }
        
        public void GetAllCustomerDetails_BL()
        {
            CustomerDAL obj = new CustomerDAL();
            obj.GetAllCustomerDAL();
        }

        public void UpdateCustomerByCustomerID_BL(CustomerEntities customerEntities)
        {
            Validate(customerEntities);
            ValidateCustomerID(customerEntities.CustomerID);
            CustomerDAL obj = new CustomerDAL();
            CustomerEntities customerEntitiesTemporary = new CustomerEntities();
            customerEntitiesTemporary = obj.GetCustomerByCustomerID_DAL(customerEntities.CustomerID);
            customerEntitiesTemporary.CustomerName = customerEntities.CustomerName;
            customerEntitiesTemporary.CustomerID = customerEntities.CustomerID;
            customerEntitiesTemporary.CustomerMobile = customerEntities.CustomerMobile;
            customerEntitiesTemporary.CustomerEmail = customerEntitiesTemporary.CustomerEmail;
            customerEntitiesTemporary.CustomerAddress = customerEntitiesTemporary.CustomerAddress;
            customerEntitiesTemporary.CustomerPan = customerEntitiesTemporary.CustomerPan;
           
        }



    }
}
