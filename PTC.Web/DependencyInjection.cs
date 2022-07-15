using PTC.Application.Services;
using PTC.Domain.Interfaces.Services;
using PTC.Domain.Interfaces.Repository;
using PTC.Web.Models.Interfaces.Services;
using PTC.Infrastructure.Data.Respository;
using PTC.WEB.Models.Services;

namespace PTC.WEB
{
    public static class DependencyInjection
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            services.AddScoped<IProprietarioService, ProprietarioService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<IDocumentoService, DocumentoService>();
            services.AddScoped<IMarcasService, MarcasService>();
            services.AddScoped<IMarcasRepository, MarcasRepository>();
            services.AddScoped<IVeiculosRepository, VeiculosRepository>();
            services.AddScoped<IVeiculosService, VeiculosService>();
            services.AddScoped<IOperacaoService, OperacaoService>();
            services.AddScoped<IOperacaoRepository, OperacaoRepository>();
            services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            /*ervices.AddScoped<IImagemService, ImagemService>();*/
        }
    }
}
