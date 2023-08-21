using PFC.WebAPI.SharedKernel;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Core.DeviceRegistrationAggregate;
public class DeviceRegistration : EntityBase, IAggregateRoot
{
  public int Oid { get; private set; }

  public string? VenderDeviceId { get; private set; }

  public string? DeviceType { get; private set; }

  public string? PlatformId { get; private set; }

  public string? Idiom { get; private set; }

  public string? Manufacturer { get; private set; }

  public string? Model { get; set; }

  public string? OperatingSystemVersion { get; private set; }

  public string? FirebaseToken { get; private set; }

  public DeviceRegistration(int oid, string venderDeviceId, string deviceType, string platformId, string idiom, string manufacturer, string model, string operatingSystemVersion, string firebaseToken)
  {
    Oid = oid;
    VenderDeviceId = venderDeviceId;
    DeviceType = deviceType;
    PlatformId = platformId;
    Manufacturer = manufacturer;
    Model = model;
    OperatingSystemVersion = operatingSystemVersion;
    FirebaseToken = firebaseToken;
  }

  public DeviceRegistration Update(int? oid, string? venderDeviceId, string? deviceType, string? platformId, string? idiom, string? manufacturer, string? model, string? operatingSystemVersion, string? firebaseToken)
  {
    if (oid.HasValue && oid.Value != default && !Oid.Equals(oid.Value)) Oid = oid.Value;
    if (venderDeviceId is not null && VenderDeviceId?.Equals(venderDeviceId) is not true) VenderDeviceId = venderDeviceId;
    if (deviceType is not null && DeviceType?.Equals(deviceType) is not true) DeviceType = deviceType;
    if (platformId is not null && PlatformId?.Equals(platformId) is not true) PlatformId = platformId;
    if (manufacturer is not null && Manufacturer?.Equals(manufacturer) is not true) Manufacturer = manufacturer;
    if (model is not null && Model?.Equals(model) is not true) Model = model;
    if (operatingSystemVersion is not null && OperatingSystemVersion?.Equals(operatingSystemVersion) is not true) OperatingSystemVersion = operatingSystemVersion;
    if (firebaseToken is not null && FirebaseToken?.Equals(firebaseToken) is not true) FirebaseToken = firebaseToken;
    return this;
  }
}
