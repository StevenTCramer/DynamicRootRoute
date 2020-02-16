namespace Purple.Features.WeatherForecasts.Tests.Client
{
  using AnyClone;
  using Microsoft.AspNetCore.Blazor.Hosting;
  using Shouldly;
  using System;
  using System.Collections.Generic;
  using Purple.Integration.Tests.Infrastructure.Client;
  using Purple.Features.WeatherForecasts.Client;

  internal class WeatherForecastStateCloneTests : BaseTest
  {
    private WeatherForecastsState WeatherForecastsState => Store.GetState<WeatherForecastsState>();

    public WeatherForecastStateCloneTests(WebAssemblyHost aWebAssemblyHost) : base(aWebAssemblyHost) { }

    public void ShouldClone()
    {
      //Arrange
      var weatherForecasts = new List<WeatherForecastDto> {
        new WeatherForecastDto
        (
          aDate: DateTime.MinValue,
          aSummary: "Summary 1",
          aTemperatureC: 24
        ),
        new WeatherForecastDto
        (
          aDate: new DateTime(2019,05,17),
          aSummary: "Summary 1",
          aTemperatureC: 24
        )
      };
      WeatherForecastsState.Initialize(weatherForecasts);

      //Act
      var clone = WeatherForecastsState.Clone() as WeatherForecastsState;

      //Assert
      WeatherForecastsState.ShouldNotBeSameAs(clone);
      WeatherForecastsState.WeatherForecasts.Count.ShouldBe(clone.WeatherForecasts.Count);
      WeatherForecastsState.Guid.ShouldNotBe(clone.Guid);
      WeatherForecastsState.WeatherForecasts[0].TemperatureC.ShouldBe(clone.WeatherForecasts[0].TemperatureC);
      WeatherForecastsState.WeatherForecasts[0].ShouldNotBe(clone.WeatherForecasts[0]);
    }
  }
}
