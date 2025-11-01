using Microsoft.EntityFrameworkCore;
using Nusuk.Core.Entities;

namespace Nusuk.Infrastructure.Data;

public class NusukDbContext : DbContext
{
    public NusukDbContext(DbContextOptions<NusukDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
   
}