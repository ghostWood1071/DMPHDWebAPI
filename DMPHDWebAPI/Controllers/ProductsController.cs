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
                return context.ProductDetails.Where(x => x.MemberID == memberID).Select(x => new ProductResult() {
                       ProductID = x.ProductID,
                       ProductDetailsID = x.ProductDetailsID,
                       MemberID = x.MemberID,
                       ProductName = x.Product.ProductName,
                       BasePrice = x.Product.BasePrices.FirstOrDefault(b => b.EndDate == null).Price.Value,
                       SalesPoints = x.Product.SalesPoints.FirstOrDefault(s => s.EndDate == null).Point.Value,
                       SellPrices = x.Product.SellPrices.FirstOrDefault(se => se.EndDate == null).Price.Value,
                       Quantity = x.Quantity
                    }
                ).ToList();
            }
        }

        [HttpGet]
        [Route("GetProductsOwner")]
        public IEnumerable<OwnerProductResult> GetProductsOwner(string productID)
        {
            using (DMPContext context = new DMPContext())
            {
                return context.Products.Where(x => x.ProductID == productID).Select(x => new OwnerProductResult() {
                      MemberID = x.ProductDetails.FirstOrDefault().MemberID,
                      MemberName = x.ProductDetails.FirstOrDefault().Member.MemberName,
                      Quantity = x.ProductDetails.FirstOrDefault().Quantity
                    }
                ).ToList();
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        public ProductResult GetProduct(string memberID, string productID)
        {
            using(DMPContext context = new DMPContext())
            {
                return context.ProductDetails.Where(x => x.MemberID == memberID && x.ProductID == productID)
                                             .Select(x => new ProductResult() {
                                                  ProductID = x.ProductID,
                                                  ProductDetailsID = x.ProductDetailsID,
                                                  MemberID = x.MemberID,
                                                  ProductName = x.Product.ProductName,
                                                  BasePrice = x.Product.BasePrices.FirstOrDefault(b => b.EndDate == null).Price.Value,
                                                  SalesPoints = x.Product.SalesPoints.FirstOrDefault(s => s.EndDate == null).Point.Value,
                                                  SellPrices = x.Product.SellPrices.FirstOrDefault(se => se.EndDate == null).Price.Value,
                                                  Quantity = x.Quantity
                                                }
                                             )
                                             .FirstOrDefault();
            }
        }

        // POST: api/Products
        public void Post([FromBody] ProductResult product)
        {
            using (DMPContext context = new DMPContext()) {
                ProductResult curentProduct = GetProduct(product.MemberID, product.ProductID);
                if (curentProduct == null)
                    return;

                if (product != curentProduct)
                    return;

                Product mainProduct = context.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
                ProductDetail productDetail = mainProduct.ProductDetails.FirstOrDefault(x=> x.MemberID == product.MemberID);
                BasePrice basePrice = mainProduct.BasePrices.FirstOrDefault(x => x.EndDate == null);
                SellPrice sellPrice = mainProduct.SellPrices.FirstOrDefault(x => x.EndDate == null);
                SalesPoint salesPoint = mainProduct.SalesPoints.FirstOrDefault(x => x.EndDate == null);
                if (curentProduct.BasePrice != product.BasePrice)
                {
                    basePrice.EndDate = DateTime.Now;
                    mainProduct.BasePrices.Add(new BasePrice
                    {
                        ProductID = mainProduct.ProductID,
                        BeginDate = DateTime.Now,
                        Price = product.BasePrice,
                        EndDate = null
                    });
                }

                if (curentProduct.SellPrices != product.SellPrices)
                {
                    sellPrice.EndDate = DateTime.Now;
                    mainProduct.SellPrices.Add(new SellPrice
                    {
                        ProductID = mainProduct.ProductID,
                        BeginDate = DateTime.Now,
                        Price = product.BasePrice,
                        EndDate = null
                    });
                }
                    
                if (curentProduct.SalesPoints != product.SalesPoints) 
                {
                    salesPoint.EndDate = DateTime.Now;
                    mainProduct.SalesPoints.Add(new SalesPoint
                    {
                        ProductID = mainProduct.ProductID,
                        BeginDate = DateTime.Now,
                        Point = product.BasePrice,
                        EndDate = null
                    });
                }

                if (curentProduct.Quantity != product.Quantity)
                    productDetail.Quantity = product.Quantity;
                if (curentProduct.ProductName != product.ProductName)
                    mainProduct.ProductName = product.ProductName;

                context.SaveChanges();
            }
        }

        // PUT: api/Products/5
        public void Put([FromBody]ProductResult product)
        {
            using(DMPContext context = new DMPContext())
            {
                try
                {
                    if (context.Products.Where(x => x.ProductID == product.ProductID).Count() > 0)
                        return;

                    context.Products.Add(new Product()
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,

                    });

                    context.BasePrices.Add(new BasePrice()
                    {
                        ProductID = product.ProductID,
                        Price = product.BasePrice,
                        EndDate = null,
                        BeginDate = DateTime.Now
                    });

                    context.SellPrices.Add(new SellPrice()
                    {
                        ProductID = product.ProductID,
                        Price = product.SellPrices,
                        EndDate = null,
                        BeginDate = DateTime.Now
                    });

                    context.SalesPoints.Add(new SalesPoint()
                    {
                        ProductID = product.ProductID,
                        Point = product.SalesPoints,
                        EndDate = null,
                        BeginDate = DateTime.Now
                    });

                    context.ProductDetails.Add(new ProductDetail()
                    {
                        ProductID = product.ProductID,
                        Quantity = product.Quantity,
                        MemberID = product.MemberID
                    });

                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // DELETE: api/Products/5
        public void Delete(string productID)
        {
            using(DMPContext context = new DMPContext())
            {
                context.Products.Remove(context.Products.FirstOrDefault(x => x.ProductID == productID));
                context.ProductDetails.Remove(context.ProductDetails.FirstOrDefault(x => x.ProductID == productID));
                context.BasePrices.Remove(context.BasePrices.FirstOrDefault(x => x.ProductID == productID));
                context.SellPrices.Remove(context.SellPrices.FirstOrDefault(x => x.ProductID == productID));
                context.SalesPoints.Remove(context.SalesPoints.FirstOrDefault(x => x.ProductID == productID));
                
            }
        }
    }
}
