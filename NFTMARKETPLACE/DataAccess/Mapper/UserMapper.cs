using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UserMapper : EntityMapper, IObjectMapper, ISqlStaments

    {
        public enum RowNames
        {
            Cedula,
            Name,
            SureNames,
            Email,
            Phone,
            Nickname,
            Status,
            Otp,
            IdOrganization,
            Password,
            Type,
            UserPic
        }

        private SqlOperation sqlOperation;



        //Build Objects
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            try
            {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var user = new User()
            {
                Cedula = GetStringValue(row, RowNames.Cedula.ToString()),
                Name = GetStringValue(row, RowNames.Name.ToString()),
                Status = GetStringValue(row, RowNames.Status.ToString()),
                SureName = GetStringValue(row, RowNames.SureNames.ToString()),
                Email = GetStringValue(row, RowNames.Email.ToString()),
                Phone = GetStringValue(row, RowNames.Phone.ToString()),
                Otp = GetIntValue(row, RowNames.Otp.ToString()),
                IdOrganization = GetStringValue(row, RowNames.IdOrganization.ToString()),
                Nickname = GetStringValue(row, RowNames.Nickname.ToString()),
                UserPic = GetStringValue(row, RowNames.UserPic.ToString())
            };
            return user;
        }

        public List<BaseEntity> BuildObjectsWithRole(List<Dictionary<string, object>> lstRows)
        {
            try
            {
                var lstResults = new List<BaseEntity>();

                foreach (var row in lstRows)
                {
                    var user = BuildObjectWithRole(row);
                    lstResults.Add(user);
                }

                return lstResults;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public BaseEntity BuildObjectWithRole(Dictionary<string, object> row)
        {
            var user = new UserR()
            {
                Cedula = GetStringValue(row, RowNames.Cedula.ToString()),
                Name = GetStringValue(row, RowNames.Name.ToString()),
                Status = GetStringValue(row, RowNames.Status.ToString()),
                SureName = GetStringValue(row, RowNames.SureNames.ToString()),
                Email = GetStringValue(row, RowNames.Email.ToString()),
                Phone = GetStringValue(row, RowNames.Phone.ToString()),
                Otp = GetIntValue(row, RowNames.Otp.ToString()),
                IdOrganization = GetStringValue(row, RowNames.IdOrganization.ToString()),
                Nickname = GetStringValue(row, RowNames.Nickname.ToString()),
                Type = GetStringValue(row, RowNames.Type.ToString())
            };
            return user;
        }

        //Creates
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "CRE_USER_PR"
            };

            var user = (User)entity;

            sqlOperation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            sqlOperation.AddVarcharParam(RowNames.Name.ToString(), user.Name);
            sqlOperation.AddVarcharParam(RowNames.Email.ToString(), user.Email);
            sqlOperation.AddVarcharParam(RowNames.Status.ToString(), user.Status);
            sqlOperation.AddVarcharParam(RowNames.Nickname.ToString(), user.Nickname);
            sqlOperation.AddVarcharParam(RowNames.Phone.ToString(), user.Phone);
            sqlOperation.AddVarcharParam(RowNames.SureNames.ToString(), user.SureName);
            sqlOperation.AddIntParam(RowNames.Otp.ToString(), user.Otp);
            sqlOperation.AddVarcharParam(RowNames.IdOrganization.ToString(), user.IdOrganization);
            sqlOperation.AddVarcharParam(RowNames.UserPic.ToString(), user.UserPic);
            return sqlOperation;

        }

        internal SqlOperation GetRetriveAllStatementWithRole()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USER_WITH_ROLE" };
            return operation;
        }

        //Retrieves
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USER" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_BY_ID_PR" };
            var user = (User)entity;
            operation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            return operation;
        }

        public SqlOperation GetRetriveStatementByMail(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_BY_MAIL_PR" };
            var user = (User)entity;
            operation.AddVarcharParam(RowNames.Email.ToString(), user.Email);
            return operation;
        }

        //Updates
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "UPD_USER_PR"
            };
            var user = (User)entity;
            sqlOperation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            sqlOperation.AddVarcharParam(RowNames.Name.ToString(), user.Name);
            sqlOperation.AddVarcharParam(RowNames.Email.ToString(), user.Email);
            sqlOperation.AddVarcharParam(RowNames.Nickname.ToString(), user.Nickname);
            sqlOperation.AddVarcharParam(RowNames.Phone.ToString(), user.Phone);
            sqlOperation.AddVarcharParam(RowNames.SureNames.ToString(), user.SureName);
            return sqlOperation;
        }

        public SqlOperation GetUpdateOtpStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_OTP_USER_PR"
            };

            var user = (User)entity;
            sqlOperation.AddIntParam(RowNames.Otp.ToString(), user.Otp);
            sqlOperation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            return sqlOperation;
        }

        public SqlOperation GetUpdateNameStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_NAME_USER_PR"
            };

            var user = (User)entity;
            sqlOperation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            sqlOperation.AddVarcharParam(RowNames.Name.ToString(), user.Name);
            return sqlOperation;
        }

        public SqlOperation GetUpdateEmailStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_EMAIL_USER_PR"
            };

            var user = (User)entity;
            sqlOperation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            sqlOperation.AddVarcharParam(RowNames.Email.ToString(), user.Email);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_STATUS_USER_PR"
            };

            var user = (User)entity;
            sqlOperation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            sqlOperation.AddVarcharParam(RowNames.Status.ToString(), user.Status);
            return sqlOperation;
        }
        //Deletes
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "DEL_USER_PR"
            };

            var user = (User)entity; 
            sqlOperation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            return sqlOperation;      
        }

        public SqlOperation GetUpdateUserInfo(User user)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_INFO_USER_PR"
            };

            sqlOperation.AddVarcharParam(RowNames.Name.ToString(), user.Name);
            sqlOperation.AddVarcharParam(RowNames.Nickname.ToString(), user.Nickname);
            sqlOperation.AddVarcharParam(RowNames.Phone.ToString(), user.Phone);
            sqlOperation.AddVarcharParam(RowNames.SureNames.ToString(), user.SureName);
            sqlOperation.AddVarcharParam(RowNames.UserPic.ToString(), user.UserPic);
            sqlOperation.AddVarcharParam(RowNames.Cedula.ToString(), user.Cedula);
            return sqlOperation;
        }
    }
}
