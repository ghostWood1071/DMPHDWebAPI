using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class ProductResult
    {
        public ProductResult()
        {

        }

        public ProductResult(string productID, int productDetailsID, string memberID, string productName, double basePrice, double salesPoints, double sellPrices, int quantity)
        {
            ProductID = productID;
            ProductDetailsID = productDetailsID;
            MemberID = memberID;
            ProductName = productName;
            BasePrice = basePrice;
            SalesPoints = salesPoints;
            SellPrices = sellPrices;
            Quantity = quantity;
        }

        public string ProductID { get; set; }
        public int ProductDetailsID { get; set; }
        public string MemberID { get; set; }
        public string ProductName { get; set; }
        public double BasePrice { get; set; }
        public double SalesPoints { get; set; }
        public double SellPrices { get; set; }
        public int Quantity { get; set; }
    }
}