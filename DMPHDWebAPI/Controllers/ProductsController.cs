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
                return context.ProductDetails.Where(x => x.MemberID == memberID).Select(x => new ProductResult
                {
                    ProductDetailsID = x.ProductDetailID,
                    ProductID = x.ProductID,
                    MemberID = x.MemberID,
                    Quantity = x.Quantity,
                    BasePrice = x.Product.Prices.FirstOrDefault().BasePrice.Value,
                    SellPrices = x.Product.Prices.FirstOrDefault().OriginPrice.Value,
                    SalesPoints = x.Product.Prices.FirstOrDefault().SalePoint.Value,
                    ProductName = x.Product.ProductName

                }).ToList();
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
            using(DMPContext context = new DMPContext())
            {
                return context.ProductDetails.Where(x => x.MemberID == memberID && x.ProductID == productID).Select(x => new ProductResult
                {
                    ProductDetailsID = x.ProductDetailID,
                    ProductID = x.ProductID,
                    MemberID = x.MemberID,
                    Quantity = x.Quantity,
                    BasePrice = x.Product.Prices.FirstOrDefault().BasePrice.Value,
                    SellPrices = x.Product.Prices.FirstOrDefault().OriginPrice.Value,
                    SalesPoints = x.Product.Prices.FirstOrDefault().SalePoint.Value,
                    ProductName = x.Product.ProductName

                }).FirstOrDefault();
            }
        }

        // POST: api/Products
        public void Post([FromBody] ProductResult product)
        {
            using(DMPContext context = new DMPContext())
            {
                context.Products.Add(new Product()
                {
                     ProductID = product.ProductID,
                     ProductName = product.ProductName
                });

                context.Prices.Add(new Price()
                {
                     ProductID = product.ProductID,
                     BasePrice = product.BasePrice,
                     OriginPrice = product.SellPrices,
                     BeginDate = DateTime.Now,
                     EndDate = null,
                     SalePoint = product.SalesPoints
                });

                context.ProductDetails.Add(new ProductDetail()
                {
                    MemberID = product.MemberID,
                    ProductID = product.ProductID,
                    Quantity = product.Quantity
                });

                context.SaveChanges();
            }
        }

        // PUT: api/Products/5
        public void Put([FromBody]ProductResult product)
        {
           using(DMPContext context = new DMPContext())
            {
                Product oldProduct = context.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
                oldProduct.ProductName = product.ProductName;

                ProductDetail oldDetail = oldProduct.ProductDetails.FirstOrDefault(x => x.MemberID == product.MemberID);
                oldDetail.Quantity = product.Quantity;

                Price oldPrice = oldProduct.Prices.FirstOrDefault();
                oldPrice.EndDate = DateTime.Now;

                context.Prices.Add(new Price()
                {
                    ProductID = product.ProductID,
                    BasePrice = product.BasePrice,
                    SalePoint = product.SalesPoints,
                    OriginPrice = product.SellPrices,
                    BeginDate = DateTime.Now,
                    EndDate = null
                });

                context.SaveChanges();
            }
        }

        // DELETE: api/Products/5
        public void Delete(string productID, string memberID)
        {
            using(DMPContext context = new DMPContext())
            {
                ProductDetail detail = context.ProductDetails.FirstOrDefault(x => x.ProductID == productID && x.MemberID == memberID);
                context.ProductDetails.Remove(detail);
                context.SaveChanges();
            }
        }
    }
}
