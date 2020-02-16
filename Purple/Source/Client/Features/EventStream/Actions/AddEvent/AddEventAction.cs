namespace Purple.Features.EventStreams.Client
{
  using Purple.Features.Bases.Client;

  internal partial class EventStreamState
  {
    public class AddEventAction : BaseAction
    {
      public string Message { get; set; }
    }
  }
}
