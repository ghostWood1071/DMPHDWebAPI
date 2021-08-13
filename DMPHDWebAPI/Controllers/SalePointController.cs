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


        [HttpPost]
        [Route("Update")]
        public void Update([FromBody] SalePointPost value)
        {
            using(DMPContext context = new DMPContext())
            {
                Order order = context.Orders.FirstOrDefault(x => x.OrderID == value.OrderID);
                context.UpdateSalePoint(value.OrderID, value.MemberID, value.Mark, order.OrderDate.Value.Month, order.OrderDate.Value.Year);
            }
        }
        
    }
}
