using EnviosAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EnviosAPI.Repositories
{
    public interface IEnviosRepository
    {
        Task<IEnumerable<Envios>> GetAllAsync();
        Task<Envios?> GetByIdAsync(int id);
        Task AddAsync(Envios envios);
        Task UpdateAsync(Envios envios);
    }
}
