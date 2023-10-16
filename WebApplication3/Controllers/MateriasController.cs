﻿using Microsoft.AspNetCore.Mvc;
using WebApplication3.Contexto;
using WebApplication3.Modelo;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriasController : ControllerBase
    {

            private readonly ILogger<MateriasController> _logger;
            private readonly AplicacionContexto _aplicacionContexto;

            public MateriasController(ILogger<MateriasController> logger, AplicacionContexto aplicacionContexto)
            {
                _logger = logger;
                _aplicacionContexto = aplicacionContexto;
            }
            [Route("")]
            [HttpGet]
            public IEnumerable<Materias> GET()
            {
                return _aplicacionContexto.materias.ToList();
            }

            [Route("")]
            [HttpPost]
            public IActionResult POST([FromBody] Materias newMateria)
            {
                _aplicacionContexto.materias.Add(newMateria);
                _aplicacionContexto.SaveChanges();
                return Ok(newMateria);
            }

            [Route("")]
            [HttpPut]
            public IActionResult PUT([FromBody] Materias updateMateria)
            {
                _aplicacionContexto.materias.Update(updateMateria);
                _aplicacionContexto.SaveChanges();
                return Ok(updateMateria);
            }

            [Route("")]
            [HttpDelete]
            public IActionResult DELETE(int idMateriaDelete)
            {
                _aplicacionContexto.materias.Remove(_aplicacionContexto.materias.ToList().Where(x => x.idMateria == idMateriaDelete).FirstOrDefault());
                _aplicacionContexto.SaveChanges();
                return Ok(idMateriaDelete);
            }

        }
    
}