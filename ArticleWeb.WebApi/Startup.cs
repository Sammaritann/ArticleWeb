using AspNetCore.Identity.Mongo;

using Autofac;

using AutoMapper;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ArticleWeb.WebApi
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
            services.AddAutoMapper(
                AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("ArticleWeb"))
                .FirstOrDefault(),
                Assembly.Load("ArticleWeb.Services"),
                Assembly.Load("ArticleWeb.Services.Models"),
                Assembly.Load("ArticleWeb.DataAccess")
                );

            services.AddControllers()
     .AddFluentValidation(opt =>
     {
         opt.RegisterValidatorsFromAssembly(Assembly.Load("ArticleWeb.Services.Models"));
     });

            services.AddCors(opt =>
            {
                opt.AddPolicy("Default", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "Article",
                        ValidAudience = "Article",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aaaaaaaaaaaaaaaaa"))
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("ArticleWeb"))
                .ToArray());

            builder.RegisterAssemblyModules(Assembly.Load("ArticleWeb.Services"));
            builder.RegisterAssemblyModules(Assembly.Load("ArticleWeb.DataAccess"));
            builder.RegisterAssemblyModules(Assembly.Load("ArticleWeb.Services.Models"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Default");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
        }
    }
}