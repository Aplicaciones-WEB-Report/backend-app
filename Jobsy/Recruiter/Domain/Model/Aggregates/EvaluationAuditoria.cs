namespace Jobsy.Recruiter.Domain.Model.Aggregates
{
    public class EvaluationAuditoria
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}