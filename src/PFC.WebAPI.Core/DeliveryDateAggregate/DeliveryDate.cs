using PFC.WebAPI.SharedKernel;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Core.DeliveryDateAggregate;
public class DeliveryDate : EntityBase, IAggregateRoot
{
  public DateTime DeliveryDates { get; private set; }

  public DeliveryDate(DateTime deliveryDates)
  {
    DeliveryDates = deliveryDates;
  }

  public DeliveryDate Update(DateTime? deliveryDates)
  {
    if (deliveryDates.HasValue && DeliveryDates != deliveryDates) DeliveryDates = deliveryDates.Value;
    return this;
  }
}
