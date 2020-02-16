namespace Purple.Pipeline.Tests
{
  using Microsoft.AspNetCore.Blazor.Hosting;
  using Shouldly;
  using System;
  using System.Threading.Tasks;
  using Purple.Features.Counters.Client;
  using Purple.Integration.Tests.Infrastructure.Client;
  using static Purple.Features.Counters.Client.CounterState;

  internal class CloneStateBehaviorTests : BaseTest
  {
    private CounterState CounterState => Store.GetState<CounterState>();

    public CloneStateBehaviorTests(WebAssemblyHost aWebAssemblyHost) : base(aWebAssemblyHost) { }

    public async Task ShouldCloneState()
    {
      //Arrange
      CounterState.Initialize(aCount: 15);
      Guid preActionGuid = CounterState.Guid;

      // Create request
      var incrementCounterRequest = new IncrementCounterAction
      {
        Amount = -2
      };
      //Act
      await Send(incrementCounterRequest);

      //Assert
      CounterState.Guid.ShouldNotBe(preActionGuid);
    }

    public async Task ShouldRollBackStateAndThrow()
    {
      // Arrange
      CounterState.Initialize(aCount: 22);
      Guid preActionGuid = CounterState.Guid;

      // Act
      var throwExceptionAction = new ThrowExceptionAction
      {
        Message = "Test Rollback of State"
      };

      Exception exception = await Should.ThrowAsync<Exception>(async () =>
      await Send(throwExceptionAction));

      // Assert
      exception.Message.ShouldBe(throwExceptionAction.Message);
      CounterState.Guid.Equals(preActionGuid);
    }
  }
}
