using OrderApi.Models.Security;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models.Requests
{
    public class CreateUserRequest
    {
        public CreateUserRequest(User user)
        {
            UserName = user.Username;
            Password = user.Password;
            FullName = user.FullName;
        }

        public CreateUserRequest() { }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
