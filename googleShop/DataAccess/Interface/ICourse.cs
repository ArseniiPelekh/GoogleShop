using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface ICourse
    {
        IEnumerable<Course> Courses { get; }
        IEnumerable<Course> getFavCourses { get; }
        Course getObjectCourse(int CourseId);
    }
}
