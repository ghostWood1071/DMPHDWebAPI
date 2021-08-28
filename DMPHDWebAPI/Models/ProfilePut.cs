using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class ProfilePut
    {
        public string ID { get; set; } 
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IDCard { get; set; } 
        public string IDPlace { get; set; } 
        public DateTime IDDate { get; set; } 
        
        public string Avatar { get; set; } 
        
        
        
    }
}