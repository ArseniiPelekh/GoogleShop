using Data.Interface;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mock
{
    public class MockCorse : ICourse
    {
        private readonly ICategory _category = new MockCategory();
        public IEnumerable<Course> Courses
        {
            get
            {
                return new List<Course>
                {
                    new Course
                    {
                        Name = "Програмування C# розробки",
                        Img = "https://edx.prometheus.org.ua/c4x/Microsoft/CS201/asset/88750_c444_7.jpg",
                        Price = 200
                    },

                    new Course
                    {
                        Name = "Цель как мотивирующая сила!",
                        Img = "https://cf.ppt-online.org/files2/slide/7/7XFelwZ394fLbKnHRO5tuCEz2opMxhd6JrsYVaqBGP/slide-0.jpg",
                        Price = 150
                    }
                };
            }
        }

        public IEnumerable<Course> getFavCourses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Course getObjectCourse(int CourseId)
        {
            throw new NotImplementedException();
        }
    }
}

