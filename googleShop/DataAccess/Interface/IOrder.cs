﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IOrder
    {
        void CreateOrder(Order order);
    }
}
