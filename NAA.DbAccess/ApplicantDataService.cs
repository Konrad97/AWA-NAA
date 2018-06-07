using Naa.Shared.Service;
using System.Collections.Generic;
using System.Linq;
using NAA.Shared.Model;

namespace NAA.DbAccess
{
    public class ApplicantDataService : IApplicantService
    {
        private readonly NaaDbModel _context = new NaaDbModel();

        public List<Applicant> GetApplicants()
        {
            return _context.Applicants.ToList();
        }

        public Applicant GetApplicant(int id)
        {
            return _context.Applicants.Find(id);
        }

        public Applicant GetApplicant(string email)
        {
            return _context.Applicants.SingleOrDefault(x => x.Email == email);
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
