namespace Eykt 
{
    public static class EventTypeService
    {
        private static EyktContext db = new();
        public static EventType[] GetTypes() 
        {
            return db.EventTypes
                .OrderBy(e => e.EventTypeId)
                .ToArray();
        }

        public static EventType GetEventType(int id) 
        {
            return db.EventTypes
                .Where(b => b.EventTypeId == id)
                .First();
        }

        public static void AddEvent(string name) 
        {
            EventType newType = new() 
            {
                Name = name,
            };
            db.EventTypes.Add(newType);
            db.SaveChanges();
        }

        public static void DeleteType(int id) 
        {
            EventType toDelete = GetEventType(id);
            db.EventTypes.Remove(toDelete);
            db.SaveChanges();
        }
    }
}
