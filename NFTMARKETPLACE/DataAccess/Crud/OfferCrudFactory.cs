using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class OfferCrudFactory : CrudFactory
    {
        OfferMapper mapper;

        public OfferCrudFactory() : base()
        {
            mapper = new OfferMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var offer = (Offer)entity;
            var sqlOperation = mapper.GetCreateStatement(offer);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var offer = (Offer)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(offer));
        }

        public void DeleteALL(BaseEntity entity)
        {
            var offer = (Offer)entity;
            dao.ExecuteProcedure(mapper.GetDeleteAllStatements(offer));
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
            var lstNFTs = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstNFTs.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstNFTs;
        }

        public List<T> RetrieveAllOffersByOwner<T>(BaseEntity entity)
        {
            var lstNFTs = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllOfferByOwner(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstNFTs.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstNFTs;
        }

        public override void Update(BaseEntity entity)
        {
            var offer = (Offer)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(offer));
        }
    }
}
