using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;

namespace WebAPI.Controllers
{
    public class WalletController : ApiController
    {
        private WalletManager walletManager;

        public WalletController()
        {
            walletManager = new WalletManager();
        }

        [HttpGet]
        public APIResponse WalletInfo(Wallet _wallet)
        {

            var response = new APIResponse()
            {
                Data = walletManager.RetriveWalletCompany(_wallet)
            };

            return response;
        }

        [HttpPost]
        public APIResponse RetriveWalletByUserId(Wallet _wallet)
        {

            var response = new APIResponse()
            {
                Data = walletManager.RetriveWalletByUser(_wallet)
            };

            return response;
        }

        [HttpPost]
        public void CreateWallet(Wallet _wallet)
        {
            walletManager.CreateWallet(_wallet);
        }

        // PUT api/<controller>/5
        [HttpPost]
        public void UpdateInfo(Wallet _wallet )
        {
            walletManager.UpdateWalletCompany(_wallet);

        }

        [HttpPost]
        public void addAmount (Wallet _wallet)
        {
            walletManager.AddToAmount(_wallet);

        }

        [HttpPost]
        public void restAmount(Wallet _wallet)
        {
            walletManager.RestToAmount(_wallet);

        }

        [HttpDelete]
        public void Delete(Wallet _wallet)
        {
            walletManager.UpdateWalletCompany(_wallet);

        }
    }
}