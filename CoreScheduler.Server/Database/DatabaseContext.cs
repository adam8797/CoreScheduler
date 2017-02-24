using System.Data.Entity;

namespace CoreScheduler.Server.Database
{
    [DbConfigurationType(typeof(DatabaseConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Quartz")
        {
            
        }

        public DbSet<Script> Scripts { get; set; }
        public DbSet<JobEvent> Events { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<ConnectionString> ConnectionStrings { get; set; }
        public DbSet<ReferenceAssembly> Assemblies { get; set; }
        public DbSet<ReferenceAssemblyInfo> AssemblyInfo { get; set; }

        public void RejectChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}
