namespace Purple.Features.WeatherForecasts.Server.GetWeatherForecasts
{
  using MediatR;
  using System.Text.Json.Serialization;
  using Purple.Features.Bases;

  public class GetWeatherForecastsRequest : BaseRequest, IRequest<GetWeatherForecastsResponse>
  {
    public const string Route = "api/weatherForecast";

    /// <summary>
    /// The Number of days of forecasts to get
    /// </summary>
    public int Days { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}?{nameof(Days)}={Days}&{nameof(Id)}={Id}";
  }
}
