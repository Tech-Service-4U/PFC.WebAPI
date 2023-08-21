using PFC.WebAPI.SharedKernel;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Core.TripAggregate;
public class Trip : EntityBase, IAggregateRoot
{
  public int DataSetId { get; private set; }
  public Guid RouteOid { get; private set; }
  public DateTimeOffset StartTime { get; private set; }
  public DateTimeOffset EndTime { get; private set; }
  public double Distance { get; private set; }
  public DateTimeOffset TimeStamp { get; private set; }
  public virtual DataSetAggregate.DataSet DataSet { get; private set; } = default!;

  public Trip()
  {

  }

  public Trip(int datasetId, Guid routeOid, DateTimeOffset startTime, DateTimeOffset endTime, double distance, DateTimeOffset timeStamp)
  {
    DataSetId = datasetId;
    RouteOid = routeOid;
    StartTime = startTime;
    EndTime = endTime;
    Distance = distance;
    TimeStamp = timeStamp;
  }

  public Trip Update(int? dataSetId, Guid? routeOid, DateTimeOffset? startTime, DateTimeOffset? endTime, double? distance, DateTimeOffset? timeStamp)
  {
    if (dataSetId.HasValue && DataSetId != dataSetId) DataSetId = dataSetId.Value;
    if (routeOid.HasValue && routeOid.Value != Guid.Empty && !RouteOid.Equals(routeOid.Value)) RouteOid = routeOid.Value;
    if (distance.HasValue && Distance != distance) Distance = distance.Value;

    if (startTime.HasValue && StartTime != startTime) StartTime = startTime.Value;
    if (endTime.HasValue && EndTime != endTime) EndTime = endTime.Value;
    if (timeStamp.HasValue && TimeStamp != timeStamp) TimeStamp = timeStamp.Value;
    return this;
  }
}
