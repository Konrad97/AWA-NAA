using System.Web.Mvc;
using NAA.Service;
using NAA.Shared.Model;
using NAA.Web.Models.Login;

namespace NAA.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicantService _service = new ApplicantService();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel formData)
        {
            var applicant = _service.GetApplicant(formData.Email);

            if (applicant != null) return RedirectToAction("Index", "Application", new {applicantId = applicant.Id});

            return View("Login", new LoginViewModel {InvalidEmail = true});
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Applicant applicant)
        {
            var cannAdd = _service.CannAddApplicant(applicant, out var reason);

            if (!cannAdd)
            {
                var viewModel = new RegisterViewModel
                {
                    Applicant = applicant,
                    CannNotRegitserReason = reason,
                    CannRegisert = false
                };

                return View(viewModel);
            }

            _service.AddApplicant(applicant);

            return RedirectToAction("Index", "Application", new {applicantId = applicant.Id});
        }
    }
}