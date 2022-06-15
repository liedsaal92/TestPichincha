using Microsoft.EntityFrameworkCore;
using PichinchaTest.Entities;

namespace PichinchaTest.Services
{
    public class TestPichinchaContext : DbContext
    {
        public TestPichinchaContext(DbContextOptions<TestPichinchaContext> options) : base(options)
        {

        }
        public DbSet<cliente> cliente { get; set; }
        public DbSet<cuenta> cuenta { get; set; }
        public DbSet<persona> persona { get; set; }
        public DbSet<movimientos> movimientos { get; set; }
    }
}
