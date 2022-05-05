using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class OfferManager : BaseManager
    {
        private OfferCrudFactory OCF;

        public OfferManager()
        {
            OCF = new OfferCrudFactory();
        }

        public Offer CreateOffer(Offer offer)
        {         
            offer.CreationDate = DateTime.Now;           
            OCF.Create(offer);
            return offer;
        }

        public void UpdateOffer(Offer offer)
        {
            OCF.Update(offer);
        }

        public void DeleteOffer(Offer offer)
        {
            OCF.Delete(offer);
        }

        public void DeleteAllOffers(Offer offer)
        {
            OCF.DeleteALL(offer);
        }

        public Offer RetrieveOffer(Offer offer)
        {
            return OCF.Retrieve<Offer>(offer);
        }

        public List<Offer> RetrieveAll()
        {
            return OCF.RetrieveAll<Offer>();
        }

        public List<Offer> RetrieveAllOffersByOwner(Offer offer)
        {
            return OCF.RetrieveAllOffersByOwner<Offer>(offer);
        }
    }
}
