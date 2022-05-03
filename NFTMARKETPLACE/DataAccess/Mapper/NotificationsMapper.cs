using System.Collections.Generic;
using DataAccess.Dao;
using DTO_POJOS;

namespace DataAccess.Mapper
{
    public class NotificationsMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new System.NotImplementedException();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}