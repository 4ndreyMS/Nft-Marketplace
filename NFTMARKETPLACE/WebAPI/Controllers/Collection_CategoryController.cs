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
    public class Collection_CategoryController : ApiController
    {
        private Collection_CategoryManager CCM;

        public Collection_CategoryController()
        {
            CCM = new Collection_CategoryManager();
        }

        [HttpPost]
        public void CreateCollection_Category(Collection_Category nft)
        {
            CCM.CreateCollection_Category(nft);
        }

        [HttpDelete]
        public void DeleteCollection_Category(Collection_Category nft)
        {
            CCM.DeleteCollection_Category(nft);
        }

        [HttpPost]
        public void UpdateCollection_Categoty(Collection_Category nft)
        {
            CCM.UpdateCollection_Category(nft);
        }

        [HttpGet]
        public APIResponse RetrieveAllCollection_Category()
        {
            return new APIResponse()
            {
                Data = CCM.RetrieveAllCollection_Category(),
                Message = "All NFT_Category in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
    }
}