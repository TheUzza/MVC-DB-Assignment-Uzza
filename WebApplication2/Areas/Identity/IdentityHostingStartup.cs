﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Areas.Identity.Data;

[assembly: HostingStartup(typeof(WebApplication2.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityDBContextConnection")));

                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityDBContext>();
            });
        }
    }
}
