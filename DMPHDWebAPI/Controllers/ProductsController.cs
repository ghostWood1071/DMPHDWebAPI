using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMPHDWebAPI.Models;
namespace DMPHDWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route("GetProducts")]
        public IEnumerable<GetProducts_Result> GetProducts(string memberID)
        {
            using(DMPContext context = new DMPContext())
            {
                return context.GetProducts(memberID).ToList();
            }
        }

        

        [HttpGet]
        [Route("GetProduct")]
        public GetProductsByID_Result GetProduct(string memberID, string productID)
        {
            using(DMPContext context = new DMPContext())
            {
               return context.GetProductsByID(memberID, productID).ToList().FirstOrDefault();
            }
        }

        // POST: api/Products //add new product
        public void Post([FromBody] ProductResult productInfo)
        {
            using (DMPContext context = new DMPContext())
            {
                context.InserProduct(productInfo.MemberID,
                                     productInfo.ProductName,
                                     productInfo.SellPrices,
                                     productInfo.BasePrice,
                                     productInfo.SalesPoints,
                                     productInfo.Quantity,
                                     productInfo.Description);
            };
        }

        // PUT: api/Products/5
        public void Put([FromBody]ProductResult product)
        {
           using(DMPContext context = new DMPContext())
            {
                context.UpdateProduct(product.ProductID, 
                                      product.MemberID,
                                      product.ProductName,
                                      product.SellPrices, 
                                      product.BasePrice, 
                                      product.SalesPoints, 
                                      product.Quantity, 
                                      product.Description);
            }
        }

        // DELETE: api/Products/5
        public void Delete(string productID)
        {
            using(DMPContext context = new DMPContext())
            {
                context.DeleteProduct(productID);
            }
        }
    }
}
