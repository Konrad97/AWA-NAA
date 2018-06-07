using NAA.Service;
using NAA.Shared.Model;
using NAA.Shared.Service;
using NAA.Web.Models;
using NAA.Web.Models.Application;
using System;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class ApplicationController : Controller
    {

        private readonly ApplicationService _service = new ApplicationService();

        public ActionResult Index(int applicantId)
        {
            var canAdd = _service.CanAddApplication(applicantId, out string reson);

            var applications = _service.GetApplicationsByApplicantId(applicantId);

            var viewModel = new ApplicationIndexViewModel {
                ApplicantId = applicantId,
                Applications = applications,
                CanAddApplications = canAdd,
                CanNotAddApplicationsReason = reson
            };

            return View("Index", viewModel);
        }

        public ActionResult Details(int id)
        {
            return View(_service.GetApplication(id));
        }

        public ActionResult Edit(int id)
        {
            var applcation = _service.GetApplication(id);
            return View(applcation);
        }

        [HttpPost]
        public ActionResult Edit(int id, Application application)
        {
            try
            {
                _service.EditApplication(application);

                return RedirectToAction("Index", new { applicantId = application.ApplicantId });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var applcation = _service.GetApplication(id);
            return View(applcation);
        }

        [HttpPost]
        public ActionResult Delete(int id, Application application)
        {
            try
            {
                application = _service.GetApplication(id);

                _service.DeleteApplication(application);

                return RedirectToAction("Index", new { applicantId = application.ApplicantId });
            }
            catch
            {
                return View();
            }
        }
    }
}
