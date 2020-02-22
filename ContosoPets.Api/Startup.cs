using ContosoPets.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoPets.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ContosoPetsContext>(options => options.UseInMemoryDatabase("ContosoPets"));
      // services.AddControllers();
      services.AddMvc(options =>
        {
          // warning MVC1005: Using 'UseMvc' to configure MVC is not supported 
          // while using Endpoint Routing. To continue using 'UseMvc', 
          // please set 'MvcOptions.EnableEndpointRouting = false' inside 'ConfigureServices'. 

          options.EnableEndpointRouting = false;
        }
      );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();

      // app.UseHttpsRedirection();

      // app.UseRouting();

      // app.UseAuthorization();

      // app.UseEndpoints(endpoints =>
      // {
      //   endpoints.MapControllers();
      // });
    }
  }
}
