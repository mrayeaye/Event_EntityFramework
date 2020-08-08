using System.Data.Entity;

namespace Event_EntityFramework.Model
{
    class EventDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}
