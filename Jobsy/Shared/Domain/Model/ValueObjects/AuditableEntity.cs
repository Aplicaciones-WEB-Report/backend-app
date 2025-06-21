namespace Jobsy.Shared.Domain.Model.ValueObjects;

public class AuditableEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } // Nullable, ya que no se actualiza al crear.
}