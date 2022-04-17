using AppLogic.Managers;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class OtpController : ApiController
    {
        private OtpManager otpManager;

        public OtpController()
        {
             otpManager = new OtpManager();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        [HttpPut]
        public void Put(Otp otp)
        {
            otpManager.UpdateOtp(otp);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}