using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CategoryMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "Id";
        private const string DB_COL_CATEGORY = "CategoryName";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CATEGORY_PR" };

            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_CATEGORY, c.CategoryName);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CATEGORY_PR" };

            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_CATEGORY, c.CategoryName);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_All_CATEGORY_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATEGORY_PR" };

            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_CATEGORY, c.CategoryName);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CATEGORY_PR" };

            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_CATEGORY, c.CategoryName);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var category = new Category
            {
                Id = GetIntValue(row, DB_COL_ID),
                CategoryName = GetStringValue(row, DB_COL_CATEGORY)
            };

            return category;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var CATEGORY = BuildObject(row);
                lstResults.Add(CATEGORY);
            }

            return lstResults;
        }

    }
}
