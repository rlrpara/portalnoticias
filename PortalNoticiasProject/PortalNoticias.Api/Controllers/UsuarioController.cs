using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNoticias.Infra.CrossCutting.Auth.Services;
using PortalNoticias.Services.Interfaces;
using PortalNoticias.Services.ViewModels;
using System;
using System.Linq;
using System.Security.Claims;

namespace PortalNoticias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
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
        public IActionResult GetId(string id)
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

        [HttpPost, AllowAnonymous]
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

        [HttpPut]
        public IActionResult Put([FromBody] UsuarioViewModel entidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_usuarioService.GetById(entidade.Codigo.ToString()) == null)
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

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                int usuarioLogadoId = int.Parse(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));

                if (_usuarioService.GetById(usuarioLogadoId.ToString()) == null)
                    return NotFound();

                return Ok(_usuarioService.Delete(usuarioLogadoId.ToString()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("authenticate"), AllowAnonymous]
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
