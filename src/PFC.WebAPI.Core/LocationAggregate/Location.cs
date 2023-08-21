using PFC.WebAPI.SharedKernel;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Core.LocationAggregate;
public class Location : EntityBase, IAggregateRoot
{
  public int DataSetId { get; private set; }

  public decimal Latitude { get; private set; }

  public decimal Longitude { get; private set; }

  public decimal Accuracy { get; private set; }

  public Guid AssociatedRouteOid { get; private set; }

  public DateTimeOffset TimeStamp { get; private set; }

  public virtual DataSetAggregate.DataSet DataSet { get; private set; } = default!;

  public Location(int dataSetId, decimal latitude, decimal longitude, decimal accuracy, DateTimeOffset timeStamp, Guid associatedRouteOid)
  {
    DataSetId = dataSetId;
    Latitude = latitude;
    Longitude = longitude;
    Accuracy = accuracy;
    TimeStamp = timeStamp;
    AssociatedRouteOid = associatedRouteOid;
  }

  public Location Update(int? dataSetId, decimal? latitude, decimal? longitude, decimal? accuracy, DateTimeOffset? timeStamp, Guid? associatedRouteOid)
  {
    if (dataSetId.HasValue && DataSetId != dataSetId) DataSetId = dataSetId.Value;
    if (latitude.HasValue && Latitude != latitude) Latitude = latitude.Value;
    if (longitude.HasValue && Longitude != longitude) Longitude = longitude.Value;
    if (accuracy.HasValue && Accuracy != accuracy) Accuracy = accuracy.Value;
    if (timeStamp.HasValue && TimeStamp != timeStamp) TimeStamp = timeStamp.Value;
    if (associatedRouteOid.HasValue && associatedRouteOid != Guid.Empty) AssociatedRouteOid = associatedRouteOid.Value;

    return this;
  }

}
