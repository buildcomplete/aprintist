using Microsoft.EntityFrameworkCore;

namespace aprintist.Models
{
    public class ObservationContext : DbContext
    {
        public ObservationContext (DbContextOptions<ObservationContext> options)
            : base(options)
        {
        }

        public DbSet<aprintist.Models.Observation> Movie { get; set; }
    }
}