using Jobsy.Shared.Domain.Model.ValueObjects;

namespace Jobsy.Shared.Domain.Model.Aggregates;

public interface IAuditable
{
    AuditableEntity Audit { get; set; }
}