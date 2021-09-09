using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using DMPHDWebAPI.App_Start;
using DMPHDWebAPI.Extensions;
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

        [HttpPost]
        [Route("CheckPass")]
        public bool CheckPass([FromBody] CheckPassPost value)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                   var user =  context.Members.FirstOrDefault(x => x.MemberID == value.uid);
                    if (user == null)
                        throw new ArgumentNullException("not found");
                    if (user.Password.Trim() == value.pass)
                        return true;
                    return false;
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        [HttpPut]
        [Route("ChangePass")]
        public void ChangePass([FromBody] CheckPassPost value)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    var user = context.Members.FirstOrDefault(x => x.MemberID == value.uid);
                    if (user == null)
                        throw new ArgumentNullException("not found");
                    user.Password = value.pass;
                    context.SaveChanges();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        [HttpPut]
        [Route("ChangePassWord")]
        public IHttpActionResult ChangePassWord(string email)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    var member = context.Members.FirstOrDefault(x => x.Email.Trim() == email);
                    if (member == null)
                        return InternalServerError(new Exception("tạo mật khẩu không thành công"));

                    MD5CryptoServiceProvider encoder = new MD5CryptoServiceProvider();
                    byte[] bHash = encoder.ComputeHash(Encoding.UTF8.GetBytes((member.MemberID+member.Password.Trim())));

                    StringBuilder sbHash = new StringBuilder();

                    foreach (byte b in bHash)
                        sbHash.Append(String.Format("{0:x2}", b));

                    string newPass = sbHash.ToString();
                    member.Password = newPass;
                    context.SaveChanges();

                    Mailer mailer = new Mailer()
                    {
                        Content = $"Mật khẩu mới của bạn là: {newPass}",
                        Receiver = member.Email.Trim(),
                        Title = "Mậ khẩu mới DMP Hải Dương"
                    };
                    mailer.Send();

                    return Ok("Tạo mật khẩu mới thành công");
                }
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return InternalServerError(new Exception("Tạo mật khẩu không thành công"));
            }
        }

        [HttpPut]
        [Route("Change")]
        public string ChangeForcePassword(string id)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    var member = context.Members.FirstOrDefault(x => x.MemberID == id);
                    if (member == null)
                        return null;

                    MD5CryptoServiceProvider encoder = new MD5CryptoServiceProvider();
                    byte[] bHash = encoder.ComputeHash(Encoding.UTF8.GetBytes((member.MemberID + member.Password.Trim())));

                    StringBuilder sbHash = new StringBuilder();

                    foreach (byte b in bHash)
                        sbHash.Append(String.Format("{0:x2}", b));

                    string newPass = sbHash.ToString();
                    member.Password = newPass;
                    context.SaveChanges();
                    return newPass;
                }
            } catch(Exception e)
            {
                return null;
            }
        }
    }
}
