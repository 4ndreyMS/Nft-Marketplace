using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;

namespace DataAccess.Crud
{
    public class AuctionCrudFactory : CrudFactory
    {
        private AuctionMapper mapper;

        public AuctionCrudFactory()
        {
            mapper = new AuctionMapper();
            dao = SqlDao.GetInstance();
        }

        public T RetrieveAllByNft<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllAuctionByNft(entity));
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);

        }
        
        public override void Create(BaseEntity entity)
        {
            dao.ExecuteProcedure(mapper.GetCreateStatement(entity));
        }
        public List<T> RetrieveAllByOwner<T>(BaseEntity entity)
        {
            var lstCustomers = new List<T>(); //inicializa la lista que va a devolver

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByOwner(entity));
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
        public override List<T> RetrieveAll<T>()
        {
            var lstCustomers = new List<T>(); //inicializa la lista que va a devolver

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
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
            dao.ExecuteProcedure(mapper.GetUpdateStatement(entity));
        }

        public override void Delete(BaseEntity entity)
        {
            dao.ExecuteProcedure(mapper.GetDeleteStatement(entity));
        }
        //not in use
        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}