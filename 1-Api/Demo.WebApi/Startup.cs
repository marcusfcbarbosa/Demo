using Demo.Domain.StoreContext.Commands.Inputs;
using Demo.Domain.StoreContext.Interfaces;
using Demo.Infra.NOSQLContexts;
using Demo.Infra.NOSQLContexts.Repositories;
using Demo.Infra.SQLContexts;
using Demo.Infra.SQLContexts.Repositories.Users;
using Demo.Shared.BackgroundTasks;
using Demo.WebApi.Auth;
using Demo.WebApi.InfraEstructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Demo.WebApi
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
            services.AddControllers();
            services.AddHttpClient();
            services.Configure<ConfigDB>(
               x =>
               {
                   x.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                   x.DataBase = Configuration.GetSection("MongoConnection:DataBase").Value;
               });
            services.AddDbContext<SQLDemoContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //RegisteringDependencies(services);
            DocumentingAPI(services);
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }
        public void DocumentingAPI(IServiceCollection services)
        {
            services.AddSwaggerDocumentation();
        }
        public void RegisteringDependencies(IServiceCollection services)
        {
            #region"Contexto"
            services.AddScoped<SQLDemoContext, SQLDemoContext>();
            #endregion

            #region"Repositórios"
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMongoUserRepository, MongoUserRepository>();
            #endregion

            #region"mediator"
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
            #endregion


            services.AddSingleton<BackgroundTask>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }
            app.UseRouting();
            app.UseMiddleware<AuthMiddleware>();
            app.UseCors(x => x
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
