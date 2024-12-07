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
            decimal M = 1295.07m;//monthly mortgage
            decimal P =200000 ;//principal amount
            decimal i = 6.734m;//interest rate
            int n = 30;//loan length in years

            Program.Mortgage mortgage = new Program.Mortgage(P, i, n);

            decimal testValue = Program.MortgageCalculator.CalculateMonthlyPayment(mortgage);
            Program.Mortgage mortgage = new Program.Mortgage(P, i, n);

            decimal testValue = Program.MortgageCalculator.CalculateMonthlyPayment(mortgage);

            Assert.AreEqual(M, testValue);
    
        }





    }
}
