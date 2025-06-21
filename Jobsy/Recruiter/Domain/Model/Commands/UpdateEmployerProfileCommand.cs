using Jobsy.Recruiter.Domain.Model.ValueObjects;
using MediatR;
using System.Text.Json.Serialization;

namespace Jobsy.Recruiter.Domain.Model.Commands;

public record UpdateEmployerProfileCommand(
    [property: JsonIgnore] int Id,
    string CompanyName,
    CompanySize CompanySize,
    string? Website,
    string? Description
) : IRequest;