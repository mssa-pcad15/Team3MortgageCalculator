
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
            public string BankName { get; set;}
           
            public List<Customer>customers=new List<Customer>();
           
            public Bank(string name) 
            { 
            BankName=name;                        
            }
        }

        public class Customer
        {
            public string Name { get; set;}
            public List<Mortgage> houses = new List<Mortgage>();
            public Customer(string name) // constructor
            {
                Name = name;                
                //    HomePrice = homePrice;
                //    DownPayment = downPayment;
                //    HomePrice = homePrice;
                //    DownPayment = downPayment;
                //    HomePrice = homePrice;
                //    DownPayment = downPayment;
                //    HomePrice = homePrice;
                //    DownPayment = downPayment;
                //    HomePrice = homePrice;
                //    DownPayment = downPayment;
            }

            public void RemoveMortgage(Mortgage mortgage)
            {
                houses.Remove(mortgage);
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