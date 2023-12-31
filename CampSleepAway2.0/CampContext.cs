using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CampSleepAway2._0;

public class CampContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Camper> Campers { get; set; }
    public DbSet<Councelor> Councelors { get; set; }
    public DbSet<NextOfKin> NextOfKins { get; set; }
    public DbSet<Cabin> Cabins { get; set; }
    public DbSet<CamperStay> Stays { get; set; }
    public DbSet<CouncelorAssignments> Assignments { get; set; }
    public DbSet<Visits> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //"C:\\Users\\samue\\source\\repos\\SlutUppgiftGrupp\\CampSleepAway2.0\\"
        var configuration = new ConfigurationBuilder()
            .SetBasePath("C:\\Users\\samue\\source\\repos\\SlutUppgiftGrupp\\CampSleepAway2.0\\")
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Local");

        optionsBuilder.UseSqlServer(connectionString)
            .LogTo(Console.WriteLine,
            new[] { DbLoggerCategory.Database.Name },
            LogLevel.Information)
            .EnableSensitiveDataLogging();
    }
}