using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class Collection_CategoryMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_IDCOLLECTION = "IdCollection";
        private const string DB_COL_IDCATEGORY = "IdCategory";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_COLLECTION_CATEGORY_PR" };
            var c = (Collection_Category)entity;
            operation.AddIntParam(DB_COL_IDCOLLECTION, c.IdCollection);
            operation.AddIntParam(DB_COL_IDCATEGORY, c.IdCategory);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_COLLECTION_CATEGORY_PR" };

            var c = (Collection_Category)entity;
            operation.AddIntParam(DB_COL_IDCOLLECTION, c.IdCollection);
            operation.AddIntParam(DB_COL_IDCATEGORY, c.IdCategory);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_COLLECTION_CATEGORY_TABLE_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COLLECTION_CATEGORY_PR" };

            var c = (Collection_Category)entity;
            operation.AddIntParam(DB_COL_IDCOLLECTION, c.IdCollection);
            operation.AddIntParam(DB_COL_IDCATEGORY, c.IdCategory);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_COLLECTION_CATEGORY_PR" };

            var c = (Collection_Category)entity;
            operation.AddIntParam(DB_COL_IDCOLLECTION, c.IdCollection);
            operation.AddIntParam(DB_COL_IDCATEGORY, c.IdCategory);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var nft = new Collection_Category
            {
                IdCollection = GetIntValue(row, DB_COL_IDCOLLECTION),
                IdCategory = GetIntValue(row, DB_COL_IDCATEGORY)
            };

            return nft;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var transaction = BuildObject(row);
                lstResults.Add(transaction);
            }

            return lstResults;
        }
    }
}
