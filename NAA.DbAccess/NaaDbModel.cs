using System.Data.Entity;
using NAA.Shared.Model;

namespace NAA.DbAccess
{
    public class NaaDbModel : DbContext
    {

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Application> Applications { get; set; }

        static NaaDbModel()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NaaDbModel>());
        }

        public NaaDbModel()
        {
            Configuration.ProxyCreationEnabled = false;
            Database.Connection.ConnectionString = "data source=Julian-Notebook;initial catalog=NAA;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().HasRequired(x => x.Applicant).WithMany(x => x.Applications).HasForeignKey(x => x.ApplicantId);

        }
    }
}
