using EnviosAPI.DTOs;
using EnviosAPI.Models;
using EnviosAPI.Repositories;

namespace EnviosAPI.Services
{
    public class EnviosService : IEnviosService
    {
        private readonly IEnviosRepository _repo;
        public EnviosService(IEnviosRepository repo) => _repo = repo;

        public async Task<IEnumerable<EnviosDTO>> ListAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(o => new EnviosDTO(o.Id, o.Destinatario, o.Direccion, o.Distancia, o.Peso, o.Estado.ToString(), o.Urgencia.ToString(), o.Costo));
        }

        public async Task<EnviosDTO?> GetAsync(int id)
        {
            var o = await _repo.GetByIdAsync(id);
            return o is null ? null : new EnviosDTO(o.Id, o.Destinatario, o.Direccion, o.Distancia, o.Peso, o.Estado.ToString(), o.Urgencia.ToString(), o.Costo);
        }

        public async Task<EnviosDTO> CreateAsync(CreateEnviosDTO dto)
        {
            using var client = new HttpClient();

            var url = $"http://localhost:5005/calcularCosto?peso={dto.Peso}&distancia={dto.Distancia}&esUrgente={dto.EsUrgente}";

            double costoCalculado = 0;

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadFromJsonAsync<CostoResultado>();
                    costoCalculado = resultado?.CostoTotal ?? 0;
                }
            }
            catch (Exception)
            {
                costoCalculado = 0;
            }
            var envios = new Envios
            {
                Destinatario = dto.Destinatario,
                Direccion = dto.Direccion,
                Distancia = dto.Distancia,
                Peso = dto.Peso,
                Estado = EnviosState.Pendiente,
                Urgencia = dto.EsUrgente ? UrgenciaEnvio.Urgente : UrgenciaEnvio.Normal,
                Costo = costoCalculado
            };

            await _repo.AddAsync(envios);

            return new EnviosDTO(
                envios.Id,
                envios.Destinatario,
                envios.Direccion,
                envios.Distancia,
                envios.Peso,
                envios.Estado.ToString(),
                envios.Urgencia.ToString(),
                envios.Costo
            );
        }

        public async Task<bool> UpdateStateAsync(int id, EnviosState newState)
        {
            var envios = await _repo.GetByIdAsync(id);
            if (envios == null) return false;

            envios.Estado = newState;

            await _repo.UpdateAsync(envios);
            return true;
        }
        public class CostoResultado
        {
            public double CostoTotal { get; set; }
        }

    }
}
