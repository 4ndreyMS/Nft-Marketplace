using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    internal class PricesMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_ID = "Id";
        private const string DB_COL_AMOUNT = "Amount";
        private const string DB_COL_TYPE = "Type";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PRICES_PR" };

            var c = (Prices)entity;
            operation.AddDoubleParam(DB_COL_AMOUNT, c.Amount);
            operation.AddVarcharParam(DB_COL_TYPE, c.Type);
            
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PRICES_PR" };

            var c = (Prices)entity;
            operation.AddVarcharParam(DB_COL_TYPE, c.Type);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_All_PRICES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRICES_PR" };

            var c = (Prices)entity;
            operation.AddVarcharParam(DB_COL_TYPE, c.Type);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PRICES_PR" };

            var c = (Prices)entity;
            operation.AddDoubleParam(DB_COL_AMOUNT, c.Amount);
            operation.AddVarcharParam(DB_COL_TYPE, c.Type);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var prices = new Prices
            {
                Id = GetIntValue(row, DB_COL_ID),
                Amount = GetDoubleValue(row, DB_COL_AMOUNT),
                Type = GetStringValue(row, DB_COL_TYPE)
            };

            return prices;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var PRICES = BuildObject(row);
                lstResults.Add(PRICES);
            }

            return lstResults;
        }
    }
}
