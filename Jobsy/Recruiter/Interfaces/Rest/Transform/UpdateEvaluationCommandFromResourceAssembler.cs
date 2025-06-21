using Jobsy.Recruiter.Domain.Model.Aggregates;
using Jobsy.Recruiter.Domain.Model.Commands.EvaluationCommands;
using Jobsy.Recruiter.Interfaces.Rest.Resources;
namespace Jobsy.Recruiter.Interfaces.Rest.Transform;

/// <summary>
/// Assembles an UpdateEvaluationCommand from an UpdateEvaluationResource.
/// </summary>
public static class UpdateEvaluationCommandFromResourceAssembler
{
    /// <summary>
    /// Converts UpdateEvaluationResource to UpdateEvaluationCommand.
    /// </summary>
    /// <param name="resource">The UpdateEvaluationResource object.</param>
    /// <returns>UpdateEvaluationCommand</returns>
    public static UpdateEvaluationCommand ToCommandFromResource(UpdateEvaluationResource resource) =>
        new UpdateEvaluationCommand(
            resource.Rating,
            resource.Comments,
            resource.EvaluationDate
        );
}