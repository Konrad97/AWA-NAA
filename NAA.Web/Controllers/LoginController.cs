using Naa.Shared.Service;
using NAA.Service;
using NAA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Web.Controllers
{
    public class LoginController : Controller
    {

        private IApplicantService _service = new ApplicantService();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginFormData formData)
        {
            var applicant = _service.GetApplicant(formData.Email);

            if(applicant != null)
            {
                return RedirectToAction("GetApplications", "Application", new { applicantId = applicant.Id });
            }

            return View("Index", new LoginFormData { InvalidEmail = true });
        }
    }
}