using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMPHDWebAPI.Models;
using Newtonsoft.Json;

namespace DMPHDWebAPI.Controllers
{
    public class OrderDetailController : ApiController
    {
        // GET: api/OrderDetail
        [HttpGet]
        [Route("GetOrderDetails")]
        public IEnumerable<GetOrderDetails_Result> GetOrderDetails(string orderID)
        {
            using(DMPContext context = new DMPContext())
            {
               return  context.GetOrderDetails(orderID).ToList();
            }
        }

        // GET: api/OrderDetail/5
        public GetOrderDetail_Result Get(int id)
        {
            using(DMPContext context = new DMPContext())
            {
                return  context.GetOrderDetail(id).FirstOrDefault();
            }
        }

        // POST: api/OrderDetail
        [HttpPost]
        [Route("InsertOrderDetails")]
        public void PostDetails(string memberID, [FromBody]List<OrderDetailPost> details)
        {
             using(DMPContext context = new DMPContext())
             {
                foreach(var item in details)
                {
                    ProductDetail productDetail =  context.ProductDetails.Where(x => x.ProductID == item.ProductID && x.MemberID == memberID).FirstOrDefault();
                    productDetail.Quantity -= item.Quantity;
                }
                context.SaveChanges();
                string jsonString = JsonConvert.SerializeObject(details);
                context.InsertOrderDetails(jsonString);
              
             }
        }

        [HttpPost]
        [Route("InsertOrderDetail")]
        public void PostDetail(string memberID, [FromBody] OrderDetailPost detail)
        {
            using(DMPContext context = new DMPContext())
            {
                ProductDetail productDetail = context.ProductDetails.Where(x => x.ProductID == detail.ProductID && x.MemberID == memberID).FirstOrDefault();
                productDetail.Quantity -= detail.Quantity;
                context.SaveChanges();
                context.InsertOrderDetail(detail.OrderID, detail.Quantity, detail.UnitPrice, detail.Discount, detail.ProductID);
            }
        }

        [HttpPost]
        [Route("CheckQuantity")]
        public bool CheckQuantity( string memberID, [FromBody] List<QuantityChecker> quantities)
        {
            using(DMPContext context = new DMPContext())
            {
                List<QuantityChecker> productQuanties = context.ProductDetails.Where(x => x.MemberID == memberID)
                                                                              .Select(x => new QuantityChecker() 
                                                                              { 
                                                                                  ProductID = x.ProductID,                 
                                                                                  Quantity = x.Quantity 
                                                                              }).ToList();
                foreach(var item in quantities)
                {
                    QuantityChecker real =  productQuanties.Find(x => x.ProductID == item.ProductID);
                    if (real == null)
                        return false;

                    if (real.Quantity < item.Quantity)
                        return false;
                }

                return true;
            }
        }

        // PUT: api/OrderDetail/5
        public void Put(int id, [FromBody] OrderDetailPost value)
        {
            using(DMPContext context = new DMPContext())
            {

            }
        }

        // DELETE: api/OrderDetail/5
        public void Delete(int id)
        {
        }
    }
}
