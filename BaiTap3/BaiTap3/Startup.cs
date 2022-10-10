using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Share.Helpers;
using Share.Model;
using Share.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaiTap3
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
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );
            //services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidAudience = Configuration["Jwt:Audience"],
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                  };
              });
            services.AddControllersWithViews();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("HocViens", policy =>
                {
                    policy.RequireClaim("Role", "HocViens");
                });
                options.AddPolicy("GiangViens", policy =>
                {
                    policy.RequireClaim("Role", "GiangViens");
                });
                options.AddPolicy("NguoiDungs", policy =>
                {
                    policy.RequireClaim("Role", "NguoiDungs");
                });
            });
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaiTap3", Version = "v1" });
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        In = ParameterLocation.Header,
            //        Description = "Please insert JWT with Bearer into field",
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.ApiKey
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            //       {
            //         new OpenApiSecurityScheme
            //         {
            //           Reference = new OpenApiReference
            //           {
            //             Type = ReferenceType.SecurityScheme,
            //             Id = "Bearer"
            //           }

            //          },
            //          new string[] { }
            //        }
            //      });
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);
            //});
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo { Title = "BaiTap3", Version = "v1" });
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    setup.IncludeXmlComments(xmlPath);
                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

            });

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
              , b => b.MigrationsAssembly("BaiTap3")));
            services.AddTransient<IMaHoaHelper, MaHoaHelpers>();
            services.AddTransient<IHocVien, HocVien_Svc>();
            services.AddTransient<IKhoaDaoTao, KhoaDaoTao_Svc > ();
            services.AddTransient<ILopHoc, LopHoc_Svc>();
            services.AddTransient<IGiangVien, GiangVien_Svc>();
            services.AddTransient<IThuHocPhi, ThuHocPhi_Svc>();
            services.AddTransient<IMonHoc, MonHoc_Svc>();
            services.AddTransient<ILichHoc, LichHoc_Svc>();
            services.AddTransient<IThuPhiChiTiet, ThuHocPhiChiTiet_Svc>();
            services.AddTransient<IThongKe, ThongKe_Svc>();
            services.AddTransient<INguoiDung, NguoiDung_Svc>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaiTap3 v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
