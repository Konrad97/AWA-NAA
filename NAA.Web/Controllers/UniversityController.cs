using Naa.Shared.Service;
using NAA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class UniversityController : Controller
    {

        private readonly ICourseService _service = new CourseService();


        // GET: University
        public ActionResult GetUniversities(int applicantId)
        {
            ViewBag.ApplicantId = applicantId;
            return View(_service.GetUniversities());
        }

        public ActionResult GetCources(int applicantId, string university)
        {
            ViewBag.ApplicantId = applicantId;
            ViewBag.University = university;

            return View(_service.GetCourses(university));
        }

    }
}