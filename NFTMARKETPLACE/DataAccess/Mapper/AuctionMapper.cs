using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DTO_POJOS;

namespace DataAccess.Mapper
{
    public class AuctionMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private SqlOperation sqlOperation;

            public enum RowNames
        {
            Id,
            IdOwner,
            IdBuyer,
            Amount,
            NftId,
            Nft,
            EndDate,
            CreationDate,
            Image,
            CreationDateNft,
            CollectionName,
            CreatorImage,
            CreatorName,
            NftName,
            Price
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            {
                try
                {
                    var lstResults = new List<BaseEntity>();

                    foreach (var row in lstRows)
                    {
                        var user = BuildObject(row);
                        lstResults.Add(user);
                    }

                    return lstResults;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var auction = new Auction()
            {
                Id = GetIntValue(row, RowNames.Id.ToString()),
                IdBuyer = GetStringValue(row, RowNames.IdBuyer.ToString()),
                IdOwner = GetStringValue(row, RowNames.IdOwner.ToString()),
                Amount = GetDoubleValue(row, RowNames.Amount.ToString()),
                EndDate = GetDateValue(row,RowNames.EndDate.ToString()),
                CreationDate= GetDateValue(row, RowNames.CreationDate.ToString()),
                Nft = new InfoNFT()
                {
                    Id = GetStringValue(row, RowNames.NftId.ToString()),
                    Image = GetStringValue(row, RowNames.Image.ToString()),
                    CreationDate = GetDateValue(row, RowNames.CreationDateNft.ToString()),
                    CollectionName = GetStringValue(row, RowNames.CollectionName.ToString()),
                    CreatorImage = GetStringValue(row, RowNames.CreatorImage.ToString()),
                    CreatorName = GetStringValue(row, RowNames.CreatorName.ToString()),
                    NftName = GetStringValue(row, RowNames.NftName.ToString()),
                    Price = GetDecimalValue(row, RowNames.Price.ToString())
                }


            };

            return auction;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {

            sqlOperation = new SqlOperation()
            {
                ProcedureName = "CRE_AUCTION_PR"
            };

            var obj = (Auction)entity;

            sqlOperation.AddVarcharParam(RowNames.IdBuyer.ToString(), obj.IdBuyer);
            sqlOperation.AddVarcharParam(RowNames.IdOwner.ToString(), obj.IdOwner);
            sqlOperation.AddDoubleParam(RowNames.Amount.ToString(), obj.Amount);
            sqlOperation.AddVarcharParam(RowNames.Nft.ToString(), obj.Nft.Id);
            sqlOperation.AddDateTimeParam(RowNames.EndDate.ToString(), obj.EndDate);
            sqlOperation.AddDateTimeParam(RowNames.CreationDate.ToString(), obj.CreationDate);
            return sqlOperation;
        }
        
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_AUCTION_BID_PR"
            };

            var obj = (Auction)entity;
            sqlOperation.AddVarcharParam(RowNames.IdBuyer.ToString(), obj.IdBuyer);
            sqlOperation.AddDoubleParam(RowNames.Amount.ToString(), obj.Amount);
            return sqlOperation;
        }
        public SqlOperation GetRetriveAllByOwner(BaseEntity entity)
        {
            var obj = (Auction)entity;
            sqlOperation = new SqlOperation {ProcedureName = "RET_OWNER_AUCTION_PR"};
            sqlOperation.AddVarcharParam(RowNames.IdOwner.ToString(), obj.IdOwner);
            return sqlOperation;

        }
        public SqlOperation GetRetriveAllStatement()
        {
           return new SqlOperation { ProcedureName = "RET_ALL_AUCTION_PR" };
        }
        public SqlOperation GetRetriveAllAuctionByNft(BaseEntity entity)
        {
            var obj = (Auction)entity;
            sqlOperation = new SqlOperation { ProcedureName = "RET_NFT_AUCTION_PR" };
            sqlOperation.AddVarcharParam(RowNames.Nft.ToString(), obj.Nft.Id);
            return sqlOperation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "DEL_AUCTION_PR"
            };

            var obj = (Auction)entity;
            sqlOperation.AddSmallIntParam(RowNames.Id.ToString(), obj.Id);
            return sqlOperation;
        }

        //not in use
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}