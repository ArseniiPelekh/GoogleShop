using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Desc { get; set; }

        public List<Course> Courses { get; set; }
    }
}
