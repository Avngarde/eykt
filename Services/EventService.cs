namespace Eykt 
{
    public static class EventService
    {
        public static Event[] GetEvents(EyktContext db) 
        {
            return db.Events
                .OrderBy(e => e.Date)
                .ToArray();
        }

        public static Event GetEvent(EyktContext db, int id) 
        {
            return db.Events
                .Where(b => b.EventId == id)
                .First();
        }

        public static void AddEvent(EyktContext db, string name, DateOnly date, EventType type, string description) 
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
