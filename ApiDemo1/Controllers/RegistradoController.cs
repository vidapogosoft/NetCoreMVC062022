using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Interfaces;
using ApiDemo1.Modelos.Database;

using Microsoft.AspNetCore.Authorization;


namespace ApiDemo1.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistradoController : ControllerBase
    {

        private readonly IRegistrados _register;


        public RegistradoController(IRegistrados ireg)
        {

            _register = ireg;
        }

        /// <summary>
        /// Metodo de consulta
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_register.ListRegistrados);

        }

        /// <summary>
        /// Metodo de consulta
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("dto")]
        public IActionResult GetDTO()
        {

            return Ok(_register.ListDTORegistrados);

        }

        /// <summary>
        /// Metodo de consulta
        /// </summary>
        /// <returns></returns>
        [HttpGet("sp")]
        public IActionResult GetSP()
        {

            return Ok(_register.ListSPRegistrados);

        }

        [HttpGet("{Identificacion}")]
        public IActionResult GetByIdentificacion(string Identificacion)
        {

            return Ok(_register.ListRegistrado(Identificacion));

        }


        [HttpGet("Id/{IdRegistrado}")]
        public IActionResult GetById(int IdRegistrado)
        {

            return Ok(_register.ListRegistradoById(IdRegistrado));

        }


        [HttpGet("Datos2/{IdRegistrado}", Name = "Get4")]
        public IActionResult GetDatosRoute2(int IdRegistrado)
        {
            return Ok(_register.ListDatoRegistrado2(IdRegistrado));
        }

        /// <summary>
        /// metodo de registro de datos
        /// </summary>
        /// <param name="NewItem"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Create ([FromBody] Registrados NewItem)
        {
            try
            {
                if(NewItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el ingreso de datos
                _register.InsertRegistrado(NewItem);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok(NewItem);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Registrados UpdItem)
        {
            try
            {
                if (UpdItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el ingreso de datos
                _register.UpdateRegistrado(UpdItem);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return NoContent();
        }


        [HttpPut("update2")]
        public IActionResult Update2([FromBody] Registrados UpdItem)
        {
            try
            {
                if (UpdItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el ingreso de datos
                _register.UpdateRegistrado2(UpdItem);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Registrados DelItem)
        {
            try
            {
                if (DelItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el ingreso de datos
                _register.DeleteRegistrado(DelItem);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("delete2/{IdRegistrado}")]
        public IActionResult Delete2(int IdRegistrado)
        {
            try
            {
              
                //continuo con el ingreso de datos
                _register.DeleteRegistrado2(IdRegistrado);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return NoContent();
        }
    }
}
