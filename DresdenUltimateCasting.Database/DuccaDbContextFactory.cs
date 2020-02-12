using System.Data.Entity.Infrastructure;

namespace DresdenUltimateCasting.Database {
    public class DuccaDbContextFactory : IDbContextFactory<DuccaDbContext>
    {
        const string DbConnectionString = @"data source=(LocalDb)\DUCCADB;initial catalog=DUCCADB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        public DuccaDbContext Create()
        {
            return new DuccaDbContext(DbConnectionString);
        }
    }
}