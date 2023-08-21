using System.ComponentModel.DataAnnotations.Schema;

namespace PFC.WebAPI.SharedKernel;
// This can be modified to EntityBase<TId> to support multiple key types (e.g. Guid)
public abstract class EntityBase
{
  public int Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTimeOffset CreatedOn { get; private set; }
  public Guid LastModifiedBy { get; set; }
  public DateTimeOffset? LastModifiedOn { get; set; }
  public DateTimeOffset? DeletedOn { get; set; }
  public Guid? DeletedBy { get; set; }

  private List<DomainEventBase> _domainEvents = new();
  [NotMapped]
  public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
  internal void ClearDomainEvents() => _domainEvents.Clear();
}
