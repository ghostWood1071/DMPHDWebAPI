using DMPHDWebAPI.Extensions;
using DMPHDWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMPHDWebAPI.Controllers
{
    public class NotifyController : ApiController
    {
        // GET: api/Notify
        public IEnumerable<NotifyResult> Get()
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    return context.Notifies.Select(x => new NotifyResult()
                    {
                        NotifyID = x.NotifyID,
                        Receiver = x.Receiver,
                        CreateDate = x.LastUpdated.Value,
                        Title = x.Title
                    }).OrderByDescending(x=>x.CreateDate).ToList();
                };
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        // GET: api/Notify/5
        public NotifyDetailResult Get(int id)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    return context.Notifies.Where(x => x.NotifyID == id).Select(x => new NotifyDetailResult()
                    {
                        NotifyID = x.NotifyID,
                        Receiver = x.Receiver,
                        CreateDate = x.LastUpdated.Value,
                        Title = x.Title,
                        Content = x.NotifyContent

                    }).FirstOrDefault();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        // POST: api/Notify
        public void Post([FromBody]NotifyPost value)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    context.Notifies.Add(new Notify()
                    {
                        NotifyID = value.NotifyID,
                        Title = value.Title,
                        NotifyContent = value.Content,
                        Receiver = value.IsSendAll? null:value.Receiver,
                        Sender = value.Sender,
                        LastUpdated = value.CreateDate
                    });
                    context.SaveChanges();


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
                        return;
                    }
                    var receiver = context.Members.FirstOrDefault(x => x.MemberID == value.Receiver);
                    mailer.Receiver = receiver.Email.Trim();
                    mailer.Send(true);
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        // PUT: api/Notify/5
        public void Put([FromBody]NotifyPost value)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    var notifiy = context.Notifies.FirstOrDefault(x => x.NotifyID == value.NotifyID);
                    if (notifiy == null)
                        throw new ArgumentNullException();
                    notifiy.Receiver = value.Receiver;
                    notifiy.Sender = value.Sender;
                    notifiy.Title = value.Title;
                    notifiy.NotifyContent = value.Content;
                    notifiy.LastUpdated = value.CreateDate;
                    context.SaveChanges();
                };
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        // DELETE: api/Notify/5
        public void Delete(int id)
        {
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    var notify = context.Notifies.FirstOrDefault(x => x.NotifyID == id);
                    context.Notifies.Remove(notify);
                    context.SaveChanges();
                }
            }catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
