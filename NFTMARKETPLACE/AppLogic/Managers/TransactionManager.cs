using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class TransactionManager : BaseManager
    {

        private TransactionCrudFactory crudTransaction;
        public TransactionManager()
        {
            crudTransaction = new TransactionCrudFactory();
        }

        public void CreatePaypalTransaction(Transaction transaction)
        {
            var tipoDeCambio = "";
            tipoDeCambio = ConfigurationManager.AppSettings.Get("TIPO_CAMBIO_USD_CRC");
            decimal tipoDeCambioDecimal = decimal.Parse(tipoDeCambio);

            var c = crudTransaction.Retrieve<Transaction>(transaction);
            if (c != null)
            {
                throw new Exception("No se ha podido realizar la transacción");
            }
            else
            {
                var today = DateTime.Today;
                transaction.Amount = transaction.Amount * tipoDeCambioDecimal;
                transaction.TransactionDate = today.Date;
                //transaction.TransType = "Paypal";
                crudTransaction.Create(transaction);
            }
        }
        public List<Transaction> RetrieveAll()
        {
            return crudTransaction.RetrieveAll<Transaction>();
        }

        public Transaction RetrieveById(Transaction transaction)
        {
            return crudTransaction.Retrieve<Transaction>(transaction);

        }

        public List<Transaction> ListTransactionByWalletId(string walletId)
        {
            return crudTransaction.RetrieveAllByWallet<Transaction>(walletId);

        }

        public void Update(Transaction transaction)
        {
            crudTransaction.Update(transaction);
        }

        public void Delete(Transaction transaction)
        {
            crudTransaction.Delete(transaction);
        }


    }
}


