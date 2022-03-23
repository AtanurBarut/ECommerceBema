using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mappings;
using Core.Extensions;
using Core.Utilities.Security.Token;
using Core.Utilities.Security.Token.Jwt;
using DataAcccess.Abstract;
using DataAcccess.Concrete.Contexts;
using DataAcccess.Concrete.EntityFremawork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace WebAPI
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
            IServiceCollection servicesCollections = services.AddDbContext<ECommerceBemaContext>(opts => opts.UseSqlServer("Data Source=.; Initial Catalog =ECommerceBemaDB; User Id=sa; Password=sapass"
                 , options => options.MigrationsAssembly("DataAccess").MigrationsHistoryTable
             (HistoryRepository.DefaultTableName, "dbo")));

            services.AddControllers();
            services.AddCustomSwagger();
            services.AddCustomJwtToken(Configuration);       

            #region AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            //#region DI
            //services.AddTransient<IUserDal, EfUserDal>();
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<ITokenService, JwtTokenService>();
            //services.AddTransient<IAuthService, AuthService>();
            //#endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

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
