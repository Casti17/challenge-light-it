using Microsoft.EntityFrameworkCore;
using PatientRegistry.Domain;

namespace PatientRegistry.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 23)),
                    mysqlOptions =>
                    {
                        mysqlOptions.EnableRetryOnFailure();
                    });
            }
        }
    }
}
