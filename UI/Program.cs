using Spectre.Console;
internal class Program
{
    private static void Main(string[] args)
    {

        MortgageCalculator.Program.Bank tdBank = new MortgageCalculator.Program.Bank("TD Bank");
        MortgageCalculator.Program.Customer reese = new MortgageCalculator.Program.Customer("Reese");
        MortgageCalculator.Program.Mortgage house = new MortgageCalculator.Program.Mortgage(200000, 6.734m, 30);
        reese.houses.Add(house);

        ShowAccountMenu();


        static void ShowAccountMenu()
        {
            MortgageCalculator.Program.Mortgage house = new MortgageCalculator.Program.Mortgage(200000, 6.734m, 30);


            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .PageSize(10)
            .AddChoices(new[] {
            "My Mortgages", "My Account Information", "Account Settings"
            }));
            //switch (choice)
            //{
            //    case "My Mortgages":
            //        CustomerMortgages._mortgages;
            //        break;
            //    case "My Account Information":
            //        CustomerAccount.Information;
            //        break;
            //    case "Account Settings":
            //        CustomerAccountSettings();
            //        break;
            //    case "Quit":
            //        return;
            //}
        }
  


        AnsiConsole.Markup($"[green]Account[/]:{house.AccountNumber}\n[green]Loan Amount[/]:{house.LoanAmount}\n" +
            $"[green]Interest Rate[/]:{house.AnnualInterestRate:p}\n[green]Loan Length[/]:{house.LoanTimeInYears}");


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
