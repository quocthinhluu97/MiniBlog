using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MiniBlog.Server.Controllers
{
    public class LoginController : Controller
    {
        public IConfiguration Configuration { get; }

        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDetails loginDetails)
        {
            if (loginDetails.Username == "admin" && loginDetails.Password == "admin")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, loginDetails.Username)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt")["JwtSecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(Convert.ToInt32(Configuration.GetSection("Jwt")["JwtExpiryInDays"]));
                var token = new JwtSecurityToken(
                    Configuration.GetSection("Jwt")["JwtIssuer"],
                    Configuration.GetSection("Jwt")["JwtIssuer"],
                    claims,
                    expires: expiry,
                    signingCredentials: creds
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {
                return BadRequest("Username or password invalid");
            }
        }
    }
}
