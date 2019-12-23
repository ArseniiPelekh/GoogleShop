using Data.Interface;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly AppDBContent appDBContent;

        public CourseRepository(AppDBContent appDB)
        {
            this.appDBContent = appDB;
        }


        public IEnumerable<Course> Courses => appDBContent.Courses.Include(c => c.Category);

        public IEnumerable<Course> getFavCourses { get => throw new NotImplementedException(); }

        public Course getObjectCourse(int CourseId) => appDBContent.Courses.FirstOrDefault(p => p.Id == CourseId);
    }
}
