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
