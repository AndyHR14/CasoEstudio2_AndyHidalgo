using EnvíosWEB.Models;
using EnvíosWEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnvíosWEB.Controllers
{
    public class EnviosController : Controller
    {
        private readonly IEnviosAPIClient _api;

        public EnviosController(IEnviosAPIClient api) => _api = api;

        public async Task<IActionResult> Index()
        {
            var envios = await _api.GetEnviosAsync();

            return View(envios ?? new List<EnviosViewModel>());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Destinatario, string Direccion, double Distancia, double Peso, bool EsUrgente)
        {
            if (string.IsNullOrWhiteSpace(Destinatario) || string.IsNullOrWhiteSpace(Direccion) || Distancia <= 0 || Peso <= 0) return BadRequest("Todos los campos son requeridos y deben ser mayores a 0");
            await _api.CreateOrderAsync(Destinatario, Direccion, Distancia, Peso, EsUrgente);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string newState)
        {
            await _api.UpdateStateAsync(id, newState);
            return RedirectToAction(nameof(Index));
        }

    }

}