using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class NFTMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_Id = "Id";
        private const string DB_COL_NFTName = "NftName";
        private const string DB_COL_Price = "Price";
        private const string DB_COL_CreationDate = "CreationDate";
        private const string DB_COL_IdCollection = "IdCollection";
        private const string DB_COL_IdCreator = "IdCreator";
        private const string DB_COL_IdOwner = "IdOwner";
        private const string DB_COL_Image = "Image";
        private const string DB_COL_SaleState = "SaleState";
        private const string DB_COL_CATEGORYNAME = "CategoryName";
        private const string DB_COL_OwnerName = "OwnerName";
        private const string DB_COL_CollectionName = "CollectionName";
        private const string DB_COL_CompanyName = "Name";
        private const string DB_COL_UserImage = "UserPic";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_NFT_PR" };

            var c = (NFT)entity;
            operation.AddVarcharParam(DB_COL_Id, c.Id);
            operation.AddVarcharParam(DB_COL_NFTName, c.NftName);
            operation.AddDecimalParam(DB_COL_Price, c.Price);
            operation.AddDateTimeParam(DB_COL_CreationDate, c.CreationDate);
            operation.AddIntParam(DB_COL_IdCollection, c.IdCollection);
            operation.AddVarcharParam(DB_COL_IdCreator, c.IdCreator);
            operation.AddVarcharParam(DB_COL_IdOwner, c.IdOwner);
            operation.AddVarcharParam(DB_COL_Image, c.Image);
            operation.AddVarcharParam(DB_COL_SaleState, c.SaleState);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_NFT_PR" };

            var c = (NFT)entity;
            operation.AddVarcharParam(DB_COL_Id, c.Id);

            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_NFT_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllNFTWithCategory()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_NFT_WITH_CATEGORY_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllNFTCategory(string category)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_NFT_CATEGORY_PR" };
            operation.AddVarcharParam(DB_COL_CATEGORYNAME, category);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_NFT_PR" };

            var c = (NFT)entity;
            operation.AddVarcharParam(DB_COL_Id, c.Id);
            operation.AddVarcharParam(DB_COL_NFTName, c.NftName);
            operation.AddDecimalParam(DB_COL_Price, c.Price);
            operation.AddDateTimeParam(DB_COL_CreationDate, c.CreationDate);
            operation.AddIntParam(DB_COL_IdCollection, c.IdCollection);
            operation.AddVarcharParam(DB_COL_IdCreator, c.IdCreator);
            operation.AddVarcharParam(DB_COL_NFTName, c.IdOwner);
            operation.AddVarcharParam(DB_COL_Image, c.Image);
            operation.AddVarcharParam(DB_COL_SaleState, c.SaleState);

            return operation;
        }

        internal SqlOperation PutOnSale(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "NFT_PUT_ON_SALE" };

            var c = (NFT)entity;
            operation.AddVarcharParam(DB_COL_Id, c.Id);
            operation.AddDecimalParam(DB_COL_Price, c.Price);
            operation.AddVarcharParam(DB_COL_SaleState, c.SaleState);

            return operation;
        }

        public SqlOperation GetRetrieveAllNFTInProperty(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_NFT_PROPERTY" };

            var c = (NFT)entity;
            operation.AddVarcharParam(DB_COL_IdOwner, c.IdOwner);
            operation.AddVarcharParam(DB_COL_SaleState, c.SaleState);
            return operation;
        }

        public SqlOperation GetRetrieveAllNFTINFO(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_NFT_INFORMATION" };

            var c = (NFT)entity;
            operation.AddVarcharParam(DB_COL_Id, c.Id);          
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_NFT_PR" };

            var c = (NFT)entity;
            operation.AddVarcharParam(DB_COL_Id, c.Id);
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
            var nft = new NFT
            {
                Id = GetStringValue(row, DB_COL_Id),
                NftName = GetStringValue(row, DB_COL_NFTName),
                Price = GetDecimalValue(row, DB_COL_Price),
                CreationDate = GetDateValue(row, DB_COL_CreationDate),
                IdCollection = GetIntValue(row, DB_COL_IdCollection),
                IdCreator = GetStringValue(row, DB_COL_IdCreator),
                IdOwner = GetStringValue(row, DB_COL_IdOwner),
                Image = GetStringValue(row, DB_COL_Image),
                SaleState = GetStringValue(row, DB_COL_SaleState)
            };

            return nft;
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
            var nft = new NFTC
            {
                Id = GetStringValue(row, DB_COL_Id),
                NftName = GetStringValue(row, DB_COL_NFTName),
                Price = GetDecimalValue(row, DB_COL_Price),
                CreationDate = GetDateValue(row, DB_COL_CreationDate),
                IdCollection = GetIntValue(row, DB_COL_IdCollection),
                IdCreator = GetStringValue(row, DB_COL_IdCreator),
                IdOwner = GetStringValue(row, DB_COL_IdOwner),
                Image = GetStringValue(row, DB_COL_Image),
                CategoryName = GetStringValue(row, DB_COL_CATEGORYNAME),
                SaleState = GetStringValue(row, DB_COL_SaleState)
            };

            return nft;
        }


        public SqlOperation GetRetriveAllNFTWithOwnerName()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_NFT_WITH_OWNER_PR" };
            return operation;
        }


        public List<BaseEntity> BuildObjectsWithOwner(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var transaction = BuildObjectWithOwner(row);
                lstResults.Add(transaction);
            }

            return lstResults;
        }

        public BaseEntity BuildObjectWithOwner(Dictionary<string, object> row)
        {


            var nft = new NFTC
            {
                Id = GetStringValue(row, DB_COL_Id),
                NftName = GetStringValue(row, DB_COL_NFTName),
                Price = GetDecimalValue(row, DB_COL_Price),
                CreationDate = GetDateValue(row, DB_COL_CreationDate),
                IdCollection = GetIntValue(row, DB_COL_IdCollection),
                IdCreator = GetStringValue(row, DB_COL_IdCreator),
                IdOwner = GetStringValue(row, DB_COL_IdOwner),
                Image = GetStringValue(row, DB_COL_Image),
                OwnerName = GetStringValue(row, DB_COL_OwnerName)
            };

            return nft;
        }

        public List<BaseEntity> BuildObjectsINFO(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var transaction = BuildObjectINFO(row);
                lstResults.Add(transaction);
            }

            return lstResults;
        }

        public BaseEntity BuildObjectINFO(Dictionary<string, object> row)
        {
            var nft = new InfoNFT
            {
                Id = GetStringValue(row, DB_COL_Id),
                NftName = GetStringValue(row, DB_COL_NFTName),
                Price = GetDecimalValue(row, DB_COL_Price),
                CreationDate = GetDateValue(row, DB_COL_CreationDate),
                CollectionName = GetStringValue(row, DB_COL_CollectionName),
                CreatorName = GetStringValue(row, DB_COL_CompanyName),
                CreatorImage = GetStringValue(row, DB_COL_UserImage),
                Image = GetStringValue(row, DB_COL_Image)
            };

            return nft;
        }
    }
}

