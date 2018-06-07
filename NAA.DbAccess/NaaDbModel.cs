namespace NAA.DbAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using NAA.Shared.Model;

    public class NaaDbModel : DbContext
    {

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Conformation> Conformations { get; set; }

        static NaaDbModel()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NaaDbModel>());
        }

        public NaaDbModel()
            : base("name=NaaDbModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conformation>().HasKey(x => x.ApplicantId);
            modelBuilder.Entity<Conformation>().HasRequired(x => x.Application).WithOptional(x => x.Conformation);

            modelBuilder.Entity<Application>().HasRequired(x => x.Applicant).WithMany(x => x.Applications).HasForeignKey(x => x.ApplicantId);

        }
    }
}
