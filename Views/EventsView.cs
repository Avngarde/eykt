using Spectre.Console;

namespace Eykt 
{
    public class EventsView 
    {
        public EyktContext db;
        
        public EventsView(EyktContext dbCtx)
        {
            db = dbCtx;
            AnsiConsole.Clear();
            PrintEventsSelect();
        }

        public void PrintEvents() 
        {
            Table table = new Table();
            table.Border(TableBorder.Rounded);
            table.BorderColor(Color.Orange1);

            table.AddColumn("ID");
            table.AddColumn(new TableColumn("Name").Centered());
            table.AddColumn(new TableColumn("Date").Centered());
            table.AddColumn(new TableColumn("Description").Centered().Width(100));

            Event[] events = EventService.GetEvents(db);
            foreach(Event ev in events)
            {
                table.AddRow($"{ev.EventId}", $"{ev.Name}", $"{ev.Date.ToString("dd/MM/yyyy")}", $"{ev.Description}");
            }  

            AnsiConsole.Write(table);         
        }

        public void PrintEventsSelect() 
        {
            AnsiConsole.Clear();
            PrintEvents();
            AnsiConsole.Write("\n");
            var eventsMainSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What to do [purple]next?[/]")
                    .HighlightStyle(new Style(foreground: Color.Blue))
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Add new event", "Delete event", "Return to main menu"
                    }));
            if (eventsMainSelection == "Add new event")
                PrintAddEventForm();
            else if (eventsMainSelection == "Delete event")
                DeleteEventForm();
            else if (eventsMainSelection == "Return to main menu") 
                Program.PrintMainMenu(db); 
        }

        public void PrintAddEventForm() 
        {
            string[] choices = GetTypesChoiceArray();
            var name = AnsiConsole.Ask<string>("Event [purple]name[/]:");
            var date = AnsiConsole.Ask<string>("Event date ([green]dd/mm/yyyy[/]):");
            var type = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select event [purple]Type: [/]")
                    .HighlightStyle(new Style(foreground: Color.Blue))
                    .PageSize(10)
                    .AddChoices(choices)
                );
            var description = AnsiConsole.Ask<string>("Event [red]description[/]:");

            EventService.AddEvent(
                db,
                name,
                DateOnly.ParseExact(date, "dd/MM/yyyy"),
                EventTypeService.GetEventTypeByName(db, type),
                description
            );
            PrintEventsSelect();
        }

        public string[] GetTypesChoiceArray()
        {
            List<string> typeChoices = new();
            foreach(EventType type in EventTypeService.GetTypes(db))
            {
                typeChoices.Add(type.Name);
            }

            return typeChoices.ToArray();
        }

        public void DeleteEventForm() 
        {
            Event[] events = EventService.GetEvents(db);
            List<string> choices = new();
            foreach(Event evnt in events) 
            {
                choices.Add($"{evnt.EventId} - {evnt.Name}");   
            }

            var eventDeleteSelect = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What to do [purple]next?[/]")
                    .HighlightStyle(new Style(foreground: Color.Orange1))
                    .PageSize(10)
                    .AddChoices(choices.ToArray())
            );

            int id = Convert.ToInt16(eventDeleteSelect.Split(' ')[0]);
            EventService.DeleteEvent(db, id);
            PrintEventsSelect();
        }
    }
}