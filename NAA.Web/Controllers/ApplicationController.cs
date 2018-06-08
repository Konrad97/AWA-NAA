using System;
using System.Linq;
using System.Web.Mvc;
using NAA.Service;
using NAA.Shared.Model;
using NAA.Web.Models.Application;

namespace NAA.Web.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationService _applicationService = new ApplicationService();
        private readonly PdfGenerator _pdfGenerator = new PdfGenerator();

        public ActionResult Index(int applicantId)
        {
            var canAdd = _applicationService.CanAddApplication(applicantId, out var reson);

            var applications = _applicationService.GetApplicationsByApplicantId(applicantId);

            var viewModel = new ApplicationIndexViewModel
            {
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

        public ActionResult GeneratePdf(int id)
        {
            var application = _applicationService.GetApplication(id);

            var pdf = _pdfGenerator.GeneratePdf(application, out var title);

            return File(pdf, "application/pdf", title);
        }

        public ActionResult Edit(int id)
        {
            var applcation = _applicationService.GetApplication(id);
            return View(applcation);
        }

        [HttpPost]
        public ActionResult Edit(int id, Application application)
        {
            _applicationService.EditApplication(application);

            return RedirectToAction("Index", new {applicantId = application.ApplicantId});

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

                return RedirectToAction("Index", new {applicantId = application.ApplicantId});
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

            return RedirectToAction("Index", new {applicantId = application.ApplicantId});
        }
    }
}