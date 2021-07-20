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
        public IEnumerable<ProductResult> GetProducts(string memberID)
        {
            using(DMPContext context = new DMPContext())
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetProductsOwner")]
        public IEnumerable<OwnerProductResult> GetProductsOwner(string productID)
        {
            return null;
        }

        [HttpGet]
        [Route("GetProduct")]
        public ProductResult GetProduct(string memberID, string productID)
        {
            return null;
        }

        // POST: api/Products
        public void Post([FromBody] ProductResult product)
        {
            
        }

        // PUT: api/Products/5
        public void Put([FromBody]ProductResult product)
        {
           
        }

        // DELETE: api/Products/5
        public void Delete(string productID)
        {
            
        }
    }
}
