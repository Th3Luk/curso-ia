using Newtonsoft.Json;

namespace API.LeituraDados.Classes.ObterValor
{
    public class ResultadoValidadeSinal
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
        [JsonProperty("Scored Labels")]
        public bool ScoredLabels { get; set; }
        [JsonProperty("Scored Probabilities")]
        public double ScoredProbabilities { get; set; }
    }

    public class ResultadosValidadeSinal
    {
        [JsonProperty("WebServiceOutput1")]
        public List<ResultadoValidadeSinal> Resultados { get; set; }
    }

    public class ResponseValidadeSinal
    {
        [JsonProperty("Results")]
        public ResultadosValidadeSinal Resultado { get; set; }
    }
}
