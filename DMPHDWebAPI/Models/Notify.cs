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
    
    public partial class Notify
    {
        public int NotifyID { get; set; }
        public string Title { get; set; }
        public string NotifyContent { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual Member Member1 { get; set; }
    }
}