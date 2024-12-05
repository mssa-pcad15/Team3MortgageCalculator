﻿
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
        // M = P [ i (1 + i)^n ] / [ (1 + i)^n – 1]
        //public static decimal CalculateMonthlyPayment(decimal loanAmount, decimal monthlyInterest, int LoanTimeInYears)
        //{
        //    decimal monthlyRate = monthlyInterest / 100 / 12;
        //
        //    int totalPayments = LoanTimeInYears * 12;
        //
        //    decimal monthlyPayment = loanAmount *
        //        (monthlyRate * (decimal)Math.Pow(1 + (double)monthlyRate, totalPayments))
        //        /
        //        ((decimal)Math.Pow(1 + (double)monthlyRate, totalPayments) - 1);
        //    return Math.Round(monthlyPayment, 2);
        //}
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




        public class Mortgage
        {
            public decimal LoanAmount { get; set; }
            public decimal AnnualInterestRate { get; set; }
            public int LoanTimeInYears { get; set; }

            public Mortgage(decimal loanAmount, decimal annualInterestRate, int loanTimeInYears) // mortgage constructor
            {
                LoanAmount = loanAmount;
                AnnualInterestRate = annualInterestRate;
                LoanTimeInYears = loanTimeInYears;
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