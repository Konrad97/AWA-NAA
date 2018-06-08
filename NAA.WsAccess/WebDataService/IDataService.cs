using System.Collections.Generic;
using NAA.Shared.Model;

namespace NAA.WsAccess.WebDataService
{
    public interface IDataService
    {
        List<Course> GetCourses();
    }
}