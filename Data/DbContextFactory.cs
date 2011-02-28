using System.Data.Entity;

namespace Omu.ProDinner.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext c;
        public DbContextFactory()
        {
            c = new Db();
        }

        public DbContext GetContext()
        {
            return c;
        }
    }

    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}