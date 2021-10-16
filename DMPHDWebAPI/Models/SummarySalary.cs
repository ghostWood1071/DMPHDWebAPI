using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMPHDWebAPI.Models
{
    public class SummarySalary
    {
        public int month { get; set; }
        public int year { get; set; }
        public List<GetSalary_Result> salarise { get; set; }
    }
}