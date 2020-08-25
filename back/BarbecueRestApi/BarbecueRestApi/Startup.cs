using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BarbecueRestApi.Data;
using BarbecueRestApi.Services;
using Newtonsoft.Json.Serialization;
using BarbecueRestApi.Models;
using Microsoft.OpenApi.Models;

namespace BarbecueRestApi
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
           services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


           services.AddDbContext<BarbecueRestApiContext>(options =>
           options.UseMySql(Configuration.GetConnectionString("BarbecueRestApiContext"), builder =>
           builder.MigrationsAssembly("BarbecueRestApi")));

            //services.AddControllers().AddNewtonsoftJson();

            services.AddMvc()
              .AddJsonOptions(options => options.SerializerSettings.ContractResolver
                                        = new DefaultContractResolver());


            services.AddScoped<EstablishmentService>();
            services.AddScoped<ParticipantService>();

            // add cors para o front se comunicar com o back
            services.AddCors();


            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Barbecue RestApi",
                    Version = "v1",
                    Description = "Desafio Hammer - Barbercue",
                    Contact = new OpenApiContact
                    {
                        Name = "Gian Karlos"
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // add cors
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Barbercue RestApi V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
