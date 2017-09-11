using System.Security.Claims;

namespace Demo.Api.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}