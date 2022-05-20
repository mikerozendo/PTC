using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PTC.Domain.Interfaces.Services;
using PTC.Domain.Interfaces.Repository;
using PTC.Application.Services;
using PTC.Infrastructure.Data.Respository;
using PTC.Web.Models.Interfaces.Services;
using PTC.Web.Models.Services;

namespace PTC.Web
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddScoped<IProprietarioService, ProprietarioService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<IDocumentoService, DocumentoService>();
            services.AddScoped<IMarcasService, MarcasService>();
            services.AddScoped<IMarcasRepository, MarcasRepository>();
            services.AddScoped<IVeiculosRepository, VeiculosRepository>();
            services.AddScoped<IVeiculosService, VeiculosService>();
            services.AddScoped<IHelperService, HelperService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Veiculos}/{action=Adicionar}");
            });
        }
    }
}
