using System;
using AutheAutho.Areas.Identity.Data;
using AutheAutho.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AutheAutho.Areas.Identity.IdentityHostingStartup))]
namespace AutheAutho.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ReceiptDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ReceiptDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ReceiptDbContext>();
            });
        }
    }
}