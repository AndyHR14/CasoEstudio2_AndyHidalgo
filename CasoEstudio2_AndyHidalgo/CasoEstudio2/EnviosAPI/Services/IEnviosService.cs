using EnviosAPI.DTOs;
using EnviosAPI.Models;

namespace EnviosAPI.Services
{
    public interface IEnviosService
    {
        Task<IEnumerable<EnviosDTO>> ListAsync();
        Task<EnviosDTO?> GetAsync(int id);
        Task<bool> UpdateStateAsync(int id, EnviosState newState);
        Task<EnviosDTO> CreateAsync(CreateEnviosDTO dto);
    }
}
