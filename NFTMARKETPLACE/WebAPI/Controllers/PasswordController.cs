using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;
using System;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PasswordController : ApiController
    {
        private UserPasswordManager passwordManager;

        public PasswordController()
        {
            passwordManager = new UserPasswordManager();
        }

        [HttpGet]
        public APIResponse RetrieveAllPasswordById(UserPassword _userPassword)
        {
            APIResponse response = new APIResponse()
            {
                Data = passwordManager.RetrievePasswordById(_userPassword),
                Status = "Ok",
                Message = "History Password",
                TransacctionDate = DateTime.Now.ToString()
            };
            return response;
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

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}