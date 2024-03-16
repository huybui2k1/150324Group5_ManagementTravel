namespace ManagementTravel_API.BusinessObjects.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
