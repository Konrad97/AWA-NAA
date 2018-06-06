using System.Linq;
using NAA.Shared.Interfaces;
using NAA.Shared.Models;

namespace NAA.DbAccess
{
    public class ApplicantDataService : IApplicantService
    {

        private readonly NaaModel _context;

        internal ApplicantDataService(NaaModel context)
        {
            _context = context;
        }

        public Applicant GetApplicant(string email)
        {
            return _context.Applicants.Single(x => x.Email == email);
        }

        public void AddApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
        }

        public void EditApplicant(Applicant applicant)
        {
            var current = _context.Applicants.Find(applicant.Id);
            _context.Entry(current).CurrentValues.SetValues(applicant);
            _context.SaveChanges();
        }
    }
}
