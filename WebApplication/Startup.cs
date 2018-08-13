namespace WebApplication
{
    using System;
    using Database.Entities;
    using Database.Infrastracture;
    using Database.Repositories;
    using Database.Repositories.Interfaces;
    using Logic.Services;
    using Logic.Services.Interfaces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Middleware;
    using Migrations;
    using NLog.Extensions.Logging;
    using NLog.Web;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGameUserService, GameUserService>();
            services.AddScoped<IGameUserRepository, GameUserRepository>();
            services.AddScoped<IUserBetsService, UserBetsService>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IGameFootballTeamRepository, GameFootballTeamRepository>();
            services.AddScoped<IRoundRepository, RoundRepository>();
            services.AddScoped<IDatabaseConnectionFactory>(x => new RealDatabase(Configuration.GetConnectionString("Security")));

            services.AddDbContext<SecurityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Security")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(x =>
            {
                var password = x.Password;
                password.RequiredLength = 12;
                password.RequireDigit = true;
                password.RequireLowercase = true;
                password.RequireNonAlphanumeric = true;
                password.RequireUppercase = true;
                password.RequiredUniqueChars = 8;

                var lockout = x.Lockout;
                lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                lockout.AllowedForNewUsers = true;
                lockout.MaxFailedAccessAttempts = 3;

                x.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(x =>
            {
                var cookie = x.Cookie;
                cookie.HttpOnly = true;
                cookie.SecurePolicy = CookieSecurePolicy.Always;

                x.LoginPath = "/Account/Login";
                x.SlidingExpiration = true;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");
            app.UseAuthentication();
            app.UseMiddleware(typeof(ErrorHandlerMiddleware));
            app.UseMvc();
        }
    }
}