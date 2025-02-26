using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Padel.Domain.Entities;
namespace Padel.Infrastructure.Database;

public class PadelContext : DbContext
{
    public PadelContext(DbContextOptions options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Producto> Productos { get; set; }
}
