using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Entities
{
    public enum TypeOfTranscation
    {
        Credit,
        Debit

    }
    public class TransactionEntities
    {
        private long _accountNo;
        private string _customerID;
        private TypeOfTranscation _type;
        private double _amount;
        private string _transactionID;
        private DateTime _dateOfTransaction;
        private string _mode;
        private string _chequeNo;

        public long AccountNo { get => _accountNo; set => _accountNo = value; }
        public string CustomerID { get => _customerID; set => _customerID = value; }
        public TypeOfTranscation Type { get => _type; set => _type = value; }
        public double Amount { get => _amount; set => _amount = value; }
        public string TransactionID { get => _transactionID; set => _transactionID = value; }
        public DateTime DateOfTransaction { get => _dateOfTransaction; set => _dateOfTransaction = value; }
        public string Mode { get => _mode; set => _mode = value; }
        public string ChequeNo { get => ChequeNo; set => ChequeNo = value; }
    }
}
