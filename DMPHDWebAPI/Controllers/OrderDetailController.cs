using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

        [HttpGet]
        [Route("GetDetails")]
        public IEnumerable<DetailsGet> GetDetails(string memberID, string orderID)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                   return context.GetListDetails(memberID, orderID).Select(x => new DetailsGet()
                    {
                        BasePrice = x.BasePrice,
                        OriginPrice = x.OriginPrice,
                        BuyQuantity = x.BuyQuantity,
                        Quantity = x.Quantity,
                        ProductID = x.ProductID,
                        ProductName = x.ProductName,
                        SalePoint = x.SalePoint,
                        IsBought = x.BuyQuantity.HasValue
                    }).ToList();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
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
        public void PostDetails(string memberID, [FromBody]OrderDetailsPost details)
        {
             using(DMPContext context = new DMPContext())
             {
                foreach(var item in details.Details)
                {
                    ProductDetail productDetail =  context.ProductDetails.Where(x => x.ProductID == item.ProductID && x.MemberID == memberID).FirstOrDefault();
                    productDetail.Quantity -= item.Quantity;
                }
                context.SaveChanges();
                string jsonString = JsonConvert.SerializeObject(details.Details);
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
                context.InsertOrderDetail(detail.OrderID, detail.Quantity, detail.UnitPrice, detail.ProductID);
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
        public void Put([FromBody] DetailsPut value)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    List<OrderDetailPut> detailPuts = value.Details.ToList();
                    foreach (var detail in detailPuts)
                    {
                        var old = context.OrderDetails.FirstOrDefault(x => x.OrderID == detail.OrderID && x.ProductID == detail.ProductID);
                        var product = context.ProductDetails.FirstOrDefault(x => x.ProductID == detail.ProductID && x.MemberID == value.MemberID);
                        if (detail.IsBought)
                        {
                            if (old != null)
                            {
                                product.Quantity -= (detail.Quantity - old.Quantity.Value);
                                old.Quantity = detail.Quantity;
                                old.UnitPrice = detail.UnitPrice;
                            }
                            else
                            {
                                context.OrderDetails.Add(new OrderDetail()
                                {
                                    OrderID = detail.OrderID,
                                    ProductID = detail.ProductID,
                                    Quantity = detail.Quantity,
                                    UnitPrice = detail.UnitPrice,
                                });
                                product.Quantity -= detail.Quantity;
                            }
                        }
                        else if (old != null)
                        {
                            product.Quantity += old.Quantity.Value;
                            context.OrderDetails.Remove(old);
                        }
                    }
                    context.SalePoints.FirstOrDefault(x => x.OrderID == value.OrderID).Mark = value.Mark;
                    context.SaveChanges();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        // DELETE: api/OrderDetail/5
        public void Delete(int id)
        {
            using(DMPContext context = new DMPContext())
            {
                context.DeleteOrderDetail(id);
            }
        }

        public void DeleteOrderDetails(string orderID)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    context.DeleteOrderdetails(orderID);
                }
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
