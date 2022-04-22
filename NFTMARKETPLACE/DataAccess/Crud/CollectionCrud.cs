using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class CollectionCrud : CrudFactory
    {
        CollectionMapper mapper;

        public CollectionCrud() : base()
        {
            mapper = new CollectionMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var nft = (NFTCollection)entity;
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
            var lstCollections = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCollections.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstCollections;
        }

        public List<T> RetrieveAllNFTCollectionCompany<T>(BaseEntity entity)
        {
            var lstCollections = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByCompanyId(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCollections.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstCollections;
        }

        public List<T> RetrieveAllCollectionCategory<T>(string category)
        {
            var lstCollections = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllCollectionCategory(category));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCollections.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstCollections;
        }

        public object RetrieveAllCollectionByCompany<T>(NFTCollection collection)
        {
            var lstCollections = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByCompanyId(collection));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCollections.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstCollections;
        }

        public List<T> RetrieveAllCollectionWithCategory<T>()
        {
            var lstCollections = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllCollectionWithCategory());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsWithCategory(lstResult);
                foreach (var c in objs)
                {
                    lstCollections.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstCollections;
        }

        public T RetrieveFilterByName<T>(NFTCollection collection)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByName(collection));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }

        public override void Update(BaseEntity entity)
        {
            var collection = (NFTCollection)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(collection));
        }

        public override void Delete(BaseEntity entity)
        {
            var collection = (NFTCollection)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(collection));
        }

    }
}
