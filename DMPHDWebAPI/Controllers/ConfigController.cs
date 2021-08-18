using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMPHDWebAPI.Models;
using DMPHDWebAPI.App_Start;
using System.Web.Http.Cors;

namespace DMPHDWebAPI.Controllers
{
    [EnableCors(origins: SystemConfig.CLIENT_DOMAIN, headers: "*", methods: "*")]
    public class ConfigController : ApiController
    {

        [HttpGet]
        [Route("StandardMember")]
        public float GetStandardMemberScore()
        {
            using(DMPContext context = new DMPContext())
            {
               return float.Parse(context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_MEMBER).Value);
            }
        }

        [HttpGet]
        [Route("StandardTCMember")]
        public float GetStandardTCMemberScore()
        {
            using(DMPContext context = new DMPContext())
            {
               return float.Parse(context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_TC_MEMBER).Value);
            }
        }

        [HttpGet]
        [Route("StandardDCMember")]
        public float GetStandardDCMemberScore()
        {
            using (DMPContext context = new DMPContext())
            {
                return float.Parse(context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_DC_MEMBER).Value);
            }
        }

        [HttpGet]
        [Route("StandardBeginMember")]
        public float GetStandardBeginMemberScore()
        {
            using (DMPContext context = new DMPContext())
            {
                return float.Parse(context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_BEGIN_MEMBER).Value);
            }
        }

        [HttpGet]
        [Route("ExchangeRate")]
        public float GetExchangeRate()
        {
            using(DMPContext context = new DMPContext())
            {
                return float.Parse(context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.EXCHANGE_RATE).Value);
            }
        }

        [HttpGet]
        [Route("GetLeaderScore")]
        public float GetLeaderScore()
        {
            using(DMPContext context = new DMPContext())
            {
                return float.Parse(context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_LEADER).Value);
            }
        }

        [HttpGet]
        [Route("GetManagerScore")]
        public float GetManagerScore()
        {
            using (DMPContext context = new DMPContext())
            {
                return float.Parse(context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_MANAGER).Value);
            }
        }

        [HttpGet]
        [Route("GetReserveManagerScore")]
        public float GetReserveManagerScore()
        {
            using (DMPContext context = new DMPContext())
            {
                return float.Parse(context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_RESERVE_MANAGER).Value);
            }
        }
        


        [HttpPut]
        [Route("SetMemberScore")]
        public void SetStandardMemberScore(float val)
        {
            using (DMPContext context = new DMPContext())
            {
                context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_MEMBER).Value = val.ToString();
            }
        }

        [HttpPut]
        [Route("SetTCMemberScore")]
        public void SetStandardTCMemberScore(float val)
        {
            using (DMPContext context = new DMPContext())
            {
                context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_TC_MEMBER).Value = val.ToString();
            }
        }

        [HttpPut]
        [Route("SetMemberDCScore")]
        public void SetStandardDCMemberScore( float val)
        {
            using (DMPContext context = new DMPContext())
            {
                context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_DC_MEMBER).Value = val.ToString();
            }
        }

        [HttpPut]
        [Route("SetBeginMemberScore")]
        public void SetStandardBeginMemberScore(float val)
        {
            using (DMPContext context = new DMPContext())
            {
                context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_BEGIN_MEMBER).Value = val.ToString();
            }
        }

        [HttpPut]
        [Route("SetExchangeRate")]
        public void SetExchangeRate(float val)
        {
            using (DMPContext context = new DMPContext())
            {
                context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.EXCHANGE_RATE).Value = val.ToString();
            }
        }

        [HttpPut]
        [Route("SetLeaderScore")]
        public void SetLeaderScore( float val)
        {
            using (DMPContext context = new DMPContext())
            {
                context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_LEADER).Value = val.ToString();
            }
        }

        [HttpPut]
        [Route("SetManagerScore")]
        public void SetManagerScore(float val)
        {
            using (DMPContext context = new DMPContext())
            {
                context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_MANAGER).Value = val.ToString();
            }
        }

        [HttpPut]
        [Route("SetReserveManagerScore")]
        public void SetReserveManagerScore(float val)
        {
            using (DMPContext context = new DMPContext())
            {
                context.Configs.FirstOrDefault(x => x.ParameterID == SystemConfig.STANDARD_RESERVE_MANAGER).Value = val.ToString();
            }
        }
    }
}
