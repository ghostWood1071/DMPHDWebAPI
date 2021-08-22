using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class NotifyPost: NotifyResult
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public bool IsSendAll { get; set; }
    }
}