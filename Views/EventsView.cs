using Spectre.Console;

namespace Eykt 
{
    public class EventsView 
    {
        public EventsView()
        {
            AnsiConsole.Clear();
            // Create a table
            var table = new Table();
            table.Border(TableBorder.Ascii);
            table.BorderColor(Color.Blue);

            // Add some columns
            table.AddColumn("ID");
            table.AddColumn(new TableColumn("Name").Centered());
            table.AddColumn(new TableColumn("Date").Centered());
            table.AddColumn(new TableColumn("Description").Centered().Width(100));

            table.AddRow("1", "TestEvent", "2023-03-24", "BlahblahblahblahblahblahblahBlahblahblahblahblahblahblahBlahblahblahblahblahblahblah");
            table.AddRow("2", "TestEven2", "2023-03-27", "Random garbage");

            // Render the table to the console
            AnsiConsole.Write(table);
        }
    }
}