using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Controllers
{
    public class SalePointPost
    {
        public string OrderID { get; set; }
        public string MemberID { get; set; }
        public float Mark { get; set; }
    }
}