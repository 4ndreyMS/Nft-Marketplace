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
    public class UserFactory : CrudFactory
    {

        private UserMapper mapper;
        private SqlOperation sqlOperation;

        //Creamos el constructor
        public UserFactory()
        {
            dao = SqlDao.GetInstance();
            mapper = new UserMapper();
        }


        //Creates
        public override void Create(BaseEntity entity)
        {
            var sqlOperation = mapper.GetCreateStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        //Deletes
        public override void Delete(BaseEntity entity)
        {
            var sqlOperation = mapper.GetDeleteStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }


        //Retrieves
        public T RetrieveByMail<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByMail(entity));
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }


        //Retrieves
        public override T Retrieve<T>(BaseEntity entity)
        {
           var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));   
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs    = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
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

        public List<T> RetrieveAllWithRole<T>()
        {

            var lstCustomers = new List<T>(); //inicializa la lista que va a devolver

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatementWithRole());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsWithRole(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;

        }

        //Updates
        public override void Update(BaseEntity entity)
        {
           var sqlOperation = mapper.GetUpdateStatement(entity);
            dao.ExecuteProcedure(sqlOperation);

        }

        public void UpdateOtpUser(BaseEntity entity)
        {
            var sqlOperation = mapper.GetUpdateOtpStatement(entity);
            dao.ExecuteProcedure(sqlOperation);

        }

        public void UpdateStatusUser(BaseEntity entity)
        {
            var sqlOperation = mapper.GetUpdateStatusStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        


    }
}
