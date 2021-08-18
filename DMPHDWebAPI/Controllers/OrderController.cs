using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMPHDWebAPI.Models;

namespace DMPHDWebAPI.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/Order
        public IEnumerable<GetOrders_Result> Get()
        {
            using(DMPContext context = new DMPContext())
            {
               return context.GetOrders().ToList();
            }
        }

        // GET: api/Order/5
        public IEnumerable<GetOrderByID_Result> Get(string id)
        {
            using(DMPContext context = new DMPContext())
            {
                return context.GetOrderByID(id).ToList();
            };
        }

        // POST: api/Order
        public void Post([FromBody] OrderPost order)
        {
            using(DMPContext context = new DMPContext())
            {
                context.InsertOrder(order.MemberID, order.OrderDate, order.Discount);
            }
        }

        // PUT: api/Order/5
        public void Put([FromBody] OrderPut order)
        {
            using (DMPContext context = new DMPContext())
            {
                context.UpdateOrder(order.OrderID , order.MemberID, order.OrderDate);
            }
        }

        // DELETE: api/Order/5
        public void Delete(string orderID)
        {
            using(DMPContext context = new DMPContext())
            {
                context.DeleteOrder(orderID);
            }
        }
    }
}
