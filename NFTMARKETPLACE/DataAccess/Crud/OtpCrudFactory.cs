using DataAccess.Dao;
using DataAccess.Mapper;
using DTO_POJOS;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class OtpCrudFactory : CrudFactory
    {
        private OtpMapper otpMapper;
        private SqlOperation sqlOperation;



        public OtpCrudFactory()
        {
            dao = SqlDao.GetInstance();
            otpMapper = new OtpMapper();
        }

        public override void Create(BaseEntity entity)
        {

        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            sqlOperation = otpMapper.GetUpdateStatement(entity);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
