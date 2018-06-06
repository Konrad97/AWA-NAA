using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Shared.Models;

namespace NAA.DbAccess
{
    class Initializer : DropCreateDatabaseIfModelChanges<NaaModel>
    {
        protected override void Seed(NaaModel context)
        {
            var applicant = new Applicant
            {
                Address = "Holzweg",
                Email = "blub@whatever.com",
                Name = "Hnas Wrust",
                Phone = "123456789"
            };
            context.Applicants.Add(applicant);

            var application = new Application()
            {
                Applicant = applicant,
                CourseId = 1,
                OfferState = OfferState.Pending,
                PersonalStatement = "Hallo, nehmen sie mich bitte danke",
                TeacherContact = "Lehrer",
                Uninverity = "Havard"
            };
            context.Applications.Add(application);

            context.SaveChanges();
        }
    }
}
