using System.Collections.Generic;

namespace NAA.Web.Models.Application
{
    public class ApplicationIndexViewModel
    {

        public List<Shared.Model.Application> Applications { get; set; }

        public int ApplicantId { get; set; }

        public bool CanAddApplications { get; set; }

        public string CanNotAddApplicationsReason { get; set; }

    }
}