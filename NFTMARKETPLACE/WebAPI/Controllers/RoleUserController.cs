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
    public class RoleUserController : ApiController
    {
        // GET api/<controller>
        private UserRoleManager roleManager;

        public RoleUserController()
        {
            roleManager = new UserRoleManager();
        }


        //
        [HttpGet]
        public APIResponse RetriveEspecificUserRole (UserRole _userRole)
        {
            var response = new APIResponse()
            {
                Data = roleManager.RetriveListSpecificOfRole(_userRole)
            };
            return response;
        }

        //returns the role of id user
        [HttpPost]
        public APIResponse RetriveUserRoleByUserId(UserRole _userRole)
        {
            var RoleResponse = roleManager.RetriveRoleByUserId(_userRole).RoleId;

            var response = new APIResponse()
            {
                Data = RoleResponse
            };
            return response;
        }

        [HttpPost]
        public void UpdateRoleOfUser(UserRole _userRole)
        {
            roleManager.UpdateRoleOfUser(_userRole);
        }


        // DELETE api/<controller>/5
        [HttpDelete]
        public void DeleteUserRole(UserRole _userRole)
        {
            roleManager.DeleteUserRole(_userRole);
        }


    }
}