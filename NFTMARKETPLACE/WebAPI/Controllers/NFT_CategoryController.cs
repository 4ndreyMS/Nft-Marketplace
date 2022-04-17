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
    public class NFT_CategoryController : ApiController
    {
        private NFT_CategoryManager NFTCManager;

        public NFT_CategoryController()
        {
            NFTCManager = new NFT_CategoryManager();
        }

        [HttpPost]
        public void CreateNFTCategory(NFT_Category nft)
        {
            NFTCManager.CreateNFT_Category(nft);
        }

        [HttpDelete]
        public void DeleteNFT_Category(NFT_Category nft)
        {
            NFTCManager.DeleteNFT_Category(nft);
        }

        [HttpPost]
        public void UpdateNFT_Categoty(NFT_Category nft)
        {
            NFTCManager.UpdateNFT_Category(nft);
        }

        [HttpPost]
        public void UpdateNFT_CategotyNFTId(NFT_Category caregory)
        {
            NFTCManager.UpdateNFT_CategoryNFTId(caregory);
        }


        [HttpGet]
        public APIResponse RetrieveAllNFT_Category()
        {
            return new APIResponse()
            {
                Data = NFTCManager.RetrieveAllNFT_Category(),
                Message = "All NFT_Category in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
    }
}