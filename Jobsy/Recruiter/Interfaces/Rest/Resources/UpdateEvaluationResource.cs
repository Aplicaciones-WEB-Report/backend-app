namespace Jobsy.Recruiter.Interfaces.Rest.Resources;

public record UpdateEvaluationResource(
    decimal Rating,
    string Comments,
    DateTime EvaluationDate);