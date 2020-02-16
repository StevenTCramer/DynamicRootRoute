namespace Purple.Integration.Tests
{
  using BlazorState;
  using Microsoft.AspNetCore.Blazor.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System;
  using System.IO;
  using Purple.Features.Applications.Client;
  using Purple.Features.Counters.Client;
  using Purple.Integration.Tests.Infrastructure.Client;
  using Purple.Features.WeatherForecasts.Client;

  internal class StoreTests : BaseTest
  {
    private readonly IReduxDevToolsStore ReduxDevToolsStore;

    public StoreTests(WebAssemblyHost aWebAssemblyHost) : base(aWebAssemblyHost)
    {
      ReduxDevToolsStore = aWebAssemblyHost.Services.GetService<IReduxDevToolsStore>();
    }


    /// <summary>
    /// WeatherForecatesState will throw an exception if items initialized in the constructor are null.
    /// </summary>
    public void ShouldInitializeStateAfterConstruction()
    {
      WeatherForecastsState state = Store.GetState<WeatherForecastsState>();
      state.ShouldNotBeNull();
    }
  }
}
