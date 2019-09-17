using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Entities
{
    public enum LoanType
    {
        EDULOAN = 0, HOMELOAN = 1, CARLOAN = 2
    }
    public enum LoanStatus
    {
        APPLIED, PROCESSING, REJECTED, APPROVED
    }
    public class LoanEntities
    {
        private string _loanID;
        private string _customerID;
        private double _income;
        private double _amountApplied;
        private double _interestRate;
        private double _EMI;//
        private int _tenure;
        private DateTime _dateOfApplication;
        private LoanType _type;
        private LoanStatus _status;
        
        

        ////////////////////////////////// properties/////////////////////////
        public string LoanID { get => _loanID; set => _loanID = value; }
        public string CustomerID { get => _customerID; set => _customerID = value; }
        public double Income { get => _income; set => _income = value; }
        public double AmountApplied { get => _amountApplied; set => _amountApplied = value; }
        public double InterestRate { get => _interestRate; set => _interestRate = value; }
        public double EMI { get => _EMI; set => _EMI = value; }
        public int Tenure { get => _tenure; set => _tenure = value; }
        public DateTime DateOfApplication { get => _dateOfApplication; set => _dateOfApplication = value; }
        public LoanStatus Status { get => _status; set => _status = value; }
        public LoanType Type { get => _type; set => _type = value; }
    }
}
