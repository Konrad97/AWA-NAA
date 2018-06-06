using System.Collections.Generic;
using System.Linq;
using NAA.Shared.Interfaces;
using NAA.Shared.Models;

namespace NAA.DbAccess
{
    public class ApplicationDataService : IApplicationService
    {
        private readonly NaaModel _context;

        internal ApplicationDataService(NaaModel context)
        {
            _context = context;
        }

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

        public List<Application> GetApplications(int applicatId)
        {
            return _context.Applications.Where(x => x.Applicant.Id == applicatId).ToList();
        }

        public List<Application> GetApplications(string university)
        {
            return _context.Applications.Where(x => x.Uninverity == university).ToList();
        }
    }
}
