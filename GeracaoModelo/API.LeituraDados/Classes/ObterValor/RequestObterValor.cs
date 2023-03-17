using Newtonsoft.Json;
using System.Security.Principal;

namespace API.LeituraDados.Classes.ObterValor
{
    public class ParametrosObterValor
    {
        public DateTime data { get; set; }
        public double ATR { get; set; }
        public double RSI { get; set; }
        public bool VOLUME { get; set; }
        [JsonProperty("Med 9")]
        public bool Med9 { get; set; }
        [JsonProperty("Med 21")]
        public bool Med21 { get; set; }
        public bool med200 { get; set; }
    }

    public class ListaParametrosObterValor
    {
        public ListaParametrosObterValor(List<ParametrosObterValor> listaParametros)
        {
            ListaParametros = listaParametros;         
        }

        [JsonProperty("data")]
        public List<ParametrosObterValor> ListaParametros { get; set; }        
    }

    public class RequestObterValor
    {
        public RequestObterValor(ListaParametrosObterValor parametros)
        {
            Parametros = parametros;
            GlobalParameters = 0;
        }
        [JsonProperty("Inputs")]
        public ListaParametrosObterValor Parametros { get; set; }
        public double GlobalParameters { get; set; }
    }

}
