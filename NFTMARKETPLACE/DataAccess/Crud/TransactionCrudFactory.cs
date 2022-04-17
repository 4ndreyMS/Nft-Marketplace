using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class TransactionCrudFactory : CrudFactory
    {
        TransactionMapper mapper;

        public TransactionCrudFactory() : base()
        {
            mapper = new TransactionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var transaccion = (Transaction)entity;
            var sqlOperation = mapper.GetCreateStatement(transaccion);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
        public override List<T> RetrieveAll<T>()
        {
            var lstTransaccions = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransaccions.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstTransaccions;
        }


        public List<T> RetrieveAllByWallet<T>(string entityId)
        {
            var lstTransaccions = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByWalletStatement(entityId));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransaccions.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstTransaccions;
        }


        public override void Update(BaseEntity entity)
        {
            var transaccion = (Transaction)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(transaccion));
        }

        public override void Delete(BaseEntity entity)
        {
            var transaccion = (Transaction)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(transaccion));
        }
    }
}
