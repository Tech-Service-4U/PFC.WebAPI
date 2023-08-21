using PFC.WebAPI.Core.DataSetAggregate;
using PFC.WebAPI.Core.LocationAggregate;
using PFC.WebAPI.SharedKernel;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Core.EventAggregate;
public class Event : EntityBase, IAggregateRoot
{
  public int DataSetId { get; private set; }
  public int LocationOid { get; private set; }

  public Guid EventTypeOid { get; private set; }
  public DateTimeOffset TimeStamp { get; private set; }

  public virtual DataSet DataSet { get; private set; } = default!;
  public virtual Location Location { get; private set; } = default!;

  public Event(int dataSetId, Guid eventTypeOid, int locationOid, DateTimeOffset timeStamp)
  {
    DataSetId = dataSetId;
    EventTypeOid = eventTypeOid;
    LocationOid = locationOid;
    TimeStamp = timeStamp;
  }

  public Event Update(int? dataSetId, Guid? eventTypeOid, int? locationOid, DateTimeOffset? timeStamp)
  {
    if (dataSetId.HasValue && DataSetId != dataSetId) DataSetId = dataSetId.Value;
    if (eventTypeOid.HasValue && eventTypeOid.Value != Guid.Empty && !EventTypeOid.Equals(eventTypeOid.Value)) EventTypeOid = eventTypeOid.Value;
    if (locationOid.HasValue && LocationOid != locationOid) LocationOid = locationOid.Value;
    if (timeStamp.HasValue && TimeStamp != timeStamp) TimeStamp = timeStamp.Value;
    return this;
  }

}
