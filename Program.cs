using Spectre.Console;

namespace Eykt
{
    public static class Program
    {
        public static void Main()
        {
            EyktContext db = new();
            PrintMainMenu(db);
        }

        public static void PrintMainMenu(EyktContext db)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(
                new FigletText("EYKT")
                    .Centered()
                    .Color(Color.DarkOrange));

            var mainMenuSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What to do [red]next?[/]")
                    .HighlightStyle(new Style(foreground: Color.Blue))
                    .PageSize(10)
                    .AddChoices(new[] {
                        "1. View events", "2. Edit event types", "2. Exit",
                    }));
            if (mainMenuSelection == "1. View events")
                new EventsView(db);
            else if (mainMenuSelection == "2. Edit event types") 
                new  EventTypesView(db);
            else
            {
                AnsiConsole.Clear();
                return;
            }
        }
    }
}
