using System;
using System.Security.Cryptography;
using DataAccess.Crud;
using DTO_POJOS;

namespace AppLogic.Managers
{
    public class WalletManager : BaseManager
    {
        private WalletFactory wFactory;
        private const string COINNAME = "CenfoCoin";
        private ActionLogManager ActionManager;
        private UserManager userManager;
        public WalletManager()
        {
            wFactory = new WalletFactory();
        }
        public string GenHexaId()
        {
            var byteArray = new byte[(int)Math.Ceiling(10 / 2.0)];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byteArray);
            }
            return String.Concat(Array.ConvertAll(byteArray, x => x.ToString("X2")));
        }
        public void CreateWallet(Wallet _wallet)
        {
            var obj = _wallet;
            obj.CoinName = COINNAME;
            obj.Identifier = GenHexaId();
            obj.Amount = 0.0;
            wFactory.Create(obj);

        }
        public void UpdateWalletCompany(Wallet _wallet)
        {
            if (!string.IsNullOrEmpty(_wallet.CompanyId))
            {
                wFactory.Update(_wallet);
            }
        }
        public void AddToAmount(Wallet _wallet)
        {
            wFactory.UpdateAddAmount(_wallet);

        }
        public void RestToAmount(Wallet _wallet)
        {
            wFactory.UpdateRestAmount(_wallet);
        }

        public void DeleteWallet(Wallet _wallet)
        {
            wFactory.Delete(_wallet);
        }

        public Wallet RetriveWalletCompany(Wallet _wallet)
        {
            
            return wFactory.Retrieve<Wallet>(_wallet);
        }

        public Wallet RetriveWalletByUser(Wallet _wallet)
        {
            userManager = new UserManager();
            var retUSer = userManager.RetrieveUser(new User(){Cedula = _wallet.UserId});
            return wFactory.Retrieve<Wallet>(new Wallet(){CompanyId = retUSer.IdOrganization});
        }

    }
}