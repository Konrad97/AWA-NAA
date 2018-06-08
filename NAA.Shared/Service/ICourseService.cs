using System.Collections.Generic;
using NAA.Shared.Model;

namespace Naa.Shared.Service
{
    public interface ICourseService
    {
        List<Course> GetCourses(string university);

        List<string> GetUniversities();
    }
}