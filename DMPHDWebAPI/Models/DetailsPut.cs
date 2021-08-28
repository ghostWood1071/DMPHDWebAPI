using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class DetailsPut
    {
        public string OrderID { get; set; }
        public IEnumerable<OrderDetailPut> Details { get; set; }
        public float Mark { get; set; }
        public string MemberID { get; set; }
    }
}