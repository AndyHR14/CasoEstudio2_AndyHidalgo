using EnvíosWEB.Models;

namespace EnvíosWEB.Services
{
    public interface IEnviosAPIClient
    {
        Task<List<EnviosViewModel>> GetEnviosAsync(CancellationToken cancellation = default);
        Task CreateOrderAsync(string Destinatario, string Direccion, double Distancia, double Peso, bool EsUrgente, CancellationToken cancellation = default);
        Task UpdateStateAsync(int id, string newState, CancellationToken cancellation = default);
    }
}
