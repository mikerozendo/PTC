using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Services;
using PTC.Domain.Interfaces.Repository;

namespace PTC.Application.Services
{
    public class ProprietarioService : BaseService, IProprietarioService
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly IDocumentoService _documentoService;

        public ProprietarioService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _proprietarioRepository = (IProprietarioRepository)serviceProvider.GetService(typeof(IProprietarioRepository));
            _enderecoService = (IEnderecoService)serviceProvider.GetService(typeof(IEnderecoService));
            _documentoService = (IDocumentoService)serviceProvider.GetService(typeof(IDocumentoService)); ;
        }

        public async Task<string> Inserir(Proprietario obj)
        {
            if (!await Existe(obj))
            {
                if (_documentoService.ValidarDocumento(obj.Documento))
                {
                    int.TryParse(await _enderecoService.Inserir(obj.Endereco), out int idEndereco);

                    if (idEndereco > 0)
                    {
                        obj.Endereco.Id = idEndereco;

                        try
                        {
                            int proprietarioId = await _proprietarioRepository.Inserir(obj);

                            if (proprietarioId > 0)
                            {
                                return "Sucesso ao cadastrar Proprietario";
                            }
                            else
                            {
                                await RollBackBuilder(obj.Endereco);
                                return "Erro ao cadastrar proprietário, tente novamente mais tarde";
                            }
                        }
                        catch (Exception)
                        {
                            await RollBackBuilder(obj.Endereco);
                            return "Erro ao cadastrar proprietário, tente novamente mais tarde";
                        }
                    }

                    return "Falha ao cadastrar endereço, tente novamente";
                }
                else return "Informe um documento válido!";
            }
            else return "Proprietário existente!";
        }

        public async Task RollBackBuilder(Endereco obj)
        {
            await _enderecoService.Deletar(obj);
        }

        public async Task<bool> Existe(Proprietario obj)
        {
            return await _proprietarioRepository.Existe(obj);
        }

        public async Task<IEnumerable<Proprietario>> ObterTodos()
        {
            try
            {
                var proprietarios = await _proprietarioRepository.ObterTodos();
                return proprietarios.OrderByDescending(x => x.Cadastro).ToList();
            }
            catch (Exception)
            {
                return new List<Proprietario>();
            }
        }

        public async Task Deletar(Proprietario obj)
        {
            await _proprietarioRepository.Deletar(obj);
        }

        public async Task<string> Alterar(Proprietario obj)
        {
            if (_documentoService.ValidarDocumento(obj.Documento))
            {
                try
                {
                    obj.Endereco.ProprietarioId = obj.Id;
                    await _enderecoService.Alterar(obj.Endereco);
                    await _proprietarioRepository.Alterar(obj);
                    return "Alterado com sucesso!";
                }
                catch (Exception)
                {
                    return "Falha na alteração, revise seus dados";
                }
            }
            else return "Informe um documento válido";
        }

        public async Task<Proprietario> ObterPorId(int id)
        {
            return await _proprietarioRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Proprietario>> Filtrar(string filtro)
        {
            var lista = await ObterTodos();

            if (!string.IsNullOrWhiteSpace(filtro) && !filtro.Contains("undefined"))
            {
                return lista
                    .Where(x => x.Documento.Contains(filtro)
                        || x.Email.Contains(filtro)
                        || x.Endereco.Cep.Contains(filtro)
                        || x.Nome.Contains(filtro)
                        || x.WhatsApp.Contains(filtro))
                    .ToList();

            }
            else return lista.ToList();
        }
    }
}
