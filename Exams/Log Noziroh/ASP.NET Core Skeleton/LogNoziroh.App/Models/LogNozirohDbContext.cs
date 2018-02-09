namespace LogNoziroh.App.Models
{
    using Microsoft.EntityFrameworkCore;

    public class LogNozirohDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }

        public LogNozirohDbContext(DbContextOptions<LogNozirohDbContext> options) : base(options)
        {
            this.InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            this.Database.EnsureCreated();
        }
    }
}