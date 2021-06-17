using Microsoft.AspNetCore.Mvc;
using PortalNoticias.Services.Interfaces;
using PortalNoticias.Services.ViewModels;
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
        public IActionResult Post([FromBody] UsuarioViewModel entidade)
        {
            try
            {
                if (ModelState.IsValid)
                    return Created($"api/{RouteData.Values.First().Value}", _usuarioService.Post(entidade));

                return BadRequest("Classe inválida");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("")]
        public IActionResult Put([FromBody] UsuarioViewModel entidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_usuarioService.GetById(entidade.Codigo) == null)
                        return NotFound();

                    return Ok(_usuarioService.Put(entidade));
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
                if (_usuarioService.GetById(id) == null)
                    return NotFound();

                return Ok(_usuarioService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserAuthenticateRequestViewModel entidade)
        {
            try
            {
                return Ok(_usuarioService.Authenticate(entidade));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
