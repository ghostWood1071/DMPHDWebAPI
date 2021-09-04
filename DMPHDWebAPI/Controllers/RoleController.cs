using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMPHDWebAPI.Models;
namespace DMPHDWebAPI.Controllers
{
    public class RoleController : ApiController
    {
        // GET: api/Role
        public IEnumerable<string> Get(string memberID)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    return context.GetFunctions(memberID).ToList();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        
    }
}
