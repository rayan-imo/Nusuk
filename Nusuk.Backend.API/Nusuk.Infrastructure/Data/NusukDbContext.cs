using Microsoft.EntityFrameworkCore;
using Nusuk.Core.Entities;
using Nusuk.Services.Otp;
using System.Data.Common;

namespace Nusuk.Infrastructure.Data;

public class NusukDbContext : DbContext
{
    public NusukDbContext(DbContextOptions<NusukDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
        .HasOne(u => u.Role)
        .WithMany(r => r.Users)
        .HasForeignKey(u => u.RoleId)
        .IsRequired(false)
        .OnDelete(DeleteBehavior.Restrict);

        // Booking → Role
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Role)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoleId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // Booking → User
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Booking)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        //Seed 
        var seed = new SeedData();
        modelBuilder.Entity<Trip>().HasData(seed.GetTrips());
        modelBuilder.Entity<Package>().HasData(seed.GetPackages());
        modelBuilder.Entity<Service>().HasData(seed.GetServices());
        modelBuilder.Entity<TripPackage>().HasData(seed.GetTripPackages());
        modelBuilder.Entity<ServiceDetail>().HasData(seed.GetServiceDetails());
        modelBuilder.Entity<Caravan>().HasData(seed.GetCaravans());


    }


    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Caravan> Caravans { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<TripPackage> TripPackages { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Service> ServicesDetail { get; set; }
    public DbSet<UserServiceInfo> UsersService { get; set; }
    public DbSet<UserOtp> Otps { get; set; }

}