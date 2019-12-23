using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public ushort Price { get; set; }

        public string ShopCartId { get; set; }

    }
}
