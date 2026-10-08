using System;
using System.Collections.Generic;

namespace BankingSystem.Models
{
    public abstract class Account
    {
     public string AccountNumber { get; set; }
          public string AccountHolderName { get; set; }
   
        private decimal _balance { get; set; }

        public List<TransactionHistory> Transactions { get; set; }
        public abstract decimal CalculateInterest();
        public decimal Balance => _balance;

        public Account(string accountNumber, string holderName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = holderName;
            _balance = initialBalance;
            Transactions = new List<TransactionHistory>();
        }

        public virtual void PrintDetails()
        {
            Console.WriteLine($"Account No : {AccountNumber}");
            Console.WriteLine($"Holder     : {AccountHolderName}");
            Console.WriteLine($"Balance    : {Balance}");
        }
public void UpdateBalance(decimal amount)
        {
            _balance+=amount;
        }



    }
}