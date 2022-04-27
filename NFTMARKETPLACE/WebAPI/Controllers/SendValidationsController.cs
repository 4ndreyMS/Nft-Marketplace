using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;

namespace WebAPI.Controllers
{
    public class SendValidationsController : ApiController
    {

        private SendValidationsManager validationManger;

        public SendValidationsController()
        {
            validationManger = new SendValidationsManager();
        }

        [HttpPost]
        public APIResponse SendDymanicValidation(Validation _validation)
        {
            return new APIResponse()
            {
                Data = validationManger.sendBothValidations(_validation)
            };
        }
    }
}