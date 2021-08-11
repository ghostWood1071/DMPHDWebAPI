using DMPHDWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMPHDWebAPI.Controllers
{
    public class MembersController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("GetMembers")]
        public IEnumerable<GetMembers_Result> Get()
        {
            using(DMPContext context = new DMPContext())
            {
                return context.GetMembers().ToList();
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetMember")]
        public IEnumerable<GetMemberByID_Result> Get(string id)
        {
            using (DMPContext context = new DMPContext())
            {
                return context.GetMemberByID(id).ToList();
            }
        }
        [HttpGet]
        [Route("GetLowerMembers")]
        public IEnumerable<GetLowerMembers_Result> GetLowerMembers(string id)
        {
            using (DMPContext context = new DMPContext())
            {
                return context.GetLowerMembers(id).ToList();
            }
        }
        [HttpGet]
        [Route("GetSalary")]
        public IEnumerable<GetSalary_Result> GetSalary(string id,int year)
        {
            using (DMPContext context = new DMPContext())
            {
                return context.GetSalary(id,year).ToList();
            }
        }
        // POST api/<controller>
        public void Post([FromBody] MemberResult Member)
        {
            using (DMPContext context = new DMPContext())
            {
                context.InsertMember(Member.MemberID, 
                                    Member.FullName, 
                                    Member.ReferralID, 
                                    Member.Gender, 
                                    Member.Birthday, 
                                    Member.Address, 
                                    Member.Email, 
                                    Member.Phone, 
                                    Member.IDCard, 
                                    Member.IDCard_PlaceIssue, 
                                    Member.IDCard_DateIssue,
                                    Member.Password,
                                    Member.PositionID, 
                                    Member.RoleID, 
                                    Member.IsActive, 
                                    Member.Avatar);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateMember")]
        public void Put([FromBody] MemberResult Member)
        {
            using (DMPContext context = new DMPContext())
            {
                context.UpdateMember(Member.MemberID,
                                    Member.FullName,
                                    Member.ReferralID,
                                    Member.Gender,
                                    Member.Birthday,
                                    Member.Address,
                                    Member.Email,
                                    Member.Phone,
                                    Member.IDCard,
                                    Member.IDCard_PlaceIssue,
                                    Member.IDCard_DateIssue,
                                    Member.Password,
                                    Member.PositionID,
                                    Member.RoleID,
                                    Member.IsActive,
                                    Member.Avatar);
            }
        }
        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            using (DMPContext context = new DMPContext())
            {
                context.DeleteMember(id);
            }
        }
    }
}