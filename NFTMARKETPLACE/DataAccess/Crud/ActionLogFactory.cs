using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;

namespace DataAccess.Crud
{
    public class ActionLogFactory : CrudFactory
    {
        private ActionLogMapper actionMapper;
        private SqlOperation sqlOperation;

        public ActionLogFactory()
        {
            actionMapper = new ActionLogMapper();
            sqlOperation = new SqlOperation();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            sqlOperation = actionMapper.GetCreateStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override List<T> RetrieveAll<T>()
        {
            var list = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(actionMapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = actionMapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return list;
        }
        public List<T> RetrieveAllByRole<T>(BaseEntity entity)
        {
            var list = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(actionMapper.GetActionByUserRoleStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = actionMapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return list;
        }

        public List<T> RetrieveAllByUser<T>(BaseEntity entity)
        {
            var list = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(actionMapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = actionMapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return list;
        }


        //not used
        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        //not used
        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        //not used
        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();

        }
    }
}
