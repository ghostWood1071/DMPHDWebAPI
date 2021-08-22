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
    public class MembersController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("GetMembers")]
        public IEnumerable<GetMembers_Result> Get()
        {
            List<GetMembers_Result> result = null;
            try {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetMembers().ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetMember")]
        public IEnumerable<GetMemberByID_Result> Get(string id)
        {

            List<GetMemberByID_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetMemberByID(id).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }
        [HttpGet]
        [Route("GetLowerMembers")]
        public IEnumerable<GetLowerMembers_Result> GetLowerMembers(string id)
        {
            List<GetLowerMembers_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetLowerMembers(id).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }
        [HttpGet]
        [Route("GetSalary")]
        public IEnumerable<GetSalary_Result> GetSalary(string id,int year)
        {
            List<GetSalary_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetSalary(id, year).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }
        [HttpGet]
        [Route("ReportGenaral")]
        public IEnumerable<ReportGenaral_Result> ReportGenaral(string id, int year,int month)
        {
            List<ReportGenaral_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.ReportGenaral(id, year,month).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }
        // POST api/<controller>
        [HttpGet]
        [Route("ReportMemberQuantityByLevel")]
        public IEnumerable<ReportMemberQuantityByLevel_Result> ReportMemberQuantityByLevel(string id)
        {
            List<ReportMemberQuantityByLevel_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.ReportMemberQuantityByLevel(id).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }

        [HttpGet]
        [Route("ReportMemberQuantityByPosition")]
        public IEnumerable<ReportMemberQuantityByPosition_Result> ReportMemberQuantityByPosition(string id)
        {
            List<ReportMemberQuantityByPosition_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.ReportMemberQuantityByPosition(id).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }
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

        [HttpGet]
        [Route("GetOrg")]
        public IEnumerable<GetMembersOrg_Result> GetOrg(string memberID)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    return context.GetMembersOrg(memberID).ToList();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        } 
    }
}