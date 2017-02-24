using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace CoreScheduler.Server.Database
{
    public class DatabaseConfiguration : DbConfiguration
    {
        public DatabaseConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDefaultConnectionFactory(new SqlConnectionFactory("Data Source=localhost;Integrated Security=True;MultipleActiveResultSets=True"));

        }
    }
}
