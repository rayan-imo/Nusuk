using Microsoft.EntityFrameworkCore;
using Nusuk.Core.Entities;
using System.Data.Common;

namespace Nusuk.Infrastructure.Data;

public class NusukDbContext : DbContext
{
    public NusukDbContext(DbContextOptions<NusukDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Caravan> Caravans { get; set; }
    public DbSet <Trip> Trips { get;set; }
    public DbSet<TripPackage> TripPackages { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Service> ServicesDetail { get; set; }
    public DbSet<UserServiceInfo> UsersService { get; set; }
   
}