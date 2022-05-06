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
            Owner,
            Buyer,
            Amount,
            Nft,
            EndDate,
            Image,
            IdOwner,
            NftName
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
                Buyer = GetStringValue(row, RowNames.Buyer.ToString()),
                Owner = GetStringValue(row, RowNames.Owner.ToString()),
                Amount = GetDoubleValue(row, RowNames.Amount.ToString()),
                EndDate = GetDateValue(row,RowNames.EndDate.ToString()),
                Nft = new NFTC()
                {
                    Id = GetStringValue(row, RowNames.Nft.ToString()),

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

            sqlOperation.AddVarcharParam(RowNames.Buyer.ToString(), obj.Buyer);
            sqlOperation.AddVarcharParam(RowNames.Owner.ToString(), obj.Owner);
            sqlOperation.AddDoubleParam(RowNames.Amount.ToString(), obj.Amount);
            sqlOperation.AddVarcharParam(RowNames.Nft.ToString(), obj.Nft.Id);
            sqlOperation.AddDateTimeParam(RowNames.EndDate.ToString(), obj.EndDate);
            return sqlOperation;
        }
        
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()

            {
                ProcedureName = "UPD_AUCTION_BID_PR"
            };

            var obj = (Auction)entity;
            sqlOperation.AddVarcharParam(RowNames.Buyer.ToString(), obj.Buyer);
            sqlOperation.AddDoubleParam(RowNames.Amount.ToString(), obj.Amount);
            return sqlOperation;
        }
        public SqlOperation GetRetriveAllByOwner(BaseEntity entity)
        {
            var obj = (Auction)entity;
            sqlOperation = new SqlOperation {ProcedureName = "RET_OWNER_AUCTION_PR"};
            sqlOperation.AddVarcharParam(RowNames.Owner.ToString(), obj.Owner);
            return sqlOperation;

        }
        public SqlOperation GetRetriveAllStatement()
        {
           return new SqlOperation { ProcedureName = "RET_ALL_AUCTION_PR" };
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