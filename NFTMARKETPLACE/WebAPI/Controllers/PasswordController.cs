using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public void CreatePassword(UserPassword userPassword)
        {
            User user = new User();
            user.Cedula = userPassword.Cedula;
            passwordManager.CreatePassword(user);
        }


        [HttpPost]
        public APIResponse RetrieveAllPasswordById(UserPassword _userPassword)
        {
            APIResponse response = new APIResponse();
            List<UserPassword> retrievePassword = new List<UserPassword>();
            _userPassword.Password = EncryptMd5Manager.Encrypt(_userPassword.Password);
            retrievePassword = passwordManager.RetrievePasswordById(_userPassword);
            User user = new User();
            user.Cedula = _userPassword.Cedula;

            foreach (var item in retrievePassword)
            {
                if (item.Password != null)
                {
                    if (item.Password != _userPassword.Password)
                    {
                        
                        response.Data = 1;
                        response.Status = "Ok";
                        response.Message = "success";
                        response.TransacctionDate = DateTime.Now.ToString();

                        return response;
                    }
                    else
                    {
                        response.Data = 0;
                        response.Status = "Error";
                        response.Message = "Denied";
                        response.TransacctionDate = DateTime.Now.ToString();
                    }
                }


            }
            return new APIResponse() { Data = 0 };
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