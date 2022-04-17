using DataAccess.Dao;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    enum RowNamesOtp
    {
        Code
    }
    public class OtpMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private SqlOperation slqOperation;


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            slqOperation = new SqlOperation()
            {
                ProcedureName = "UPD_OTP_PR"
            };
            var obj = (Otp)entity;
            slqOperation.AddIntParam(RowNamesOtp.Code.ToString(), obj.Code);

            return slqOperation;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new NotImplementedException();
        }


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }


    }
}
