using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class OwnerProductResult
    {
        public OwnerProductResult()
        {

        }

        public OwnerProductResult(string memberID, string memberName, int quantity)
        {
            MemberID = memberID;
            MemberName = memberName;
            Quantity = quantity;
        }

        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public int Quantity { get; set; }
        
    }
}