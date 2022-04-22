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
    public class CollectionController : ApiController
    {
        private CollectionManager CM;

        public CollectionController()
        {
            CM = new CollectionManager();
        }

        [HttpPost]
        public APIResponse CreateCollection(NFTCollection collection)
        {
            var retCollection = CM.CreateCollection(collection);

            return new APIResponse()
            {
                Data = retCollection
            };
        }


        [HttpDelete]
        public void DeleteCollection(NFTCollection nft)
        {
            CM.DeleteCollection(nft);
        }

        [HttpPost]
        public void UpdateCollection(NFTCollection nft)
        {
            CM.UpdateCollection(nft);
        }

        [HttpPost]
        public APIResponse RetrieveCollectionCategoryByName(NFTCollection category)
        {
            return new APIResponse()
            {
                Data = CM.RetriveCollectionFilterByName(category),
                Message = "All collections of a category in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpGet]
        public APIResponse RetrieveAllCollection()
        {
            return new APIResponse()
            {
                Data = CM.RetrieveAllNFTCollection(),
                Message = "All collections in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpGet]
        public APIResponse RetrieveAllCollectionCategory(string category)
        {
            return new APIResponse()
            {
                Data = CM.RetrieveAllCollectionCategory(category),
                Message = "All collections of a category in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpPost]
        public APIResponse RetrieveAllCollectionByCompany(NFTCollection collection)
        {
            return new APIResponse()
            {
                Data = CM.RetrieveAllCollectionByCompany(collection),
                Message = "All collections of a category in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }


        [HttpGet]
        public APIResponse RetrieveAllCollectionWithCategory()
        {
            return new APIResponse()
            {
                Data = CM.RetrieveAllCollectionWithCategory(),
                Message = "All collections with category in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
    }
}