using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;

namespace DataAccess.Crud
{
    public class WalletFactory : CrudFactory
    {
        private WalletMapper walletMapper;
        private SqlOperation sqlOperation;
        private Wallet wallet;


        public WalletFactory()
        {
            dao = SqlDao.GetInstance();
            walletMapper = new WalletMapper();
        }

        public override void Create(BaseEntity entity)
        {

            sqlOperation = walletMapper.GetCreateStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(walletMapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = walletMapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new System.NotImplementedException();
        }

        //this method is only used to update the id of the company 
        public override void Update(BaseEntity entity)
        {
            //var obj = (Wallet)entity;
            dao.ExecuteProcedure(walletMapper.GetUpdateStatement(entity));
        }

        //add the amount of the parameter with the actual amount
        public void UpdateAddAmount(BaseEntity entity)
        {
            dao.ExecuteProcedure(walletMapper.GetUpdateAddAmount(entity));
        }

        //rest the amount of the parameter with the actual amount
        public void UpdateRestAmount(BaseEntity entity)
        {
            dao.ExecuteProcedure(walletMapper.GetUpdateRestAmount(entity));
        }

        public override void Delete(BaseEntity entity)
        {
            dao.ExecuteProcedure(walletMapper.GetDeleteStatement(entity));
        }
    }
}