namespace DTO_POJOS
{
    public class Notifications: BaseEntity
    {
        public int Id { get; set; }
        public string Msj { get; set; }
        public string SentDate { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }

    }
}