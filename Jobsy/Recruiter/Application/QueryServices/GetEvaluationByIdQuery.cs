namespace Jobsy.Recruiter.Application.QueryServices;

public class GetEvaluationByIdQuery
{
    public int Id { get; set; }

    public GetEvaluationByIdQuery(int id)
    {
        Id = id;
    }
}