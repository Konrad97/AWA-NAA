using System.Collections.Generic;
using Naa.Shared.Service;
using NAA.Shared.Model;
using NAA.WsAccess;

namespace NAA.Service
{
    public class CourseService : ICourseService
    {

        private ICourseService _service = new CourseDataService();

        public List<Course> GetCourses(string university)
        {
            return _service.GetCourses(university);
        }

        public List<string> GetUniversities()
        {
            return _service.GetUniversities();
        }
    }
}
