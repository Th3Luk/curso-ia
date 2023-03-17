using Newtonsoft.Json;

namespace API.LeituraDados.Classes.ObterValidadeSinal
{
    public class GlobalParameters
    {
    }

    public class RequestObterValidadeSinal
    {
        public RequestObterValidadeSinal(ListaParametrosValidadeSinal inputs)
        {
            Inputs = inputs;
            GlobalParameters = new GlobalParameters();
        }
        [JsonProperty("Inputs")]
        public ListaParametrosValidadeSinal Inputs { get; set; }
        public GlobalParameters GlobalParameters { get; set; }
    }

    public class ListaParametrosValidadeSinal
    {
        public ListaParametrosValidadeSinal(List<ParametroValidadeSinal> listaParametros)
        {
            ListaParametros = listaParametros;
        }

        [JsonProperty("input1")]
        public List<ParametroValidadeSinal> ListaParametros { get; set; }
    }

    public class ParametroValidadeSinal
    {
        [JsonProperty("Tipo entrada")]
        public string TipoEntrada { get; set; }
        public double ATR { get; set; }
        public double RSI { get; set; }
        public bool VOLUME { get; set; }
        [JsonProperty("Med 9")]
        public bool Med9 { get; set; }
        [JsonProperty("Med 21")]
        public bool Med21 { get; set; }
        public bool med200 { get; set; }
    }
}
