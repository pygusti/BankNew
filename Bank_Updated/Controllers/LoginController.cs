using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank_Updated.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BankContext _bankcontext;

        private readonly IConfiguration _config;

        public LoginController(BankContext context, IConfiguration config)
        {
            _bankcontext = context;
            _config = config;
        }
        // GET: api/<LoginController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginmodel)
        {
            var token="";
            try
            {
               var tempUser = _bankcontext.userModels.FirstOrDefault(u => u.Email == loginmodel.Email && u.Password == loginmodel.Password);


                if (tempUser == null)
                {
                    return BadRequest("USER NOT FOUND");
                }
                else
                {
                    try
                    {
                        token = GenerateToken(tempUser);
                    }
                    catch (Exception ex)
                    {
                        BadRequest(ex.Message);
                    }
                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [NonAction]
        public string GenerateToken(UserModel user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
        
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

              var  token = new JwtSecurityToken(
                        issuer: _config["JWT:ValidIssuer"],
                        audience: _config["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: claims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );


            return new JwtSecurityTokenHandler().WriteToken(token);


        }


        
    }
}
