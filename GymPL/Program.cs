using System.Diagnostics;
using GymBL.Comman;
using GymBL.Services.Impmention;
using GymBL.Services.Interfaces;
using GymDAL.Common;
using GymDAL.Data;
using GymDAL.Entities;
using GymDAL.Repos.Implmention;
using GymDAL.Repos.InterFaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Rigster service
            // this is extenisson method come from Common Folder where i rigster service into interface
            builder.Services.AddMemberRepoInDAL();
            builder.Services.AddMemberBusnissToBLL();
            builder.Services.AddTrainerRepoInDAL();
            builder.Services.AddTrainerBusnissToBLL();
            #endregion

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            #region AutoMapper
            //Code in Common Folder
            #endregion

            #region AddAuthentication
            #region ConnectionString
            var CS = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(CS)
            .LogTo(message => Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging()
            );

            #endregion
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;

                options.User.RequireUniqueEmail = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            })
   .AddEntityFrameworkStores<AppDbContext>()
   .AddDefaultTokenProviders();


            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/LogIn";
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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



            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
