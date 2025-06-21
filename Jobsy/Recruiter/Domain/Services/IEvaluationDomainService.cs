using Jobsy.Recruiter.Domain.Model.Aggregates;

namespace Jobsy.Recruiter.Domain.Services;

public interface IEvaluationDomainService
{
    bool IsValidEvaluation(Evaluation evaluation);
}