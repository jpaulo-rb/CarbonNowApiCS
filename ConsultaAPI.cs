using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Net;
using CarbonNow.Types;
using System.Text.Json.Serialization;

namespace CarbonNow {
    public class ConsultaAPI {

        #region Configurações
        // Opcional: Ocultar apikey em algum arquivo e fazer a leitura dele.
        private static readonly string _apiKey = "SUA API KEY AQUI";

        private static readonly HttpClient _client = new() {
            DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", _apiKey) }
        };
        #endregion

        // Método principal, que irá receber algum modelo, fazer a consulta e retornar com o cálculo d CO2
        // TModel = tipagem genérica, irá aceitar qualquer tipagem de dados
        public async static Task<Estimate.ApiResponse<TModel>> CalcCO2<TModel>(TModel typeModel) {

            var content = new StringContent(JsonSerializer.Serialize(typeModel), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://www.carboninterface.com/api/v1/estimates", content);

            var result = await response.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<Estimate.ApiResponse<TModel>>(result);

            if (response.IsSuccessStatusCode) {
                Console.WriteLine("Sucesso ao calcular CO2. "); //{typeof(TModel).Name}"
                return model ?? throw new Exception($"Modelo {typeof(TModel)} retornado vazio!");
            } else if (response.StatusCode == HttpStatusCode.TooManyRequests) {
                throw new Exception("Limites de requisições atigindas");
            } else {
                throw new Exception($"Falha ao calcular CO2 - Status: {response.StatusCode} Resposta: {result}");
            }
        }

        // Buscar os veículos para utilizar no Vehicle
        public async static Task<List<VehicleModel>> GetVehicleModel() {
            var response = await _client.GetAsync("https://www.carboninterface.com/api/v1/vehicle_makes");

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                Console.WriteLine("Sucesso ao consultar veículos");
                List<VehicleModel> vehicles = JsonSerializer.Deserialize<List<VehicleModel>>(result) ??
                    throw new Exception("Falha na consulta, lista vazia!");
                return vehicles;
            } else {
                throw new Exception($"Falha ao consultar veículos - Status: {response.StatusCode}");
            }
        }

        // Get por id das estimativas, não funciona
        public async static Task GetEstimate() {
            var response = await _client.GetAsync("https://www.carboninterface.com/api/v1/e06bc26b-874e-4594-a09f-9177c6fee658");

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                Console.WriteLine("Sucesso ao consultar estimativa - " + result);
            } else {
                throw new Exception($"Falha ao consultar - Status: {response.StatusCode}");
            }
        }

        // Teste de validação da api key
        public async static Task ValidAuth() {
            var response = await _client.GetAsync("https://www.carboninterface.com/api/v1/auth");

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                Console.WriteLine("Sucesso ao autenticar - " + result);

            } else {
                throw new Exception($"Falha ao autenticar - Status: {response.StatusCode} Resposta: {result}");
            }
        }
    }
}
