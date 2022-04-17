using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class User_CompanyMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_IdUser_X_Company = "IdUserXCompany";
        private const string DB_COL_IdUser = "IdUser";
        private const string DB_COL_IdCompany = "IdCompany";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_User_Company_PR" };

            var c = (User_Company)entity;
            operation.AddVarcharParam(DB_COL_IdUser, c.IdUser);
            operation.AddIntParam(DB_COL_IdCompany, c.IdCompany);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_X_ORGANIZACION_PR" };

            var c = (User_Company)entity;
            operation.AddIntParam(DB_COL_IdUser_X_Company, c.IdUserXCompany);

            return operation;
        }
        /*
                public SqlOperation GetRetriveOrgByUserIdStatement(BaseEntity entity)
                {
                    var operation = new SqlOperation { ProcedureName = "RET_User_X_CompanyId_PR" };

                    var c = (User)entity;
                    operation.AddVarcharParam(DB_COL_IdUser, c.IdUser);

                    return operation;
                }
        */
        public SqlOperation GetRetriveComapanyByIdStatement(String entityId)
        {
            var operation = new SqlOperation { ProcedureName = "RET_User_X_CompanyId_PR" };

            operation.AddVarcharParam(DB_COL_IdUser, entityId);

            return operation;
        }

        public SqlOperation GetRetriveByOrgStatement(int entityId)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_X_ORGANIZACION_ORGANIZACION_PR" };
            operation.AddIntParam(DB_COL_IdCompany, entityId);

            return operation;
        }

        public SqlOperation GetRetriveRolUsuarioByOrgStatement(int entityId)
        {
            var operation = new SqlOperation { ProcedureName = "[RET_ALL_USUARIO_X_ORGANIZACION_ESTADO_PR]" };
            operation.AddIntParam(DB_COL_IdCompany, entityId);

            return operation;
        }

        public SqlOperation GetRetriveAllByCedulaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_X_ORGANIZACION_CEDULA_PR" };

            var c = (User_Company)entity;
            operation.AddVarcharParam(DB_COL_IdUser, c.IdUser);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIO_X_ORGANIZACION_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_X_ORGANIZACION_PR" };

            var c = (User_Company)entity;
            operation.AddIntParam(DB_COL_IdUser_X_Company, c.IdUserXCompany);
            operation.AddVarcharParam(DB_COL_IdUser, c.IdUser);
            operation.AddIntParam(DB_COL_IdCompany, c.IdCompany);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USUARIO_X_ORGANIZACION_PR" };

            var c = (User_Company)entity;
            operation.AddIntParam(DB_COL_IdUser_X_Company, c.IdUserXCompany);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var userXcompany = BuildObject(row);
                lstResults.Add(userXcompany);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuarioXOrganizacion = new User_Company
            {
                IdUserXCompany = GetIntValue(row, DB_COL_IdUser_X_Company),
                IdUser = GetStringValue(row, DB_COL_IdUser),
                IdCompany = GetIntValue(row, DB_COL_IdCompany),
            };

            return usuarioXOrganizacion;
        }

    }
}
