using System.Collections.Generic;
using NAA.Shared.Model;

namespace NAA.Web.Models.Apply
{
    public class CourceViewModel
    {
        public List<CourceViewModelHolder> CourseHolders { get; set; }

        public int ApplicantId { get; set; }

        public string University { get; set; }
    }

    public class CourceViewModelHolder
    {
        public Course Course { get; set; }

        public bool CanAddApplications { get; set; }

        public string CanNotAddApplicationsReason { get; set; }
    }
}