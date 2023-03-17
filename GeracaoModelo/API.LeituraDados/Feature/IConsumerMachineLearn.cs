using API.LeituraDados.Classes;
using API.LeituraDados.Classes.ObterValidadeSinal;
using API.LeituraDados.Classes.ObterValor;

namespace API.LeituraDados.Feature
{
    public interface IConsumerMachineLearn
    {
        Task<ResponseObterValor> ObterValorAtivo(ParametrosObterValor parametros);
        Task<ResponseValidadeSinal> ObterValidadeSinal(ParametroValidadeSinal parametros);
    }
}
