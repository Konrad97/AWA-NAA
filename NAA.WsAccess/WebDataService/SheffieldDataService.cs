using System.Collections.Generic;
using System.Linq;
using NAA.WsAccess.uk.ac.shu.hallam.webteach_net;
using Course = NAA.Shared.Model.Course;

namespace NAA.WsAccess.WebDataService
{
    internal class SheffieldDataService : IDataService
    {
        private readonly SheffieldWebService _ws = new SheffieldWebService();

        public List<Course> GetCourses()
        {
            return _ws.SheffCourses().Select(x => new Course
            {
                Description = x.Description,
                EntryRequirements = x.EntryReq,
                Id = x.Id,
                Name = x.Name,
                Nss = x.NSS.ToString(),
                Tarif = x.Tarif.ToString(),
                University = "Sheffield"
            }).ToList();
        }
    }
}