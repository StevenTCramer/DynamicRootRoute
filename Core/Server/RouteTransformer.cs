using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Server
{
  public class RouteTransformer : DynamicRouteValueTransformer
  {
    public override ValueTask<RouteValueDictionary> TransformAsync(HttpContext aHttpContext, RouteValueDictionary aRouteValueDictionary)
    {
      Console.WriteLine("Yo");
      return new ValueTask<RouteValueDictionary>(aRouteValueDictionary);
    }
  }
}
