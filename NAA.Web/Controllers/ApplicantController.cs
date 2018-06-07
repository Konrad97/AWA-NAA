using NAA.Service;
using NAA.Shared.Model;
using System.Web.Mvc;
using Naa.Shared.Service;

namespace NAA.Web.Controllers
{
    public class ApplicantController : Controller
    {

        private readonly IApplicantService _service = new ApplicantService();

        public ActionResult Details(int id)
        {
            return View(_service.GetApplicant(id));
        }

        public ActionResult Edit(int id)
        {
            return View(_service.GetApplicant(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Applicant applicant)
        {
            try
            {
                _service.EditApplicant(applicant);

                return RedirectToAction("Index", "Application", new { applicantId = applicant.Id });
            }
            catch
            {
                return View();
            }
        }

    }
}
