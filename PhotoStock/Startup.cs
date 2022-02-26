using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using PhotoStock.Data.Models;
using PhotoStock.Database;
using PhotoStock.Repositories.Implimentations;
using PhotoStock.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LoggerService;

namespace PhotoStock
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PhotoStockContext>(options => options
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddControllers().AddJsonOptions(x => x
                .JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhotoStock", Version = "v1" });
            });
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IBaseRepository<Author>, BaseRepository<Author>>();
            services.AddTransient<IBaseRepository<Photo>, BaseRepository<Photo>>();
            services.AddTransient<IBaseRepository<Text>, BaseRepository<Text>>();
            services.AddTransient<IBaseRepository<Rating>, BaseRepository<Rating>>();
            services.AddTransient<IBaseRepository<RatingValue>, BaseRepository<RatingValue>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhotoStock v1"));
            };

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
