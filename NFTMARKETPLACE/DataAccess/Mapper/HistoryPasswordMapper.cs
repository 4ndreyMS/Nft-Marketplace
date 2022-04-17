using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class HistoryPasswordMapper: EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_CEDULA = "Cedula";
        private const string DB_COL_CONTRASENIA = "Contrasenia";
        private const string DB_COL_ID_HISTORIAL_CONTRASENIA = "ID_Historial_Contrasenia";
        private const string DB_COL_FECHA_CREACION = "Fecha_Creacion";
        



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var password = new UserPassword
            {
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                Password = GetStringValue(row, DB_COL_CONTRASENIA),
                IdHistorial = GetIntValue(row, DB_COL_ID_HISTORIAL_CONTRASENIA),
                DateCreation = GetDateValue(row, DB_COL_FECHA_CREACION),
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
            var operation = new SqlOperation { ProcedureName = "CRE_PASSWORD_PR" };

            var c = (UserPassword)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);
            operation.AddVarcharParam(DB_COL_CONTRASENIA, c.Password);
            operation.AddDateTimeParam(DB_COL_FECHA_CREACION, c.DateCreation);
            
            return operation;
        }

       
        public SqlOperation GetRetrivePasswordById(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PASSWORD_ID" };

            var c = (UserPassword)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);


            return operation;
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
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
