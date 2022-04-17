using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class PricesManager : BaseManager
    {
        private PricesCrudFactory pricesCrudFactory;

        public PricesManager()
        {
            pricesCrudFactory = new PricesCrudFactory();
        }

        public void CreatePrices(Prices prices)
        {
            pricesCrudFactory.Create(prices);


        }

        public void UpdatePrices(Prices prices)
        {
            pricesCrudFactory.Update(prices);
        }

        public void DeleteSuscriptor(Prices prices)
        {
            pricesCrudFactory.Delete(prices);
        }

        public List<Prices> RetrieveAll()
        {
            return pricesCrudFactory.RetrieveAll<Prices>();
        }
    }
}
