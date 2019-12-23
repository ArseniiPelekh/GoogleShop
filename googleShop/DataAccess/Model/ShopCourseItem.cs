using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class ShopCourseItem
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public ushort Price { get; set; }

        public string ShopCourseId { get; set; }

    }
}
