namespace Purple.Features.Counters.Client
{
  using Purple.Features.Bases.Client;

  internal partial class CounterState
  {
    public class IncrementCounterAction : BaseAction
    {
      public int Amount { get; set; }
    }
  }
}
