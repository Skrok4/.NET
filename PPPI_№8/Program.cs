using System;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fitness_Tracking.Models;
using Swashbuckle.AspNetCore.Filters;

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
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        services.AddControllers();
                        services.AddSwaggerGen(e =>
                        {
                            e.SwaggerDoc("v1", new OpenApiInfo { Title = "Fitness Tracking API", Version = "v1" });

                            // Add JWT authorization in Swagger
                            e.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                            {
                                Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                                Name = "Authorization",
                                In = ParameterLocation.Header,
                                Type = SecuritySchemeType.ApiKey,
                                Scheme = "Bearer"
                            });

                            e.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                                    Scheme = "oauth2",
                                    Name = "Bearer",
                                    In = ParameterLocation.Header
                                },
                                new List<string>()
                            }
                            });
                        });

                        // Add authentication and authorization services
                        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = hostContext.Configuration["JwtIssuer"],
                                    ValidAudience = hostContext.Configuration["JwtAudience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(hostContext.Configuration["TokenKey"]))
                                };
                            });

                        services.AddAuthorization();

                        // Add custom services
                        services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
                        services.AddTransient<IExerciseLogService, ExerciseLogService>();
                        services.AddTransient<IGoalService, GoalService>();
                        services.AddTransient<IUserProgressService, UserProgressService>();

                        // Add token generator service
                        services.AddSingleton<ITokenGeneratorService, TokenGeneratorService>();
                    })
                    .Configure((hostContext, app) =>
                    {
                        if (hostContext.HostingEnvironment.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        app.UseHttpsRedirection();
                        app.UseRouting();

                        app.UseAuthentication();
                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });

                        app.UseSwagger();
                        app.UseSwaggerUI(e =>
                        {
                            e.SwaggerEndpoint("/swagger/v1/swagger.json", "Fitness Tracking API V1");
                            e.RoutePrefix = string.Empty;
                        });
                    });
                });
    }
}