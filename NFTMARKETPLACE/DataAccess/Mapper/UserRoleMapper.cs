using System.Collections.Generic;
using DataAccess.Dao;
using DTO_POJOS;

namespace DataAccess.Mapper
{
    public class UserRoleMapper: EntityMapper, IObjectMapper, ISqlStaments
    {
        enum RowNames
        {
            RoleId,
            UserId
        }
        private UserMapper Usermapper;

        private SqlOperation sqlOperation;

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
        }

        //se debe de crear un objeto dentro de otro
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            UserMapper.RowNames.Status.ToString();
            var userRole = new UserRole()
            {
                RoleId = GetIntValue(row, RowNames.RoleId.ToString()),
                UserId = GetStringValue(row, RowNames.UserId.ToString()),
                User = new User()
                {
                    Cedula = GetStringValue(row, UserMapper.RowNames.Cedula.ToString()),
                    Name = GetStringValue(row, UserMapper.RowNames.Name.ToString()),
                    Status = GetStringValue(row, UserMapper.RowNames.Status.ToString()),
                    SureName = GetStringValue(row, UserMapper.RowNames.SureNames.ToString()),
                    Email = GetStringValue(row, UserMapper.RowNames.Email.ToString()),
                    Phone = GetStringValue(row, UserMapper.RowNames.Phone.ToString()),
                    Otp = GetIntValue(row, UserMapper.RowNames.Otp.ToString()),
                    IdOrganization = GetStringValue(row, UserMapper.RowNames.IdOrganization.ToString()),
                    Nickname = GetStringValue(row, UserMapper.RowNames.Nickname.ToString())
                }
            };

            return userRole;
        }

        public BaseEntity BuildObjectUserRole(Dictionary<string, object> row)
        {
            UserMapper.RowNames.Status.ToString();
            var userRole = new UserRole()
            {
                RoleId = GetIntValue(row, RowNames.RoleId.ToString()),
                UserId = GetStringValue(row, RowNames.UserId.ToString())
            };

            return userRole;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "CRE_USER_ROLE_PR"
            };

            var obj = (UserRole) entity;
            sqlOperation.AddVarcharParam(RowNames.UserId.ToString(),obj.UserId);
            sqlOperation.AddIntParam(RowNames.RoleId.ToString(), obj.RoleId);
            return sqlOperation;
        }
        
        //retrive all statement of an specific user type
        public SqlOperation GetRetriveAllSpecificType(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "DEL_USER_ROL_PR"
            };

            var obj = (UserRole)entity;
            sqlOperation.AddIntParam(RowNames.RoleId.ToString(), obj.RoleId);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "UPD_ROL_OF_USER_PR"
            };

            var obj = (UserRole)entity;
            sqlOperation.AddVarcharParam(RowNames.UserId.ToString(), obj.UserId);
            sqlOperation.AddIntParam(RowNames.RoleId.ToString(), obj.RoleId);
            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "DEL_USER_ROL_PR"
            };

            var obj = (UserRole)entity;
            sqlOperation.AddVarcharParam(RowNames.UserId.ToString(), obj.UserId);
            sqlOperation.AddIntParam(RowNames.RoleId.ToString(), obj.RoleId);
            return sqlOperation;
        }

        public SqlOperation GetDeleteAllRolesStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "DEL_ALL_USER_ROL_PR"
            };

            var obj = (UserRole)entity;
            sqlOperation.AddVarcharParam(RowNames.UserId.ToString(), obj.UserId);
            return sqlOperation;
        }

        public SqlOperation GetRetriveByUserIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation() {ProcedureName = "RET_USER_ROLE_ID_PR"};

            var obj = (UserRole)entity;
            operation.AddVarcharParam(RowNames.UserId.ToString(), obj.UserId);

            return operation;
        }
        
        //not used
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        //not used
        public SqlOperation GetRetriveAllStatement()
        {
            throw new System.NotImplementedException();
        }
    }
}