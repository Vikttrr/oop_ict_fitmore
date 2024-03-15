using FitmoRE.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitmoRE.Infrastructure.Persistence.Contexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

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
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("Branch_pkey");

            entity.ToTable("Branch");

            entity.Property(e => e.BranchId).HasColumnName("branchId");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Workinghours).HasColumnName("workinghours");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("Client_pkey");

            entity.ToTable("Client");

            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("Employee_pkey");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Workschedule).HasColumnName("workschedule");
        });

        modelBuilder.Entity<FitnessService>(entity =>
        {
            entity.HasKey(e => e.Serviceid).HasName("FitnessService_pkey");

            entity.ToTable("FitnessService");

            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Roomid).HasColumnName("roomid");

            entity.HasOne(d => d.Employee).WithMany(p => p.FitnessServices)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("employeeid");

            entity.HasOne(d => d.Room).WithMany(p => p.FitnessServices)
                .HasForeignKey(d => d.Roomid)
                .HasConstraintName("FitnessService_roomid_fkey");
        });

        modelBuilder.Entity<GymRoom>(entity =>
        {
            entity.HasKey(e => e.Roomid).HasName("GymRoom_pkey");

            entity.ToTable("GymRoom");

            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.BranchId).HasColumnName("branchid");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.RoomNumber).HasColumnName("roomnumber");
            entity.Property(e => e.Space).HasColumnName("space");
            entity.Property(e => e.Temperature).HasColumnName("temperature");

            entity.HasOne(d => d.Branch).WithMany(p => p.GymRooms)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("GymRoom_branchid_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("Payment_pkey");

            entity.ToTable("Payment");

            entity.Property(e => e.Paymentid).HasColumnName("paymentid");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Ispaid).HasColumnName("ispaid");

            entity.HasOne(d => d.Client).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Clientid)
                .HasConstraintName("Payment_clientid_fkey");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Subscriptionid).HasName("Subscription_pkey");

            entity.ToTable("Subscription");

            entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Tariffid).HasColumnName("tariffid");

            entity.HasOne(d => d.Client).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.Clientid)
                .HasConstraintName("Subscription_clientid_fkey");

            entity.HasOne(d => d.Tariff).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.Tariffid)
                .HasConstraintName("Subscription_tariffid_fkey");
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.Tariffid).HasName("tariffid");

            entity.ToTable("Tariff");

            entity.Property(e => e.Tariffid).HasColumnName("tariffid");
            entity.Property(e => e.Tariffcategoryid).HasColumnName("tariffcategoryid");
            entity.Property(e => e.Tarifftypeid).HasColumnName("tarifftypeid");

            entity.HasOne(d => d.Tariffcategory).WithMany(p => p.Tariffs)
                .HasForeignKey(d => d.Tariffcategoryid)
                .HasConstraintName("Tariff_tariffcategoryid_fkey");

            entity.HasOne(d => d.Tarifftype).WithMany(p => p.Tariffs)
                .HasForeignKey(d => d.Tarifftypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tariff_tarifftypeid_fkey");
        });

        modelBuilder.Entity<TariffCategory>(entity =>
        {
            entity.HasKey(e => e.Tariffcategoryid).HasName("TariffCategory_pkey");

            entity.ToTable("TariffCategory");

            entity.Property(e => e.Tariffcategoryid).HasColumnName("tariffcategoryid");
            entity.Property(e => e.Category)
                .HasColumnType("char")
                .HasColumnName("category");
        });

        modelBuilder.Entity<TariffType>(entity =>
        {
            entity.HasKey(e => e.Tarifftypeid).HasName("TariffType_pkey");

            entity.ToTable("TariffType");

            entity.Property(e => e.Tarifftypeid).HasColumnName("tarifftypeid");
            entity.Property(e => e.Type)
                .HasColumnType("char")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TrainingRegistration>(entity =>
        {
            entity.HasKey(e => e.Registrationid).HasName("TrainingRegistration_pkey");

            entity.ToTable("TrainingRegistration");

            entity.Property(e => e.Registrationid).HasColumnName("registrationid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Isconfirmed).HasColumnName("isconfirmed");
            entity.Property(e => e.Registrationdate).HasColumnName("registrationdate");
            entity.Property(e => e.Trainingid).HasColumnName("trainingid");

            entity.HasOne(d => d.Client).WithMany(p => p.TrainingRegistrations)
                .HasForeignKey(d => d.Clientid)
                .HasConstraintName("TrainingRegistration_clientid_fkey");

            entity.HasOne(d => d.Training).WithMany(p => p.TrainingRegistrations)
                .HasForeignKey(d => d.Trainingid)
                .HasConstraintName("TrainingRegistration_trainingid_fkey");
        });

        modelBuilder.Entity<TrainingSession>(entity =>
        {
            entity.HasKey(e => e.Trainingid).HasName("TrainingSession_pkey");

            entity.ToTable("TrainingSession");

            entity.Property(e => e.Trainingid).HasColumnName("trainingid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid ");
            entity.Property(e => e.Endtime)
                .HasColumnType("time with time zone")
                .HasColumnName("endtime");
            entity.Property(e => e.Numberofparticipants).HasColumnName("numberofparticipants");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Starttime)
                .HasColumnType("time with time zone")
                .HasColumnName("starttime");

            entity.HasOne(d => d.Employee).WithMany(p => p.TrainingSessions)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TrainingSession_employeeid _fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.TrainingSessions)
                .HasForeignKey(d => d.Roomid)
                .HasConstraintName("TrainingSession_roomid_fkey");
        });

        base.OnModelCreating(modelBuilder);
    }
}