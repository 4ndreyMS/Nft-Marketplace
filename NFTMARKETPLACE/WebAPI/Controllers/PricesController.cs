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
    public class PricesController : ApiController
    {
        [HttpPost]
        public void UpadatePrices(Prices prices)
        {
            var pm = new PricesManager();
            pm.UpdatePrices(prices);
        }

        [HttpGet]
        public APIResponse ShowPrices()
        {
            var pm = new PricesManager();
            return new APIResponse()
            {
                Data = pm.RetrieveAll(),
                Message = "Prueba",
                Status = "ok",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
    }
}