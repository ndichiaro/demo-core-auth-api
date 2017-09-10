using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Demo.Api.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Demo.Api.Models;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IOptions<TokenSettings> _tokenSettings;

        public TokenController(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = model.Email == "ndichiaro@gmail.com";
                
                if (result)
                {
            
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
            
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Value.Key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
                    var token = new JwtSecurityToken(_tokenSettings.Value.Issuer,
                    _tokenSettings.Value.Issuer,
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
            
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                
            }
            return BadRequest("Could not create token");
        }
    }
}