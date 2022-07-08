using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Identity.Services;
using Identity.Services.Post;
using MediatR;


namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(
            
            IMediator mediator

            )
        {
            _mediator = mediator;
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreatePost com)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(com);

                if (!result.Succeeded) 
                {
                    return BadRequest(result.Errors);
                }

            }

            return Ok();
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticaction(UserLoginPost com)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(com);

                if (!result.Succeeded)
                {
                    return BadRequest("Acceso denegado");
                }

                return Ok(result);

            }

            return BadRequest();

        }

    }
}
