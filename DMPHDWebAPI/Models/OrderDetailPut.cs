using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OrderDetailPut: OrderDetailPost
    {
        public int OrderDetailID { get; set; }
    }
}