using System.Net.Mime;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Commands;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Queries;
using Jobsy.Postulant.CandidateAuthentication.Domain.Services;
using Jobsy.Postulant.CandidateAuthentication.Interfaces.REST.Resources;
using Jobsy.Postulant.CandidateAuthentication.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobsy.Postulant.CandidateAuthentication.Interfaces.REST;

/// <summary>
/// Candidate profiles controller.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Candidate Profiles")]
public class CandidateProfilesController(
    ICandidateProfileCommandService commandService,
    ICandidateProfileQueryService queryService)
    : ControllerBase
{
    // POST: api/v1/CandidateProfiles
    [HttpPost]
    [SwaggerOperation(Summary = "Create a candidate profile", OperationId = "CreateCandidateProfile")]
    [SwaggerResponse(201, "The candidate profile was created", typeof(CandidateProfileResource))]
    [SwaggerResponse(400, "The candidate profile was not created")]
    public async Task<ActionResult> Create([FromBody] CreateCandidateProfileResource resource)
    {
        var command = CreateCandidateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        var response = CandidateProfileResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, response);
    }

    // GET: api/v1/CandidateProfiles
    [HttpGet]
    [SwaggerOperation(Summary = "Get all candidate profiles", OperationId = "GetAllCandidateProfiles")]
    [SwaggerResponse(200, "Candidate profiles found", typeof(IEnumerable<CandidateProfileResource>))]
    public async Task<ActionResult> GetAll()
    {
        var query = new GetAllCandidateProfilesQuery();
        var result = await queryService.Handle(query);
        var resources = result.Select(CandidateProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // GET: api/v1/CandidateProfiles/{id}
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a candidate profile by ID", OperationId = "GetCandidateProfileById")]
    [SwaggerResponse(200, "Candidate profile found", typeof(CandidateProfileResource))]
    [SwaggerResponse(404, "Candidate profile not found")]
    public async Task<ActionResult> GetById(int id)
    {
        var query = new GetCandidateProfileByIdQuery(id);
        var result = await queryService.Handle(query);
        if (result is null) return NotFound();
        var resource = CandidateProfileResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    // PUT: api/v1/CandidateProfiles/{id}
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update a candidate profile", OperationId = "UpdateCandidateProfile")]
    [SwaggerResponse(204, "Candidate profile updated")]
    [SwaggerResponse(404, "Candidate profile not found")]
    public async Task<ActionResult> Update(int id, [FromBody] CreateCandidateProfileResource resource)
    {
        var command = new UpdateCandidateProfileCommand(id, resource.Name, resource.PublicationNumber, resource.CV, resource.Posible);
        var result = await commandService.Handle(command);
        if (!result) return NotFound();
        return NoContent();
    }

    // DELETE: api/v1/CandidateProfiles/{id}
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a candidate profile", OperationId = "DeleteCandidateProfile")]
    [SwaggerResponse(204, "Candidate profile deleted")]
    [SwaggerResponse(404, "Candidate profile not found")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCandidateProfileCommand(id);
        var result = await commandService.Handle(command);
        if (!result) return NotFound();
        return NoContent();
    }
}