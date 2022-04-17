using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class LogginMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_CEDULA = "Cedula";
        private const string DB_COL_CONTRASENIA = "Contrasenia";
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var password = new UserPassword
            {
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                Password = GetStringValue(row, DB_COL_CONTRASENIA),
            };

            return password;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var password = BuildObject(row);
                lstResults.Add(password);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LOGGIN_PR" };

            var c = (UserPassword)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);
           

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
