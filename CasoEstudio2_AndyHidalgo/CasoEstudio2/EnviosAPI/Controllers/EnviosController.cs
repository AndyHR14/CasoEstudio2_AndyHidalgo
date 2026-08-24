using EnviosAPI.DTOs;
using EnviosAPI.Models;
using EnviosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnviosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnviosController : ControllerBase
    {
        private readonly IEnviosService _svc;
        public EnviosController(IEnviosService svc) => _svc = svc;

        [HttpGet]
        public async Task<IEnumerable<EnviosDTO>> Get() => await _svc.ListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<EnviosDTO>> Get(int id)
        {
            var o = await _svc.GetAsync(id);
            if (o is null) return NotFound();
            return Ok(o);
        }

        [HttpPost]
        public async Task<ActionResult<EnviosDTO>> Create(CreateEnviosDTO dto)
        {
            var created = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(int id, EnviosState newState)
        {
            var ok = await _svc.UpdateStateAsync(id, newState);
            if (!ok) return BadRequest();
            return NoContent();
        }
    }
}
