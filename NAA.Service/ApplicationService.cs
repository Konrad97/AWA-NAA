using System;
using System.Collections.Generic;
using System.Text;
using NAA.DbAccess;
using NAA.Shared.Interfaces;
using NAA.Shared.Models;

namespace NAA.Service
{
    class ApplicationService : IApplicationService
    {
        private IApplicationService _dataService = DataServiceFactory.GetApplicationService();

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

        public List<Application> GetApplications(int applicatId)
        {
            return _dataService.GetApplications(applicatId);
        }

        public List<Application> GetApplications(string university)
        {
            return _dataService.GetApplications(university);
        }
    }
}
