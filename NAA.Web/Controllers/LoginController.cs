using Naa.Shared.Service;
using NAA.Service;
using NAA.Web.Models;
using NAA.Web.Models.Login;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class LoginController : Controller
    {

        private IApplicantService _service = new ApplicantService();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel formData)
        {
            var applicant = _service.GetApplicant(formData.Email);

            if(applicant != null)
            {
                return RedirectToAction("Index", "Application", new { applicantId = applicant.Id });
            }

            return View("Login", new LoginViewModel { InvalidEmail = true });
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Shared.Model.Applicant applicant)
        {
            try
            {
                _service.AddApplicant(applicant);

                return RedirectToAction("Index", "Application", new { applicantId = applicant.Id });
            }
            catch
            {
                return View();
            }
        }

    }
}