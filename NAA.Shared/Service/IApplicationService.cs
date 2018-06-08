using System.Collections.Generic;
using NAA.Shared.Model;

namespace NAA.Shared.Service
{
    public interface IApplicationService
    {
        void AddApplication(Application application);

        void EditApplication(Application application);

        void DeleteApplication(Application application);

        List<Application> GetApplicationsByApplicantId(int applicatId);

        List<Application> GetApplications();

        Application GetApplication(int id);

        List<Application> GetApplicationsByUniversity(string university);
    }
}