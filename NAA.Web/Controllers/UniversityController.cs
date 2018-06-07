using Naa.Shared.Service;
using NAA.Service;
using NAA.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class UniversityController : Controller
    {

        private readonly ICourseService _courseService = new CourseService();
        private readonly IApplicationService _applicationService = new ApplicationService();


        // GET: University
        public ActionResult GetUniversities(int applicantId)
        {
            ViewBag.ApplicantId = applicantId;
            return View(_courseService.GetUniversities());
        }

        public ActionResult GetCources(int applicantId, string university)
        {
            var applications = _applicationService.GetApplicationsByApplicantId(applicantId);
            applications = applications.Where(x => x.University == university).ToList();

            ViewBag.Applications = applications;
            ViewBag.ApplicantId = applicantId;
            ViewBag.University = university;

            return View(_courseService.GetCourses(university));
        }

    }
}