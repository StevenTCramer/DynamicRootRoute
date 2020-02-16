namespace Purple.Features.Applications.Client.Tests
{
  using AnyClone;
  using Microsoft.AspNetCore.Blazor.Hosting;
  using Shouldly;
  using Purple.Features.Applications.Client;
  using Purple.Integration.Tests.Infrastructure.Client;

  internal class ApplicationStateCloneTests : BaseTest
  {
    private ApplicationState ApplicationState { get; set; }

    public ApplicationStateCloneTests(WebAssemblyHost aWebAssemblyHost) : base(aWebAssemblyHost)
    {
      ApplicationState = Store.GetState<ApplicationState>();
    }

    public void ShouldClone()
    {
      //Arrange
      ApplicationState.Initialize(aName: "TestName", aLogo: "SomeUrl", aIsMenuExpanded: false);

      //Act
      ApplicationState clone = ApplicationState.Clone();

      //Assert
      ApplicationState.ShouldNotBeSameAs(clone);
      ApplicationState.Name.ShouldBe(clone.Name);
      ApplicationState.Logo.ShouldBe(clone.Logo);
      ApplicationState.IsMenuExpanded.ShouldBe(clone.IsMenuExpanded);
      ApplicationState.Guid.ShouldNotBe(clone.Guid);
    }
  }
}
