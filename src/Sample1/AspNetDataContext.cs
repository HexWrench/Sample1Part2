using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Sample1Data;
using System.Linq;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.SqlServer;

namespace Sample1
{
    public class AspNetDataContext : IdentityDbContext, IDataContext
    {
        private readonly string _connectionString;
        public DbSet<Player> Players { get; set; }

        public AspNetDataContext()
        {
            _connectionString =
                "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DB1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        
        public AspNetDataContext(DbContextOptions options)
        {
            _connectionString = ((SqlServerOptionsExtension) options.Extensions.First()).ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
