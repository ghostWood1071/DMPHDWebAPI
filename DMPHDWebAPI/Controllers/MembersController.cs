using DMPHDWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;
using ClosedXML.Report;
using System.IO;
using System.Net.Http.Headers;

namespace DMPHDWebAPI.Controllers
{
    public class MembersController : ApiController
    {

        [HttpGet]
        [Route("GetYears")]
        public IEnumerable<int> GetYears (string memberID)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    int year = context.Members.FirstOrDefault(x => x.MemberID == memberID).TimeJoin.Value.Year;
                    int currentYear = DateTime.Now.Year;
                    List<int> years = new List<int>();
                    for (var i = currentYear; i >= year; i--)
                        years.Add(i);
                    return years;
                }
            } catch(Exception e)
            {
                return new int[0];
            }
        }

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
        [Route("GetPromotable")]
        public GetPromotable_Result GetPromotable(string id)
        {

            GetPromotable_Result result;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetPromotable(id).ToList().FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }

        [HttpGet]
        [Route("GetReportGenaral")]
        public IEnumerable<ReportGenaral_Result> GetReportGenaral(string id,int year,string key)
        {

            List<ReportGenaral_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.ReportGenaral(id,year,key).ToList();
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
        [Route("GetNextMemberID")]
        public string GetNextMemberID()
        {
            string result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetNextMemberID().ToList().FirstOrDefault();
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
        public IEnumerable<GetSalary_Result> GetSalary(int month,int year)
        {
            List<GetSalary_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetSalary(month, year).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }

        [HttpGet]
        [Route("GetPrepareSalaryInMonthYear")]
        public IEnumerable<GetPrepareSalaryInMonthYear_Result> GetPrepareSalaryInMonthYear(int month, int year)
        {
            List<GetPrepareSalaryInMonthYear_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetPrepareSalaryInMonthYear(month, year).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }

        [HttpGet]
        [Route("GetExcel")]
        public HttpResponseMessage GetExcel(int month, int year)
        {
            using (DMPContext context = new DMPContext())
            {
                try
                {
                    string path = HostingEnvironment.MapPath("~/ExcelTemplate/template.xlsx");
                    XLTemplate template = new XLTemplate(path);
                    List<GetSalary_Result> salary = context.GetSalary(month, year).ToList();
                    SummarySalary summary = new SummarySalary()
                    {
                        month = month,
                        year = year,
                        salarise = salary
                    };
                    template.AddVariable(summary);

                    template.Generate();
                    var stream = new MemoryStream();
                    template.SaveAs(stream);
                    HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
                    message.Content = new ByteArrayContent(stream.ToArray());
                    message.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    message.Content.Headers.ContentDisposition.FileName = $"Bảng lương tháng {month} năm {year}.xlsx";
                    message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    return message;
                } catch(Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            
        }

        [HttpGet]
        [Route("GetSalaryForMember")]
        public IEnumerable<GetSalaryForMember_Result> GetSalaryForMember(string id, int year)
        {
            List<GetSalaryForMember_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetSalaryForMember(id, year).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }

        [HttpGet]
        [Route("GetStatus")]
        public IEnumerable<GetStatusMember_Result> GetStatus(string id)
        {
            List<GetStatusMember_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetStatusMember(id).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }

        [HttpGet]
        [Route("CheckSalaryUpdated")]
        public IEnumerable<CheckSalaryUpdated_Result> CheckSalaryUpdated()
        {
            List<CheckSalaryUpdated_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.CheckSalaryUpdated().ToList();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("My message", e);
            }
            return result;
        }

        [HttpGet]
        [Route("GetMemberPoint")]
        public IEnumerable<GetMemberPoints_Result> GetMemberPoints(string id, int year)
        {
            List<GetMemberPoints_Result> result = null;
            try
            {
                using (DMPContext context = new DMPContext())
                {
                    result = context.GetMemberPoints (id, year).ToList();
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

        [HttpPost]
        [Route("InsertNewMemberPoints")]
        public void InsertNewMemberPointsPoints(int month,int year)
        {
            using (DMPContext context = new DMPContext())
            {
                context.InsertJobMemberPoints(month,year);
            }
        }

        [HttpPost]
        [Route("InsertNewSalary")]
        public void InsertNewSalary(int month,int year)
        {
            using (DMPContext context = new DMPContext())
            {
                context.InsertJobSalary(month,year);
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

        [HttpPut]
        [Route("UpdatePosPromote")]
        public void UpdatePosPromote([FromBody] string id)
        {
            using (DMPContext context = new DMPContext())
            {
                context.UpdatePosPromote(id);
            }
        }

        [HttpPut]
        [Route("UpdateStatus")]
        public void UpdateStatus([FromBody] string id)
        {
            using (DMPContext context = new DMPContext())
            {
                context.UpdateStatus(id);
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

        [HttpPut]
        [Route("UpdateProfile")]
        public void UpdateProfile([FromBody] ProfilePut value)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    var profile = context.Members.FirstOrDefault(x => x.MemberID == value.ID);
                    profile.FullName = value.FullName;
                    profile.Gender = value.Gender;
                    profile.Email = value.Email;
                    profile.Birthday = value.BirthDay;
                    profile.Phone = value.Phone;
                    profile.Address = value.Address;
                    profile.IDCard = value.IDCard;
                    profile.IDCard_DateIssue = value.IDDate;
                    profile.IDCard_PlaceIssue = value.IDPlace;
                    profile.Avatar = value.Avatar;
                    context.SaveChanges();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}