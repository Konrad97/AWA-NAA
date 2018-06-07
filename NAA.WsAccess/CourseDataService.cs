using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naa.Shared.Service;
using NAA.Shared.Model;
using NAA.WsAccess.WebDataService;

namespace NAA.WsAccess
{
    public class CourseDataService : ICourseService
    {
        Dictionary<string, IDataService> _universities;

        public CourseDataService()
        {
            _universities = new Dictionary<string, IDataService>();
            _universities.Add("Sheffield", new SheffieldDataService());
            _universities.Add("Sheffield Hallam", new SheffieldHallamDataService());
        }

        public List<Course> GetCourses(string university)
        {
            return _universities[university].GetCourses();
        }
    }
}
