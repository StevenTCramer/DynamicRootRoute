namespace Purple.Features.EventStreams.Client
{
  using BlazorState;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  using Purple.Features.Bases.Client;

  internal partial class EventStreamState
  {
    internal class AddEventHandler : BaseHandler<AddEventAction>
    {
      public AddEventHandler(IStore aStore) : base(aStore) { }

      public override Task<Unit> Handle
      (
        AddEventAction aAddEventAction,
        CancellationToken aCancellationToken
      )
      {
        EventStreamState._Events.Add(aAddEventAction.Message);
        return Unit.Task;
      }
    }
  }
}
