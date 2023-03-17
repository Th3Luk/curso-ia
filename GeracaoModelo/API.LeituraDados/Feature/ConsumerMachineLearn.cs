using API.LeituraDados.Classes;
using API.LeituraDados.Classes.ObterValidadeSinal;
using API.LeituraDados.Classes.ObterValor;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace API.LeituraDados.Feature
{

    public class ConsumerMachineLearn : IConsumerMachineLearn
    {
        public async Task<ResponseObterValor> ObterValorAtivo(ParametrosObterValor parametros)
        {
            RequestObterValor request = new RequestObterValor(new ListaParametrosObterValor(new List<ParametrosObterValor>() { parametros }));
            return JsonConvert.DeserializeObject<ResponseObterValor>(await ChamarMachineLearnAzure(request,
                "APcmGAtI2HdZ23lNF4k4ibosWzBdZD9z",
                "http://51ada938-6528-4ed5-883e-feef13198743.centralus.azurecontainer.io/score"));
        }

        public async Task<ResponseValidadeSinal> ObterValidadeSinal(ParametroValidadeSinal parametros)
        {
            RequestObterValidadeSinal request = new RequestObterValidadeSinal(new ListaParametrosValidadeSinal(new List<ParametroValidadeSinal>() { parametros }));
            return JsonConvert.DeserializeObject<ResponseValidadeSinal>(await ChamarMachineLearnAzure(request,
                "Ub8BOnabnRInXAK0Nl4mVIQ1Y6PqsnzM",
                "http://fe99a257-dee0-4086-948a-d3a5721f1e97.centralus.azurecontainer.io/score"));
        }

        private async Task<string> ChamarMachineLearnAzure(object request, string apiKey, string link)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            }; 
            using (var client = new HttpClient(handler))
            {                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri(link);

                var content = new StringContent(JsonConvert.SerializeObject(request));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));
                    Console.WriteLine(response.Headers.ToString());
                    throw new BadHttpRequestException(await response.Content.ReadAsStringAsync());                    
                }
            }
        }

    }
}