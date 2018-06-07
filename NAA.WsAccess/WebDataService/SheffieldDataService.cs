using System.Collections.Generic;
using System.Linq;
using Course = NAA.Shared.Model.Course;
using NAA.WsAccess.SheffieldWebService;


namespace NAA.WsAccess.WebDataService
{
    class SheffieldDataService : IDataService
    {
        readonly SheffieldWebService.SheffieldWebService _ws = new SheffieldWebService.SheffieldWebService();
        public List<Course> GetCourses()
        {
            return _ws.SheffCourses().Select(x => new Course()
            {
                Description = x.Description,
                EntryRequirements = x.EntryReq,
                Id = x.Id,
                Name = x.Name,
                Nss = x.NSS.ToString(),
                Tarif = x.Tarif.ToString()
            }).ToList();
        }
    }
}
}
