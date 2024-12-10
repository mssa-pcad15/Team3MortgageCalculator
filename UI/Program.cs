using Spectre.Console;
internal class Program
{
	private static Dictionary<string, List<Mortgage>> customers = new Dictionary<string, List<Mortgage>>();

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

	public static void CustomerNamesMenu()
	{
		if (customers.Count == 0)
		{
			AnsiConsole.MarkupLine("[red]No customers found.[/]");
			return;
		}

		var choice = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title("Select a customer to view details")
				.PageSize(10)
				.AddChoices(customers.Keys.Concat(new[] { "Back" })));

		if (choice == "Back")
			return;

		ShowCustomerDetails(choice);
	}

	static void AddCustomer()
	{
		string customerName = AnsiConsole.Ask<string>("Enter the [green]customer name[/]:");
		if (customers.ContainsKey(customerName))
		{
			AnsiConsole.MarkupLine("[yellow]Customer already exists.[/]");
			return;
		}

		customers[customerName] = new List<Mortgage>();

		string addMore;
		do
		{
			decimal loanAmount = AnsiConsole.Ask<decimal>("Enter the [green]loan amount[/]:");
			decimal interestRate = AnsiConsole.Ask<decimal>("Enter the [green]annual interest rate[/] (%):");
			int loanTime = AnsiConsole.Ask<int>("Enter the [green]loan time[/] (in years):");

			customers[customerName].Add(new Mortgage(loanAmount, interestRate, loanTime));

			addMore = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("Do you want to add another mortgage?")
					.AddChoices("Yes", "No"));
		} while (addMore == "Yes");

		AnsiConsole.MarkupLine($"[bold green]Customer {customerName} added successfully![/]");
	}


	public static void ShowCustomerDetails(string customerName)
	{
		if (!customers.ContainsKey(customerName))
		{
			AnsiConsole.MarkupLine("[red]Customer not found.[/]");
			return;
		}

		var mortgages = customers[customerName];
		if (mortgages.Count == 0)
		{
			AnsiConsole.MarkupLine($"[yellow]{customerName} has no mortgages.[/]");
			return;
		}

		AnsiConsole.MarkupLine($"[bold green]{customerName}'s Mortgage Accounts:[/]");
		foreach (var mortgage in mortgages)
		{
			AnsiConsole.MarkupLine($"\n[green]Loan Amount[/]: {mortgage.LoanAmount:C}\n" +
								   $"[green]Interest Rate[/]: {mortgage.AnnualInterestRate}%\n" +
								   $"[green]Loan Length[/]: {mortgage.LoanTimeInYears} years\n");
		}

		AnsiConsole.WriteLine("\nPress any key to return...");
		Console.ReadKey(true);
	}

	private static void DisplayWelcome()
    {

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine($"[bold green]Welcome {currentCustomer.Name}![/]");
        AnsiConsole.MarkupLine("[yellow]Here are your available options:[/]");


    }

    static void ShowMortgagesMenu()
    {
		var choice = string.Empty;
		do
		{
			choice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("What would you like to do?")
					.PageSize(10)
					.AddChoices(new[] {
					"Show Monthly Payments",
					"Remove Mortgage",
					"Customer Names",
					"Back"
					}));

			switch (choice)
			{
				case "Show Monthly Payments":
					ShowMonthlyPayment();
					break;
				case "Remove Mortgage":
					RemoveMortgage();
					break;
				case "Customer Names":
					CustomerNamesMenu();
					break;
				case "Back":
					return;
			}
		} while (choice != "Back");
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
        do
        {
            choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .PageSize(10)
            .AddChoices(new[] {
        "Show My Mortgages", "My Account Information", "Customer Names", "Account Settings"
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
                case "Customer Names":
                    CustomerNamesMenu();
                    break;
                case "Quit":
                    return;
            }
        } while (choice != "Back");
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

    public class Mortgage
    {
        public decimal LoanAmount { get; }
        public decimal AnnualInterestRate { get; }
        public int LoanTimeInYears { get; }

        public Mortgage(decimal loanAmount, decimal annualInterestRate, int loanTimeInYears)
        {
            LoanAmount = loanAmount;
            AnnualInterestRate = annualInterestRate;
            LoanTimeInYears = loanTimeInYears;
        }
    }
}



