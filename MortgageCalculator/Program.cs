
namespace MortgageCalculator
{
    public class Program
    {
        private static void Main(string[] args)
        {

        }
        // M = P [ i (1 + i)^n ] / [ (1 + i)^n – 1]
        public static decimal CalculateMonthlyPayment(decimal loanAmount, decimal monthlyInterest, int LoanTimeInYears)
        {
            decimal monthlyRate = monthlyInterest / 100/12;

            int totalPayments = LoanTimeInYears * 12;

            decimal monthlyPayment = loanAmount *
                (monthlyRate * (decimal)Math.Pow(1 + (double)monthlyRate, totalPayments)) 
                /
                ((decimal)Math.Pow(1 + (double)monthlyRate, totalPayments) - 1);
            return Math.Round(monthlyPayment, 2);
        }
        public class Customer
        {
            public string Name { get; set; }
            public decimal HomePrice { get; set; }
            public decimal DownPayment { get; set; }
            public decimal LoanAmount => HomePrice - DownPayment;

            public Customer(string name, decimal homePrice, decimal downPayment) // constructor
            {
                Name = name;
                HomePrice = homePrice;
                DownPayment = downPayment;
            }
        }


    }
}