using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness_Tracking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Builds and runs the host
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        // Adds controllers
                        services.AddControllers();
                        // Adds Swagger generation
                        services.AddSwaggerGen(e =>
                        {
                            e.SwaggerDoc("v1", new OpenApiInfo { Title = "Fitness Tracking API", Version = "v1" });
                        });
                        // Adds services
                        services.AddTransient<IExerciseLogService, ExerciseLogService>();
                        services.AddTransient<IGoalService, GoalService>();
                        services.AddTransient<IUserProgressService, UserProgressService>();
                    });

                    webBuilder.Configure(app =>
                    {
                        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                        if (env.IsDevelopment())
                        {
                            // Enables Swagger UI in development environment
                            app.UseSwagger();
                            app.UseSwaggerUI(options =>
                            {
                                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Fitness Tracking API v1");
                                options.RoutePrefix = string.Empty;
                            });
                        }

                        app.UseHttpsRedirection();
                        app.UseRouting();
                        app.UseAuthorization();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}
