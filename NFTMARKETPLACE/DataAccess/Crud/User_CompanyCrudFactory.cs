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
    public class User_CompanyCrudFactory : CrudFactory
    {
        User_CompanyMapper mapper;

        public User_CompanyCrudFactory() : base()
        {
            mapper = new User_CompanyMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var userXcompany = (User_Company)entity;
            var sqlOperation = mapper.GetCreateStatement(userXcompany);
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

        public T RetrieveCompanyById<T>(string entity)
        {

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveComapanyByIdStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);

        }

        public List<T> RetrieveCompanybyISa<T>(String entityId)
        {
            var lstUsuarioXOrganizacion = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveComapanyByIdStatement(entityId));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsuarioXOrganizacion.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUsuarioXOrganizacion;
        }

        public List<T> RetrieveAllByCompany<T>(int entityId)
        {
            var lstUsuarioXOrganizacion = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByOrgStatement(entityId));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsuarioXOrganizacion.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUsuarioXOrganizacion;
        }
        /*
                public List<T> RetrieveAllUsuarioRolByOrg<T>(int entityId)
                {
                    var lstUsuarioXOrganizacion = new List<T>();

                    var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveRolUsuarioByOrgStatement(entityId));
                    var dic = new Dictionary<string, object>();
                    if (lstResult.Count > 0)
                    {
                        var objs = mapper.BuildObjects2(lstResult);
                        foreach (var c in objs)
                        {
                            lstUsuarioXOrganizacion.Add((T)Convert.ChangeType(c, typeof(T)));
                        }
                    }

                    return lstUsuarioXOrganizacion;
                }

        */
        public List<T> RetrieveAllByIdUser<T>(BaseEntity entity)
        {
            var lstUsuarioXOrganizacions = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByCedulaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsuarioXOrganizacions.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUsuarioXOrganizacions;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsuarioXOrganizacions = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsuarioXOrganizacions.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUsuarioXOrganizacions;
        }

        public override void Update(BaseEntity entity)
        {
            var userXcompany = (User_Company)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(userXcompany));
        }

        public override void Delete(BaseEntity entity)
        {
            var userXcompany = (User_Company)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(userXcompany));
        }
    }
}
