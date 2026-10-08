using System;
using System.Collections.Generic;
using System.Linq;
using BankingSystem.Models;

using BankingSystem.Interfaces ;


namespace BankingSystem.Services
{
    public class BankService : IBankService
    {
        private Dictionary<string,Account> _accounts = new Dictionary<string, Account>();

        //create account
        public void CreateAccount(Account account)
        {
            if (_accounts.ContainsKey(account.AccountNumber))
            {
                throw new InvalidOperationException("Account already exists");
            }
            else
            {
                _accounts.Add(account.AccountNumber,account);
                Console.WriteLine("Account created Successfully....");
                Console.WriteLine($"Account No : {account.AccountNumber}");
                Console.WriteLine($"Name :{account.AccountHolderName}");
            }
        }

        //get account
        private Account GetAccount(string accountNumber)
        {
            if (_accounts.TryGetValue(accountNumber, out Account account))
                return account;

            throw new KeyNotFoundException(
                $"Account {accountNumber} not found!");
        }

        // deposit amount 
        public void Deposit(string accountNumber,decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Amount must be greater than 0..");
            }

            Account acc = GetAccount(accountNumber);
            acc.UpdateBalance(amount);

            acc.Transactions.Add(new TransactionHistory
            {
                TransactionType = "Depoist",
                Amount = amount,
                TransactionDate = DateTime.Now,
                Description = $"Deposited ₹{amount}"
            });

            Console.WriteLine($"✅ Deposited ₹{amount} successfully!");
            Console.WriteLine($"New Balance : ₹{acc.Balance}");
        }

        // withdraw amount
        public void WithDraw(string accountNumber,decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Amount must be greater than 0..");
            }

                 Account acc = GetAccount(accountNumber);
            if (amount > acc.Balance)
            {
                throw new InvalidOperationException($"Insufficient balance! Available: ₹{acc.Balance}");

            }
            acc.UpdateBalance(-amount);
            acc.Transactions.Add(new TransactionHistory
            {
                TransactionType = "Withdrawal",
                Amount          = amount,
                TransactionDate = DateTime.Now,
                Description     = $"Withdrew ₹{amount}"
            });

            Console.WriteLine($"✅ Withdrawn ₹{amount} successfully!");
            Console.WriteLine($"New Balance : ₹{acc.Balance}");
        }

        // view all details
        public void ViewAllAccountDetails()
        {
            if (!_accounts.Any())
            {
                 Console.WriteLine("No accounts found!");
                return;
            }

            foreach(var acc in _accounts.Values)
            {
             acc.PrintDetails();
               Console.WriteLine("----------------------------------");   
            }
        }
        // view all transaction history
        public void ViewTransactionHistory(string accountNumber)
        {
            Account acc = GetAccount(accountNumber);

            if (!acc.Transactions.Any())
            {
                Console.WriteLine("No transactions yet!");
                return;
            }

            Console.WriteLine($"\n===== Transaction History =====");
            Console.WriteLine($"Account : {accountNumber}");
            Console.WriteLine($"Holder  : {acc.AccountHolderName}");
            Console.WriteLine("-------------------------------");

            foreach (var t in acc.Transactions)
            {
                Console.WriteLine($"Type   : {t.TransactionType}");
                Console.WriteLine($"Amount : ₹{t.Amount}");
                Console.WriteLine($"Date   : {t.TransactionDate}");
                Console.WriteLine($"Desc   : {t.Description}");
                Console.WriteLine("---");
            }
        }

        // search by name

        public void SearchByName(string name)
        {
            var result = _accounts.Values
                         .Where(a=>a.AccountHolderName.Contains(name,StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any())
            {
                Console.WriteLine($"No accounts found for '{name}'!");
                return;
            } 

            foreach(var acc in result)
            {
                acc.PrintDetails();
                Console.WriteLine("====");
            }          
        }
    }
}