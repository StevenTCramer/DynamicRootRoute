namespace Purple.Components
{
  using Purple.Features.Bases.Client;
  using static Purple.Features.Applications.Client.ApplicationState;

  public partial class ResetButton:BaseComponent
  {
    internal void ButtonClick() => Mediator.Send(new ResetStoreAction());
  }
}
