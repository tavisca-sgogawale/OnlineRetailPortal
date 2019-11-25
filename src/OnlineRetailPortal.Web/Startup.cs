using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using OnlineRetailPortal.MongoDBStore;
using OnlineRetailPortal.Services;
using OnlineRetailPortal.Services.Services;
using System.IO;

namespace OnlineRetailPortal.Web
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
            var namespaceToTypes = typeof(Filter).Namespace;
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddMvc()
            .AddJsonOptions(options=> {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductStoreFactory>().As<IProductStoreFactory>();
            builder.RegisterType<ImageService>().As<IImageService>();
            builder.RegisterType<CategoryStoreFactory>().As<ICategoryStoreFactory>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<MockProductStore>().Keyed<IProductStore>("Mock");
            builder.RegisterType<MongoProductStore>().Keyed<IProductStore>("Mongo");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/storage"))
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                 Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"))
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
