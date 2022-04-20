using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppLogic.Managers
{
    public class UserManager : BaseManager
    {

        private UserFactory UserFactory;
        private CompanyManager companyManager;
        private UserRoleManager userRoleManager;
        private OtpManager _otp;
        private ActionLogManager ActionManager;
        private UserPasswordManager userPassword;
        
        private SendMailManager sendMail;
        //private UserRole user;

        public UserManager()
        {
            UserFactory = new UserFactory();
        }

        //Creates
        public void CreateUser(User _user)
        {
            if (RetrieveUser(_user) == null)
            {
                UserPasswordManager passManager = new UserPasswordManager();
              
                try
                {
                   
                    UserFactory.Create(_user);
                    passManager.CreatePassword(_user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        //crea usarios creadores de contenido
        public User CreateUserContentCreator(User _user)
        {
            companyManager = new CompanyManager();
            userRoleManager = new UserRoleManager();
            _otp = new OtpManager();
            ActionManager = new ActionLogManager();
            userPassword = new UserPasswordManager();
            var retCompanyId = "";
            //se crea la compania y devuelve el id que crea

            if (RetrieveUser(_user) == null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(_user.Company.id))
                    {
                        retCompanyId = companyManager.RetriveCompany(_user.Company).id;
                    }
                    else
                    {
                        retCompanyId = companyManager.CreateCompany(_user.Company);
                    }
                    
                    if (retCompanyId != null)
                    {
                        //se crea el usuario con el otp y el id de la compania
                        _user.Otp = OtpManager.GenerateOtp();
                        _user.IdOrganization = retCompanyId;
                        _user.Status = "Active";

                        UserFactory.Create(_user);
                        var retUser = RetrieveUser(_user);
                        userPassword.CreatePassword(_user);
                        var x = SendMailManager.SendMail(retUser.Otp, retUser.Email);
                        SmsManager.SendSmsParamOtp(retUser.Phone, retUser.Otp);
                        //se crea asigna el rol con una vez creado el usuario
                        userRoleManager.CreateUserRole(new UserRole()
                        {
                            RoleId = 3,
                            UserId = retUser.Cedula
                        });
                        ActionManager.createActionLog(new ActionLog(){ActionName = "USER_REGISTER", IdUser = retUser.Cedula});

                        return retUser;
                    }



                }
                catch (Exception e)
                {
                    new Exception(e.ToString());
                    throw;
                }
            }

            return new User() { IdOrganization = "0", Status = "false" };
        }

        public object RetrieveAllUserWithRole()
        {
            {
                UserFactory = new UserFactory();
                return UserFactory.RetrieveAllWithRole<UserR>();
            }
        }

        //crea usarios clientes
        public User CreateUserCustomer(User _user)
        {
            ActionManager = new ActionLogManager();
            companyManager = new CompanyManager();
            userRoleManager = new UserRoleManager();
            _otp = new OtpManager();
            userPassword = new UserPasswordManager();

            if (RetrieveUser(_user) == null)
            {

                try
                {   //se crea con los valores del usuario
                    _user.Company = new Company()
                    {
                        email = _user.Email,
                        name = _user.Name,
                        status = "Inactive"
                    };
                    //se crea la compania y devuelve el id que crea
                    var retCompanyId = companyManager.CreateCompany(_user.Company);

                    if (retCompanyId != null)
                    {
                        //se crea el usuario con el otp y el id de la compania
                        _user.Otp = OtpManager.GenerateOtp();
                        _user.IdOrganization = retCompanyId;
                        _user.Status = "Active";

                        UserFactory.Create(_user);
                        var retUser = RetrieveUser(_user);
                        userPassword.CreatePassword(_user);
                        var sendMail = SendMailManager.SendMail(retUser.Otp, retUser.Email);
                        SmsManager.SendSmsParamOtp(retUser.Phone, retUser.Otp);
                        //se crea asigna el rol con una vez creado el usuario
                        userRoleManager.CreateUserRole(new UserRole()
                        {
                            RoleId = 2,
                            UserId = retUser.Cedula
                        });

                        ActionManager.createActionLog(new ActionLog() { ActionName = "USER_REGISTER", IdUser = retUser.Cedula });

                        return retUser;
                    }

                }
                catch (Exception e)
                {
                    new Exception(e.ToString());
                    throw;
                }
            }

            return new User(){IdOrganization = "0", Status = "false"};
        }


        public User CreateUserAdmin(User _user)
        {
            companyManager = new CompanyManager();
            userRoleManager = new UserRoleManager();
            _otp = new OtpManager();
            ActionManager = new ActionLogManager();
            userPassword = new UserPasswordManager();
            var retCompanyId = "";
            //se crea la compania y devuelve el id que crea

            if (RetrieveUser(_user) == null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(_user.Company.id))
                    {
                        retCompanyId = companyManager.RetriveCompany(_user.Company).id;
                    }
                    else
                    {
                        retCompanyId = companyManager.CreateCompany(_user.Company);
                    }

                    if (retCompanyId != null)
                    {
                        //se crea el usuario con el otp y el id de la compania
                        _user.Otp = OtpManager.GenerateOtp();
                        _user.IdOrganization = retCompanyId;
                        _user.Status = "Active";

                        UserFactory.Create(_user);
                        var retUser = RetrieveUser(_user);
                        userPassword.CreatePassword(_user);
                        //se crea asigna el rol con una vez creado el usuario
                        userRoleManager.CreateUserRole(new UserRole()
                        {
                            RoleId = 1,
                            UserId = retUser.Cedula
                        });
                        ActionManager.createActionLog(new ActionLog() { ActionName = "USER_REGISTER", IdUser = retUser.Cedula });

                        return retUser;
                    }



                }
                catch (Exception e)
                {
                    new Exception(e.ToString());
                    throw;
                }
            }

            return new User() { IdOrganization = "0", Status = "false" };
        }




        //Deletes
        public void DeleteUser(User _user)
        {
            userRoleManager = new UserRoleManager();

            if (RetrieveUser(_user) != null)
            {
                try
                {
                    userRoleManager.DeleteAllUserRole(new UserRole() { UserId = _user.Cedula });
                    UserFactory.Delete(_user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

        }

        //Updates
        public void UpdateUser(User _user)
        {
            if (RetrieveUser(_user) != null)
            {
                try
                {
                    UserFactory.Update(_user);
                    var retUser = UserFactory.Retrieve<User>(_user);
                    ActionManager.createActionLog(new ActionLog() { ActionName = "USER_INFO_UPDATE", IdUser = retUser.Cedula });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        //Retrieves
        public User RetrieveUser(User _user)
        {
            UserFactory = new UserFactory();
            User result = new User();
            try
            {
                result = UserFactory.Retrieve<User>(_user);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        public User RetrieveUserBymail(User _user)
        {
            UserFactory = new UserFactory();

            UserFactory = new UserFactory();
            User result = new User();
            try
            {
                result = UserFactory.RetrieveByMail<User>(_user);

                if (result!=null)
                {
                    return result;
                }
                
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        public List<User> RetrieveAllUser()
        {
            {
                UserFactory = new UserFactory();
                return UserFactory.RetrieveAll<User>();
            }
        }

        public void UpdateUserOtp(User _user)
        {
            if (RetrieveUser(_user) != null)
            {
                try
                {
                    UserFactory.UpdateOtpUser(_user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

        }

        public void UpdateUserStatus(User _user)
        {
            ActionManager = new ActionLogManager();
            if (RetrieveUser(_user) != null)
            {
                try
                {
                    UserFactory.UpdateStatusUser(_user);
                    var retUser = UserFactory.Retrieve<User>(_user);
                    ActionManager.createActionLog(new ActionLog() { ActionName = "USER_STATUS_UPDATE", IdUser = retUser.Cedula });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }


    }
}
