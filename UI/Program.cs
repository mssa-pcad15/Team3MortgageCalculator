using Spectre.Console;
internal class Program
{

    private static MortgageCalculator.Program.Customer currentCustomer;
    private static void Main(string[] args)
    {
        currentCustomer = new MortgageCalculator.Program.Customer("Reese");
        currentCustomer.houses.Add(new MortgageCalculator.Program.Mortgage(180000, 6.734m, 30));
        currentCustomer.houses.Add(new MortgageCalculator.Program.Mortgage(150000, 5.5m, 15));
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
        do
        {
            choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select one")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(new[] { "Mortgages", "Account", "Quit" }));
            switch (choice)
            {
                case "Mortgages":
                    ShowMortgagesMenu();
                    break;
                case "Account":
                    ShowAccountMenu();
                    break;
                case "Quit":
                    return;
            }
        } while (choice != "Quit");

    }
    static void ShowMortgagesMenu()
    {
        var choice = String.Empty;
        choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("What would you like to do?")
        .PageSize(10)
        .AddChoices(new[] {
            "Show Monthly Payments", "Remove Mortgage", "Back"
        }));

        switch (choice)
        {
            case "Show Monthly Payments":
                ShowMonthlyPayment();
                break;
            case "Remove Mortgage":
                RemoveMortgage();
                // when remove is selected, go to new menu
                // in new menu, show mortgages, and select one to remove
                break;
            case "Back":
                return;
        }
    }

    static void ShowMonthlyPayment()
    {
        if (currentCustomer.houses.Count == 0)
        {
            AnsiConsole.WriteLine("You have no mortgages");
            return;
        }
        foreach (var mortgage in currentCustomer.houses)
        {
            decimal monthlyPayment = MortgageCalculator.Program.MortgageCalculator.CalculateMonthlyPayment(mortgage);
            AnsiConsole.WriteLine($"The monthly payment for {mortgage.AccountNumber} is {monthlyPayment}");
        }

    }

    static void RemoveMortgage()
    {
        if (currentCustomer.houses.Count == 0)
        {
            AnsiConsole.WriteLine("You have no mortgages");
            return;
        }
        var choice = String.Empty;
        choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select mortgage to remove")
            .PageSize(10)
            .AddChoices(currentCustomer.houses.Select(h => h.AccountNumber).Concat(new string[] { "Cancel" }))
            );

        switch (choice)
        {
            case "Cancel":
                return;
            default:
                var mortgage = currentCustomer.houses.FirstOrDefault(h => h.AccountNumber == choice);
                if (mortgage != null)
                {
                    currentCustomer.houses.Remove(mortgage);
                    AnsiConsole.WriteLine($"Mortgage {mortgage.AccountNumber} removed");
                }
                break;
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
        "Show My Mortgages", "My Account Information", "Account Settings"
        }));

        switch (choice)
        {
            case "Show My Mortgages":

                // when my mortgages is selected, go to new menu
                // in new menu, show all mortgages
                // --------------maybe-----------------
                // choose to either remove or exit
                // if remove, go to new context menu to select which to delete
                ShowMyMortgages();
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
    public static void ShowMyMortgages()
    {
        if (currentCustomer.houses.Count == 0)
        {
            AnsiConsole.WriteLine("No mortgages found.");
            return;
        }

        foreach (var mortgage in currentCustomer.houses)
        {
            AnsiConsole.Markup($"\n[green]Loan Amount[/]: {mortgage.LoanAmount}\n" +
                               $"[green]Interest Rate[/]: {mortgage.AnnualInterestRate}%\n" +
                               $"[green]Loan Length[/]: {mortgage.LoanTimeInYears} years\n");
        }
    }




}