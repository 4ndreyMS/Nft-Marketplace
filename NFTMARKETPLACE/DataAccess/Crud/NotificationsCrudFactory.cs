using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;

namespace DataAccess.Crud
{
    public class NotificationsCrudFactory : CrudFactory
    {
        private NotificationsMapper mapper;
        private SqlOperation sqlOperation;


        public override void Create(BaseEntity entity)
        {
            dao.ExecuteProcedure(mapper.GetCreateStatement(entity));
        }

        public override void Delete(BaseEntity entity)
        {
            dao.ExecuteProcedure(mapper.GetDeleteStatement(entity));
        }
        public List<T> retrieveNotifUserByCompany<T>(BaseEntity entity)
        {
            var lstNotif = new List<T>(); //inicializa la lista que va a devolver
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByReciver(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstNotif.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstNotif;
        }

        //not used
        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
        //not used
        public override List<T> RetrieveAll<T>()
        {
            throw new System.NotImplementedException();
        }
        //not used
        public override void Update(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}