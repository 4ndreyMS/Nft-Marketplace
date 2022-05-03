using System;
using System.Collections.Generic;
using DataAccess.Crud;
using DTO_POJOS;
namespace AppLogic.Managers
{
    public class NotificationsManager :BaseManager
    {
        private NotificationsCrudFactory notiFactory;

        public NotificationsManager()
        {
            notiFactory = new NotificationsCrudFactory();
        }

        public void createNotif(Notifications _notifications)
        {
            _notifications.SentDate = DateTime.Now;
            notiFactory.Create(_notifications);
        }

        public void deleteNotif(Notifications _notifications)
        {
            notiFactory.Delete(_notifications);
        }

        public List<Notifications> retrieveNotifOfUserByCompany(Notifications _notifications)
        {
            return notiFactory.retrieveNotifUserByCompany<Notifications>(_notifications);
        }


    }
}