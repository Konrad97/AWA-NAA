using NAA.Service;
using NAA.Shared.Model;
using System.Web.Mvc;
using Naa.Shared.Service;

namespace NAA.Web.Controllers
{
    public class ApplicantController : Controller
    {

        private readonly IApplicantService _dataService = new ApplicantService();

        public ActionResult Details(int id)
        {
            return View(_dataService.GetApplicant(id));
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

    }
}
