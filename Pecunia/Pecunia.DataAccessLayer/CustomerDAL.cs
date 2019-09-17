using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using System.Text.RegularExpressions;
using Pecunia.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Pecunia.DAL
{
    public class CustomerDAL
    {
        public static List<CustomerEntities> CustomersList; // list of customers is created by passing CustomerEntities class as data type 
        public bool AddCustomerDAL(CustomerEntities customerEntities)
        {
            try
            {
                DateTime Time = DateTime.Now;
                string customerID = Time.ToString("yyyyMMddhhmmss");
                customerEntities.CustomerID = customerID;
                CustomersList.Add(customerEntities);  //Customer is added in the list        
                return SerialiazeIntoJSON(CustomersList,"Customerdata.txt");
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveCustomerDAL(string CustomerID)
        {
            try
            {
                List<CustomerEntities> customerlist = DeserializeFromJSON("Customerdata.txt");// deserialize because we have to search list
               
                foreach (CustomerEntities cust in customerlist)  //foreach(dataType variable in collectionName)
                {
                    if (cust.CustomerID.Equals(CustomerID) == true)
                    {
                        customerlist.Remove(cust);
                        SerialiazeIntoJSON(customerlist,"Customerdata.txt");// we serialize because in our original database we have to make the above changes
                        break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public CustomerEntities GetCustomerByCustomerID_DAL(string CustomerID)
        {
            bool validate = false;
            try
            {
                CustomerEntities customerEntitiesTemporary = new CustomerEntities();

                List<CustomerEntities> custlist = DeserializeFromJSON("Customerdata.txt"); //we have to search customer through CustomerID

                foreach (CustomerEntities cust in custlist) //foreach will search the list
                {
                    if (cust.CustomerID.Equals(CustomerID) == true)
                    {
                        validate = true;
                        customerEntitiesTemporary = cust;
                        break;
                    }
                }
                if(validate!=true)
                {
                    throw new CustomerDoesNotExistException("Customer Not available based on given CustomerID");
                }
                //if customerID not found
                return customerEntitiesTemporary;
            }
            catch (Exception e)
            {
                CustomerEntities c = new CustomerEntities();
                return c;
            }
        }

        public List<CustomerEntities> GetAllCustomerDAL()
        {
            List<CustomerEntities> custlist = DeserializeFromJSON("Customerdata.txt");
            return custlist;
        }

        public void UpdateCustomerByCustomerID_DAL(string CustomerID)
        {
            try
            {
                foreach (CustomerEntities cust in CustomersList)
                {
                    if (cust.CustomerID.Equals(CustomerID) == true)
                    {
                        Console.WriteLine("Enter Customer Name ");
                        cust.CustomerName = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerName, "^[a-zA-Z]$") == false)
                        {
                            throw new InvalidStringException("not a valid name");
                        }

                        Console.WriteLine("Enter Customer Address");
                        cust.CustomerAddress = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerAddress, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$") == false)
                        {
                            throw new InvalidStringException("not a valid address");
                        }

                        Console.WriteLine("Enter Customer Mobile");
                        cust.CustomerMobile = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerMobile, @"\+?[0-9]{10}") == false)
                        {
                            throw new InvalidStringException("not a valid mobile");
                        }
                        Console.WriteLine("Enter Customer Email");
                        cust.CustomerEmail = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerEmail, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false)
                        {
                            throw new InvalidStringException("not a valid email");
                        }

                        Console.WriteLine("Enter Customer PAN");
                        cust.CustomerPan = Console.ReadLine();
                        if (Regex.IsMatch(cust.CustomerPan, @"^([A - Z]{ 5}\d{ 4}[A-Z]{1})$") == false)
                        {
                            throw new InvalidStringException("not a valid pan ");
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("cannot update");
            }
        }

        public bool SerialiazeIntoJSON(List<CustomerEntities> CustomersList,string FileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(FileName))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, CustomersList); // Serialize customers in customer.json
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CustomerEntities> DeserializeFromJSON(string FileName)
        {
            List<CustomerEntities> customers = JsonConvert.DeserializeObject<List<CustomerEntities>>(File.ReadAllText(FileName));// Done to read data from file
            using (StreamReader file = File.OpenText(FileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<CustomerEntities> customers1 = (List<CustomerEntities>)serializer.Deserialize(file, typeof(List<CustomerEntities>));
                return customers1;
            }
        }
    }
}
