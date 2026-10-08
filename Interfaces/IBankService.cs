using System;

namespace BankingSystem.Interfaces 
{
    public interface IBankService
    {
        void WithDraw(string accountNumber,decimal amount);
        void Deposit(string accountNumber ,decimal amount);
        // void Transfer(string fromAccount, string toAccount, decimal amount);

        void ViewAllAccountDetails();
        void ViewTransactionHistory(string accountNumber);
    }
}