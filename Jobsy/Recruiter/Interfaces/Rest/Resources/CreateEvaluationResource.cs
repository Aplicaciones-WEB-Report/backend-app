using System.ComponentModel.DataAnnotations;

namespace Jobsy.Recruiter.Interfaces.Rest.Resources;

public record CreateEvaluationResource(
    int InterviewId,
    int CandidateId,
    decimal Rating,
    string Comments,
    DateTime EvaluationDate);