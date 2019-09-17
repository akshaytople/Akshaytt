using Pecunia.Entities;
using Pecunia.Exceptions;
using Pecunia.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pecunia.BusinessLayer
{
    public class LoanBL
    {
        public bool ApplyLoanBL(LoanEntities loan)
        {

            if (Regex.IsMatch(loan.CustomerID, "[0-9]{14}$") == false)
                throw new InvalidStringException("Customer ID must be of 14 digits!");

            if (loan.AmountApplied < 50000 || loan.AmountApplied > 10000000)
                throw new InvalidAmountException("Loan amount must be between Rs.50000 to Rs.10000000 !");

            if (loan.Tenure > 10)
                throw new InvalidRangeException("Tenure can be maximum of 10 years!");

            //LoanType loanType;
            //if(Enum.TryParse(Parse.ToString(loan.Type), out loanType) == true)
            //{
                // for education loan no income bar required

                if ((int)loan.Type == 1 && loan.Income < 50000) // home loan
                    throw new InvalidAmountException("For applying home loan you must have minimum income of Rs.50000/month !");

                if((int)loan.Type == 2 && loan.Income < 30000) //car loan
                    throw new InvalidAmountException("For applying car loan you must have minimum income of Rs.30000/month !");
            //}
            //else
            //    throw new InvalidEnumException("Not a valid loan type, must be among HOMELOAN, EDULOAN, CARLOAN");

            LoanDAL loanDALobj = new LoanDAL(); 
            return loanDALobj.ApplyLoanDAL(loan);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        public bool GetLoanStatusBL(string loanID)
        {
            if (Regex.IsMatch(loanID, "[CARLOAN|HOMELOAN|EDULOAN][0-9]{14}$") == false)
                throw new InvalidStringException("Not a valid load ID!");

            LoanDAL loanDALobj = new LoanDAL();
            return loanDALobj.GetLoanStatusDAL(loanID);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByCustomerID_BL(string customerID)
        {
            if (Regex.IsMatch(customerID, "[0-9]{14}$") == false)
                throw new InvalidStringException("Not a valid customer ID");

            LoanDAL loanDALobj = new LoanDAL();
            return loanDALobj.GetLoanByCustomerID_DAL(customerID);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByLoanID_BL(string loanID)
        {
            if (Regex.IsMatch(loanID, "[CARLOAN|HOMELOAN|EDULOAN][0-9]{14}$") == false)
                throw new InvalidStringException("Not a valid loan ID");

            LoanDAL loanDALobj = new LoanDAL();
            return loanDALobj.GetLoanByLoanID_DAL(loanID);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void ApproveLoanBL(string loanID)
        {
            if (Regex.IsMatch(loanID, "[CARLOAN|HOMELOAN|EDULOAN][0-9]{14}$") == false)
                throw new InvalidStringException("Not a valid loan ID");

            LoanDAL loanDALobj = new LoanDAL();
            loanDALobj.ApproveLoanDAL(loanID);
        }

    }


    /////////////////////////////////////////// 
   
}
