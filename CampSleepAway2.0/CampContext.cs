using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CampSleepAway2._0;

public class CampContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Camper> Campers { get; set; }
    public DbSet<Councelor> Councelors { get; set; }
    public DbSet<NextOfKin> NextOfKins { get; set; }
    public DbSet<Cabin> Cabins { get; set; }
    public DbSet<CamperStay> CamperStays { get; set; }
    public DbSet<CouncelorAssignment> CouncelorAssignments { get; set; }
    public DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            .SetBasePath("C:\\Users\\Samuel Sandenäs\\source\\repos\\SlutUppgiftGrupp\\CampSleepAway2.0\\")
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Local");

        optionsBuilder.UseSqlServer(connectionString)
            .LogTo(Console.WriteLine,
            new[] { DbLoggerCategory.Database.Name },
            LogLevel.Information)
            .EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Person>(entity =>
        //{
        //    entity.HasKey(x => x.Id);
        //    entity.Property(x => x.Id).ValueGeneratedOnAdd();
        //    entity.HasAlternateKey(x => new { x.Id, x.Id});
        //});

        modelBuilder.Entity<Councelor>()
            .HasOne(c => c.Person)
            .WithMany()
            .HasForeignKey(c => c.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Camper>()
            .HasOne(c => c.Person)
            .WithMany()
            .HasForeignKey(c => c.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NextOfKin>()
            .HasOne(n => n.Person)
            .WithMany()
            .HasForeignKey(n => n.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}