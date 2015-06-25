using Microsoft.Data.Entity;

namespace Sample1Data
{
    public interface IDataContext
    {
        DbSet<Player> Players { get; set; }
        int SaveChanges();
    }
}