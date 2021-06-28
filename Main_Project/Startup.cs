using Main_Project.Data;
using Main_Project.Interfaces;
using Main_Project.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Main_Project.BL.SQLServises;
using Main_Project.SQLServises;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
//using Main_Project.BL.JWT;

namespace Main_Project
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
            services.AddScoped<Value_Repository>();
            services.AddTransient<IVikladachrep, VikladachRepository>();
            services.AddTransient<ICoursesrep, CoursesRepository>();
            services.AddTransient<IStudentrep, StudentRepository>();
            services.AddTransient<IStudCourses, StudCoursesReposytory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<ICoursesServices, CoursesServices>();
            services.AddTransient<IVikladachServices, VikladachServices>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<AplContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("defaultConnection");
                options.UseSqlServer(connectionString);
            });

            /*services.AddIdentity<Student, IdentityRole>()
               .AddEntityFrameworkStores<AplContext>()
               .AddDefaultTokenProviders();
            
            // Adding Authentication
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding JWT Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = JWTconfig.AUDIENCE,
                    ValidIssuer = JWTconfig.ISSUER,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTconfig.KEY)),
                    ValidateLifetime = true,
                    LifetimeValidator = JWTconfig.ValidateLifeTime
                };
            });
        }
        */
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ne dushit' pls api");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
           /* app.UseAuthentication(); // аутентифікація
            app.UseAuthorization(); // авторизація
           */
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
