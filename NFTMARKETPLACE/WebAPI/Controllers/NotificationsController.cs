using System;
using System.Web.Http;
using AppLogic.Managers;
using DTO_POJO;
using DTO_POJOS;

namespace WebAPI.Controllers
{
    public class NotificationsController : ApiController
    {

        private NotificationsManager notifManager;

        public NotificationsController()
        {
            notifManager = new NotificationsManager();
        }

        [HttpPost]
        public APIResponse CreateNotif(Notifications _notifications)
        {
            notifManager.createNotif(_notifications);
            return new APIResponse()
            {
                Data = "Notification Created",
                Status = "Ok",
                Message = "Created",
                TransacctionDate = DateTime.Now.ToString()
            };
        }

        [HttpPost]
        public APIResponse DeleteNotif(Notifications _notifications)
        {
            notifManager.deleteNotif(_notifications);
            return new APIResponse()
            {
                Data = "Notification Deleted",
                Status = "Ok",
                Message = "Deleted",
                TransacctionDate = DateTime.Now.ToString()
            };
        }
        [HttpPost]
        public APIResponse RetrieveNotifUserByCompany (Notifications _notifications)
        {
            return new APIResponse()
            {
                Data = notifManager.retrieveNotifOfUserByCompany(_notifications),
                Status = "Ok",
                Message = "Created",
                TransacctionDate = DateTime.Now.ToString()
            };
        }


    }
}