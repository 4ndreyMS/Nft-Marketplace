using System.Web.Mvc;
using static WebUI.Models.Enum;

namespace AppWebWithSweetAlert.Controllers
{
    public class AlertController : BaseController
    {
        [HttpGet]
        public ActionResult ShowAlert()
        {
            Alert("El tutorial ha finalizado con éxito", NotificationType.success);
            return View();
        }
    }
}