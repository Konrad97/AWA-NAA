using System.Collections.Generic;
using System.Linq;
using NAA.Shared.Service;
using NAA.Shared.Model;

namespace NAA.DbAccess
{
    public class ApplicationDataService : IApplicationService
    {
        private readonly NaaDbModel _context = new NaaDbModel();

        public void AddApplication(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();
        }

        public void EditApplication(Application application)
        {
            var current = _context.Applications.Find(application.Id);
            _context.Entry(current).CurrentValues.SetValues(application);
            _context.SaveChanges();
        }

        public void DeleteApplication(Application application)
        {
            _context.Applications.Remove(application);
            _context.SaveChanges();
        }

        public List<Application> GetApplicationsByApplicantId(int applicantId)
        {
            return _context.Applications.Where(x => x.Applicant.Id == applicantId).ToList();
        }

        public List<Application> GetApplicationsByUniversity(string university)
        {
            return _context.Applications.Where(x => x.Uninverity == university).ToList();
        }

        public List<Application> GetApplications()
        {
            return _context.Applications.ToList();
        }

        public Application GetApplication(int id)
        {
            return _context.Applications.Find(id);
        }
    }
}
