using DataAccess.Dao;
using DTO_POJOS;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CollectionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_Id = "Id";
        private const string DB_COL_CollectionName = "CollectionName";
        private const string DB_COL_CreationDate = "CreationDate";
        private const string DB_COL_CompanyId = "CompanyId";
        private const string DB_COL_CATEGORYNAME = "CategoryName";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_NFTCollection_PR" };

            var c = (NFTCollection)entity;
            operation.AddVarcharParam(DB_COL_CollectionName, c.CollectionName);
            operation.AddDateTimeParam(DB_COL_CreationDate, c.CreationDate);
            operation.AddVarcharParam(DB_COL_CompanyId, c.CompanyId);

            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_NFTCollection_PR" };
            var c = (NFTCollection)entity;
            operation.AddIntParam(DB_COL_Id, c.Id);
            return operation;
        }

        public SqlOperation GetRetriveStatementByNameAndId(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_NFTCollection_BYNAMEANDID_PR" };
            var c = (NFTCollection)entity;
            operation.AddVarcharParam(DB_COL_CollectionName, c.CollectionName);
            operation.AddVarcharParam(DB_COL_CompanyId, c.CompanyId);
            return operation;
        }


        public SqlOperation GetRetriveStatementByCompanyId(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_NFTCollection_CompanyId_PR" };

            var c = (NFTCollection)entity;
            operation.AddIntParam(DB_COL_Id, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllCollectionCategory(string category)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_COLLECTION_CATEGORY_PR" };
            operation.AddVarcharParam(DB_COL_CATEGORYNAME, category);

            return operation;
        }
        public SqlOperation GetRetriveStatementByName(NFTCollection collection)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COLLECTION_BY_NAME_PR" };
            operation.AddVarcharParam(DB_COL_CollectionName, collection.CollectionName);
            operation.AddVarcharParam(DB_COL_CompanyId, collection.CompanyId);
            return operation;
        }

      
        public SqlOperation GetRetriveAllCollectionWithCategory()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_COLLECTION_WITH_CATEGORY_PR" };
            return operation;
        }

      
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_NFTCollection_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_NFT_PR" };

            var c = (NFTCollection)entity;
            operation.AddIntParam(DB_COL_Id, c.Id);
            operation.AddVarcharParam(DB_COL_CollectionName, c.CollectionName);
            operation.AddDateTimeParam(DB_COL_CreationDate, c.CreationDate);
            operation.AddVarcharParam(DB_COL_CompanyId, c.CompanyId);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_NFTCollection_PR" };

            var c = (NFTCollection)entity;
            operation.AddIntParam(DB_COL_Id, c.Id);
            return operation;
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
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var nftCollection = new NFTCollection
            {
                Id = GetIntValue(row, DB_COL_Id),
                CollectionName = GetStringValue(row, DB_COL_CollectionName),
                CreationDate = GetDateValue(row, DB_COL_CreationDate),
                CompanyId = GetStringValue(row, DB_COL_CompanyId),
            };

            return nftCollection;
        }

        public List<BaseEntity> BuildObjectsWithCategory(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var transaction = BuildObjectWithCategory(row);
                lstResults.Add(transaction);
            }

            return lstResults;
        }
        public BaseEntity BuildObjectWithCategory(Dictionary<string, object> row)
        {
            var nftCollection = new CollectionC
            {
                Id = GetIntValue(row, DB_COL_Id),
                CollectionName = GetStringValue(row, DB_COL_CollectionName),
                CreationDate = GetDateValue(row, DB_COL_CreationDate),
                CompanyId = GetStringValue(row, DB_COL_CompanyId),
                CategoryName = GetStringValue(row, DB_COL_CATEGORYNAME)
            };

            return nftCollection;
        }
    }

}

