using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using ReviewsAPI.Extensions;

namespace ReviewsAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? 
                Configuration.GetConnectionString("DefaultDBConnection");
            string jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? Configuration.GetSection("Jwt")["Key"];


            services.ConfigureAutoMapper();
            services.ConfigureCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.ConfigureEntityFramework(connectionString);
            services.ConfigureRepositories();
            services.ConfigureAppServices();


            var key = Encoding.ASCII.GetBytes(jwtSecret);
            services.ConfigureIdentity();
            services.ConfigureAuthentication(key);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowOrigins");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
