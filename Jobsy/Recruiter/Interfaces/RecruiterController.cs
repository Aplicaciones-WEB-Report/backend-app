using Jobsy.Recruiter.Domain.Model.Commands;
using Jobsy.Shared.Domain.Repositories; // Para IUnitOfWork
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobsy.Recruiter.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
public class RecruiterController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public RecruiterController(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    [HttpPost("profiles")]
    public async Task<IActionResult> CreateEmployerProfile([FromBody] CreateEmployerProfileCommand command)
    {
        try
        {
            var profileId = await _mediator.Send(command);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(CreateEmployerProfile), new { id = profileId }, new { message = "Perfil de empleador creado exitosamente.", id = profileId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // --- AÑADIR ENDPOINT DE ACTUALIZACIÓN (PUT) ---
    [HttpPut("profiles/{id:int}")]
    public async Task<IActionResult> UpdateEmployerProfile(int id, [FromBody] UpdateEmployerProfileCommand command)
    {
        // Creamos un nuevo comando con el ID de la URL.
        var updateCommand = command with { Id = id };
        
        try
        {
            await _mediator.Send(updateCommand);
            await _unitOfWork.CompleteAsync();
            return Ok(new { message = "Perfil de empleador actualizado exitosamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // --- AÑADIR ENDPOINT DE ELIMINACIÓN (DELETE) ---
    [HttpDelete("profiles/{id:int}")]
    public async Task<IActionResult> DeleteEmployerProfile(int id)
    {
        try
        {
            var command = new DeleteEmployerProfileCommand(id);
            await _mediator.Send(command);
            await _unitOfWork.CompleteAsync();
            return NoContent(); // HTTP 204: Éxito, sin contenido
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}