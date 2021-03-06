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
    
    public partial class Province
    {
        public Province()
        {
            this.Districts = new HashSet<District>();
            this.Members = new HashSet<Member>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<int> TelephoneCode { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> SortOrder { get; set; }
    
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
