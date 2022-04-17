using System.Collections.Generic;
using DataAccess.Dao;
using DTO_POJOS;



namespace DataAccess.Mapper
{
    enum RowNames
    {
        Identifier,
        CoinName,
        Amount,
        CompanyId
    }
    public class WalletMapper : EntityMapper,IObjectMapper, ISqlStaments
    {
        private SqlOperation slqOperation;
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            slqOperation = new SqlOperation()
            {
                ProcedureName = "CRE_WALLET_PR"
            };
            var obj = (Wallet)entity;
            slqOperation.AddVarcharParam(RowNames.Identifier.ToString(),obj.Identifier);
            slqOperation.AddVarcharParam(RowNames.CoinName.ToString(), obj.CoinName);
            slqOperation.AddDoubleParam(RowNames.Amount.ToString(), obj.Amount);
            slqOperation.AddVarcharParam(RowNames.CompanyId.ToString(), obj.CompanyId);
            return slqOperation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_WALLET_PR" };
            var obj = (Wallet)entity;
            operation.AddVarcharParam(RowNames.CompanyId.ToString(), obj.CompanyId);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            slqOperation = new SqlOperation()
            {
                ProcedureName = "UPD_WALLET_PR"
            };
            var obj = (Wallet)entity;
            slqOperation.AddVarcharParam(RowNames.CompanyId.ToString(), obj.CompanyId);
            slqOperation.AddVarcharParam(RowNames.Identifier.ToString(), obj.Identifier);
            return slqOperation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            slqOperation = new SqlOperation()
            {
                ProcedureName = "DEL_WALLET_PR"
            };
            var obj = (Wallet)entity;
            slqOperation.AddVarcharParam(RowNames.Identifier.ToString(), obj.Identifier);
            return slqOperation;
        }

        public SqlOperation GetUpdateAddAmount(BaseEntity entity)
        {
            slqOperation = new SqlOperation()
            {
                ProcedureName = "ADD_AMOUNT_WALLET_PR"
            };
            var obj = (Wallet)entity;
            slqOperation.AddDoubleParam(RowNames.Amount.ToString(), obj.Amount);
            slqOperation.AddVarcharParam(RowNames.Identifier.ToString(), obj.Identifier);
            return slqOperation;
        }
        public SqlOperation GetUpdateRestAmount(BaseEntity entity)
        {
            slqOperation = new SqlOperation()
            {
                ProcedureName = "REST_AMOUNT_WALLET_PR"
            };
            var obj = (Wallet)entity;
            slqOperation.AddDoubleParam(RowNames.Amount.ToString(), obj.Amount);
            slqOperation.AddVarcharParam(RowNames.Identifier.ToString(), obj.Identifier);
            return slqOperation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var obj = BuildObject(row);
                lstResults.Add(obj);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var wallet = new Wallet()
            {
                Identifier = GetStringValue(row, RowNames.Identifier.ToString()),
                CompanyId = GetStringValue(row, RowNames.CompanyId.ToString()),
                Amount = GetDoubleValue(row,RowNames.Amount.ToString()),
                CoinName = GetStringValue(row, RowNames.CoinName.ToString())
            };

            return wallet;
        }

        
    }
}