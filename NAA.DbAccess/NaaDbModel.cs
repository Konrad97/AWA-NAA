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
            Configuration.LazyLoadingEnabled = false;
            Database.Connection.ConnectionString = "data source=Julian-Notebook;initial catalog=NAA5;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().HasRequired(x => x.Applicant).WithMany(x => x.Applications).HasForeignKey(x => x.ApplicantId);

            modelBuilder.Entity<Applicant>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Applicant>().Property(x => x.Email).HasMaxLength(30);
        }
    }
}
