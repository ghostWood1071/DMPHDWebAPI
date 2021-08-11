using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMPHDWebAPI.Models;

namespace DMPHDWebAPI.Controllers
{
    public class SalePointController : ApiController
    {
        

        // POST: api/SalePoint
        public void Post([FromBody]SalePointPost value)
        {
            using(DMPContext context = new DMPContext())
            {
                context.InsertSalePoint(value.OrderID, value.MemberID, value.Mark);
            }
        }

        
    }
}
