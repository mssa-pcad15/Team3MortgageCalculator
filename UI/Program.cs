using Spectre.Console;
using static MortgageCalculator.Program;

internal class Program
{

    
    private static void Main(string[] args)
    {
        List<Bank> Corpos = new List<Bank>();

        Initialize(Corpos);
    }
    //test upload

    static void Initialize(List<Bank> corporation)
    {
        
            //---------------------
            var bankName = AnsiConsole.Prompt(
                    new TextPrompt<string>("What bank will you be working with today?"));
            Bank newBank = new Bank(bankName);

            corporation.Add(newBank);
            //---------------------
            var customerName = AnsiConsole.Prompt(
                    new TextPrompt<string>("What is your Name?"));
            Customer newCustomer = new Customer(customerName);

            newBank.customers.Add(newCustomer);

        //---------------------
        AnsiConsole.Write(
new FigletText(newBank.BankName)
    .LeftJustified()
    .Color(Color.Red));
        AnsiConsole.WriteLine($"Hello {newCustomer.Name}! Welcome to {newBank.BankName}!\nHow Can We Help You?");// add bank name to package
        while (true)
        {                                                                                               
            ShowMenu(newCustomer);
        }
    }
    static void ShowMenu(Customer customer)
    {
        var choice = String.Empty;
        choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("What would you like to do?")
        .PageSize(10)
        .AddChoices(new[] {
        "Mortgages", "Account Options","Quit"
        }));

        switch (choice)
        {
            case "Mortgages":
                MortgagesMenu(customer);
                break;
            
            case "Account Options":
                ShowAccountOptions(customer);
                break;
            case "Quit":
                System.Environment.Exit(0); 
                return;
        }
    }
    //test

    static void MortgagesMenu(Customer customer)
    {
        var choice = String.Empty;
        choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("What would you like to do?")
        .PageSize(10)
        .AddChoices(new[] {
            "Add Mortgage","Show Monthly Payments", "Remove Mortgage", "Back"
        }));

        switch (choice)
        {
            case "Add Mortgage":
                AddMortgage(customer);
                break;
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
    private static void AddMortgage(Customer customer)
    {
        decimal loanAmount = AnsiConsole.Ask<decimal>("Enter loan [green]amount[/]:");
        decimal interestRate = AnsiConsole.Ask<decimal>("Enter annual interest [green]rate[/] (%):");
        int loanTime = AnsiConsole.Ask<int>("Enter loan [green]time[/] (years):");

        var mortgage = new Mortgage(loanAmount, interestRate, loanTime);
       customer.houses.Add(mortgage);
        // Calculate and display the monthly payment
        
        AnsiConsole.MarkupLine($"[green]Mortgage added successfully![/]");
        AnsiConsole.MarkupLine($"[yellow]Monthly Payment:[/] {mortgage.monthlyPayment:C}");
        AnsiConsole.MarkupLine("[green]Mortgage added successfully![/]");
    }
    static void ShowMonthlyPayment(Customer customer)
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
    static void RemoveMortgage(Customer customer)
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
    static void ShowAccountOptions(Customer customer)
    {
       var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        
        .PageSize(10)
        .AddChoices(new[] {
        "LogOut","Back"
        }));

        switch (choice)
        {
            case "LogOut":
               System.Environment.Exit(0);
                return;
            case "Back":
                ShowMenu(customer);
                break;
        }
    }
    public static void ShowMyMortgages(Customer customer)
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