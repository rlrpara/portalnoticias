using Microsoft.AspNetCore.Mvc;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Services.Interfaces;
using System;
using System.Linq;

namespace PortalNoticias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                return Ok(_usuarioService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario entidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resultado = _usuarioService.Adicionar(entidade);
                    return Created($"api/{RouteData.Values.First().Value}", resultado);
                }

                return BadRequest("Classe inválida");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario entidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_usuarioService.BuscarTodosPorId<Usuario>(id) == null)
                        return NotFound();

                    _usuarioService.Atualizar(id, entidade);

                    return Ok(id);
                }

                return BadRequest("Classe inválida");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_usuarioService.BuscarTodosPorId<Usuario>(id) == null)
                    return NotFound();

                _usuarioService.Excluir<Usuario>(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
