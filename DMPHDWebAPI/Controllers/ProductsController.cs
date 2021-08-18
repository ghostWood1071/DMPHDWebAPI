using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DMPHDWebAPI.Models;
using System.Web.Http.Cors;
using DMPHDWebAPI.App_Start;
using System.Diagnostics;

namespace DMPHDWebAPI.Controllers
{
    
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route("GetProducts")]
        public IEnumerable<GetProducts_Result> GetProducts(string memberID)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    return context.GetProducts(memberID).ToList();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        public GetProductsByID_Result GetProduct(string memberID, string productID)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    return context.GetProductsByID(memberID, productID).ToList().FirstOrDefault();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        // POST: api/Products //add new product
        [HttpPost]
        [Route("InsertProduct")]
        public string Post([FromBody] ProductResult productInfo)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    context.InserProduct(productInfo.MemberID,
                                         productInfo.ProductName,
                                         productInfo.OriginPrice,
                                         productInfo.BasePrice,
                                         productInfo.SalePoint,
                                         productInfo.Quantity,
                                         productInfo.Description);
                    return context.GetProducts(productInfo.MemberID).LastOrDefault().ProductID;
                };
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }

        // PUT: api/Products/5
        [HttpPut]
        [Route("UpdateProduct")]
        public void Put([FromBody]ProductResult product)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    context.UpdateProduct(product.ProductID,
                                          product.MemberID,
                                          product.ProductName,
                                          product.OriginPrice,
                                          product.BasePrice,
                                          product.SalePoint,
                                          product.Quantity,
                                          product.Description);
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete]
        [Route("DeleteProduct")]
        public void Delete(string productID)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    context.DeleteProduct(productID);
                    
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
