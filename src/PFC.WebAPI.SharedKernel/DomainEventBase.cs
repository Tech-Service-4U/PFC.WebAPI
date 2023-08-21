using MediatR;

namespace PFC.WebAPI.SharedKernel;
public abstract class DomainEventBase : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
