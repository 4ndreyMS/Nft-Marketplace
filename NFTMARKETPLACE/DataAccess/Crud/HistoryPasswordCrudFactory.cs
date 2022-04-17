using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class HistoryPasswordCrudFactory : CrudFactory
    {
        HistoryPasswordMapper mapper;

        public HistoryPasswordCrudFactory() : base()
        {
            mapper = new HistoryPasswordMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var password = (UserPassword)entity;
            var sqlOperation = mapper.GetCreateStatement(password);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> RetrievePasswordById<T>(BaseEntity entity)
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrivePasswordById(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
