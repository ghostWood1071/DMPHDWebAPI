using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OrderPut
    {
        public string OrderID { get; set; }
        public string MemberID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}