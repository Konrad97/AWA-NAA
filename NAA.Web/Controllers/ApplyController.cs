using Naa.Shared.Service;
using NAA.Service;
using NAA.Shared.Model;
using NAA.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class ApplyController : Controller
    {

        private readonly ICourseService _courseService = new CourseService();
        private readonly IApplicationService _applicationService = new ApplicationService();

        public ActionResult University(int applicantId)
        {
            ViewBag.ApplicantId = applicantId;
            return View(_courseService.GetUniversities());
        }

        public ActionResult Course(int applicantId, string university)
        {
            var applications = _applicationService.GetApplicationsByApplicantId(applicantId);
            applications = applications.Where(x => x.University == university).ToList();

            ViewBag.Applications = applications;
            ViewBag.ApplicantId = applicantId;
            ViewBag.University = university;

            return View(_courseService.GetCourses(university));
        }

        public ActionResult Apply(int applicantId, string university, int courseId, string courseName)
        {
            return View(new Application()
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
            try
            {
                _applicationService.AddApplication(application);

                return RedirectToAction("Index", "Application", new { applicantId = application.ApplicantId });
            }
            catch
            {
                return View();
            }
        }

    }
}