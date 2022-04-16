using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTC.Application.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly IDocumentoService _documentoService;

        public ProprietarioService(IProprietarioRepository proprietarioRepository, IEnderecoService enderecoService, IDocumentoService documentoService)
        {
            _proprietarioRepository = proprietarioRepository;
            _enderecoService = enderecoService;
            _documentoService = documentoService;
        }

        public string Incluir(Proprietario obj)
        {
            obj.FormatarValoresEnvioDb();
            if (!Existe(obj))
            {
                if (_documentoService.ValidarDocumento(obj.Documento))
                {
                    obj.Endereco.Id = _enderecoService.Incluir(obj.Endereco);
                    if (obj.Endereco.Id > 0)
                    {
                        try
                        {                    
                            _proprietarioRepository.Incluir(obj);
                        }
                        catch (Exception)
                        {
                            _enderecoService.ExcluirPorId(obj.Endereco.Id);
                            return "Erro na importação! tente novamente mais tarde";
                        }
                    }
                    return "Proprietário cadastrado com sucesso!";
                }
                else return "Informe um documento válido!";
            }
            else return "Proprietário existente!";
        }

        public bool Existe(Proprietario obj)
        {
            return _proprietarioRepository.Existe(obj);
        }

        public IEnumerable<Proprietario> Obter()
        {
            var proprietarios = _proprietarioRepository.ObterTodos();
            foreach (Proprietario obj in proprietarios)
                obj.FormatarValoresRetornoDb();

            return proprietarios;
        }
    }
}
