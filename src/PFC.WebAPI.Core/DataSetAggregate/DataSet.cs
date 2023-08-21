using PFC.WebAPI.Core.DeliveryDateAggregate;
using PFC.WebAPI.SharedKernel;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Core.DataSetAggregate;
public class DataSet : EntityBase, IAggregateRoot
{
  public Guid Oid { get; private set; }

  public Guid AccountOid { get; private set; }

  public int DeliveryDateId { get; private set; }
  public virtual DeliveryDate DeliveryDate { get; private set; } = default!;

  public DataSet(Guid oid, Guid accountOid, int deliveryDateId)
  {
    Oid = oid;
    AccountOid = accountOid;
    DeliveryDateId = deliveryDateId;
  }

  public DataSet Update(Guid? oid, Guid? accountOid, int? deliveryDateId)
  {
    if (oid.HasValue && oid.Value != Guid.Empty && !Oid.Equals(oid.Value)) Oid = oid.Value;
    if (accountOid.HasValue && accountOid.Value != Guid.Empty && !AccountOid.Equals(accountOid.Value)) AccountOid = accountOid.Value;
    if (deliveryDateId.HasValue && deliveryDateId.Value != default && !DeliveryDateId.Equals(deliveryDateId.Value)) DeliveryDateId = deliveryDateId.Value;
    return this;
  }
}
