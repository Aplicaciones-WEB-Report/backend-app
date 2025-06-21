using Jobsy.Recruiter.Domain.Model.Commands.EvaluationCommands;
using Jobsy.Recruiter.Interfaces.Rest.Resources;


namespace Jobsy.Recruiter.Interfaces.Rest.Transform;
public static class CreateEvaluationCommandFromResourceAssembler
{
    public static CreateEvaluationCommand ToCommandFromResource(CreateEvaluationResource resource) =>
        new CreateEvaluationCommand(
            resource.InterviewId,
            resource.CandidateId,
            resource.Rating,
            resource.Comments,
            resource.EvaluationDate);
}
