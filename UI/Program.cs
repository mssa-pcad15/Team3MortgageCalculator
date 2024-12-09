using Spectre.Console;
using Spectre.Console.Cli;
using MortgageCalculator;
internal class Program
{
    private static void Main(string[] args)
    {

   












        AnsiConsole.Markup("[underline red]{Hello}[/] World");


        // Ask for the user's favorite fruit
        var fruit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What's your [green]favorite fruit[/]?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices(new[] {
            "Apple", "Apricot", "Avocado",
            "Banana", "Blackcurrant", "Blueberry",
            "Cherry", "Cloudberry", "Cocunut",
                }));

        // Echo the fruit back to the terminal
        //AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");


    }
}