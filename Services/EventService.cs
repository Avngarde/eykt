namespace Eykt 
{
    public static class EventService
    {
        private static EyktContext db = new();
        public static Event[] GetEvents() 
        {
            return db.Events
                .OrderBy(e => e.Date)
                .ToArray();
        }

        public static Event GetEvent(int id) 
        {
            return db.Events
                .Where(b => b.EventId == id)
                .First();
        }

        public static void AddEvent(string name, DateOnly date, EventType type, string description) 
        {
            Event newEvent = new() 
            {
                Name = name,
                Description = description,
                Type = type,
                Date = date
            };
            db.Events.Add(newEvent);
            db.SaveChanges();
        }
    }
}
