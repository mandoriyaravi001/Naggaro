using DataAccessLayer;
using DataAccessLayer.DatabaseModels;
using DataAccessLayer.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Services.Build_Models.Classes;
using Services.Build_Models.Interfaces;
using Services.Factory.Interfaces;
using System.Collections.Generic;
using static Services.Utitlties.Constant;

namespace BookReadingEventApplicationCore
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
            services.AddDbContext<EventDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EventDataContext")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSession();
            services.AddScoped<ILogger, Logger>();
            services.AddScoped<ICommentDataAccess, CommentDataAccess>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IEventDataAccess, EventDataAccess>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserDataAccess, UserDataAccess>();
            services.AddScoped<IUserService, UserService>();
            services.AddDistributedMemoryCache();//To Store session in Memory, This is default implementation of IDistributedCache    
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
            services.AddTransient< BuildModelForLoginUser>();
            services.AddTransient< BuildUserModelForExistingUser>();
            services.AddTransient< BuildModelForRegisterUser>();
            services.AddTransient<IUnitofWork, UnitofWork>();
            services.AddTransient<serviceUserBuilderModel>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "Login" :
                        return serviceProvider.GetService<BuildModelForLoginUser>();
                    case "Exist":
                        return serviceProvider.GetService<BuildUserModelForExistingUser>();
                    case "Register":
                        return serviceProvider.GetService<BuildModelForRegisterUser>();
                    default:
                        throw new KeyNotFoundException(); // or maybe return null, up to you
                }
            });


            services.Configure<CookiePolicyOptions>(options =>
            {
                //options.CheckConsentNeeded = context => true;
                options.CheckConsentNeeded = context => false;
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
            app.UseSession();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
