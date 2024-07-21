using Microsoft.EntityFrameworkCore;

namespace TaskManagementService {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Task>? Tasks { get; set; }
    }
}