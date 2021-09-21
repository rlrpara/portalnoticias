using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Services.Interfaces;
using PortalNoticias.Services.ViewModels;
using System;
using System.Linq;

namespace PortalNoticias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IBaseService<Categoria> _service;

        public CategoriaController(IBaseService<Categoria> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAll());
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
                return Ok(_service.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post([FromBody] CategoriaViewModel entidade)
        {
            try
            {
                if (ModelState.IsValid)
                    return Created($"api/{RouteData.Values.First().Value}", _service.Insert(entidade));

                return BadRequest($"Classe inválida: {ModelState}");
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
                    if (_service.GetById(entidade.Codigo.ToString()) == null)
                        return NotFound();

                    return Ok(_service.Put(entidade));
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

                if (_service.GetById(usuarioLogadoId.ToString()) == null)
                    return NotFound();

                return Ok(_service.Delete(usuarioLogadoId.ToString()));
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
                return Ok(_service.Authenticate(entidade));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
