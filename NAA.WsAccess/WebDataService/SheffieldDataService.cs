using NAA.WsAccess.uk.ac.shu.hallam.webteach_net;
using System.Collections.Generic;
using System.Linq;

namespace NAA.WsAccess.WebDataService
{
    class SheffieldDataService : IDataService
    {
        readonly SheffieldWebService _ws = new SheffieldWebService();
        public List<Shared.Model.Course> GetCourses()
        {
            return _ws.SheffCourses().Select(x => new Shared.Model.Course()
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
