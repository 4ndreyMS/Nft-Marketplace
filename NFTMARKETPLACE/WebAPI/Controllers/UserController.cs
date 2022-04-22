using AppLogic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO_POJO;
using DTO_POJOS;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {

        private UserManager uManager;

        public UserController()
        {
            uManager = new UserManager();
        }

        // GET api/<controller>
        [HttpPost]
        public void CreateUser(User _user)
        {
            uManager.CreateUser(_user);
        }


        [HttpPost]
        public void CreateUserAdmin(User _user)
        {
            uManager.CreateUserAdmin(_user);
        }

        //evualuar si el objeto es posible mandarlo dentro de otro en la UI
        [HttpPost]
        public APIResponse CreateUserContentCreator(User _user)
        {
            var retUser = uManager.CreateUserContentCreator(_user);
            return new APIResponse() { Data = retUser };
        }

        [HttpPost]
        public APIResponse CreateUserCustomer(User _user)
        {
            var retUser = uManager.CreateUserCustomer(_user);
            return new APIResponse { Data = retUser };
        }

        [HttpPost]
        public void UpdateUser(User _user)
        {
            uManager.UpdateUser(_user);
        }

        [HttpPost]
        public void UpdateUserOtp(User _user)
        {
            uManager.UpdateUserOtp(_user);
        }

        [HttpPost]
        public void UpdateUserStatus(User _user)
        {
            uManager.UpdateUserStatus(_user);
        }

        [HttpPost]
        public APIResponse RetrieveUser(User _user)
        {
            APIResponse response = new APIResponse()
            {
                Data = uManager.RetrieveUser(_user),
                Status = "Ok",
                Message = "User retrieve",
                TransacctionDate = DateTime.Now.ToString()
            };
            return response;
        }

        [HttpPost]
        public APIResponse RetriveUserByMail(User _user)
        {
            APIResponse response = new APIResponse()
            {
                Data = uManager.RetrieveUserBymail(_user),
                Status = "Ok",
                Message = "User retrieve",
                TransacctionDate = DateTime.Now.ToString()
            };
            return response;
        }


        [HttpPost]
        public APIResponse ExistUserByMail(User _user)
        {
            var retUser = uManager.RetrieveUserBymail(_user);

            APIResponse response = new APIResponse()
            {
                Status = "Ok",
                Message = "User retrieve",
                TransacctionDate = DateTime.Now.ToString()
            };

            if (retUser != null)
            {
                response.Data = true;
            }
            else
            {
                response.Data = false;

            }
            return response;
        }

        [HttpGet]
        public APIResponse RetriveAll()
        {
            APIResponse response = new APIResponse()
            {
                Data = uManager.RetrieveAllUser(),
                Status = "Ok",
                Message = "User created",
                TransacctionDate = DateTime.Now.ToString()
            };
            return response;
        }

            [HttpGet]
            public APIResponse RetriveAllWithRole()
            {
                APIResponse response = new APIResponse()
                {
                    Data = uManager.RetrieveAllUserWithRole(),
                    Status = "Ok",
                    Message = "User created",
                    TransacctionDate = DateTime.Now.ToString()
                };
                return response;
            }

        // DELETE api/<controller>/5
        [HttpPost]
        public void Delete(User _user)
        {

            uManager.DeleteUser(_user);
        }

        [HttpPost]
        public APIResponse UserLogin(User _user)
        {
            var x = _user;

            return new APIResponse()
            {
                Data = true
            };
        }


        [HttpGet]
        public APIResponse example()
        {
            APIResponse response = new APIResponse()
            {
                Data = "this controller works",
                Status = "Ok",
                Message = "example",
                TransacctionDate = DateTime.Now.ToString()
            };

            return response;
        }

    }
}
