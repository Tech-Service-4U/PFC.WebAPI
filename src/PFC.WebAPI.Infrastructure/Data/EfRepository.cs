using Ardalis.Specification.EntityFrameworkCore;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Infrastructure.Data;
// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
