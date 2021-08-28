using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class DetailsGet
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Nullable<double> BasePrice { get; set; }
        public Nullable<double> OriginPrice { get; set; }
        public Nullable<double> SalePoint { get; set; }
        public Nullable<int> BuyQuantity { get; set; }
        public bool IsBought { get; set; }
    }
}