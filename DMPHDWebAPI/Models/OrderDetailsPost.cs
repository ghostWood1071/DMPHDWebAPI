using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OrderDetailsPost
    {
        public IEnumerable<OrderDetailPost> Details { get; set; }
    }
}