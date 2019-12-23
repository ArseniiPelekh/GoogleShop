using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Img { get; set; }

        public ushort Price { get; set; }

        public Category Category { get; set; }
    }
}
