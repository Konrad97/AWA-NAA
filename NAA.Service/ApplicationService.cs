using System;
using System.Collections.Generic;
using System.Text;
using NAA.DbAccess;
using NAA.Shared.Service;
using NAA.Shared.Model;

namespace NAA.Service
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationService _dataService = new ApplicationDataService();

        public void AddApplication(Application application)
        {
            _dataService.AddApplication(application);
        }

        public void EditApplication(Application application)
        {
            _dataService.EditApplication(application);
        }

        public void DeleteApplication(Application application)
        {
            _dataService.DeleteApplication(application);
        }

        public List<Application> GetApplicationsByApplicantId(int applicatId)
        {
            return _dataService.GetApplicationsByApplicantId(applicatId);
        }

        public List<Application> GetApplicationsByUniversity(string university)
        {
            return _dataService.GetApplicationsByUniversity(university);
        }

        public List<Application> GetApplications()
        {
            return _dataService.GetApplications();
        }

        public Application GetApplication(int id)
        {
            return _dataService.GetApplication(id);
        }
    }
}
