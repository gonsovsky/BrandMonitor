using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BrandMonitor.API.Domain.Services;
using BrandMonitor.API.Services;
using Microsoft.AspNetCore.Mvc;
using BrandMonitor.API.Persistence;
using BrandMonitor.API.Helpers;
using BrandMonitor.API.Domain.Responses;

namespace BrandMonitor.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomSwagger();

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
                options.InvalidModelStateResponseFactory = context
                    =>  new BadRequestObjectResult(new ErrorResponse(context.ModelState.GetErrorMessages()))
            );

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase(Configuration.GetConnectionString("memory"));
            });

            services.Configure<TaskOptions>(Configuration.GetSection("Task"));

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddSingleton<TaskHostedService>();
            services.AddHostedService(provider => provider.GetService<TaskHostedService>());
            services.AddScoped<ITaskService, TaskService>();

            services.AddAutoMapper(typeof(Startup));
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}