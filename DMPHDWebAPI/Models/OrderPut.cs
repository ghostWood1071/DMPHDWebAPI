﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OrderPut: OrderPost
    {
        public string OrderID { get; set; }
    }
}