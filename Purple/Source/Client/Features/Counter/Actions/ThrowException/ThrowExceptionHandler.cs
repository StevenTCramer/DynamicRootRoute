namespace Purple.Features.Counters.Client
{
  using BlazorState;
  using MediatR;
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using Purple.Features.Bases.Client;

  internal partial class CounterState
  {
    internal class ThrowExceptionHandler : BaseHandler<ThrowExceptionAction>
    {
      public ThrowExceptionHandler(IStore aStore) : base(aStore) { }

      public override Task<Unit> Handle
      (
        ThrowExceptionAction aThrowExceptionAction,
        CancellationToken aCancellationToken
      )
      {
        // Intentionally throw so we can test exception handling.
        throw new Exception(aThrowExceptionAction.Message);
      }
    }
  }
}
