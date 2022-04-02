using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebSite.Application.Interfaces.Contexts;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Alerts.FacadPattern;
using WebSite.Application.Services.Email;
using WebSite.Application.Services.Rules.FacadPattern;
using WebSite.Application.Services.Users.FacadPattern;
using WebSite.Domain.Entities.Users;
using WebSite.Persistence.Contexts;

namespace EndPoint.Site
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
            services.AddControllersWithViews();

            services.AddDbContext<DataBaseContext>(p => p.UseSqlServer(Configuration["ConnectionString"]));

            services.AddScoped<IUserFacad, UserFacad>();
            services.AddScoped<IRuleFacad, RuleFacad>();
            services.AddScoped<IAlertFacad, AlertFacad>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IDataBaseContext, DataBaseContext>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(options =>
            {
                // This pushes users to login if not authenticated
                options.Filters.Add(new AuthorizeFilter());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Rule}/{action=Index}");
            });
        }
    }
}
