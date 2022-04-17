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
    public class NFTCrudFactory : CrudFactory
    {
        NFTMapper mapper;

        public NFTCrudFactory() : base()
        {
            mapper = new NFTMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var nft = (NFT)entity;
            var sqlOperation = mapper.GetCreateStatement(nft);
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

        public List<T> RetrieveAllNFTWithCategory<T>()
        {
            var lstNFTs = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllNFTWithCategory());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsWithCategory(lstResult);
                foreach (var c in objs)
                {
                    lstNFTs.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstNFTs;
        }

        public List<T> RetrieveAllNFTCategory<T>(string category)
        {
            var lstNFTs = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllNFTCategory(category));
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
            var nft = (NFT)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(nft));
        }

        public override void Delete(BaseEntity entity)
        {
            var nft = (NFT)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(nft));
        }
    }
}

