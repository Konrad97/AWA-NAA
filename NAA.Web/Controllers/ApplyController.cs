using NAA.Service;
using NAA.Shared.Model;
using NAA.Web.Models.Apply;
using System.Linq;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class ApplyController : Controller
    {

        private readonly CourseService _courseService = new CourseService();
        private readonly ApplicationService _applicationService = new ApplicationService();

        public ActionResult University(int applicantId)
        {
            var viewModel = new UniversityViewModel
            {
                ApplicantId = applicantId,
                Universities = _courseService.GetUniversities()
            };

            return View(viewModel);
        }

        public ActionResult Course(int applicantId, string university)
        {
            var courses = _courseService.GetCourses(university);

            CourceViewModel viewModel = new CourceViewModel
            {
                ApplicantId = applicantId,
                University = university,
                CourseHolders = courses.Select(x => BuildHolder(applicantId, x)).ToList()
            };

            return View(viewModel);
        }

        private CourceViewModelHolder BuildHolder(int applicantId, Course course)
        {
            var canAdd = _applicationService.CanAddApplication(applicantId, course.University, course.Id, out string reason);

            return new CourceViewModelHolder
            {
                Course = course,
                CanAddApplications = canAdd,
                CanNotAddApplicationsReason = reason
            };
        }

        public ActionResult Apply(int applicantId, string university, int courseId, string courseName)
        {
            return View(new Application
            {
                ApplicantId = applicantId,
                University = university,
                CourseId = courseId,
                CourseName = courseName
            });
        }

        [HttpPost]
        public ActionResult Apply(Application application)
        {
            _applicationService.AddApplication(application);

            return RedirectToAction("Index", "Application", new { applicantId = application.ApplicantId });
        }

    }
}