using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Shared.Model;

namespace NAA.WsAccess.WebDataService
{
    public interface IDataService
    {
        List<Course> GetCourses();
    }
}
