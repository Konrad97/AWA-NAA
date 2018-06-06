using System.Collections.Generic;
using NAA.Shared.Models;

namespace NAA.Shared.Interfaces
{
    public interface IApplicationService
    {

        void AddApplication(Application application);

        void EditApplication(Application application);

        void DeleteApplication(Application application);

        List<Application> GetApplications(int applicatId);

        List<Application> GetApplications(string university);

    }
}
