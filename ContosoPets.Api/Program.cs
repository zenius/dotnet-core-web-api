using System;
using ContosoPets.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContosoPets.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();
      SeedDatabase(host);
      host.Run();
    }

    // This database seeding strategy isn't recommended in a production environment. 
    //Consider seeding during database deployment instead.
    private static void SeedDatabase(IHost host)
    {
      var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

      using (var scope = scopeFactory.CreateScope())
      {
        var context = scope.ServiceProvider.GetRequiredService<ContosoPetsContext>();

        if (context.Database.EnsureCreated())
        {
          try
          {
            SeedData.Initialize(context);
          }
          catch (Exception ex)
          {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "A database seeding error occurred.");
          }
        }
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
