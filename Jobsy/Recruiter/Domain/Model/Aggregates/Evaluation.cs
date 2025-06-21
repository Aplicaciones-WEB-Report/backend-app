namespace Jobsy.Recruiter.Domain.Model.Aggregates
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public int CandidateId { get; set; }
        public decimal Rating { get; set; }
        public string Comments { get; set; }
        public DateTime EvaluationDate { get; set; }

        public EvaluationAuditoria Auditoria { get; set; } = new EvaluationAuditoria();
    }
}