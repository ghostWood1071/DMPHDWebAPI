using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class MailPost
    {
        public string Title { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public bool IsHTML { get; set; }
        public bool IsSendAll { get; set; }
    }
}