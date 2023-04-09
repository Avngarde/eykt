using Spectre.Console;

namespace Eykt 
{
    public class EventTypesView
    {
        public EyktContext db;
        
        public EventTypesView(EyktContext dbCtx)
        {
            db = dbCtx;
            PrintMainTypesSelection();
        }

        private void PrintMainTypesSelection() 
        {
            AnsiConsole.Clear();
            PrintTypes();
            AnsiConsole.Write("\n");
            var typesMainSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What to do [purple]next?[/]")
                    .HighlightStyle(new Style(foreground: Color.Blue))
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Add new type", "Delete type", "Return to main menu"
                    }));
            if (typesMainSelection == "Add new type")
                AddNewTypeForm();
            else if (typesMainSelection == "Delete type")
                DeleteTypeForm();
            else if (typesMainSelection == "Return to main menu") 
                Program.PrintMainMenu(db);           
        }

        private void PrintTypes() 
        {
            var table = new Table();
            table.Border(TableBorder.Rounded);
            table.BorderColor(Color.DarkOrange);

            table.AddColumn("ID");
            table.AddColumn(new TableColumn("Name").Centered());

            EventType[] types = EventTypeService.GetTypes(db);
            foreach(EventType type in types) 
            {
                table.AddRow($"{type.EventTypeId}", $"{type.Name}");    
            }

            AnsiConsole.Write(table);
        }

        private string? GetTypeToDelete() 
        {
            EventType[] types = EventTypeService.GetTypes(db);
            List<string> choices = new();
            foreach(EventType type in types) 
            {
                choices.Add($"{type.EventTypeId} - {type.Name}");   
            }

            var typesMainSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What to do [purple]next?[/]")
                    .HighlightStyle(new Style(foreground: Color.Orange1))
                    .PageSize(10)
                    .AddChoices(choices.ToArray())
            );

            return typesMainSelection;            
        }

        private void AddNewTypeForm() 
        {
            AnsiConsole.Clear();
            var name = AnsiConsole.Ask<string>("New type [purple]name[/]:");
            EventTypeService.AddEvent(db, name);
            PrintMainTypesSelection();
        }

        private void DeleteTypeForm()
        {
            AnsiConsole.Clear();
            string deleteType = GetTypeToDelete();
            int eventId = Convert.ToInt16(deleteType.Split(" ")[0]);
            EventTypeService.DeleteType(db, eventId);
            PrintMainTypesSelection();
        }
    }
}