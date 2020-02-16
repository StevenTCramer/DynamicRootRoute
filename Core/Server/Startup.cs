using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Core.Server
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<RouteTransformer>();
      services.AddRazorPages();
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/build";
      });

      services.AddMvc();
      services.AddResponseCompression(opts =>
      {
        opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                  new[] { "application/octet-stream" });
      });

      //services.TryAddEnumerable(
      //          ServiceDescriptor.Singleton<EndpointDataSource>(new DefaultEndpointDataSource(Endpoints)));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseResponseCompression();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBlazorDebugging();
      }

      app.UseStaticFiles();

      app.UseRouting();
      app.UseEndpoints
      (
        aEndpointRouteBuilder =>
        {
          aEndpointRouteBuilder.MapFallbackToPage("/Routes");
        }
      );

      //app.Map("/Routes", app =>
      //{
      //  app.UseRouting();
      //  app.UseEndpoints
      //  (
      //    aEndpointRouteBuilder =>
      //    {
      //      //aEndpointRouteBuilder.MapFallbackToPage("/Routes");
      //      aEndpointRouteBuilder.MapDynamicPageRoute<RouteTransformer>("{page}");
      //    }
      //  );
      //});

      app.Map("/blue", app =>
      {
        app.UseRouting();
        app.UseClientSideBlazorFiles<Blue.Program>();
        app.UseEndpoints(endpoints =>
        {
          endpoints.MapFallbackToClientSideBlazor<Blue.Program>("index.html");
        });
      });




      //app.Map("/client", app =>
      //{
      //  app.UseRouting();
      //  app.UseClientSideBlazorFiles<Client.Program>();
      //  app.UseEndpoints(endpoints =>
      //  {
      //    endpoints.MapRazorPages();
      //    endpoints.MapFallbackToClientSideBlazor<Client.Program>("index.html");
      //  });
      //});

      //app.Map("/yellow", app =>
      //{
      //  app.UseRouting();
      //  app.UseClientSideBlazorFiles<Yellow.Program>();
      //  app.UseEndpoints(endpoints =>
      //  {
      //    endpoints.MapRazorPages();
      //    endpoints.MapFallbackToClientSideBlazor<Yellow.Program>("index.html");
      //  });
      //});

      //string reactPath = "/react";
      //app.Map(reactPath, app =>
      //{
      //  app.UseSpaStaticFiles();
      //  app.UseRouting();
      //  app.UseEndpoints(endpoints =>
      //  {
      //    endpoints.MapControllerRoute(
      //        name: "default",
      //        pattern: "{controller}/{action=Index}/{id?}");
      //  });

      //  app.UseSpa(spa =>
      //  {
      //    spa.Options.DefaultPage = reactPath + "/index.html";
      //    spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
      //    {
      //      RequestPath = reactPath,
      //    };
      //    spa.Options.SourcePath = "ClientApp";

      //    if (env.IsDevelopment())
      //    {
      //      spa.UseReactDevelopmentServer(npmScript: "start");
      //    }
      //  });
      //});



    }
  }
}