using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OrderPost
    {
        public string MemberID { get; set; }
        public DateTime OrderDate { get; set; }
        public float Discount { get; set; }
    }
}