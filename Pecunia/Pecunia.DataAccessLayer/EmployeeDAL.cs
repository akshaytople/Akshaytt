using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.Exceptions;
using System.Data.Common;

namespace Pecunia.DataAccessLayer
{
    public class EmployeeDAL
    {
        public static List<Employee> employeeList = new List<Employee>();

        public bool EmployeeLogInDAL(Employee employee)
        {
            bool employeeLogin = false;
            try
            {
                foreach(Employee emp in employeeList)
                {
                    if (employee.EmployeeID == emp.EmployeeID && employee.EmployeeCode == emp.EmployeeCode && employee.EmployeePassword == emp.EmployeePassword)
                    {
                        employeeLogin = true;
                    }
                }                
            }
            catch (Exception)
            {

                throw new PecuniaException("Cannot Login");
            }
            return employeeLogin;
        }

        public bool AddEmployeeDAL(Employee newEmployee)
        {
            DateTime time = DateTime.Now;
            string employeeID = "EMP" + time.ToString("yyyyMMddhhmmss");    //generating a unique employee ID
            newEmployee.EmployeeID = employeeID;
            string employeeCode = "EMC" + time.ToString("yyyyMMddhhmmss");  //generating a unique employee code
            newEmployee.EmployeeCode = employeeCode;

            bool employeeAdded = false;
            try
            {
                employeeList.Add(newEmployee);          //adding new employee to the list
                employeeAdded = true;
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return employeeAdded;

        }

        public List<Employee> GetAllEmployeesDAL()
        {
            return employeeList;
        }

        public Employee SearchEmployeeDAL(string searchEmployeeID)
        {
            Employee searchEmployee = null;
            try
            {
                foreach (Employee item in employeeList)             //searching employee through employeeID in list
                {
                    if (item.EmployeeID == searchEmployeeID)
                    {
                        searchEmployee = item;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return searchEmployee;
        }

        public List<Employee> GetEmployeesByNameDAL(string employeeName)
        {
            List<Employee> searchEmployee = new List<Employee>();
            try
            {
                foreach (Employee item in employeeList)
                {
                    if (item.EmployeeName == employeeName)              //searching employee by employee name in list
                    {
                        searchEmployee.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return searchEmployee;
        }

        public bool UpdateEmployeeDAL(Employee updateEmployee)
        {
            bool employeeUpdated = false;
            try
            {
                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].EmployeeID == updateEmployee.EmployeeID)               //matching employeeID in list with user provided employeeID
                    {
                        updateEmployee.EmployeeName = employeeList[i].EmployeeName;            //updating  employee name
                        updateEmployee.EmployeeEmail = employeeList[i].EmployeeEmail;          //updating  employee email
                        updateEmployee.EmployeePassword = employeeList[i].EmployeePassword;    //updating  employee password
                        updateEmployee.EmployeeMobile = employeeList[i].EmployeeMobile;        //updating  employee mobile

                        employeeUpdated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return employeeUpdated;

        }

        public bool DeleteEmployeeDAL(string deleteEmployeeID)
        {
            bool employeeDeleted = false;
            try
            {
                Employee deleteEmployee = null;
                foreach (Employee item in employeeList)
                {
                    if (item.EmployeeID == deleteEmployeeID)       //matching employeeID in list with the user provided employeeID
                    {
                        deleteEmployee = item;
                    }
                }

                if (deleteEmployee != null)
                {
                    employeeList.Remove(deleteEmployee);         //removing employee from the list    
                    employeeDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return employeeDeleted;

        }

    }
}
