namespace Jobsy.Recruiter.Domain.Model.Commands.EvaluationCommands;

public record UpdateEvaluationCommand(
    decimal Rating,
    string Comments,
    DateTime EvaluationDate);