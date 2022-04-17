using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;

namespace DataAccess.Crud
{
    public class UserRoleFactory : CrudFactory
    {

        private UserRoleMapper mapper;
        private SqlOperation sqlOperation;
        public UserRoleFactory()
        {
            dao = SqlDao.GetInstance();
            mapper = new UserRoleMapper();
        }

        public override void Create(BaseEntity entity)
        {
            var sqlOperation = mapper.GetCreateStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        //retrive all of an especific type
        public List<T> RetrieveAllSpecificType<T>(BaseEntity entity)
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

        //update the role sending the user id
        public override void Update(BaseEntity entity)
        {
            var sqlOperation = mapper.GetDeleteStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var sqlOperation = mapper.GetDeleteStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void DeleteAllUserRoles(BaseEntity entity)
        {
            var sqlOperation = mapper.GetDeleteAllRolesStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByUserIdStatement(entity));
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectUserRole(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);

        }



        //not used
        public override List<T> RetrieveAll<T>()
        {
            throw new System.NotImplementedException();

        }


    }
}