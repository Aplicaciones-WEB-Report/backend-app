using Jobsy.UserAuthentication.Domain.Model.Commands;
using Jobsy.UserAuthentication.Domain.Model.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobsy.UserAuthentication.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> RegistrarUsuario([FromBody] RegisterUserCommand command)
    { 
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id }, new { id });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
    // Placeholder (puedes implementar esto luego con una Query real
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

}