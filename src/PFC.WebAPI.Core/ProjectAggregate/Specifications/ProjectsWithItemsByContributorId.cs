using Ardalis.Specification;

namespace PFC.WebAPI.Core.ProjectAggregate.Specifications;
public class ProjectsWithItemsByContributorIdSpec : Specification<Project>, ISingleResultSpecification<Project>
{
  public ProjectsWithItemsByContributorIdSpec(int contributorId)
  {
    Query
        .Where(project => project.Items.Any(item => item.ContributorId == contributorId))
        .Include(project => project.Items);
  }
}
