using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO_POJOS;

namespace DataAccess.Mapper
{
    public class ActionLogMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private enum RowNames
        {
            Id, ActionName, ActionDate,UserRole, IdUser
        }

        private SqlOperation slqOperation;
        
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var obj = BuildObject(row);
                lstResults.Add(obj);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var obj = new ActionLog()
            {
                Id = GetIntValue(row,RowNames.Id.ToString()),
                ActionDate = GetDateValue(row, RowNames.ActionDate.ToString()),
                ActionName = GetStringValue(row,RowNames.ActionName.ToString()),
                IdUser = GetStringValue(row, RowNames.IdUser.ToString()),
                UserRole = GetIntValue(row, RowNames.UserRole.ToString())
            };
            return obj;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            slqOperation = new SqlOperation()
            {
                ProcedureName = "CRE_ACTION_LOG_PR"
            };
            var obj = (ActionLog)entity;
            slqOperation.AddVarcharParam(RowNames.ActionName.ToString(),obj.ActionName);
            slqOperation.AddDateTimeParam(RowNames.ActionDate.ToString(), obj.ActionDate);
            slqOperation.AddIntParam(RowNames.UserRole.ToString(), obj.UserRole);
            slqOperation.AddVarcharParam(RowNames.IdUser.ToString(), obj.IdUser);
            return slqOperation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACTIONS_BY_USER_PR" };

            var obj = (ActionLog)entity;
            operation.AddVarcharParam(RowNames.IdUser.ToString(), obj.IdUser);
            return operation;
        }
        public SqlOperation GetActionByUserRoleStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACTIONS_BY_USER_ROLE_PR" };

            var obj = (ActionLog)entity;
            operation.AddSmallIntParam(RowNames.UserRole.ToString(), obj.UserRole);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            return new SqlOperation() {ProcedureName = "RET_ALL_ACTION_LOG_PR"};
        }

        //not used
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        //not used
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
