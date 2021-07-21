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
        public IEnumerable<OrderResult> Get()
        {
            using(DMPContext context = new DMPContext())
            {
                return context.Orders.Select(x => new OrderResult
                {
                    MemberID = x.MemberID,
                    MemberName = x.Member.FullName,
                    OrderDate = x.OrderDate.Value.ToString("dd/MM/yyyy"),
                    OrderID = x.OrderID,
                    TotalPrice = x.OrderDetails.Sum(dt => dt.UnitPrice.Value),
                    UsedMark = x.UsedMark.Value
                }).ToList();
            }
        }

        // GET: api/Order/5
        public IEnumerable<OrderDetailResult> Get(string id)
        {
            using(DMPContext context = new DMPContext())
            {
                return context.OrderDetails.Where(x => x.OrderID == id).Select(x => new OrderDetailResult
                {
                    OrderDetailID = x.OrderDetailID,
                    Discount = x.Discount.Value,
                    ProductID = x.Product.ProductID,
                    ProductName = x.Product.ProductName,
                    Quantity = x.Quantity.Value,
                    UnitPrice = x.UnitPrice.Value
                }).ToList();
            };
        }

        // POST: api/Order
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
