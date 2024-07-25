using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaskManagementService {
    public class ApplicationDbContext : IdentityDbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Task>? Tasks { get; set; }
    }
}