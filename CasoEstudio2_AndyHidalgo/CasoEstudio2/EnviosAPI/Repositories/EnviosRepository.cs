using EnviosAPI.Data;
using EnviosAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EnviosAPI.Repositories
{
    public class EnviosRepository : IEnviosRepository
    {
        private readonly AppDbContext _db;
        public EnviosRepository(AppDbContext db) => _db = db;
        public async Task<IEnumerable<Envios>> GetAllAsync()
    => await _db.Envios.AsNoTracking().ToListAsync();

        public async Task<Envios?> GetByIdAsync(int id)
            => await _db.Envios.FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(Envios envios)
        {
            _db.Envios.Add(envios);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Envios envios)
        {
            _db.Envios.Update(envios);
            await _db.SaveChangesAsync();
        }
    }
}
