using DataAccess.Dao;
using DTO_POJOS;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class TransactionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_Id = "Id";
        private const string DB_COL_Amount = "Amount";
        private const string DB_COL_TransType = "TransType";
        private const string DB_COL_TransactionDate = "TransactionDate";
        private const string DB_COL_Status = "Status";
        private const string DB_Col_WalletSend = "WalletSend";
        private const string DB_Col_WalletReceive = "WalletReceive";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_TRANSACTION_PR" };

            var c = (Transaction)entity;
            operation.AddDecimalParam(DB_COL_Amount, c.Amount);
            operation.AddVarcharParam(DB_COL_TransType, c.TransType);
            operation.AddDateTimeParam(DB_COL_TransactionDate, c.TransactionDate);
            operation.AddVarcharParam(DB_COL_Status, c.Status);
            operation.AddVarcharParam(DB_Col_WalletSend, c.WalletSend);
            operation.AddVarcharParam(DB_Col_WalletReceive, c.WalletReceive);

            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_TRANSACTION_PR" };

            var c = (Transaction)entity;
            operation.AddIntParam(DB_COL_Id, c.Id);

            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRANSACTION_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_TRANSACTION_PR" };

            var c = (Transaction)entity;
            operation.AddDecimalParam(DB_COL_Amount, c.Amount);
            operation.AddVarcharParam(DB_COL_TransType, c.TransType);
            operation.AddDateTimeParam(DB_COL_TransactionDate, c.TransactionDate);
            operation.AddVarcharParam(DB_COL_Status, c.Status);
            operation.AddVarcharParam(DB_Col_WalletSend, c.WalletSend);
            operation.AddVarcharParam(DB_Col_WalletReceive, c.WalletReceive);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_TRANSACTION_PR" };
            var c = (Transaction)entity;
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

        public SqlOperation GetRetriveByWalletStatement(string walletId)
        {
            var operation = new SqlOperation { ProcedureName = "RET_TRANSACTION_WALLET_PR" };

            operation.AddVarcharParam(DB_Col_WalletSend, walletId);

            return operation;
        }


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var transaction = new Transaction
            {
                Id = GetIntValue(row, DB_COL_Id),
                Amount = GetDecimalValue(row, DB_COL_Amount),
                TransType = GetStringValue(row, DB_COL_TransType),
                TransactionDate = GetDateValue(row, DB_COL_TransactionDate),
                Status = GetStringValue(row, DB_COL_Status),
                WalletSend = GetStringValue(row, DB_Col_WalletSend),
                WalletReceive = GetStringValue(row, DB_Col_WalletReceive),
            };

            return transaction;
        }
    }


}
