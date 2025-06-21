namespace Jobsy.Shared.Domain.Repository;

public interface IUnitOfWork
{
    Task CompleteAsync();
}