using System.Collections.Generic;
using System.Linq;
using NAA.Shared.Model;
using NAA.WsAccess.uk.ac.shu.hallam.webteach_net1;

namespace NAA.WsAccess.WebDataService
{
    class SheffieldHallamDataService : IDataService
    {
        readonly SHUWebService _ws = new SHUWebService();

        public List<Course> GetCourses()
        {
            return _ws.SHUCourses().Select(x => new Course()
            {
                Description = x.CDescription,
                EntryRequirements = x.CRequirements,
                Id = x.CourseId,
                Name = x.CName,
                Nss = x.CNSS,
                Tarif = x.CTarif
            }).ToList();
        }
    }
}
