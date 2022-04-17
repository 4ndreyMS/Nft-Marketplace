using DTO_POJO;
using DTO_POJOS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {

        static HttpClient client = new HttpClient();

        public ActionResult Index()
        {
        
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View("HomePage");
        }
        public ActionResult vPaypal()
        {

            HttpResponseMessage response = client.GetAsync("http://localhost:57056/api/UsuarioXOrganizacion/GetOrganizacionByCedula/" + Session["IdUsuarioCedula"]).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var apiResponse = JsonConvert.DeserializeObject<APIResponse>(content);
            var company = JsonConvert.DeserializeObject<List<User_Company>>(apiResponse.Data.ToString());
            var IdCompany = 0;

            if (company.Count == 0)
            {
                IdCompany = 0;
            }
            else
            {
                IdCompany = company[0].IdCompany;
            }

            ViewBag.IdCompany = IdCompany;
            return View();

        }
    }
}
