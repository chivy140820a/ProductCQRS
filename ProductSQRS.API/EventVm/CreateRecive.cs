﻿using ProductSQRS.API.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSQRS.API.EventVm
{
    public class CreateRecive
    {
        public int ProductId { get; set; } 
        public int Quantity { get; set; }
        public Common Common { get; set; }
    }
}
