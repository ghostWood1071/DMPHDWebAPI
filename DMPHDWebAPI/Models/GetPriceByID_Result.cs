//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMPHDWebAPI.Models
{
    using System;
    
    public partial class GetPriceByID_Result
    {
        public int PriceID { get; set; }
        public string ProductID { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<double> BasePrice { get; set; }
        public Nullable<double> OriginPrice { get; set; }
        public Nullable<double> SalePoint { get; set; }
    }
}
