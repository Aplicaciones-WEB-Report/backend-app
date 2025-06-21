using Jobsy.Recruiter.Domain.Model.Aggregates;

namespace Jobsy.Recruiter.Domain.Repositories;


public interface IEvaluationCommandRepository
{
    Task<Evaluation> AddAsync(Evaluation evaluation);
    Task<Evaluation> UpdateAsync(Evaluation evaluation);
    Task DeleteAsync(Evaluation evaluation);
}
