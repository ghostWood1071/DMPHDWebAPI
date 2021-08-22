using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMPHDWebAPI.Models;
using DMPHDWebAPI.App_Start;
using System.Web.Http.Cors;
using System.Diagnostics;

namespace DMPHDWebAPI.Controllers
{
    public class ConfigController : ApiController
    {
        [HttpGet]
        [Route("GetConfigs")]
        public IEnumerable<Config> GetConfigs()
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    return context.Configs.ToList();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        [HttpPut]
        [Route("SetConfig")]
        public void SetConfig([FromBody] ConfigPost value)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    context.Configs.FirstOrDefault(x => x.ParameterID.Trim() == value.ID).Value = value.Value;
                    context.SaveChanges();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        
        [HttpGet]
        [Route("GetDiscounts")]
        public IEnumerable<GetPositions_Result> GetPositions()
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    return context.GetPositions().ToList();
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            } 
        }

        [HttpPut]
        [Route("SetDiscount")]
        public void SetDiscount([FromBody] DiscountPut value)
        {
            try
            {
                using(DMPContext context = new DMPContext())
                {
                    context.Positions.FirstOrDefault(x => x.PositionID == value.ID).Discount = value.Discount;
                };
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
