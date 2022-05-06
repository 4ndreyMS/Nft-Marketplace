using System.Collections.Generic;
using System.Windows.Documents;
using DataAccess.Crud;
using DTO_POJOS;

namespace AppLogic.Managers
{
    public class AuctionManger : BaseManager
    {
        private AuctionCrudFactory auctionFactory;

        public AuctionManger()
        {
            auctionFactory = new AuctionCrudFactory();
        }

        public void createAuction(Auction _auction)
        {
            auctionFactory.Create(_auction);
        }
        public void UpdateAuction(Auction _auction)
        {
            auctionFactory.Update(_auction);
        }
        public void DeleteAuction(Auction _auction)
        {
            auctionFactory.Delete(_auction);
        }

        public List<Auction> RetriveAllAcutions()
        {
            return auctionFactory.RetrieveAll<Auction>();
        }
        public List<Auction> RetriveAllByOwner(BaseEntity entity)
        {
            return auctionFactory.RetrieveAllByOwner<Auction>(entity);
        }
    }
}