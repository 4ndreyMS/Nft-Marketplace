using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class NFTController : ApiController
    {
        private NFTManager nftM;

        public NFTController()
        {
            nftM = new NFTManager();
        }

        [HttpPost]
        public APIResponse CreateNFT(NFT nft)
        {
            var retNft = nftM.CreateNFT(nft);

            return new APIResponse()
            {
                Data = retNft
            };
        }

        [HttpDelete]
        public void DeleteNFT(NFT nft)
        {
            nftM.DeleteNFT(nft);
        }

        [HttpPost]
        public void UpdateNFT(NFT nft)
        {
            nftM.UpdateNFT(nft);
        }

        [HttpGet]
        public APIResponse RetrieveAllNFT()
        {
            var nm = new NFTManager();
            return new APIResponse()
            {
                Data = nm.RetrieveAllNFT(),
                Message = "All NFT in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpGet]
        public APIResponse RetrieveAllNFTWithCategory()
        {
            var nm = new NFTManager();
            return new APIResponse()
            {
                Data = nm.RetrieveAllNFTWithCategory(),
                Message = "All NFT in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpPost]
        public APIResponse RetrieveAllNFTWithCategories()
        {
            var nm = new NFTManager();
            return new APIResponse()
            {
                Data = nm.RetrieveAllNFTWithCategory(),
                Message = "All NFT in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
        



        [HttpPost]
        public APIResponse RetrieveAllNFTWithOwner()
        {
            var nm = new NFTManager();
            return new APIResponse()
            {
                Data = nm.RetrieveNFTWithOwner(),
                Message = "All NFT in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }


        [HttpGet]
        public APIResponse RetrieveAllNFTCategory(string nft)
        {
            var nm = new NFTManager();
            return new APIResponse()
            {
                Data = nm.RetrieveNFTCategory(nft),
                Message = "All NFT in a category in the data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
    }
}