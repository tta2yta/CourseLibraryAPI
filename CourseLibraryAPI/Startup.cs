using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibraryAPI.DbContexts;
using CourseLibraryAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CourseLibraryAPI
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
            /*services.AddControllers(setUpAction =>
            {
                setUpAction.ReturnHttpNotAcceptable = true;

            }).AddXmlDataContractSerializerFormatters();*/
            
            services.AddControllers(options => options.RespectBrowserAcceptHeader = true)
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();
            services.AddDbContext<CourseLibraryContext>(o =>
            o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            /* services.AddDbContext<CourseLibraryContext>(options =>
             {
                 options.UseSqlServer(
                     @"Server=(localdb)\mssqllocaldb;Database=CourseLibraryDB;Trusted_Connection=True;");
             });*/
            services.AddScoped<ICourseLibraryRepository, CourseLibraryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
