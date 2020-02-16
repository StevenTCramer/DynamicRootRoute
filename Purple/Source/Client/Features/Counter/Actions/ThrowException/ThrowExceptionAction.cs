namespace Purple.Features.Counters.Client
{
  using Purple.Features.Bases.Client;

  internal partial class CounterState
  {
    public class ThrowExceptionAction : BaseAction
    {
      public string Message { get; set; }
    }
  }
}
