using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class ProductResult
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }

        public double BasePrice { get; set; }

    }
}