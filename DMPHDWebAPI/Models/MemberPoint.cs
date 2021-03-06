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
    using System.Collections.Generic;
    
    public partial class MemberPoint
    {
        public string MemberID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Nullable<double> MediateMark { get; set; }
        public Nullable<double> ImmediateMark { get; set; }
        public Nullable<double> AccumulatedMark { get; set; }
        public Nullable<double> UsedMark { get; set; }
        public Nullable<double> UnUsedMark { get; set; }
        public Nullable<double> ExtraMark { get; set; }
        public Nullable<bool> PromoteIsActive { get; set; }
        public Nullable<double> PersonalPoint { get; set; }
        public Nullable<double> TotalSales { get; set; }
        public Nullable<double> NetPoint { get; set; }
    
        public virtual Member Member { get; set; }
    }
}
