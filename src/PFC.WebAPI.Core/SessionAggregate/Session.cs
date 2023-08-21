using PFC.WebAPI.Core.DeviceRegistrationAggregate;
using PFC.WebAPI.SharedKernel;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Core.SessionAggregate;
public class Session : EntityBase, IAggregateRoot
{
  public Guid AccountOid { get; private set; }
  public Guid SessionOid { get; private set; }
  public int DeviceRegistrationId { get; private set; }
  public virtual DeviceRegistration DeviceRegistration { get; private set; } = default!;

  public Session(Guid accountOid, Guid sessionOid, int deviceRegistrationId)
  {
    AccountOid = accountOid;
    SessionOid = sessionOid;
    DeviceRegistrationId = deviceRegistrationId;
  }

  public Session Update(Guid? accountOid, Guid? sessionOid, int? deviceRegistrationId)
  {
    if (accountOid.HasValue && accountOid.Value != Guid.Empty && !AccountOid.Equals(accountOid.Value)) AccountOid = accountOid.Value;
    if (sessionOid.HasValue && sessionOid.Value != Guid.Empty && !SessionOid.Equals(sessionOid.Value)) SessionOid = sessionOid.Value;
    if (deviceRegistrationId.HasValue && DeviceRegistrationId != deviceRegistrationId) DeviceRegistrationId = deviceRegistrationId.Value;
    return this;
  }
}
