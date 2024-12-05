using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator { 







    public class Customer
    {
        public string Name { get; set; }
        public decimal HomePrice { get; set; }
        public decimal DownPayment { get; set; }
        public decimal LoanAmount => HomePrice - DownPayment;

        public Customer(string name, decimal homePrice, decimal downPayment)
        {
            Name = name;
            HomePrice = homePrice;
            DownPayment = downPayment;
        }
    }
}


