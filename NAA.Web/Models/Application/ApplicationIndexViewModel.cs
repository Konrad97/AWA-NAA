using System.Collections.Generic;

namespace NAA.Web.Models.Application
{
    public class ApplicationIndexViewModel
    {
        public List<ApplicationIndexViewModelHolder> ApplicationHolders { get; set; }

        public int ApplicantId { get; set; }

        public bool CanAddApplications { get; set; }

        public string CanNotAddApplicationsReason { get; set; }
    }

    public class ApplicationIndexViewModelHolder
    {
        public Shared.Model.Application Application { get; set; }

        public bool CanAcceptApplication { get; set; }

        public bool CanEditApplication { get; set; }
    }
}