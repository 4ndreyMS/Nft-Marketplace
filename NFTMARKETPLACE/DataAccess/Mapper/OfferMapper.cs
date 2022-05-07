using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class OfferMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "Id";
        private const string DB_COL_NFT = "NFT";
        private const string DB_COL_BIDDERID = "BidderID";
        private const string DB_COL_OWNERID = "OwnerID";
        private const string DB_COL_AMOUNT = "Amount";
        private const string DB_COL_CREATIONDATE = "CreationDate";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_OFFER_PR" };

            var c = (Offer)entity;
            operation.AddVarcharParam(DB_COL_NFT, c.NFT);
            operation.AddVarcharParam(DB_COL_BIDDERID, c.BidderID);
            operation.AddVarcharParam(DB_COL_OWNERID, c.OwnerID);
            operation.AddDecimalParam(DB_COL_AMOUNT, c.Amount);
            operation.AddDateTimeParam(DB_COL_CREATIONDATE, c.CreationDate);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_OFFER_PR" };

            var c = (Offer)entity;
            operation.AddVarcharParam(DB_COL_NFT, c.NFT);
            operation.AddVarcharParam(DB_COL_BIDDERID, c.BidderID);
            return operation;
        }

        public SqlOperation GetDeleteAllStatements(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ALL_OFFERS_PR" };

            var c = (Offer)entity;
            operation.AddVarcharParam(DB_COL_NFT, c.NFT);           
            return operation;
        }

        public SqlOperation GetRetriveAllOfferByOwner(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_All_OFFERS_BY_OWNER_PR" };

            var c = (Offer)entity;
            operation.AddVarcharParam(DB_COL_OWNERID, c.OwnerID);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_OFFERS_PR" };

            var c = (Offer)entity;
            operation.AddVarcharParam(DB_COL_NFT, c.NFT);
            operation.AddVarcharParam(DB_COL_BIDDERID, c.BidderID);
            operation.AddVarcharParam(DB_COL_OWNERID, c.OwnerID);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_OFFER_PR" };

            var c = (Offer)entity;
            operation.AddVarcharParam(DB_COL_NFT, c.NFT);
            operation.AddVarcharParam(DB_COL_BIDDERID, c.BidderID);
            operation.AddVarcharParam(DB_COL_OWNERID, c.OwnerID);
            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var offer = new Offer
            {
                Id = GetIntValue(row, DB_COL_ID),
                NFT = GetStringValue(row, DB_COL_NFT),
                BidderID = GetStringValue(row, DB_COL_BIDDERID),
                OwnerID = GetStringValue(row, DB_COL_OWNERID),
                Amount = GetDecimalValue(row, DB_COL_AMOUNT),
                CreationDate = GetDateValue(row, DB_COL_CREATIONDATE)           
            };

            return offer;
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

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_OFFERS_PR" };
            return operation;
        }
    }
}
