using System;
using System.Web.Http;
using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;

namespace WebAPI.Controllers
{
    public class AuctionController : ApiController
    {
        private AuctionManger manger;

        public AuctionController()
        {
            manger = new AuctionManger();
        }

        [HttpPost]
        public APIResponse CreateAuction(Auction _auction)
        {
            _auction.CreationDate = DateTime.Now;
            manger.createAuction(_auction);
            return new APIResponse()
            {
                Data = "Auction Created",
                Message = "Auction Created",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
        [HttpPost]
        public APIResponse UpdateAuction(Auction _auction)
        {
            manger.UpdateAuction(_auction);
            return new APIResponse()
            {
                Data = "Auction updated",
                Message = "Auction updated",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
        [HttpDelete]
        public APIResponse DeleteAuction(Auction _auction)
        {
            manger.DeleteAuction(_auction);
            return new APIResponse()
            {
                Data = "Auction delted",
                Message = "Auction delted",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpPost]
        public APIResponse RetrieveAllAuction()
        {
            
            return new APIResponse()
            {
                Data = manger.RetriveAllAcutions(),
                Message = "Auction delted",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpPost]
        public APIResponse RetrieveAllByOwner(Auction _auction)
        {

            return new APIResponse()
            {
                Data = manger.RetriveAllByOwner(_auction),
                Message = "Auction delted",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpPost]
        public APIResponse RetrieveAllByNft(Auction _auction)
        {

            return new APIResponse()
            {
                Data = manger.RetriveAllByNft(_auction),
                Message ="retrieve",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }


    }
}