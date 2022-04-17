using System;
using System.Web.Http;
using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;

namespace WebAPI.Controllers
{
    public class ActionLogController : ApiController
    {
        private ActionLogManager actionLogManager;


        public ActionLogController()
        {
            actionLogManager = new ActionLogManager();
        }

        [HttpPost]
        public void CreateActionLog(ActionLog _action)
        {
            actionLogManager.createActionLog(_action);
        }

        [HttpGet]
        public APIResponse RetriveAllByUserId(ActionLog _action)
        {
            var actionResponse  = actionLogManager.RetriveActionLogByUser(_action);

            return new APIResponse()
            {
                Data = actionResponse,
                Status = "Ok"
            };
        }


        [HttpGet]
        public APIResponse RetriveAllByRole(ActionLog _action)
        {
            var actionResponse = actionLogManager.RetriveActionLogByRole(_action);

            return new APIResponse()
            {
                Data = actionResponse,
                Status = "Ok"
            };
        }

        //este metodo llama al manager y el se encarga de llamar a alguno de los otros dos retrives
        //dependiendo del valor que se le pase por medio del obj action
        //si id user es null o "" ejecuta metodo RetriveAllByRole
        //si RetriveAllByRole es 0 ejecuta RetriveAllByUserId
        [HttpGet]
        public APIResponse RetriveAllByParamFilter(ActionLog _action)
        {
            var actionResponse = actionLogManager.CallRetrivesActions(_action);

            return new APIResponse()
            {
                Data = actionResponse,
                Status = "Ok"
            };
        }


    }
}