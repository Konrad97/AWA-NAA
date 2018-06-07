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
        public ActionResult Login(LoginFormData formData)
        {
            var applicantId = _service.GetApplicant(formData.Email).Id;

            return RedirectToAction("GetApplications", "Application", new { applicantId });
        }
    }
}