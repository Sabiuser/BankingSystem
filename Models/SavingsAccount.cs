
namespace BankingSystem.Models
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate = 0.05m;  

        public SavingsAccount(string accNo, string holder, decimal balance)
            : base(accNo, holder, balance) { }

        public override decimal CalculateInterest()
        {
            return Balance * InterestRate;
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Type       : Savings");
            Console.WriteLine($"Interest   : {CalculateInterest()}");
        }
    }
}