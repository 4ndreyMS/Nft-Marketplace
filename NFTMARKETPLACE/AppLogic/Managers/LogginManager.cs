using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class LogginManager
    {
        private LogginCrudFactory LogginCrudFactory;
        private EncryptMd5Manager encryptMd5Manager;

        public LogginManager()
        {
            LogginCrudFactory = new LogginCrudFactory();
            encryptMd5Manager = new EncryptMd5Manager();
        }

        public UserPassword Retrieve<T>(UserPassword _userPassword)
        {
           
            return LogginCrudFactory.Retrieve<UserPassword>(_userPassword);
        }
    }
}
