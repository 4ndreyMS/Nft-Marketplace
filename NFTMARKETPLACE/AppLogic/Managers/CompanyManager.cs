using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{


   public class CompanyManager : BaseManager
    {

        private CompanyFactory CompanyFactory;
        private WalletManager wManager;

        //Performance constructor
        public CompanyManager()
        {
            CompanyFactory = new CompanyFactory();
        }


        //Creates
        public string CreateCompany(Company _Company)
        {
            wManager = new WalletManager();
            _Company.creationDate = DateTime.Now;
            _Company.status = "Invalid";
            //si usuario ingresa es porque no pertenecer
            string code = "";
            if (string.IsNullOrEmpty(_Company.id))
            {
                code = GenerateCode();
                _Company.id = code;
            }
            //si ingresa entonces se crea con la companía a la que pertenece

            if (RetriveCompanyFilterByName(_Company)==null)
            {
                CompanyFactory.Create(_Company);
                var retCreate = RetriveCompany(_Company);
                wManager.CreateWallet(new Wallet(){CompanyId = retCreate.id, WalletPin = _Company.walletPin});
            }
            else
            {
                return null;
            }

            return RetriveCompany(_Company).id;
        }

        public string GenerateCode()
        {
            var random = new Random();
            return random.Next(10000).ToString();
        }

        public void UpdateAll(Company _company)
        {
            CompanyFactory.Update(_company);
        }

        public void Delete(Company _company)
        {
            CompanyFactory.Delete(_company);
        }

        public Company RetriveCompany(Company _company)
        {
            return CompanyFactory.Retrieve<Company>(_company);
        }

        public Company RetriveCompanyFilterByName(Company _company)
        {

            return CompanyFactory.RetrieveFilterByName<Company>(_company);
        }

        public void UpdateCompanyStatus(Company _company)
        {
            CompanyFactory.Update(_company);
        }

        public List<Company> RetriveAllCompany()
        {
            return CompanyFactory.RetrieveAll<Company>();
        }

        public void UpdateName(Company _company)
        {
            CompanyFactory.UpdateName(_company);

        }
    }
}
