
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class MemberResult
    {
        public string MemberID { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string IDCard { get; set; }
        public string IDCard_PlaceIssue { get; set; }
        public System.DateTime IDCard_DateIssue { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ReferralID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int RoleID { get; set; }
    }   
}