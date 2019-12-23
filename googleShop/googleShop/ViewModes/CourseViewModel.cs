using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace googleShop.ViewModes
{
    public class CourseViewModel
    {
        public IEnumerable<Course> getCourses { get; set; }

        public string currCourse { get; set; }
    }
}
