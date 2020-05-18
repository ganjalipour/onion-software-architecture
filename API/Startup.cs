using System.Text;
using AutoMapper;
using Consulting.Applications.AppService.AuthAppService;
using Consulting.Applications.AppService.RoleManagement;
using Consulting.Common.Data;
using Consulting.Domains.Core.Repositories;
using Consulting.Domains.Core.Service;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;

using Consulting.Infrastructure.Data.Repositories.MongoDbManagment;
using Consulting.Domains.Core.MongoDb.Service;
using Consulting.Infrastructure.Core.Data.Repositories.MongoDbManagment;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.CoreContext;
using Consulting.Infrastructure.Data.Factories;
using Consulting.Infrastructure.Core.Data.Factories;
using Microsoft.AspNetCore.SignalR;
using API.HandleRequest;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Consulting.Domains.MongoDb.Repositories;
using Consulting.Domains.MongoDb.Service;
using Consulting.Domains.Customer.Repositories;
using Consulting.Domains.Customer.Service;
using Consulting.Domains.Core.Customer.Repositories;
using Consulting.Applications.Customer;
using Consulting.Applications.Notification;
using Consulting.Applications.Mapper;
using Consulting.Applications.ExceptionHandling;
using Consulting.Applications.AppService.FileManagement;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSignalR();
            services.AddMvc(p=>p.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            #region AddScoped_Dependency
            services.AddScoped<ActionFilterMicroFund>();
            services.AddScoped<ActionRequestFilter>();
            services.AddSingleton<MongoDBManager, MongoDBManager>();
            services.AddSingleton<IServiceLogRepository, ServiceLogRepository>();
            services.AddSingleton<IExceptionLogRepository, ExceptionLogRepository>();
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<AuditLogRepository>();
            services.AddSingleton<ServiceLogService>();
            services.AddSingleton<ExceptionLogService>();
            services.AddSingleton<AuditLogService>();


            services.AddScoped<ITransactionManager, TransactionManager>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<RoleService, RoleService>();
            services.AddScoped<RoleAppService, RoleAppService>();

            services.AddScoped<IActivityRepositoy, ActivityRepositoy>();
            services.AddScoped<AccessControlAppService, AccessControlAppService>();
            services.AddScoped<ActivityService, ActivityService>();

            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<BranchAppService, BranchAppService>();
            services.AddScoped<BranchService, BranchService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserAppService, UserAppService>();
            services.AddScoped<UserService, UserService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserBranchRepository, UserBranchRepository>();

            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<ZoneAppService, ZoneAppService>();
            services.AddScoped<ZoneService, ZoneService>();



            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<CustomerService, CustomerService>();
            services.AddScoped<CustomerAppService, CustomerAppService>();
            services.AddScoped<ICustomerDetailsRepository, CustomerDetailsRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<UploadAppService>();
            services.AddScoped<UploadService>();
            services.AddScoped<NotificationAppService, NotificationAppService>();
            services.AddScoped<NotificationService, NotificationService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();


            services.AddScoped<ConsultAppService>();
            services.AddScoped<ConsultService>();
            services.AddScoped<IConsultRepository, ConsultRepository>();

            services.AddHttpContextAccessor();
            services.AddSingleton<UserResolverService>();

            services.AddSingleton<IUserIdProvider, CustomUserIDProvider>();

            services.AddDbContextPool<AppCommandDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConsultingConnectionString")).EnableSensitiveDataLogging(true));

            services.AddDbContextPool<AppQueryDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConsultingConnectionString")).EnableSensitiveDataLogging(true));

            services.AddScoped<IContextProviderFactory, ContextFactory>();

            #endregion AddScoped_Dependency

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200"). 
                    //"http://localhost:4285", "http://Consulting.karafariniomid.com").
                AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JIOBLi6eVjBpvGtWBgJzjWd2QH0sOn5tI8rIFXSHKijXWEt/3J2jFYL79DQ1vKu+EtTYgYkwTluFRDdtF41yAQ=="))
                };

        
            });

            //services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //});

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "My API"
            //    });
            //});


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("CorsPolicy");

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCommandDBContext>();
                if (env.IsDevelopment())
                {

                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }
            }
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseMiddleware<ExceptionMiddleware>();
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    //c.RoutePrefix = string.Empty;
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationAppService>("/message");
            });

            app.UseMvc();
        }
    }
}
