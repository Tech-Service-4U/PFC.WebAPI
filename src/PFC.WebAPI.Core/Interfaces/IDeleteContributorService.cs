using Ardalis.Result;

namespace PFC.WebAPI.Core.Interfaces;
public interface IDeleteContributorService
{
  public Task<Result> DeleteContributor(int contributorId);
}
