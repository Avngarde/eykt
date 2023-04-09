namespace Eykt 
{
    public static class EventTypeService
    {
        public static EventType[] GetTypes(EyktContext db) 
        {
            return db.EventTypes
                .OrderBy(e => e.EventTypeId)
                .ToArray();
        }

        public static EventType GetEventType(EyktContext db, int id) 
        {
            return db.EventTypes
                .Where(b => b.EventTypeId == id)
                .First();
        }

        public static EventType GetEventTypeByName(EyktContext db, string name) 
        {
            return db.EventTypes
                .Where(b => b.Name == name)
                .First();
        }

        public static void AddEvent(EyktContext db, string name) 
        {
            EventType newType = new() 
            {
                Name = name,
            };
            db.EventTypes.Add(newType);
            db.SaveChanges();
        }

        public static void DeleteType(EyktContext db, int id) 
        {
            EventType toDelete = GetEventType(db, id);
            db.EventTypes.Remove(toDelete);
            db.SaveChanges();
        }
    }
}
