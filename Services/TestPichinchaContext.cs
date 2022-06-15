using Microsoft.EntityFrameworkCore;
using TestPichincha.Entities;

namespace TestPichincha.Services
{
    public class TestPichinchaContext : DbContext
    {
        public TestPichinchaContext(DbContextOptions<TestPichinchaContext> options) : base(options)
        { 
        
        }
        public DbSet<cliente> clientes { get; set; }
        public DbSet<cuenta> cuentas { get; set; }
        public DbSet<persona> personas { get; set; }
        public DbSet<movimientos>  movimientos { get; set; }
    }
}
