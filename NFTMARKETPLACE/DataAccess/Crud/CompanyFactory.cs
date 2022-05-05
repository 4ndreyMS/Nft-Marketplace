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
    public class CompanyFactory : CrudFactory
    {
        private CompanyMapper mapper;
        private SqlOperation sqlOperation;


        //Creamos el constructor
        public CompanyFactory()
        {
            dao =  SqlDao.GetInstance();
            mapper = new CompanyMapper();

        }



        //Creates
        public override void Create(BaseEntity entity)
        {
            //El mapper obtiene la instruccion a ejecutar
            var sqlOperation = mapper.GetCreateStatement(entity);

            //Ejecutamos la operacion
            dao.ExecuteProcedure(sqlOperation);
        }


        //Deletes
        public override void Delete(BaseEntity entity)
        {
            var sqlOperation = mapper.GetDeleteStatement(entity);

            //Ejecutamos la operacion
            dao.ExecuteProcedure(sqlOperation);
        }

     


        //Retrieves
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

        public  T RetrieveFilterByName<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByName(entity));
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



        //Updates
        public override void Update(BaseEntity entity)
        {
            var sqlOperation = mapper.GetUpdateStatusStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void UpdateName(Company company)
        {
            dao.ExecuteProcedure(mapper.GetUpdateNameStatement(company));
        }
    }
}
