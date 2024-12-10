using Spectre.Console;
using Spectre.Console.Cli;
using MortgageCalculator;
using System.Reflection;
internal class Program
{

    private static MortgageCalculator.Program.Customer currentCustomer;
    private static void Main(string[] args)
    {
        //currentCustomer = new MortgageCalculator.Program.Customer("Reese");
        //currentCustomer.Mortgages.Add(new MortgageCalculator.Program.Mortgage(180000, 6.734m, 30));
        //currentCustomer.Mortgages.Add(new MortgageCalculator.Program.Mortgage(150000, 5.5m, 15));
        //MortgageCalculator.Program.Bank tdBank = new MortgageCalculator.Program.Bank();
        //MortgageCalculator.Program.Customer reese= new MortgageCalculator.Program.Customer("Reese");
        //MortgageCalculator.Program.Mortgage house = new MortgageCalculator.Program.Mortgage(200000, 6.734m, 30);
        //reese.houses.Add(house);
        //
        //AnsiConsole.WriteLine($"Hello {reese.Name}! Welcome to {tdBank}");// add bank name to package
        //
        //
        //AnsiConsole.Markup($"[green]Account[/]:{house.AccountNumber}\n[green]Loan Amount[/]:{house.LoanAmount}\n" +
        //$"[green]Interest Rate[/]:{house.AnnualInterestRate:p}\n[green]Loan Length[/]:{house.LoanTimeInYears}");

        var choice = String.Empty;
        //while (choice != "Quit") ;
        //{
            choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select one")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(new[] { "Mortgages", "Account", "Quit" }));
            switch (choice)
            {
                case "Mortgages": ShowMortgagesMenu();
                        break;
                case "Account": ShowAccountMenu();
                        break;
                case "Quit": 
                    return;
            }
        //}

        static void ShowMortgagesMenu()
        {
            var choice = String.Empty;
            choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .PageSize(10)
            .AddChoices(new[] {
            "New Loan", "New Mortgage", "Remove Mortgage"
            }));

            switch (choice)
            {
                case "New Loan":
                    //MortgagesNewLoan();
                    break;
                case "New Mortgage":
                    //MortgagesNewMortgage();
                    break;
                case "Remove Mortgage":
                    //MortgagesRemoveMortgage();
                    break;
                case "Quit":
                    return;
            }
        }

        static void ShowAccountMenu()
        {
            var choice = String.Empty;
            choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .PageSize(10)
            .AddChoices(new[] {
            "My Mortgages", "My Account Information", "Account Settings"
            }));

            switch (choice)
            {
                case "My Mortgages":

                    // when my mortgages is selected, go to new menu
                    // in new menu, show all mortgages
                    // --------------maybe-----------------
                    // choose to either remove or exit
                    // if remove, go to new context menu to select which to delete
                    //this.Customer.MyMortgages;
                    break;
                case "My Account Information":
                    //CustomerAccount.Information;
                    break;
                case "Account Settings":
                    //CustomerAccountSettings();
                    break;
                case "Quit":
                    return;
            }
        }













        //AnsiConsole.Markup("[underline red]{Hello}[/] World");


        // Ask for the user's favorite fruit
        //var fruit = AnsiConsole.Prompt(
        //    new SelectionPrompt<string>()
        //        .Title("What's your [green]favorite fruit[/]?")
        //        .PageSize(10)
        //        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        //        .AddChoices(new[] {
        //    "Apple", "Apricot", "Avocado",
        //    "Banana", "Blackcurrant", "Blueberry",
        //    "Cherry", "Cloudberry", "Cocunut",
        //        }));

        // Echo the fruit back to the terminal
        //AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");


    }
}