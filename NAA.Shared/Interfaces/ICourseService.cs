using System.Collections.Generic;
using NAA.Shared.Models;

namespace NAA.Shared.Interfaces
{
    public interface ICourseService
    {

        List<Course> GetCources(string university);

        Course GetCourse(string university, int id);

    }
}
