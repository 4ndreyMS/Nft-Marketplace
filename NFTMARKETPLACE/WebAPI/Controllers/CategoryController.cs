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
    public class CategoryController : ApiController
    {
        private CategoryManager categoryManager;

        public CategoryController()
        {
            categoryManager = new CategoryManager();
        }

        [HttpPost]
        public void CreateCategory(Category category)
        {

            categoryManager.CreateCategory(category);
        }

        [HttpPost]
        public void UpdateCategory(Category category)
        {

            categoryManager.UpdateCategory(category);
        }

        [HttpGet]
        public APIResponse RetrieveAllCategory()
        {
            var cm = new CategoryManager();
            return new APIResponse()
            {
                Data = cm.RetrieveAll(),
                Message = "All categories in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpDelete]
        public void DeleteCategory(Category category)
        {
            categoryManager.DeleteCategory(category);

        }
    }
}