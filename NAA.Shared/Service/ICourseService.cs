using NAA.Shared.Model;
using System.Collections.Generic;

namespace Naa.Shared.Service
{
    public interface ICourseService
    {

        List<Course> GetCourses(string university);

        List<string> GetUniversities();

    }
}
