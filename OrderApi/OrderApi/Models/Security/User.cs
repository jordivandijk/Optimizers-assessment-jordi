using OrderApi.Models.Orders;
using OrderApi.Models.Requests;
using System.Diagnostics.CodeAnalysis;

namespace OrderApi.Models.Security
{
    public class User : Entity
    {
        public User() { }

        public User(CreateUserRequest request)
            : base(Guid.NewGuid())
        {
            Username = request.UserName;
            Password = request.Password;
            FullName = request.FullName;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        [AllowNull]
        public ICollection<Order>? Orders { get; set; }
    }
}
