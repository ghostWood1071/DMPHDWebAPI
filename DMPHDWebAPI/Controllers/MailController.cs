using DMPHDWebAPI.Extensions;
using DMPHDWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DMPHDWebAPI.Controllers
{
    public class MailController : ApiController
    {
        [HttpPost]
        [Route("OrderMail")]
        public IHttpActionResult SendMail([FromBody] MailPost value)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    Mailer mailer = new Mailer
                    {
                        Content = value.Content,
                        HostName = null,
                        Password = null,
                        Sender = null,
                        Title = value.Title
                    };


                    if (value.IsSendAll)
                    {
                        var emails = context.Members.Select(x => x.Email.Trim()).ToList();
                        mailer.Send(emails, true);

                    }
                    else
                    {
                        var receiver = context.Members.FirstOrDefault(x => x.MemberID == value.Receiver);
                        mailer.Receiver = receiver.Email.Trim();
                        mailer.Send(true);
                    }
                    return Ok("sucess");
                }
            } catch (Exception e)
            {

                return Json<Exception>(e);
            }

        }

        
    }
}
