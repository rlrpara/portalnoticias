﻿using Microsoft.AspNetCore.Mvc;
using PortalNoticias.Application.Interfaces;
using System;

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

        //[HttpGet("{id}")]
        //public IActionResult GetId(int id)
        //{
        //    try
        //    {
        //        return Ok(_baseService.BuscarTodosPorId<Usuario>(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody] Usuario entidade)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var resultado = _baseService.Adicionar(entidade);
        //            return Created($"api/{RouteData.Values.First().Value}", resultado);
        //        }

        //        return BadRequest("Classe inválida");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Usuario entidade)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (_baseService.BuscarTodosPorId<Usuario>(id) == null)
        //                return NotFound();

        //            _baseService.Atualizar(id, entidade);

        //            return Ok(_baseService.BuscarTodosPorId<Usuario>(id));
        //        }

        //        return BadRequest("Classe inválida");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        if (_baseService.BuscarTodosPorId<Usuario>(id) == null)
        //            return NotFound();

        //        _baseService.Excluir<Usuario>(id);

        //        return Ok(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}
    }
}
