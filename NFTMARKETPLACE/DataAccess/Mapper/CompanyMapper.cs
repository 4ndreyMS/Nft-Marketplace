using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{


    public class CompanyMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        enum RowNames
        {
            Id,
            Name,
            Email,
            Status,
            CreationDate
        }

        private SqlOperation sqlOperation;


        //Build Objects
  

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var company = BuildObject(row);
                lstResults.Add(company);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var company = new Company()
            {
                id = GetStringValue(row, RowNames.Id.ToString()),
                name = GetStringValue(row, RowNames.Name.ToString()),
                status = GetStringValue(row, RowNames.Status.ToString()),
                creationDate = GetDateValue(row, RowNames.CreationDate.ToString()),
                email = GetStringValue(row, RowNames.Email.ToString())
            };

            return company;
        }

        //Creates
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            //Nombre del procedimiento
            {
                ProcedureName =  "CRE_COMPANY_PR"
            };

            var company = (Company)entity;

            //Agregamos los parametros de nuestro procedimiento, lo que recibe la BD

            sqlOperation.AddVarcharParam(RowNames.Id.ToString(), company.id);
            sqlOperation.AddVarcharParam(RowNames.Name.ToString(), company.name);
            sqlOperation.AddVarcharParam(RowNames.Email.ToString(), company.email);
            sqlOperation.AddVarcharParam(RowNames.Status.ToString(), company.status);  
            sqlOperation.AddDateTimeParam(RowNames.CreationDate.ToString(), company.creationDate);

            return sqlOperation;
        }


        //Deletes
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

                {
                    ProcedureName = "DEL_COMPANY_PR"
                };

            var company = (Company)entity;
            sqlOperation.AddVarcharParam(RowNames.Id.ToString(), company.id);
            return sqlOperation;

        }


        //Retrieves
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_COMPANY_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COMPANY_PR" };
            var company = (Company)entity;
            operation.AddVarcharParam(RowNames.Id.ToString(), company.id);
            return operation;
        }

        public SqlOperation GetRetriveStatementByName(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COMPANY_BY_NAME_PR" };
            var company = (Company)entity;
            operation.AddVarcharParam(RowNames.Name.ToString(), company.name);
            return operation;
        }

        //Updates

        public SqlOperation GetUpdateNameStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_NAME_COMPANY_PR"
            };

            var company = (Company)entity;
            sqlOperation.AddVarcharParam(RowNames.Id.ToString(), company.id);
            sqlOperation.AddVarcharParam(RowNames.Name.ToString(), company.name);
            return sqlOperation;
        }

        public SqlOperation GetUpdateEmailStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_EMAIL_COMPANY_PR"
            };

            var company = (Company)entity;
            sqlOperation.AddVarcharParam(RowNames.Id.ToString(), company.id);
            sqlOperation.AddVarcharParam(RowNames.Email.ToString(), company.email);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_STATUS_COMPANY_PR"
            };

            var company = (Company)entity;
            sqlOperation.AddVarcharParam(RowNames.Id.ToString(), company.id);
            sqlOperation.AddVarcharParam(RowNames.Status.ToString(), company.status);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
