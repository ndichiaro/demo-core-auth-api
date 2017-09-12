using Demo.Api.Models;
using Demo.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private IUserManager _userManager;
        
        public AuthenticationController(IUserManager userManager)
        {
            _userManager = userManager;

        }
        
        [HttpPost]
        public IActionResult Post([FromBody] RegistrationViewModel model)
        {
            var result = _userManager?.CreateUser(model.FirstName, model.LastName, model.Email, model.Password);
            return Ok(new{ FirstName = result.FirstName, LastName = result.LastName, Email = result.Email});
        }
    }
}