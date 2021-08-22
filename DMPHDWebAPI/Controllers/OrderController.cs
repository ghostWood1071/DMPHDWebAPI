using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public GetOrders_Result Post([FromBody] OrderPost order)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    context.InsertOrder(order.MemberID, order.OrderDate, order.Discount);
                    return context.GetOrders().LastOrDefault();
                }
            } catch
            {
                return null;
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

        [HttpGet]
        [Route("GetYears")]
        public IEnumerable<int> GetYears(string memberID)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                   return context.Orders.Where(x => x.MemberID == memberID).Select(x => x.OrderDate.Value.Year).Distinct().ToList();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("GetOrders")]
        public IEnumerable<OrderResults> GetOrders(string memberID)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    return context.Orders.Where(x => x.MemberID == memberID).Select(x => new OrderResults()
                    {
                       OrderID = x.OrderID,
                       Discount = x.Discount,
                       FullName = x.Member.FullName,
                       MemberID = x.MemberID,
                       OrderDate = x.OrderDate
                    }).ToList();
                }

            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
