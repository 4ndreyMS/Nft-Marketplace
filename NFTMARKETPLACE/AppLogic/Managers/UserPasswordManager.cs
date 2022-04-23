using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;

namespace AppLogic.Managers
{
    public class UserPasswordManager : BaseManager
    {
        private HistoryPasswordCrudFactory historyPasswordCrudFactory;

        public UserPasswordManager()
        {
            historyPasswordCrudFactory = new HistoryPasswordCrudFactory();
        }

        public void CreatePassword(User user)
        {
            UserPassword _userPassword = new UserPassword()
            {
                Cedula = user.Cedula,
                Password = EncryptMd5Manager.Encrypt(user.Password),
                DateCreation = DateTime.Now
            };


            historyPasswordCrudFactory.Create(_userPassword);
        }

        public List<UserPassword> RetrievePasswordById(UserPassword _password)
        {
            {
                return historyPasswordCrudFactory.RetrievePasswordById<UserPassword>(_password);
            }
        }

        




    }
}
