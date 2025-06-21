namespace Jobsy.Recruiter.Domain.Model.Commands.EvaluationCommands;

public record CreateEvaluationCommand(
    int InterviewId,
    int CandidateId,
    decimal Rating,
    string Comments,
    DateTime EvaluationDate);