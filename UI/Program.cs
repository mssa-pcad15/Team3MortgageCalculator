using Spectre.Console;
internal class Program
{

    
    private static void Main(string[] args)
    {
        //currentCustomer = new MortgageCalculator.Program.Customer("Reese");
        //currentCustomer.houses.Add(new MortgageCalculator.Program.Mortgage(180000, 6.734m, 30));
        //currentCustomer.houses.Add(new MortgageCalculator.Program.Mortgage(150000, 5.5m, 15));
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
        //MortgageCalculator.Program.Bank List<MortgageCalculator.Program.Bank>
        List<MortgageCalculator.Program.Bank> Corpos = new List<MortgageCalculator.Program.Bank>();

        Initialize(Corpos);



    }



    static void Initialize(List<MortgageCalculator.Program.Bank> corporation)
    {
        
            //---------------------
            var bankName = AnsiConsole.Prompt(
                    new TextPrompt<string>("What bank will you be working with today?"));
            MortgageCalculator.Program.Bank newBank = new MortgageCalculator.Program.Bank(bankName);

            corporation.Add(newBank);
            //---------------------
            var customerName = AnsiConsole.Prompt(
                    new TextPrompt<string>("What is your Name?"));
            MortgageCalculator.Program.Customer newCustomer = new MortgageCalculator.Program.Customer(customerName);

            newBank.customers.Add(newCustomer);

            //---------------------
            AnsiConsole.WriteLine($"Hello {newCustomer.Name}! Welcome to {newBank.BankName}!\nHow Can We Help You?");// add bank name to package
        while (true)
        {                                                                                               //==================
            ShowMenu(newCustomer);
        }
    }


    static void ShowMortgagesMenu(MortgageCalculator.Program.Customer customer)
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
                ShowMonthlyPayment(customer);
                break;
            case "Remove Mortgage":
                RemoveMortgage(customer);
                // when remove is selected, go to new menu
                // in new menu, show mortgages, and select one to remove
                break;
            case "Back":
                return;
        }
    }


    static void ShowMonthlyPayment(MortgageCalculator.Program.Customer customer)
    {
        if (customer.houses.Count == 0)
        {
            AnsiConsole.WriteLine("You have no mortgages");
            return;
        }
        foreach (var mortgage in customer.houses)
        {
            decimal monthlyPayment = MortgageCalculator.Program.MortgageCalculator.CalculateMonthlyPayment(mortgage);
            AnsiConsole.WriteLine($"The monthly payment for {mortgage.AccountNumber} is {monthlyPayment}");
        }
    }


    static void RemoveMortgage(MortgageCalculator.Program.Customer customer)
    {
        if (customer.houses.Count == 0)
        {
            AnsiConsole.WriteLine("You have no mortgages");
            return;
        }
        var choice = String.Empty;
        choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select mortgage to remove")
            .PageSize(10)
            .AddChoices(customer.houses.Select(h => h.AccountNumber).Concat(new string[] { "Cancel" }))
            );

        switch (choice)
        {
            case "Cancel":
                return;
            default:
                var mortgage = customer.houses.FirstOrDefault(h => h.AccountNumber == choice);
                if (mortgage != null)
                {
                    customer.houses.Remove(mortgage);
                    AnsiConsole.WriteLine($"Mortgage {mortgage.AccountNumber} removed");
                }
                break;
        }
    }


    static void ShowMenu(MortgageCalculator.Program.Customer customer)
    {
        var choice = String.Empty;
        choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("What would you like to do?")
        .PageSize(10)
        .AddChoices(new[] {
        "Show My Mortgages", "My Account", "Account Options","Quit"
        }));

        switch (choice)
        {
            case "Show My Mortgages":
                ShowMyMortgages(customer);
                break;
            case "My Account":
                ShowAccountMenu(customer);
                break;
            case "Account Options":
                //CustomerAccountSettings();
                break;
            case "Quit":
                System.Environment.Exit(0); 
                return;
        }
    }


    static void ShowAccountOptions(MortgageCalculator.Program.Customer customer)
    {

    }

        static void ShowAccountMenu(MortgageCalculator.Program.Customer customer)
    {

        var choice = String.Empty;
        do
        {
            choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select one")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(new[] { "Add Mortgage" ,"Mortgage Info", "Back" }));
            switch (choice)
            {
                case "Add Mortgage":
                    //add mortgage func
                    break ;
                case "Mortgages":
                    ShowMortgagesMenu(customer);
                    break;
                case "Back":
                    ShowMenu(customer);
                    break;
                
            }
        } while (choice != "Quit");


        //var choice = String.Empty;
        //choice = AnsiConsole.Prompt(
        //new SelectionPrompt<string>()
        //.Title("What would you like to do?")
        //.PageSize(10)
        //.AddChoices(new[] {
        //"Show My Mortgages", "My Account Information", "Account Settings"
        //}));

        //switch (choice)
        //{
        //    case "Show My Mortgages":

        //        // when my mortgages is selected, go to new menu
        //        // in new menu, show all mortgages
        //        // --------------maybe-----------------
        //        // choose to either remove or exit
        //        // if remove, go to new context menu to select which to delete
        //        ShowMyMortgages();
        //        break;
        //    case "My Account Information":
        //        //CustomerAccount.Information;
        //        break;
        //    case "Account Settings":
        //        //CustomerAccountSettings();
        //        break;
        //    case "Quit":
        //        return;
        //}
    }

    public static void ShowMyMortgages(MortgageCalculator.Program.Customer customer)
    {
        if (customer.houses.Count == 0)
        {
            AnsiConsole.WriteLine("No mortgages found.");
            return;
        }

        foreach (var mortgage in customer.houses)
        {
            AnsiConsole.Markup($"\n[green]Loan Amount[/]: {mortgage.LoanAmount}\n" +
                               $"[green]Interest Rate[/]: {mortgage.AnnualInterestRate}%\n" +
                               $"[green]Loan Length[/]: {mortgage.LoanTimeInYears} years\n");
        }
    }




}