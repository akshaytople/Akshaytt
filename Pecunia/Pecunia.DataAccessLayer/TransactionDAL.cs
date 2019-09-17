using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.DataAccessLayer;

namespace Pecunia.DataAccessLayer
{
    public class TransactionDAL
    {
        public static List<TransactionEntities> Transactions = new List<TransactionEntities>() { };

        public void StoreTransaction(long accountNo, double Amount, TypeOfTranscation type, string mode, string chequeNo)
        {
            //// retrieving customerID based on account No
            string customerID = "00000000000000";// dummy initialization to avoid warnings
            foreach(Account acc in AccountDAL.ListOfAccounts)
            {
                    if (acc.AccountNo == accountNo)
                        customerID = acc.CustomerID;
            }

            DateTime time = DateTime.Now;
            string transactionID = "TRANS" + time.ToString("yyyyMMddhhmmss");//sample transactionID : TRANS20190921154525

            TransactionEntities trans = new TransactionEntities();
            trans.AccountNo = accountNo;
            trans.CustomerID = customerID;
            trans.Type = type;
            trans.Amount = Amount;
            trans.TransactionID = transactionID;
            trans.DateOfTransaction = time;
            trans.Mode = mode;
            trans.ChequeNo = chequeNo;

            Transactions.Add(trans);
        }
        public bool DebitTransactionByWithdrawalSlipDAL(long AccountNo, double Amount)
        {
            int flag = 0;
            foreach (Account acc in AccountDAL.ListOfAccounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    acc.Balance = acc.Balance - Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Debit", out transEnum);
                    StoreTransaction(AccountNo, Amount, transEnum ,"WithdrawalSlip", null);
                    flag = 1;
                    break;
                }

            }
            if (flag == 1)
            {
                Console.WriteLine("Succesfully Debited");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number");
                return false;
            }
        }
        public bool CreditTransactionByWithdrawalSlipDAL(long AccountNo, double Amount)
        {
            int flag = 0;
            foreach (Account acc in AccountDAL.ListOfAccounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    acc.Balance = acc.Balance + Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Credit", out transEnum);
                    StoreTransaction(AccountNo, Amount, transEnum, "WithdrawalSlip", null);
                    flag = 1;
                    break;
                }

            }
            if (flag == 1)
            {
                Console.WriteLine("Succesfully Credited");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number");
                return false;
            }
        }
        public bool DebitTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo)
        {
            int flag = 0;
            foreach (Account acc in AccountDAL.ListOfAccounts)
            {
                if (acc.AccountNo == AccountNo && ValidateCheque(ChequeNo) == true)
                {
                    acc.Balance = acc.Balance - Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Debit", out transEnum);
                    StoreTransaction(AccountNo, Amount, transEnum, "Cheque", ChequeNo);
                    flag = 1;
                    break;
                }

            }
            if (flag == 1)
            {
                Console.WriteLine("Succesfully Debited");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number or Cheque");
                return false;
            }
        }
        public bool CreditTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo)
        {
            int flag = 0;
            foreach (Account acc in AccountDAL.ListOfAccounts)
            {
                if (acc.AccountNo == AccountNo && ValidateCheque(ChequeNo) == true)
                {
                    acc.Balance = acc.Balance + Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Credit", out transEnum);
                    StoreTransaction(AccountNo, Amount, transEnum, "Cheque", ChequeNo);
                    flag = 1;
                    break;
                }

            }
            if (flag == 1)
            {
                Console.WriteLine("Succesfully Credited");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number or Cheque");
                return false;
            }
        }
        public void DisplayTransactionByCustomerID_DAL(string CustomerID)
        {
            foreach (TransactionEntities trans in Transactions)
            {
                if (trans.CustomerID == CustomerID)
                {
                    Console.WriteLine(trans.AccountNo);
                    Console.WriteLine(trans.Type);
                    Console.WriteLine(trans.Amount);
                    Console.WriteLine(trans.TransactionID);
                    Console.WriteLine(trans.DateOfTransaction);
                    Console.WriteLine(trans.Mode);
                }
            }
        }
        public void DisplayTransactionByAccountNo_DAL(long AccountNo)
        {
            foreach (TransactionEntities trans in Transactions)
            {
                if (trans.AccountNo == AccountNo)
                {
                    Console.WriteLine(trans.CustomerID);
                    Console.WriteLine(trans.Type);
                    Console.WriteLine(trans.Amount);
                    Console.WriteLine(trans.TransactionID);
                    Console.WriteLine(trans.DateOfTransaction);
                    Console.WriteLine(trans.Mode);
                }
            }
        }
        public void DisplayTransactionDetailsByTransactionID_DAL(string TransactionID)
        {
            foreach (TransactionEntities trans in Transactions)
            {
                if (trans.TransactionID == TransactionID)
                {
                    Console.WriteLine(trans.CustomerID);
                    Console.WriteLine(trans.Type);
                    Console.WriteLine(trans.Amount);
                    Console.WriteLine(trans.TransactionID);
                    Console.WriteLine(trans.DateOfTransaction);
                    Console.WriteLine(trans.Mode);
                }
            }
        }
        public void GetAllTransactionsDAL()
        {
            foreach (TransactionEntities trans in Transactions)
            {
                Console.WriteLine(trans.CustomerID);
                Console.WriteLine(trans.AccountNo);
                Console.WriteLine(trans.Type);
                Console.WriteLine(trans.Amount);
                Console.WriteLine(trans.TransactionID);
                Console.WriteLine(trans.DateOfTransaction);
                Console.WriteLine(trans.Mode);

            }

        }
    }
}
