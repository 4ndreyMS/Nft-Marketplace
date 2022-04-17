namespace DTO_POJOS
{
    public class UserRole : BaseEntity
    {
        public string UserId { get; set;}
        public int RoleId { get; set;}
        public User User { get; set;}
    }
}