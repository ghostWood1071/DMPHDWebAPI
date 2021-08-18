using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DMPHDWebAPI.App_Start;
using DMPHDWebAPI.Models;

namespace DMPHDWebAPI.Controllers
{
    [EnableCors(origins: SystemConfig.CLIENT_DOMAIN, headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        // POST: api/Login
        [HttpPost]
        [Route("CheckAccount")]
        public GetMemberByID_Result Post([FromBody] AccountPost account)
        {
            using(DMPContext context = new DMPContext())
            {
               GetMemberByID_Result member = context.GetMemberByID(account.UserID).FirstOrDefault();
                if (member == null)
                    return null;
                if (member.Password.Trim() == account.Password)
                    return member;
                else
                    return null;
            }
        }

    }
}
