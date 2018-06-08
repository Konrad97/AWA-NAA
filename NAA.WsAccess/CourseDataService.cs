using System.Collections.Generic;
using System.Linq;
using Naa.Shared.Service;
using NAA.Shared.Model;
using NAA.WsAccess.WebDataService;

namespace NAA.WsAccess
{
    public class CourseDataService : ICourseService
    {
        private readonly Dictionary<string, IDataService> _universities;

        public CourseDataService()
        {
            _universities = new Dictionary<string, IDataService>
            {
                {"Sheffield", new SheffieldDataService()},
                {"Sheffield Hallam", new SheffieldHallamDataService()}
            };
        }

        public List<Course> GetCourses(string university)
        {
            return _universities[university].GetCourses();
        }

        public List<string> GetUniversities()
        {
            return _universities.Keys.ToList();
        }
    }
}