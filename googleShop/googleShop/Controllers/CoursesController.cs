using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Interface;
using googleShop.ViewModes;
using Data.Model;

namespace googleShop.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICategory _category;
        private readonly ICourse _course;

        public CoursesController(ICategory category, ICourse course)
        {
            _category = category;
            _course = course;
        }

        [Route("Courses/List")]
        [Route("Courses/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Course> course = null;
            string curCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                course = _course.Courses.OrderBy(i => i.Id);
            }
            else {
                if (string.Equals("programming", category, StringComparison.OrdinalIgnoreCase))
                {
                    course = _course.Courses.Where(i => i.Category.CategoryName.Equals("Програмирования")).OrderBy(i => i.Id);
                }
                else if (string.Equals("psychology", category, StringComparison.OrdinalIgnoreCase)) {
                    course = _course.Courses.Where(i => i.Category.CategoryName.Equals("Психология")).OrderBy(i => i.Id);
                }
            }

            var obj = new CourseViewModel
            {
                currCourse = curCategory,
                getCourses = course
            };

            return View(obj);
        }
    }
}