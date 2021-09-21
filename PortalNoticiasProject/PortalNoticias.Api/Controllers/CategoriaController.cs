using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNoticias.Services.Services;
using PortalNoticias.Services.ViewModels;
using System;
using System.Linq;

namespace PortalNoticias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _service;

        public CategoriaController(CategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
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
                    return Created($"api/{RouteData.Values.First().Value}", _service.Inserir(entidade));

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
                    if (_service.GetById(entidade.Codigo) == null)
                        return NotFound();

                    return Ok(_service.Atualizar(entidade));
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
                if (_service.GetById(id) == null)
                    return NotFound();

                return Ok(_service.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
