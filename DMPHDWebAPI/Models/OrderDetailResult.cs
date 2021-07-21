using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OrderDetailResult
    {
        public int OrderDetailID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}