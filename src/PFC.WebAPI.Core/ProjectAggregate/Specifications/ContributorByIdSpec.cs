using Ardalis.Specification;
using PFC.WebAPI.Core.ContributorAggregate;

namespace PFC.WebAPI.Core.ProjectAggregate.Specifications;
public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification<Contributor>
{
  public ContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
