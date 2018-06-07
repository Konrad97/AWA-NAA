using NAA.Service;
using NAA.Shared.Model;
using NAA.Shared.Service;
using NAA.Web.Models;
using System;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class ApplicationController : Controller
    {

        private readonly IApplicationService _service = new ApplicationService();

        public ActionResult GetApplications(int applicantId)
        {
            var applications = _service.GetApplicationsByApplicantId(applicantId);

            var viewModel = new ApplicationViewModel { ApplicantId = applicantId, Applications = applications };

            return View("Index", viewModel);
        }

        // GET: Application
        public ActionResult Index()
        {
            return View(_service.GetApplications());
        }

        // GET: Application/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.GetApplication(id));
        }

        // GET: Application/Create
        public ActionResult Create(int applicantId, string university, int courseId, string courseName)
        {
            return View(new Application() {
                ApplicantId = applicantId,
                University = university,
                CourseId = courseId,
                CourseName = courseName
            });
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Create(Application application)
        {
            try
            {
                _service.AddApplication(application);

                return RedirectToAction("GetApplications", new { applicantId = application.ApplicantId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            var applcation = _service.GetApplication(id);
            return View(applcation);
        }

        // POST: Application/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Application application)
        {
            try
            {
                _service.EditApplication(application);

                return RedirectToAction("GetApplications", new { applicantId = application.ApplicantId });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Application/Delete/5
        public ActionResult Delete(int id)
        {
            var applcation = _service.GetApplication(id);
            return View(applcation);
        }

        // POST: Application/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Application application)
        {
            try
            {
                application = _service.GetApplication(id);

                _service.DeleteApplication(application);

                return RedirectToAction("GetApplications", new { applicantId = application.ApplicantId });
            }
            catch
            {
                return View();
            }
        }
    }
}
