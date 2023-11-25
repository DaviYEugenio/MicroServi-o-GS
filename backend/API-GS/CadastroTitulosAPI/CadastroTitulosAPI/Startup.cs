using Business;
using Business.Interfaces;
using DAL;
using DAL.Base;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CadastroTitulosAPI
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Swagger CadastrarTitulosAPI",
                    Description = "Swagger CadastrarTitulosAPI",
                });
            });

            services.AddScoped<IODSBUS, ODSBusiness>().AddScoped<IODSDAL, ODSDAL>();
         
            Dictionary<string, string> databasesDictionary = new Dictionary<string, string>();
            string environment = Configuration.GetValue<string>("ProjectEnvironment");

            string pathConnectionString = $"ConnectionStrings:{environment}:Master";
            string pathDatabases = $"Databases:{environment}";

            List<IConfigurationSection> databaseList = Configuration.GetSection(pathDatabases).GetChildren().ToList();

            for (int i = 0; i < databaseList.Count; i++)
            {
                databasesDictionary.Add(databaseList[i].Key, databaseList[i].Value);
            }

            services.AddSingleton<IRepositoryBase>(ctx => new RepositoryBase(
                databases: databasesDictionary, // pode dar ruim demais Databases
                connectionString: Configuration.GetValue<string>(pathConnectionString),
                inviteHashSalt: Configuration.GetValue<string>("InviteConfiguration:InviteHashSalt")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "CadastrarTitulosAPI");
            });



            app.UseCors(builder =>
            {
                builder.WithOrigins("*")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });




            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


