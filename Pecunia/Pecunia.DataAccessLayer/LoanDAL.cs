using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;

namespace Pecunia.DataAccessLayer
{
    public class LoanDAL
    {
        static List<LoanEntities> Loans = new List<LoanEntities>();
        public bool ApplyLoanDAL(LoanEntities loan)
        {
            try
            {
                
                DateTime time = DateTime.Now;
                string currentTime = time.ToString("yyyyMMddhhmmss");

                if ((int)loan.Type == 0)
                {//eduloan
                    loan.LoanID = "EDU" + currentTime; //string concatenation loanID sample : EDULOAN20190912101552
                    loan.InterestRate = 10;
                }
                else if ((int)loan.Type == 1)
                { //homeloan
                    loan.LoanID = "HOME" + currentTime; //string concatenation loanID sample : HOMELOAN20190912101552
                    loan.InterestRate = 10.85;
                }
                else//car loan
                {
                    loan.LoanID = "CAR" + currentTime; //string concatenation loanID sample : CARLOAN20190912101552
                    loan.InterestRate = 8;
                }
                
                loan.DateOfApplication = time;
                loan.Status = (LoanStatus)Enum.Parse(typeof(LoanStatus), "APPLIED");

                Loans.Add(loan);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool GetLoanStatusDAL(string loanID)
        {
            try
            {
                foreach (LoanEntities loan in Loans)
                {
                    if (loan.LoanID.Equals(loanID))
                    {
                        Console.WriteLine(loan.Status);
                        break;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByCustomerID_DAL(string customerID)
        {
            foreach(LoanEntities loan in Loans)
            {
                if (loan.CustomerID.Equals(customerID) == true)
                    return loan;
            }

            //// if not found return a null object
            LoanEntities emptyObj = new LoanEntities();
            return emptyObj;
        }

        ////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByLoanID_DAL(string loanID)
        {
            foreach (LoanEntities loan in Loans)
            {
                if (loan.LoanID.Equals(loanID) == true)
                    return loan;
            }

            //// if not found return a null object
            LoanEntities emptyObj = new LoanEntities();
            return emptyObj;
        }

        ////////////////////////////////////////////////////////////////////////////////
        public void ApproveLoanDAL(string loanID)
        {
            try
            {
                foreach (LoanEntities loan in Loans)
                {
                    if (loan.LoanID.Equals(loanID))
                    {
                        Console.WriteLine("Current status of loan is as follows : ");
                        Console.WriteLine("Cusotmer ID : " + loan.CustomerID);
                        Console.WriteLine("Income : " + loan.Income);
                        Console.WriteLine("Amount Applied : " + loan.AmountApplied);
                        Console.WriteLine("Interest Rate : " + loan.InterestRate);
                        Console.WriteLine("Applied EMI : " + loan.EMI);
                        Console.WriteLine("Tenure : " + loan.Tenure);
                        Console.WriteLine("Date of application : " + loan.DateOfApplication);
                        Console.WriteLine("Types : " + loan.Type);
                        Console.WriteLine("Current Status : " + loan.Status);

                        Console.WriteLine("Enter modified status");
                        string modStatus = Console.ReadLine();
                        LoanStatus modStatusEnum;
                        bool isValid = Enum.TryParse(modStatus, out modStatusEnum);
                        if (isValid == true)
                            loan.Status = modStatusEnum;
                        else
                            Console.WriteLine("Not a valid loan status!");
                        break;
                    }
                }
            }
            catch(Exception e)
            {

            }
            
                
        }
    }
}
                   