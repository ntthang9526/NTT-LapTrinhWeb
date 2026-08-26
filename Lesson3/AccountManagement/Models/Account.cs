namespace AccountManagement.Models
{
    public class Account
    {
        public int ID { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }
        public String? Phone { get; set; }
        public String? Avatar { get; set; }
        public String? Address { get; set; }
        public String? Bio { get; set; }
        public int Gender { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
