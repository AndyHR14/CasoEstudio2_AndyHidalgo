using EnvíosWEB.Models;

namespace EnvíosWEB.Services
{
    public class EnviosAPIClient : IEnviosAPIClient
    {
        private readonly HttpClient _http;

        public EnviosAPIClient(HttpClient http) => _http = http;

        public async Task<List<EnviosViewModel>> GetEnviosAsync(CancellationToken cancellation = default)
        {
            var response = await _http.GetAsync("api/Envios", cancellation);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la API: {response.StatusCode}. Detalle: {errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<List<EnviosViewModel>>(cancellationToken: cancellation)
                   ?? new List<EnviosViewModel>();
        }
        public async Task CreateOrderAsync(string Destinatario, string Direccion, double Distancia, double Peso, bool EsUrgente, CancellationToken cancellation = default)
        {
            var dto = new { Destinatario = Destinatario, Direccion = Direccion, Distancia = Distancia, Peso = Peso, EsUrgente = EsUrgente };

            var response = await _http.PostAsJsonAsync("api/Envios", dto, cancellation);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error 500 en API: {error}");
            }
        }

        public async Task UpdateStateAsync(int id, string newState, CancellationToken cancellation = default)
        {
            await _http.PostAsync($"api/Envios/{id}/update?newState={newState}", null, cancellation);
        }
    }
}