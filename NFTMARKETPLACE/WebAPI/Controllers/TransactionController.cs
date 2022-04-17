using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TransactionController : ApiController
    {

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

