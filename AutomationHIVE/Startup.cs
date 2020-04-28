using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutomationCodeHive.Data;
using AutomationHIVE.Data.Data.Migrations;

namespace AutomationHIVE
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

            //Database related config
            services.AddDbContextPool<AutomationCodeHiveDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AutomationCodeHive"));

            });

            //Use for paperwork to exlain why we need to add it 'registering a data service'
            services.AddScoped<IMentorData, SQLMentorData>();

            services.AddDbContext<AutomationCodeHiveDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AutomationCodeHive")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AutomationCodeHiveDbContext>();
            services.AddRazorPages();
            //controllers (to make changes related to controllers work)
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                       IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //node to start to work
            app.UseNodeModules();
            app.UseCookiePolicy();

            //controllers (to make changes related to controllers work)
            //UseRouting is used now instead of app.UseMvc();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //controllers (to make changes related to controllers work)
                endpoints.MapControllers();

            });
       
        }
    }
}
