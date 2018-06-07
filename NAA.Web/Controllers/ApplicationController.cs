using NAA.Service;
using NAA.Shared.Model;
using NAA.Shared.Service;
using NAA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Create(int applicantId)
        {

            return View(new Application() { ApplicantId = applicantId });
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Create(Application application)
        {
            try
            {
                _service.AddApplication(application);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Application/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Application/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
