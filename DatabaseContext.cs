using Microsoft.EntityFrameworkCore;

namespace Eykt
{
    public class EyktContext : DbContext 
    {
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public string DbPath { get; }

        public EyktContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite($"Data Source={DbPath}");
    }
}