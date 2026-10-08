// Models/CurrentAccount.cs
namespace BankingSystem.Models
{
    public class CurrentAccount : Account
    {
        public decimal InterestRate = 0.02m;  // 2%
        public decimal OverdraftLimit = 5000m;

        public CurrentAccount(string accNo, string holder, decimal balance)
            : base(accNo, holder, balance) { }

        public override decimal CalculateInterest()
        {
            return Balance * InterestRate;
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Type          : Current");
            Console.WriteLine($"Interest      : {CalculateInterest()}");
            Console.WriteLine($"Overdraft Limit: {OverdraftLimit}");
        }
    }
}