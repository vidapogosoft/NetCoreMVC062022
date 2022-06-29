using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using ApiDemo1.Interfaces;
using ApiDemo1.Modelos.Database;

namespace ApiDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {

        private readonly IDireccion _dir;

        public DireccionController(IDireccion ireg)
        {

            _dir = ireg;
        }

        [HttpGet("Id/{IdRegistrado}")]
        public IActionResult GetDireccionesByIdRegistrado(string IdRegistrado)
        {

            return Ok(_dir.GetDireccionesByIdRegistrado(IdRegistrado));

        }

        [HttpPost]
        public IActionResult Create([FromBody] Direcciones NewItem)
        {
            try
            {
                if (NewItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el ingreso de datos
                _dir.InsertDireccion(NewItem);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok(NewItem);
        }


    }
}
