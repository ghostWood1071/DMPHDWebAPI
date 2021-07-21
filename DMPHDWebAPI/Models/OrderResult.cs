using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OrderResult
    {
        public string OrderID { get; set; }
        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public string OrderDate { get; set; }
        public double UsedMark { get; set; }
        public double TotalPrice { get; set; }
    }
}