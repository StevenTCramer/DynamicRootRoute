namespace Purple.Features.Counters.Components
{
  using System.Threading.Tasks;
  using static Purple.Features.Counters.Client.CounterState;

  public partial class Counter
  {
    protected async Task ButtonClick() =>
      _ = await Mediator.Send(new IncrementCounterAction { Amount = 5 });
  }
}
