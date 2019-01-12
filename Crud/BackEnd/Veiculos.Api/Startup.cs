using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyHome.Api.Brotli;
using MyHome.Infra.IoC;
using MyHome.Infra.Data;
using Newtonsoft.Json;
using OnAuth2;
using MyHome.Infra.Data.Context;

namespace MyHome.Api
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
            // Configura o modo de compressão
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => // Remove valores nulos das respostas
                 {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });


            // USE OnAUTH Options
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = "studio.myapp.myhome",
                        ValidAudience = "studio.myapp.myhome",
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = SecurityKeyBuilder.Build("$tud10@My4pp5!2018"),
                    });

            services.AddInjectionContainer();
            services.AddDbContext<DataContext>();


     
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                 .AddJsonOptions(options => // Remove valores nulos das respostas
                 {
                     options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            });

            // Ativa a compressão
            app.UseResponseCompression();

            //app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("../swagger/v1/swagger.json", "MyTime V1");
            //    c.InjectStylesheet("../swagger-ui/custom.css");
            //    c.InjectJavascript("../swagger-ui/custom.js");
            //    c.DocExpansion(DocExpansion.None);
            //});

            app.UseStaticFiles();
            //app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
