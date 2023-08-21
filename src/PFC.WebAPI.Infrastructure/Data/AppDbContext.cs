using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PFC.WebAPI.Core.ContributorAggregate;
using PFC.WebAPI.Core.DeliveryDateAggregate;
using PFC.WebAPI.Core.DeviceRegistrationAggregate;
using PFC.WebAPI.Core.EventAggregate;
using PFC.WebAPI.Core.ProjectAggregate;
using PFC.WebAPI.Core.SessionAggregate;
using PFC.WebAPI.Core.TripAggregate;
using PFC.WebAPI.SharedKernel;
using PFC.WebAPI.SharedKernel.Interfaces;

namespace PFC.WebAPI.Infrastructure.Data;
public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
  public DbSet<Project> Projects => Set<Project>();
  public DbSet<Contributor> Contributors => Set<Contributor>();
  public DbSet<DeviceRegistration> DeviceRegistrations => Set<DeviceRegistration>();
  public DbSet<Session> Sessions => Set<Session>();
  public DbSet<DeliveryDate> DeliveryDates => Set<DeliveryDate>();
  public DbSet<Core.DataSetAggregate.DataSet> DataSets => Set<Core.DataSetAggregate.DataSet>();
  public DbSet<Core.LocationAggregate.Location> Locations => Set<Core.LocationAggregate.Location>();
  public DbSet<Trip> Trips => Set<Trip>();
  public DbSet<Event> Events => Set<Event>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
