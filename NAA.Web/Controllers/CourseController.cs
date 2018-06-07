using Naa.Shared.Service;
using NAA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class CourseController : Controller
    {

        private ICourseService _service = new CourseService();

        // GET: Course
        public ActionResult GetCources(string university)
        {
            return View(_service.GetCourses(university));
        }
    }
}