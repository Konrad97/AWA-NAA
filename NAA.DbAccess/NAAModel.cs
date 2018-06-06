using NAA.Shared.Models;

namespace NAA.DbAccess
{
    using System.Data.Entity;

    internal class NaaModel : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Conformation> Conformations { get; set; }


        public NaaModel()
            : base("name=NAAModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conformation>().HasKey(x => x.Applicat);

            modelBuilder.Entity<Applicant>().HasIndex(x => x.Email).IsUnique();


        }
    }
}
