namespace Purple.Pages
{
  using System.Threading.Tasks;
  using Purple.Features.Bases.Client;
  using static Purple.Features.WeatherForecasts.Client.WeatherForecastsState;

  public partial class WeatherForecastsPage : BaseComponent
  {
    public const string Route = "/weatherforecasts";

    protected override async Task OnInitializedAsync() =>
      await Mediator.Send(new FetchWeatherForecastsAction());
  }
}
