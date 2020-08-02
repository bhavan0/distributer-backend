using Domain.Interfaces;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repo;
using System;
using System.IO;
using System.Reflection;

namespace API.HTTP
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
            services.AddDbContext<DistributerContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultDb")));

            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IStoresService, StoresService>();
            services.AddScoped<IStoresRepository, StoresRepository>();
            services.AddScoped<IStoreItemsService, StoreItemsService>();
            services.AddScoped<IStoreItemsRepository, StoreItemsRepository>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            services.AddScoped<IItenaryService, ItenaryService>();
            services.AddScoped<IItenaryRepository, ItenaryRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AR Distributer API",
                    Description = "AR Distributer API End Points",
                    Contact = new OpenApiContact()
                    {
                        Name = "Bhavan",
                        Email = "bhavan.reddy1997@gmail.com"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
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

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AR Distributer API");
            });
        }
    }
}
