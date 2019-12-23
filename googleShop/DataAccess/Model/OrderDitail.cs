using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class OrderDitail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }
        public uint Price { get; set; }
        public virtual Course Course { get; set; }
        public virtual Order Order { get; set; }
    }
}
