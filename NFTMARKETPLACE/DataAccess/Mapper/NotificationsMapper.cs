using System;
using System.Collections.Generic;
using System.Threading;
using DataAccess.Dao;
using DTO_POJOS;

namespace DataAccess.Mapper
{
    public class NotificationsMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private enum RowNames
        {
            Id,
            Msj,
            SentDate,
            ReceiverId,
            SenderId
        }

        private SqlOperation slqOperation;

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            try
            {
                var lstResults = new List<BaseEntity>();

                foreach (var row in lstRows)
                {
                    var notif = BuildObject(row);
                    lstResults.Add(notif);
                }

                return lstResults;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var notification = new Notifications()
            {
                Id = GetIntValue(row,RowNames.Id.ToString()),
                Msj = GetStringValue(row, RowNames.Msj.ToString()),
                ReceiverId= GetStringValue(row, RowNames.ReceiverId.ToString()),
                SenderId= GetStringValue(row, RowNames.SenderId.ToString()),
                SentDate = GetDateValue(row,RowNames.SentDate.ToString())
            };

            return notification;
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