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
            SenderId,
            NftId,
            SenderName,
            NftImage,
            NftName
        }

        private SqlOperation sqlOperation;

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
                SentDate = GetDateValue(row,RowNames.SentDate.ToString()),
                SenderName = GetStringValue(row, RowNames.SenderName.ToString()),
                Nft = new NFTC()
                {
                    Id = GetStringValue(row, RowNames.NftId.ToString()),
                    Image = GetStringValue(row, RowNames.NftImage.ToString()),
                    NftName = GetStringValue(row, RowNames.NftName.ToString())
                }
            };
            return notification;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "CRE_NOTIF_PR"
            };
            var notif = (Notifications)entity;
            sqlOperation.AddVarcharParam(RowNames.Msj.ToString(), notif.Msj);
            sqlOperation.AddVarcharParam(RowNames.ReceiverId.ToString(), notif.ReceiverId);
            sqlOperation.AddVarcharParam(RowNames.SenderId.ToString(), notif.SenderId);
            sqlOperation.AddDateTimeParam(RowNames.SentDate.ToString(), notif.SentDate);
            sqlOperation.AddVarcharParam(RowNames.NftId.ToString(), notif.Nft.Id);
            return sqlOperation;
        }

        public SqlOperation GetRetriveAllByReciver(BaseEntity entity)
        {
            var notif = (Notifications)entity;
            var operation = new SqlOperation { ProcedureName = "RET_NOTIF_FROM_OFFER_PR" };
            operation.AddVarcharParam(RowNames.ReceiverId.ToString(), notif.ReceiverId);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            sqlOperation = new SqlOperation()
            {
                ProcedureName = "DEL_NOTIF_RECIVER_PR"
            };

            var notif = (Notifications)entity;
            sqlOperation.AddVarcharParam(RowNames.ReceiverId.ToString(), notif.ReceiverId);
            sqlOperation.AddSmallIntParam(RowNames.Id.ToString(), notif.Id);
            return sqlOperation;
        }

        //not in use
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        //not in use
        public SqlOperation GetRetriveAllStatement()
        {
            return null;
        }

        //not in used
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}