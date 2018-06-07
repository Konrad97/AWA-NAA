namespace NAA.DbAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using NAA.Shared.Model;

    public partial class NaaDbModel : DbContext
    {

        static NaaDbModel()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NaaDbModel>());
        }

        public DbSet<Applicant> Applicants { get; set; }

        public NaaDbModel()
            : base("name=NaaDbModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
