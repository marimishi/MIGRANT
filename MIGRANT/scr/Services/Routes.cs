using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config)
    {
        var routeBuilder = new RouteBuilder(app);

        routeBuilder.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Сервер работает!");
        });

        app.UseRouter(routeBuilder.Build());

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(Path.Combine(env.ContentRootPath, "static")),
            RequestPath = ""
        });
    }
}
