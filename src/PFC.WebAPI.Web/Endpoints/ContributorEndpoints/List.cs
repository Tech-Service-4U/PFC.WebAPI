using FastEndpoints;
using PFC.WebAPI.Core.ContributorAggregate;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Web.Endpoints.ContributorEndpoints;
public class List : EndpointWithoutRequest<ContributorListResponse>
{
  private readonly IRepository<Contributor> _repository;

  public List(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get("/Contributors");
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var contributors = await _repository.ListAsync(cancellationToken);
    var response = new ContributorListResponse()
    {
      Contributors = contributors
        .Select(project => new ContributorRecord(project.Id, project.Name))
        .ToList()
    };

    await SendAsync(response, cancellation: cancellationToken);
  }
}
