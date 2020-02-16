namespace Purple.EndToEnd.Tests.Infrastructure
{
  using System;
  using Purple.Features.ClientLoaders.Client;

  public class TestClientLoaderConfiguration : IClientLoaderConfiguration
  {
    public TimeSpan DelayTimeSpan => TimeSpan.FromMilliseconds(10);
  }
}
