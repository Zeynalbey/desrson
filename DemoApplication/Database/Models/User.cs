using DemoApplication.Database.Models.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DemoApplication.Database.Models
{
    public class User : BaseEntity<Guid>, IAuditable
    {
        internal EntityEntry<User> passwordHash;

        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Basket? Basket { get; set; }
    }
}
