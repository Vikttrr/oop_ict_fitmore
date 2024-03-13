using FitmoRE.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitmoRE.Infrastructure.Persistence.Contexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Employee>? Employees { get; set; }

    public DbSet<Client>? Clients { get; set; }

    public DbSet<Branch>? Branches { get; set; }

    public DbSet<FitnessService>? FitnessServices { get; set; }

    public DbSet<GymRoom>? GymRooms { get; set; }

    public DbSet<Payment>? Payments { get; set; }

    public DbSet<Subscription>? Subscriptions { get; set; }

    public DbSet<Tariff>? Tariffs { get; set; }

    public DbSet<TrainingRegistration>? TrainingRegistrations { get; set; }

    public DbSet<TrainingSession>? TrainingSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}