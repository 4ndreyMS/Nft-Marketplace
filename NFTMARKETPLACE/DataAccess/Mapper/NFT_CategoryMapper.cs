using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class NFT_CategoryMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_NFTID = "NFTId";
        private const string DB_COL_CATEGORYID = "CategoryId";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_NFT_CATEGORY_PR" };
            var c = (NFT_Category)entity;
            operation.AddVarcharParam(DB_COL_NFTID, c.NFTId);
            operation.AddIntParam(DB_COL_CATEGORYID, c.CategoryId);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_NFT_CATEGORY_PR" };

            var c = (NFT_Category)entity;
            operation.AddVarcharParam(DB_COL_NFTID, c.NFTId);
            operation.AddIntParam(DB_COL_CATEGORYID, c.CategoryId);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_NFT_CATEGORY_TABLE_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_NFT_CATEGORY_TABLE_PR" };

            var c = (NFT_Category)entity;
            operation.AddVarcharParam(DB_COL_NFTID, c.NFTId);
            operation.AddIntParam(DB_COL_CATEGORYID, c.CategoryId);
            return operation;
        }

        public SqlOperation GetUpdateStatementCategoryNFTId(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_NFTId_CATEGORY_TABLE_PR" };
            var c = (NFT_Category)entity;
            operation.AddVarcharParam(DB_COL_NFTID, c.NFTId);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_NFT_CATEGORY_PR" };

            var c = (NFT_Category)entity;
            operation.AddVarcharParam(DB_COL_NFTID, c.NFTId);
            operation.AddIntParam(DB_COL_CATEGORYID, c.CategoryId);

            return operation;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var nft = new NFT_Category
            {
                NFTId = GetStringValue(row, DB_COL_NFTID),
                CategoryId = GetIntValue(row, DB_COL_CATEGORYID)
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
