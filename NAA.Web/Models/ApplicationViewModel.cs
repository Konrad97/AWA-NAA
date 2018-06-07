using NAA.Shared.Model;
using System.Collections.Generic;

namespace NAA.Web.Models
{
    public class ApplicationViewModel
    {

        public List<Application> Applications { get; set; }

        public int ApplicantId { get; set; }

        public bool CanAddApplications { get; set; }

        public string CanNotAddApplicationsReason { get; set; }

    }
}