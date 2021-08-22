using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class NotifyResult
    {
        public int NotifyID { get; set; }
        public string Title { get; set; }
        public string Receiver { get; set; }
        public DateTime CreateDate { get; set; }
    }
}