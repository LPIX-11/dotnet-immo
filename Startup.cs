﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Immovable.Models;
using Immovable.Services;

namespace Immovable
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
            services.Configure<ImmovableStoreDatabaseSettings>(
                Configuration.GetSection(nameof(ImmovableStoreDatabaseSettings))
            );

            services.AddSingleton<IImmovableStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ImmovableStoreDatabaseSettings>>().Value
            );

            services.AddSingleton<PropertyService>();
            services.AddSingleton<LessorService>();
            services.AddSingleton<CustomerService>();
            services.AddSingleton<Contract>();
            services.AddSingleton<Payment>();
            services.AddSingleton<PaymentType>();
            services.AddSingleton<Year>();
            services.AddSingleton<Month>();
            services.AddSingleton<YearMonth>();
            services.AddSingleton<YearMonthPayment>();
            services.AddSingleton<Picture>();


            services.AddMvc()
            .AddJsonOptions(options => options.UseMemberCasing())
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
