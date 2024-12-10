
using System;
using System.Linq;
namespace MortgageCalculator
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Mortgage mortgage = new Mortgage(650000 - 50000, 8.88m, 30);
            decimal monthlyPayment = MortgageCalculator.CalculateMonthlyPayment(mortgage);
            Console.WriteLine($"monthly payment: {monthlyPayment}");

        }


        /*
        M = P [ i (1 + i)^n ] / [ (1 + i)^n – 1]
        public static decimal CalculateMonthlyPayment(decimal loanAmount, decimal monthlyInterest, int LoanTimeInYears)
        {
            decimal monthlyRate = monthlyInterest / 100 / 12;
        
            int totalPayments = LoanTimeInYears * 12;
        
            decimal monthlyPayment = loanAmount *
                (monthlyRate * (decimal)Math.Pow(1 + (double)monthlyRate, totalPayments))
                /
                ((decimal)Math.Pow(1 + (double)monthlyRate, totalPayments) - 1);
            return Math.Round(monthlyPayment, 2);
        }

        */
        public class Bank
        {
            string bankName { get; set;}
            public List<Customer>Customers=new List<Customer>();


        }



            public class Customer
        {
            public string Name { get; set;}
            public List<Mortgage> houses = new List<Mortgage>();
            public Customer(string name/*, decimal homePrice, decimal downPayment*/) // constructor
            {
                Name = name;                
            }

            public void ShowMyMortgages()
            {
                if (houses.Count == 0)
                {
                    Console.WriteLine("You have no mortgages");
                }
                else
                {
                    foreach (var house in houses)
                    {
                        Console.WriteLine($"Account Number: {house.AccountNumber}");
                        Console.WriteLine($"Loan Amount: {house.LoanAmount}");
                        Console.WriteLine($"Annual Interest Rate: {house.AnnualInterestRate}");
                        Console.WriteLine($"Loan Time in Years: {house.LoanTimeInYears}");
                        Console.WriteLine($"Monthly Payment: {house.monthlyPayment}");
                    }
                }
            }
        }




        public class Mortgage
        {
            public string AccountNumber { get;private set; }
            public decimal LoanAmount { get; set; }
            public decimal AnnualInterestRate { get; set; }
            public int LoanTimeInYears { get; set; }
            public decimal monthlyPayment { get; private set; }
            
            public Mortgage(decimal loanAmount, decimal annualInterestRate, int loanTimeInYears) // mortgage constructor
            {
                LoanAmount = loanAmount;
                AnnualInterestRate = annualInterestRate;
                LoanTimeInYears = loanTimeInYears;
                monthlyPayment = MortgageCalculator.CalculateMonthlyPayment(this);
                AccountNumber = AccountNumberGenerator();
            }

            private static string AccountNumberGenerator() 
            { Random random= new Random();
                int length = 5;
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
               
                return new string(Enumerable.Repeat(chars, length).Select(s => s[ (random.Next(s.Length)) ]).ToArray());

            }                        
        }

        public class MortgageCalculator
        {
            // M = P [ i (1 + i)^n ] / [ (1 + i)^n – 1]
            public static decimal CalculateMonthlyPayment(Mortgage mortgage)
            {

                decimal monthlyRate = mortgage.AnnualInterestRate / 100 / 12;
                int totalPayments = mortgage.LoanTimeInYears * 12;

                decimal monthlyPayment = mortgage.LoanAmount *
                    (monthlyRate * (decimal)Math.Pow(1 + (double)monthlyRate, totalPayments)) /
                    ((decimal)Math.Pow(1 + (double)monthlyRate, totalPayments) - 1);

                return Math.Round(monthlyPayment, 2);
            }

        }
    }
}