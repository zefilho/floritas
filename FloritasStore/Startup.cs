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
using FloritasStore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using FloritasStore.Models.Users;
using FloritasStore.Models;
using FloritasStore.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;
using FloritasStore.Services.Authorization;
using FloritasStore.Data.Repositories;
using FloritasStore.Data.UnitOfWork;
using AutoMapper;

namespace FloritasStore
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
            services.AddDbContext<ApplicationDbContext>(options =>               
                  options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(Startup));
           
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllersWithViews()
                .AddMvcOptions(op => op.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        _ => "Campo Obrigatório."));

            services.AddRazorPages(options => {
                //options.Conventions.AddPageRoute("/Identity/Pages/Accont/Login", "/login");
                //options.Conventions.AuthorizeAreaFolder("Identity", "/Account");
                //options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                //options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/Manage/Email");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SameCompany", policy => policy.Requirements.Add(new CompanyRequirement()));
            });            
                    
            services.Configure<IdentityOptions>(options => {

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                //options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

            });

            services.ConfigureApplicationCookie(options => {
                // Cookie settings
                //options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/identity/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //Options
            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("SendGrid"));
            
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IAuthorizationHandler, CompanyAuthorizationHandler>();

            //UnitOfWork and Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
                
                endpoints.MapRazorPages().RequireAuthorization();
            });

            //Criando roles
            //CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            string[] names = { "Admin", "Owner", "Manager", "Employed" };

            foreach(var role in names)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                    await roleManager.CreateAsync(new ApplicationRole { Name = role });
            }

        }
    }
}
