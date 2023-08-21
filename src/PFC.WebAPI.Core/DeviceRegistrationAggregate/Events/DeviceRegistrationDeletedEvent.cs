using PFC.WebAPI.SharedKernel;

namespace PFC.WebAPI.Core.DeviceRegistrationAggregate.Events;
public class DeviceRegistrationDeletedEvent : DomainEventBase
{
  public int Oid { get; set; }

  public DeviceRegistrationDeletedEvent(int oid)
  {
    Oid = oid;
  }
}
