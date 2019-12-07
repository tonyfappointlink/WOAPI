using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using WOAPI.WOContext;

namespace WOAPI
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

            DbContextOptionsBuilder<WOModelBase> opt = new DbContextOptionsBuilder<WOModelBase>();

            services.AddDbContext<WOModel>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WOModelConnection")));

            // To refresh data context
            //Scaffold-DbContext "Server=dev-sql1.appointlink_dev.loc;Database=WO;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Output WOContext -Context WOModelBase -Force
            //
            //services.AddScoped<DbContext, new WOModel(opt.UseSqlServer(Configuration.GetConnectionString("WOModelConnection")).Options>();

            services.AddScoped<WOModel>(_ => new WOModel(opt.UseSqlServer(Configuration.GetConnectionString("WOModelConnection")).Options));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
