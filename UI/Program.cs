using Spectre.Console;
internal class Program
{

    private static MortgageCalculator.Program.Customer currentCustomer;
    private static void Main(string[] args)
    {

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
        //---------------------
        var bankName = AnsiConsole.Prompt(
                new TextPrompt<string>("What bank will you be working with today?"));
        MortgageCalculator.Program.Bank newBank = new MortgageCalculator.Program.Bank(bankName);

        Corpos.Add(newBank);
        //---------------------
        var customerName = AnsiConsole.Prompt(
                new TextPrompt<string>("What is your Name?"));
        MortgageCalculator.Program.Customer newCustomer = new MortgageCalculator.Program.Customer(customerName);

        newBank.customers.Add(newCustomer);

        //---------------------
        AnsiConsole.WriteLine($"Hello {newCustomer.Name}! Welcome to {newBank.BankName}!\nHow Can We Help You?");// add bank name to package
        //==================



        ShowAccountMenu();






        static void Initialize()
        {
            var bankName = AnsiConsole.Prompt(
                 new TextPrompt<string>("What bank will you be working with today?"));
            MortgageCalculator.Program.Bank tdBank = new MortgageCalculator.Program.Bank(bankName);


        }



        static void ShowMortgagesMenu()
        {
            var choice = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
             .Title("What would you like to do?")
             .PageSize(10)
             .AddChoices(new[] {
            "New Loan", "New Mortgage", "Remove Mortgage", "Quit"
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
            var choice = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
             .Title("What would you like to do?")
             .PageSize(10)
             .AddChoices(new[] {
            "My Mortgages", "My Account Information", "Account Settings","Quit"
             }));

            switch (choice)
            {
                case "My Mortgages":
                    ShowMortgagesMenu();
                    break;
                case "My Account Information":
                    ShowAccountInfo();
                    break;
                case "Account Settings":
                    //CustomerAccountSettings();
                    break;
                case "Quit":
                    return;

            }
        }

        static void ShowAccountInfo()
        {
            //AnsiConsole.Markup($"{}");




        }

        //AnsiConsole.Markup($"[green]Account[/]:{house.AccountNumber}\n[green]Loan Amount[/]:{house.LoanAmount}\n" +
        //$"[green]Interest Rate[/]:{house.AnnualInterestRate:p}\n[green]Loan Length[/]:{house.LoanTimeInYears}");


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
