using System;
using System.Collections.Generic;
using DataAccess.Crud;
using DTO_POJOS;

namespace AppLogic.Managers
{
    public class ActionLogManager : BaseManager
    {
        private ActionLogFactory fatoryAC;
        private UserManager uManager;
        private UserRoleManager uRole;

        public ActionLogManager()
        {
            fatoryAC = new ActionLogFactory();
        }

        public void createActionLog(ActionLog _actionLog)
        {

            //todo: insertar metodo para validar que exista el usuario
            uManager = new UserManager();
            uRole = new UserRoleManager();

            var retUser = uManager.RetrieveUser(new User() { Cedula = _actionLog.IdUser });
            if (retUser != null)
            {
                try
                {
                    _actionLog.UserRole = uRole.RetriveRoleByUserId(new UserRole() { UserId = _actionLog.IdUser }).RoleId;
                    _actionLog.ActionDate = DateTime.Now;
                    fatoryAC.Create(_actionLog);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            //todo: insertar metodo para consultar el rol del usuario  ROLL_OF_USER_PR
            //si tiene más de un rol cre


        }

        public List<ActionLog> RetriveActionLogByRole(ActionLog _action)
        {
            return fatoryAC.RetrieveAllByRole<ActionLog>(_action);
        }

        public List<ActionLog> RetriveActionLogByUser(ActionLog _action)
        {
            return fatoryAC.RetrieveAllByUser<ActionLog>(_action);

        }

        public List<ActionLog> CallRetrivesActions(ActionLog _action)
        {
            if (string.IsNullOrEmpty(_action.IdUser))
            {
                return RetriveActionLogByRole(_action);
            }
            else if (_action.UserRole == 0)
            {
                return RetriveActionLogByUser(_action);
            }

            return null;
        }

    }
}