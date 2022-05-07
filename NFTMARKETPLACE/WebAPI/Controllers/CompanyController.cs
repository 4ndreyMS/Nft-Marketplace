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
    public class CompanyController : ApiController
    {
        private CompanyManager cManager;

        public CompanyController()
        {
            cManager = new CompanyManager();
        }

        [HttpPost]
        public void UpdateCompanyStatus(Company _company)
        {
            cManager.UpdateCompanyStatus(_company);
        }

        // GET api/<controller>
        [HttpPost]
        public void CreateCompany(Company _company)
        {
            cManager.CreateCompany(_company);
        }

        [HttpPost]
        public void UpdateCompany(Company _company)
        {
            cManager.UpdateAll(_company);
        }

        [HttpGet]
        public APIResponse retriveCompany(Company _company)
        {
            APIResponse response = new APIResponse()
            {
                Data = cManager.RetriveCompany(_company),
                Status = "Ok",
                Message = "User created",
                TransacctionDate = DateTime.Now.ToString()
            };
            return response;
        }

        [HttpPost]
        public APIResponse retriveCompanyInfo(Company _company)
        {
            APIResponse response = new APIResponse()
            {
                Data = cManager.RetriveCompany(_company),
                Status = "Ok",
                Message = "User created",
                TransacctionDate = DateTime.Now.ToString()
            };
            return response;
        }

        [HttpGet]
        public APIResponse RetriveAll()
        {
            APIResponse response = new APIResponse()
            {
                Data = cManager.RetriveAllCompany(),
                Status = "Ok",
                Message = "User created",
                TransacctionDate = DateTime.Now.ToString()
            };

            return response;
        }


        // DELETE api/<controller>/5
        [HttpPost]
        public void Delete(Company _company)
        {
            cManager.Delete(_company);
        }
    }
}