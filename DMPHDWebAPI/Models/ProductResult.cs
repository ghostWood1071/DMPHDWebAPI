using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class ProductResult
    {
       

        

        public string ProductID { get; set; }
        public int ProductDetailsID { get; set; }
        public string MemberID { get; set; }
        public string ProductName { get; set; }
        public double BasePrice { get; set; }
        public double SalesPoints { get; set; }
        public double SellPrices { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}