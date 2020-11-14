using Microsoft.EntityFrameworkCore;

namespace HairSalonManyToMany.Models
{
  public class HairSalonManyToManyContext : DbContext
  {
    public virtual DbSet<Client> Clients {get;set;}
    public virtual DbSet<Stylist> Stylists {get;set;}
    public HairSalonManyToManyContext(DbContextOptions options) : base(options) { }
  }
}

