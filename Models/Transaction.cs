using System;

namespace BankingSystem.Models
{
    public class TransactionHistory
    {
        public string TransactionType {get;set;}
        public decimal Amount {get;set;}
        public DateTime TransactionDate {get;set;}
        public string Description {get;set;}
    }
}