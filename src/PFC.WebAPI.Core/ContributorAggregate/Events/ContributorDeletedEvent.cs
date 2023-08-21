using PFC.WebAPI.SharedKernel;

namespace PFC.WebAPI.Core.ContributorAggregate.Events;
public class ContributorDeletedEvent : DomainEventBase
{
  public int ContributorId { get; set; }

  public ContributorDeletedEvent(int contributorId)
  {
    ContributorId = contributorId;
  }
}
