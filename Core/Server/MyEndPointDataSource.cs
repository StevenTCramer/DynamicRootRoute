namespace Core.Server
{
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Routing;
  using Microsoft.Extensions.Primitives;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class MyEndPointDataSource : EndpointDataSource
  {
    public override IReadOnlyList<Endpoint> Endpoints => throw new NotImplementedException();

    public override IChangeToken GetChangeToken() => throw new NotImplementedException();
  }
}
