using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
    public class TransactionController : ApiController
    {
        /*#region ClientID_and_secret
        private string _paypalEnviroment = "sandbox";
        private string _clientId = "AeUbl7uUJYGEcvyl91QSGtouB82srryMF3j7Osz4hFuNGenkwrl63uQ8eUvw_guOROEuBvtc_j7zG2Ti";
        private string _secret = "EASGgnPmxpO87p4aSDgw1l5i1SsrlOOMRsdpkvfPS5XvzItUFm7mzPwil8JC9zxJi5Sr1aHjlE1wd38E";
        #endregion*/



        APIResponse apiResp = new APIResponse();
        public IHttpActionResult GetAll()
        {
            apiResp = new APIResponse();
            var mng = new TransactionManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }

        public IHttpActionResult PostPaypalTransaction(Transaction transaction)
        {
            var mng = new TransactionManager();
            mng.CreatePaypalTransaction(transaction);
            apiResp = new APIResponse();
            apiResp.Message = "Transacción paypal exitosa.";
            return Ok(apiResp);

        }
    }
}

