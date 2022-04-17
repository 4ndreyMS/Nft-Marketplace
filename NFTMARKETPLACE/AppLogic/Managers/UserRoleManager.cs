using System.Collections.Generic;
using DataAccess.Crud;
using DTO_POJOS;

namespace AppLogic.Managers
{
    public class UserRoleManager : BaseManager
    {
        private UserRoleFactory userRoleFactory;

        public UserRoleManager()
        {
            userRoleFactory = new UserRoleFactory();
        }

        public void CreateUserRole(UserRole _userRole)
        {
            userRoleFactory.Create(_userRole);
        }

        public void DeleteUserRole(UserRole _userRole)
        {
            userRoleFactory.Delete(_userRole);
        }

        public void DeleteAllUserRole(UserRole _userRole)
        {
            userRoleFactory.DeleteAllUserRoles(_userRole);
        }

        public void UpdateRoleOfUser(UserRole _userRole)
        {
            userRoleFactory.Update(_userRole);
        }

        public List<UserRole> RetriveListSpecificOfRole(UserRole _userRole)
        {
            return userRoleFactory.RetrieveAllSpecificType<UserRole>(_userRole);
        }

        public UserRole RetriveRoleByUserId(UserRole _userRole)
        {
            return userRoleFactory.Retrieve<UserRole>(_userRole);
        }
    }
}