using InventoryManagement.Repository.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using InventoryManagement.Repository;
using InventoryManagement.Entities.Models;
using AutoMapper;

namespace InventoryManagement.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InventoryManagementContext>((provider, option) => {
                var db = option.UseSqlServer(Configuration.GetConnectionString("ReleaseConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                if (Environment.IsDevelopment())
                {
                    db.EnableSensitiveDataLogging()
                    .UseLoggerFactory(provider.GetService<ILoggerFactory>());

                }
            });

            services.AddScoped<IRepository<Product>, BaseRepository<Product, InventoryManagementContext>>();
            services.AddScoped<IRepository<Seller>, BaseRepository<Seller, InventoryManagementContext>>();
            services.AddScoped<IRepository<SellingOrder>, BaseRepository<SellingOrder, InventoryManagementContext>>();

            MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddCors(o => o.AddPolicy("InventoryManagementPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryManagement_WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DomProject.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("InventoryManagementPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
