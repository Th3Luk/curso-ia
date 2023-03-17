using API.LeituraDados.Classes;
using API.LeituraDados.Classes.ObterValidadeSinal;
using API.LeituraDados.Classes.ObterValor;
using API.LeituraDados.Feature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.LeituraDados.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaValorController : ControllerBase
    {

        private readonly ILogger<ConsultaValorController> _logger;
        private readonly IConsumerMachineLearn _consumerMachineLearn;

        public ConsultaValorController(ILogger<ConsultaValorController> logger, IConsumerMachineLearn consumerMachineLearn)
        {
            _logger = logger;
            _consumerMachineLearn = consumerMachineLearn;
        }
        
        [HttpGet("obter-valor-automatizado")]
        [Authorize]
        public async Task<ResponseObterValor> ObterValorIAAutomatica([FromQuery] ParametrosObterValor parametros)
        {
            return await _consumerMachineLearn.ObterValorAtivo(parametros);
        }


        [HttpGet("obter-validade-sinal")]
        [Authorize]
        public async Task<ResponseValidadeSinal> ObterValidadeSinal([FromQuery] ParametroValidadeSinal parametros)
        {
            return await _consumerMachineLearn.ObterValidadeSinal(parametros);
        }
    }
}