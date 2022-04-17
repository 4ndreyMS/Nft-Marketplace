using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class LogginController : ApiController
    {
        private LogginManager loginManager;


        public LogginController()
        {
            loginManager = new LogginManager();
        }


        [HttpPost]
        public APIResponse RetrieveLoggin(UserPassword _userPassword)
        {

            APIResponse response = new APIResponse();
            UserPassword retrievePassword = new UserPassword();
            _userPassword.Password = EncryptMd5Manager.Encrypt(_userPassword.Password);
            retrievePassword = loginManager.Retrieve<UserPassword>(_userPassword);

            if (retrievePassword != null)
            {
                if (_userPassword.Cedula == retrievePassword.Cedula && _userPassword.Password == retrievePassword.Password)
                {
                    response.Data = 1;
                    response.Status = "Ok";
                    response.Message = "Accepted";
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
            return new APIResponse(){Data = 0};
        }
    }
}