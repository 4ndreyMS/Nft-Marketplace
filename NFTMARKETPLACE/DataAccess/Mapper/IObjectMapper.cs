using System.Collections.Generic;
using DTO_POJOS;

namespace DataAccess.Mapper
{
    interface IObjectMapper
    {
        List<BaseEntity> BuildObjects(List<Dictionary<string,object>> lstRows);
        BaseEntity BuildObject(Dictionary<string, object> row);
    }
}