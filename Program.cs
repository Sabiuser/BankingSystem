// Console.WriteLine("Hello, World!");
using System;
using BankingSystem.Models;
using BankingSystem.Services;

BankService bankService = new BankService();
bankService.CreateAccount(new SavingsAccount("SBI001", "Sabi", 10000));
bankService.CreateAccount(new SavingsAccount("SBI002", "Kumar", 5000));
bankService.CreateAccount(new CurrentAccount("SBI003", "Raj", 20000));

Console.WriteLine("\n✅ Sample accounts created!");

bool running = true;
while (running)
{
    Console.WriteLine("\n==============================");
    Console.WriteLine("   BANK MANAGEMENT SYSTEM    ");
    Console.WriteLine("==============================");
    Console.WriteLine("1. View All Accounts");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Transaction History");
    Console.WriteLine("5. Search Account by Name");
    Console.WriteLine("6. Exit");
    Console.WriteLine("==============================");
    Console.Write("Choose option (1-6): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
            case "1":
            bankService.ViewAllAccountDetails();
            break;


            case "2":
            try
            {
                Console.Write("Enter Account Number: ");
                string accNo = Console.ReadLine();

                Console.Write("Enter Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                bankService.Deposit(accNo, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
            break;

            case "3":
            try
            {
                Console.Write("Enter Account Number: ");
                string accNo = Console.ReadLine();

                Console.WriteLine("Enter amount");
                decimal amount = decimal.Parse(Console.ReadLine());

                bankService.WithDraw(accNo,amount);
                
            }catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
            break;

            case "4":
            try
            {
                Console.Write("Enter Account Number: ");
                string accNo = Console.ReadLine();

                bankService.ViewTransactionHistory(accNo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
            break;

            case "5":
            try
            {
                    Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                bankService.SearchByName(name);
            }
             catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
            break;

            case "6":
            running = false;
            Console.WriteLine("\n✅ Thank you! Goodbye!");
            break;

        default:
            Console.WriteLine("❌ Invalid option! Choose 1-7");
            break;
    }
}