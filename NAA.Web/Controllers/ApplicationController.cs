using NAA.Service;
using NAA.Shared.Model;
using NAA.Shared.Service;
using NAA.Web.Models;
using NAA.Web.Models.Application;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class ApplicationController : Controller
    {

        private readonly ApplicationService _applicationService = new ApplicationService();

        public ActionResult Index(int applicantId)
        {
            var canAdd = _applicationService.CanAddApplication(applicantId, out string reson);

            var applications = _applicationService.GetApplicationsByApplicantId(applicantId);

            var viewModel = new ApplicationIndexViewModel {
                ApplicantId = applicantId,
                ApplicationHolders = applications.Select(BuildHolder).ToList(),
                CanAddApplications = canAdd,
                CanNotAddApplicationsReason = reson
            };

            return View("Index", viewModel);
        }

        private ApplicationIndexViewModelHolder BuildHolder(Application application)
        {
            var canAccept = _applicationService.CanAcceptApplication(application.Id);
            var canEdit = _applicationService.CanEditApplication(application.Id);

            return new ApplicationIndexViewModelHolder
            {
                CanAcceptApplication = canAccept,
                Application = application,
                CanEditApplication = canEdit
            };
        }

        public ActionResult Details(int id)
        {
            return View(_applicationService.GetApplication(id));
        }

        public ActionResult Edit(int id)
        {
            var applcation = _applicationService.GetApplication(id);
            return View(applcation);
        }

        [HttpPost]
        public ActionResult Edit(int id, Application application)
        {
            try
            {
                _applicationService.EditApplication(application);

                return RedirectToAction("Index", new { applicantId = application.ApplicantId });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var applcation = _applicationService.GetApplication(id);
            return View(applcation);
        }

        [HttpPost]
        public ActionResult Delete(int id, Application application)
        {
            try
            {
                application = _applicationService.GetApplication(id);

                _applicationService.DeleteApplication(application);

                return RedirectToAction("Index", new { applicantId = application.ApplicantId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirm(int id)
        {
            return View(_applicationService.GetApplication(id));
        }

        [HttpPost]
        public ActionResult Confirm(int id, Application application)
        {
            _applicationService.ConfirmApplication(application.Id);

            return RedirectToAction("Index", new { applicantId = application.ApplicantId });
        }

    }
}
