using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Exceptions;
using Pecunia.Entities;
using Pecunia.BusinessLayer;

namespace Pecunia.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice,choiceAdmin,choiceEmployee;
            do
            {
                PrintSelectionList();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AdminLogIn();
                        choiceAdmin = Convert.ToInt32(Console.ReadLine());
                        switch (choiceAdmin)
                        {
                            case 1:
                                AddEmployee();
                                break;
                            case 2:
                                GetAllEmployees();
                                break;
                            case 3:
                                SearchEmployee();
                                break;
                            case 4:
                                UpdateEmployee();
                                break;
                            case 5:
                                DeleteEmployee();
                                break;
                            case 6:
                                ViewCustomerDetails();
                                break;
                            case 7:
                                ApproveLoan();
                                break;
                            case 8:
                                ViewTransactionReport();
                                break;
                            case 9:
                                return;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case 2:
                        EmployeeLogIn();
                        choiceEmployee = Convert.ToInt32(Console.ReadLine());
                        switch (choiceEmployee)
                        {
                            case 1:
                                //Customer
                                break;
                            case 2:
                                //Transaction
                                break;
                            case 3:
                                //Loan
                                break;
                            case 4:
                                //Account
                                break;
                            case 5:
                                return;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            }
            while (choice != -1);
        }

        private static void AdminLogIn()
        {
            Console.WriteLine("Enter Admin ID and Password to log in");
            try
            {
                Admin admin = new Admin();
                Console.WriteLine("Enter Admin Id");
                admin.AdminID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Password");
                admin.AdminPassword = Console.ReadLine();

                bool adminLoggedin = AdminBL.AdminLogInBL(admin);
                if (adminLoggedin)
                    Console.WriteLine("Admin Logged In");
                else
                    Console.WriteLine("Admin not Logged In");
            }
            catch (PecuniaException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void EmployeeLogIn()
        {
            Console.WriteLine("Enter Employee ID, Password and Employee Code to log in");
            try
            {
                Employee employee = new Employee();
                Console.WriteLine("Enter Employee Id");
                employee.EmployeeID = Console.ReadLine();
                Console.WriteLine("Enter Employee Password");
                employee.EmployeePassword = Console.ReadLine();
                Console.WriteLine("Enter Employee Code");
                employee.EmployeeCode = Console.ReadLine();

                bool employeeLoggedin = EmployeeBL.EmployeeLogInBL(employee);
                if (employeeLoggedin)
                    Console.WriteLine("Employee Logged In");
                else
                    Console.WriteLine("Employee not Logged In");
            }
            catch (PecuniaException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void AddEmployee()
        {
            try
            {
                Employee employee = new Employee();
                Console.WriteLine("Enter Employee Name");
                employee.EmployeeName = Console.ReadLine();
                Console.WriteLine("Enter Employee Email");
                employee.EmployeeEmail = Console.ReadLine();
                Console.WriteLine("Enter Employee Password");
                employee.EmployeePassword = Console.ReadLine();
                Console.WriteLine("Enter Employee Mobile");
                employee.EmployeeMobile = Console.ReadLine();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void PrintSelectionList()
        {
            Console.WriteLine("************Admin/Employee**************");
            Console.WriteLine("1.Admin Log In");
            Console.WriteLine("2.Employee Log In");
            Console.WriteLine("3.Exit");
           


            Console.WriteLine("********************************\n");
        }
    }
}
