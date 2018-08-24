using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyHome.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MyHome.Areas.Identity.IdentityHostingStartup))]
namespace MyHome.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyHomeIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("MyHomeIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<MyHomeIdentityDbContext>();
            });
        }
    }
}