using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageCalculator;
using static MortgageCalculator.Program;


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
            decimal P = 200000;//principal amount
            decimal i = 6.734m;//interest rate
            int n = 30;//loan length in years

            Program.Mortgage mortgage = new Program.Mortgage(P, i, n);

            decimal testValue = Program.MortgageCalculator.CalculateMonthlyPayment(mortgage);
            
            //Program.Mortgage mortgage = new Program.Mortgage(P, i, n);
            //
            //decimal testValue = Program.MortgageCalculator.CalculateMonthlyPayment(mortgage);

            Assert.AreEqual(M, testValue);
        }

        [TestMethod]
        public void TestMortgageClass()
        {
            //decimal M = 1295.07m;//monthly mortgage



            decimal P = 200000;//principal amount ---
            decimal i = 6.734m;//interest rate      |-------assert these are the same in the class using the getter
            int n = 30;//loan length in years -------

            Program.Mortgage mortgage = new Program.Mortgage(P, i, n);



            Assert.AreEqual(P, mortgage.LoanAmount);//like this(now do it for annualInterestRate, and loanTimeInYears)



        }

        [TestMethod]
        public void TestCustomerClassMortgageList()
        {
            Customer sally = new Customer("Sally");
            //HOUSE 1 250k
            decimal M1 = 1295.07m;//monthly mortgage
            decimal P1 = 200000;//principal amount
            decimal i1 = 6.734m;//interest rate
            int n1 = 30;//loan length in years

            //HOUSE 2 600k
            decimal M2 = 3273.55m;//monthly mortgage
            decimal P2 = 546000;//principal amount
            decimal i2 = 6.00m;//interest rate
            int n2 = 30;//loan length in years

            //HOUSE 3 1250000
            decimal M3 = 6520.11m;//monthly mortgage
            decimal P3 = 1087500;//principal amount
            decimal i3 = 6.00m;//interest rate
            int n3 = 30;//loan length in years

            //HOUSE 4 1000000
            decimal M4 = 4796.40m;//monthly mortgage
            decimal P4 = 800000;//principal amount
            decimal i4 = 6.00m;//interest rate
            int n4 = 30;//loan length in years

            sally.houses = new List<Mortgage>
            {
                    new Mortgage(P1,i1,n1),
                    new Mortgage(P2, i2, n2),
                    new Mortgage(P3, i3, n3),
                    new Mortgage(P4, i4, n4)
            };

            Assert.AreEqual(P1, sally.houses[0].LoanAmount);
            Assert.AreEqual(P2, sally.houses[1].LoanAmount);
            Assert.AreEqual(P3, sally.houses[2].LoanAmount);
            Assert.AreEqual(P4, sally.houses[3].LoanAmount);

            Assert.AreEqual(i1, sally.houses[0].AnnualInterestRate);
            Assert.AreEqual(i2, sally.houses[1].AnnualInterestRate);
            Assert.AreEqual(i3, sally.houses[2].AnnualInterestRate);
            Assert.AreEqual(i4, sally.houses[3].AnnualInterestRate);

            Assert.AreEqual(n1, sally.houses[0].LoanTimeInYears);
            Assert.AreEqual(n2, sally.houses[1].LoanTimeInYears);
            Assert.AreEqual(n3, sally.houses[2].LoanTimeInYears);
            Assert.AreEqual(n4, sally.houses[3].LoanTimeInYears);            
        }

        [TestMethod]
        public void TestCustomerMortgageListUsingCalculateMortgage()
        {
            Customer sally = new Customer("Sally");

            //HOUSE 1 250k
            decimal M1 = 1295.07m;//monthly mortgage
            decimal P1 = 200000;//principal amount
            decimal i1 = 6.734m;//interest rate
            int n1 = 30;//loan length in years

            //HOUSE 2 600k
            decimal M2 = 3273.55m;//monthly mortgage
            decimal P2 = 546000;//principal amount
            decimal i2 = 6.00m;//interest rate
            int n2 = 30;//loan length in years

            //HOUSE 3 1250000
            decimal M3 = 6520.11m;//monthly mortgage
            decimal P3 = 1087500;//principal amount
            decimal i3 = 6.00m;//interest rate
            int n3 = 30;//loan length in years

            //HOUSE 4 1000000
            decimal M4 = 4796.40m;//monthly mortgage
            decimal P4 = 800000;//principal amount
            decimal i4 = 6.00m;//interest rate
            int n4 = 30;//loan length in years

            sally.houses = new List<Mortgage>
            {
                    new Mortgage(P1,i1,n1),
                    new Mortgage(P2, i2, n2),
                    new Mortgage(P3, i3, n3),
                    new Mortgage(P4, i4, n4)
            };

            Assert.AreEqual(M1, Program.MortgageCalculator.CalculateMonthlyPayment(sally.houses[0]));
            Assert.AreEqual(M2, Program.MortgageCalculator.CalculateMonthlyPayment(sally.houses[1]));
            Assert.AreEqual(M3, Program.MortgageCalculator.CalculateMonthlyPayment(sally.houses[2]));
            Assert.AreEqual(M4, Program.MortgageCalculator.CalculateMonthlyPayment(sally.houses[3]));
        }


        [TestMethod]
        public void TestBank()
        {   
            


            //HOUSE 1 250k
            decimal M1 = 1295.07m;//monthly mortgage
            decimal P1 = 200000;//principal amount
            decimal i1 = 6.734m;//interest rate
            int n1 = 30;//loan length in years

            //HOUSE 2 600k
            decimal M2 = 3273.55m;//monthly mortgage
            decimal P2 = 546000;//principal amount
            decimal i2 = 6.00m;//interest rate
            int n2 = 30;//loan length in years

            //HOUSE 3 1250000
            decimal M3 = 6520.11m;//monthly mortgage
            decimal P3 = 1087500;//principal amount
            decimal i3 = 6.00m;//interest rate
            int n3 = 30;//loan length in years

            //HOUSE 4 1000000
            decimal M4 = 4796.40m;//monthly mortgage
            decimal P4 = 800000;//principal amount
            decimal i4 = 6.00m;//interest rate
            int n4 = 30;//loan length in years



            Bank tdBank = new Bank();


            Customer sally = new Customer("Sally");
            Customer bobby = new Customer("Bobby");
            Customer sammy = new Customer("Sammy");
            Customer ross = new Customer("Ross");


            tdBank.Customers = new List<Customer>
            {
               sally, bobby, sammy, ross
            };

            sally.houses.Add(new Mortgage(P1, i1, n1));
            bobby.houses.Add(new Mortgage(P2, i2, n2));
            sammy.houses.Add(new Mortgage(P3, i3, n3));
            ross.houses.Add(new Mortgage(P4, i4, n4));
            

         

            Assert.AreEqual(M1, Program.MortgageCalculator.CalculateMonthlyPayment(sally.houses[0]));
            Assert.AreEqual(M2, Program.MortgageCalculator.CalculateMonthlyPayment(bobby.houses[0]));
            Assert.AreEqual(M3, Program.MortgageCalculator.CalculateMonthlyPayment(sammy.houses[0]));
            Assert.AreEqual(M4, Program.MortgageCalculator.CalculateMonthlyPayment(ross.houses[0]));
        }
    }
}



