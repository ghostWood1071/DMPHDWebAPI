using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OrderResults
    {
        public string OrderID { get; set; }
        public string MemberID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<double> Discount { get; set; }
        public string FullName { get; set; }
    }
}