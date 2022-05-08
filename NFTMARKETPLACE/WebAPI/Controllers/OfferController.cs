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
    public class OfferController : ApiController
    {
        private OfferManager OM;

        public OfferController()
        {
            OM = new OfferManager();
        }

        [HttpPost]
        public void CreateOffer(Offer offer)
        {
            OM.CreateOffer(offer);
        }

        [HttpPost]
        public void UpdateOffer(Offer offer)
        {
            OM.UpdateOffer(offer);
        }

        [HttpDelete]
        public APIResponse DeleteOffer(Offer offer)
        {
            OM.DeleteOffer(offer);

            return new APIResponse()
            {
                Data = "Offer deleted",
                Message = "Offer deleted",
                Status = "OK",
                TransacctionDate = DateTime.Now.ToString()
            };
        }


        [HttpPost]
        public APIResponse DeleteOfferbyBidderId(Offer offer)
        {
            OM.DeleteOffer(offer);

            return new APIResponse()
            {
                Data = "Offer deleted",
                Message = "Offer deleted",
                Status = "OK",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpPost]
        public void DeleteALLOffers(Offer offer)
        {
            OM.DeleteAllOffers(offer);
        }

        [HttpPost]
        public APIResponse RetrieveOffer(Offer offer)
        {
            return new APIResponse()
            {
                Data = OM.RetrieveOffer(offer),
                Message = "Offers made by a customer",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpGet]
        public APIResponse RetrieveAllOffersByOwner(string owner)
        {
            var offer = new Offer()
            {
                OwnerID = owner
            };

            return new APIResponse()
            {
                Data = OM.RetrieveAllOffersByOwner(offer),
                Message = "Offers to a content creator",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpGet]
        public APIResponse RetrieveAllOffers()
        {
            return new APIResponse()
            {
                Data = OM.RetrieveAll(),
                Message = "All offers in data base",
                Status = "Ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
    }
}