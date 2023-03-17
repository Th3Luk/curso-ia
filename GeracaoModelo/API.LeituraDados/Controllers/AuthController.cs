using API.LeituraDados.Classes;
using API.LeituraDados.Classes.ObterValidadeSinal;
using API.LeituraDados.Classes.ObterValor;
using API.LeituraDados.Feature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.LeituraDados.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<ConsultaValorController> _logger;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<ConsultaValorController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        
        [HttpPost("CreateToken")]
        public IActionResult CreateToken(string usuario, string senha)
        {
            if (usuario != "lucas" || senha != "lucas")
                return Unauthorized("Credenciais inválidas");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
             {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, "lucas"),
                new Claim(JwtRegisteredClaimNames.Email, "teste"),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials
             (new SymmetricSecurityKey(key),
             SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(token));
        }
    }
}