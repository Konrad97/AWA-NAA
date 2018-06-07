using NAA.Service;
using NAA.Shared.Model;
using System.Web.Mvc;
using Naa.Shared.Service;

namespace NAA.Web.Controllers
{
    public class ApplicantController : Controller
    {

        private readonly IApplicantService _dataService = new ApplicantService();

        // GET: Applicant
        public ActionResult Index()
        {
            return View(_dataService.GetApplicants());
        }

        // GET: Applicant/Details/5
        public ActionResult Details(int id)
        {
            return View(_dataService.GetApplicant(id));
        }

        // GET: Applicant/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Applicant/Create
        [HttpPost]
        public ActionResult Register(Applicant applicant)
        {
            try
            {
                _dataService.AddApplicant(applicant);

                return RedirectToAction("GetApplications", "Application", new { applicantId = applicant.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Applicant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Applicant/Edit/5
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

        // GET: Applicant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Applicant/Delete/5
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
