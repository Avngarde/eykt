namespace Eykt
{
    public class Event
    {
        public int EventId { get; set; }
        public string? Name { get; set; }
        public DateOnly Date { get; set; }
        public EventType? Type { get; set; }
        public string? Description { get; set; }
    }
}