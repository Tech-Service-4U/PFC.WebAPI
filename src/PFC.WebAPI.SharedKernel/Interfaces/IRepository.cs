using Ardalis.Specification;

namespace PFC.WebAPI.SharedKernel.Interfaces;
// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
