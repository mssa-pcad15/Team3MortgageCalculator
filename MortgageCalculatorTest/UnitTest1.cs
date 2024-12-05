using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageCalculator;


namespace MortgageCalculatorTest
{
    [TestClass]
    public class UnitTest1
    {


        //M = P [ i (1 + i)^n ] / [ (1 + i)^n – 1]
        /*
         The mortgage equation is used to calculate your monthly mortgage payment. 
        M = P [ i (1 + i)^n ] / [ (1 + i)^n – 1
        M, which is the monthly mortgage payment, 
        P, which is the principal amount,
        i, which is the monthly interest rate,
        n, which is the length of time you have to pay off your loan
         */
        [TestMethod]
        public void TestMonthlyMortgagePayment()
        {
            decimal M = 2339.45m;//monthly mortgage
            decimal P =400000-8000 ;//principal amount
            decimal i = 05.98m;//interest rate
            int n = 30;//loan length in years

            decimal testValue = Program.CalculateMonthlyPayment( P, i, n);
            Assert.AreEqual(M, testValue);
            
        }





    }
}