using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
	private static CustomerManager customerManager = new CustomerManager();

	private static void Main(string[] args)
	{
		while (true)
		{
			var choice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("Select an option")
					.AddChoices("Manage Customers", "Manage Mortgages", "Quit"));

			switch (choice)
			{
				case "Manage Customers":
					CustomerManagementMenu();
					break;
				case "Manage Mortgages":
					MortgageManagementMenu();
					break;
				case "Quit":
					return;
			}
		}
	}

	private static void CustomerManagementMenu()
	{
		while (true)
		{
			var choice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("Customer Management")
					.AddChoices("Add Customer", "View Customers", "Back"));

			switch (choice)
			{
				case "Add Customer":
					AddCustomer();
					break;
				case "View Customers":
					ViewCustomers();
					break;
				case "Back":
					return;
			}
		}
	}

	private static void AddCustomer()
	{
		string name = AnsiConsole.Ask<string>("Enter customer [green]name[/]:");
		if (customerManager.CustomerExists(name))
		{
			AnsiConsole.MarkupLine("[yellow]Customer already exists![/]");
			return;
		}

		var customer = new Customer(name);
		customerManager.AddCustomer(customer);
		AnsiConsole.MarkupLine($"[green]Customer {name} added successfully![/]");
	}

	private static void ViewCustomers()
	{
		var customers = customerManager.GetAllCustomers();
		if (!customers.Any())
		{
			AnsiConsole.MarkupLine("[red]No customers found.[/]");
			return;
		}

		var selectedCustomer = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title("Select a customer")
				.AddChoices(customers.Select(c => c.Name).Concat(new[] { "Back" })));

		if (selectedCustomer != "Back")
			DisplayCustomerDetails(selectedCustomer);
	}

	private static void DisplayCustomerDetails(string name)
	{
		var customer = customerManager.GetCustomer(name);
		if (customer == null)
		{
			AnsiConsole.MarkupLine("[red]Customer not found.[/]");
			return;
		}

		AnsiConsole.MarkupLine($"[green]{customer.Name}'s Mortgages:[/]");
		foreach (var mortgage in customer.Mortgages)
		{
			AnsiConsole.MarkupLine($"- Loan: {mortgage.LoanAmount:C}, Rate: {mortgage.AnnualInterestRate}%, Time: {mortgage.LoanTimeInYears} years");
		}
	}

	private static void MortgageManagementMenu()
	{
		var customers = customerManager.GetAllCustomers();
		if (!customers.Any())
		{
			AnsiConsole.MarkupLine("[red]No customers available. Add customers first.[/]");
			return;
		}

		var selectedCustomer = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title("Select a customer to manage mortgages")
				.AddChoices(customers.Select(c => c.Name).Concat(new[] { "Back" })));

		if (selectedCustomer != "Back")
			ManageCustomerMortgages(selectedCustomer);
	}

	private static void ManageCustomerMortgages(string name)
	{
		var customer = customerManager.GetCustomer(name);
		if (customer == null) return;

		while (true)
		{
			var choice = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title($"Manage [green]{name}[/]'s Mortgages")
					.AddChoices("Add Mortgage", "View Mortgages", "Back"));

			switch (choice)
			{
				case "Add Mortgage":
					AddMortgage(customer);
					break;
				case "View Mortgages":
					DisplayCustomerDetails(name);
					break;
				case "Back":
					return;
			}
		}
	}

	private static void AddMortgage(Customer customer)
	{
		decimal loanAmount = AnsiConsole.Ask<decimal>("Enter loan [green]amount[/]:");
		decimal interestRate = AnsiConsole.Ask<decimal>("Enter annual interest [green]rate[/] (%):");
		int loanTime = AnsiConsole.Ask<int>("Enter loan [green]time[/] (years):");

		var mortgage = new Mortgage(loanAmount, interestRate, loanTime);
		customer.AddMortgage(mortgage);

		AnsiConsole.MarkupLine("[green]Mortgage added successfully![/]");
	}
}

public class CustomerManager
{
	private readonly Dictionary<string, Customer> customers = new Dictionary<string, Customer>();

	public void AddCustomer(Customer customer) => customers[customer.Name] = customer;

	public bool CustomerExists(string name) => customers.ContainsKey(name);

	public Customer GetCustomer(string name) => customers.TryGetValue(name, out var customer) ? customer : null;

	public IEnumerable<Customer> GetAllCustomers() => customers.Values;
}

public class Customer
{
	public string Name { get; }
	public List<Mortgage> Mortgages { get; } = new List<Mortgage>();

	public Customer(string name) => Name = name;

	public void AddMortgage(Mortgage mortgage) => Mortgages.Add(mortgage);
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



