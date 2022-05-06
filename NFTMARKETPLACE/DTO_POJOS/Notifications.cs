using System;
using System.Runtime.Remoting.Channels;

namespace DTO_POJOS
{
    public class Notifications: BaseEntity
    {
        public int Id { get; set; }
        public string Msj { get; set; }
        public DateTime SentDate { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }

        public NFTC Nft { get; set; }

    }
}