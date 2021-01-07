using DatingSite.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataLayer;
using System.Web.Http;
using Microsoft.AspNetCore.SignalR;
using DatingSite.Application;
using SignalRChat.Hubs;

namespace DatingSite
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
            services.AddMvc();
            services.AddSignalR();
            services.AddSingleton(typeof(IUserIdProvider), typeof(MyUserIdProvider));

            services.AddDbContext<DatingSiteContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DatingSiteConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "search-users",
                    pattern: "{controller=Search}/{action=Search}/{searchString?}");

                endpoints.MapControllerRoute(
                    name: "chat",
                    pattern: "{controller=Chat}/{action=Chat}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });

                endpoints.MapControllerRoute(
                    name: "profile-route",
                    pattern: "{controller=Profile}/{action=Index}/{profile?}");
                    //defaults: new { id = RouteParameter.Optional });

                endpoints.MapHub<FriendHub>("/friendHub");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}