using System;
using System.Linq;
using System.Collections.Generic;
using PTC.Domain.Entities;
using PTC.Domain.Enums;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;

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

        public string Inserir(Proprietario obj)
        {
            obj.FormatarEscritaDb();
            obj.Endereco.FormatarEscritaDb();

            if (!Existe(obj))
            {
                if (_documentoService.ValidarDocumento(obj.Documento))
                {
                    obj.Endereco.Id = _enderecoService.Inserir(obj.Endereco);
                    if (obj.Endereco.Id > 0)
                    {
                        try
                        {
                            return _proprietarioRepository.Inserir(obj);
                        }
                        catch (Exception)
                        {
                            _enderecoService.Deletar(obj.Endereco);
                            return "Erro cadastrar proprietário, tente novamente mais tarde";
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

        public IEnumerable<Proprietario> ObterTodos()
        {
            try
            {
                var proprietarios = _proprietarioRepository.ObterTodos();

                foreach (Proprietario obj in proprietarios)
                {
                    obj.FormatarLeituraDb();
                    obj.Endereco.FormatarLeituraDb();
                }

                return proprietarios.OrderByDescending(x => x.Cadastro);
            }
            catch (Exception)
            {
                return new List<Proprietario>();                
            }
        }

        public IEnumerable<Proprietario> ObterFiltrados(DateTime? inicio, DateTime? termino, EnumSituacao situacao)
        {
            try
            {
                if (!(inicio is null) && !(termino is null) && situacao == EnumSituacao.Ativo)
                    return ObterTodos().Where(x => x.Cadastro >= inicio && x.Cadastro <= termino && x.EnumSituacaoProprietario == situacao).OrderByDescending(x => x.Cadastro);

                else if (!(inicio is null) && !(termino is null) && situacao == EnumSituacao.Inativo)
                    return ObterTodos().Where(x => x.Exclusao >= inicio && x.Exclusao <= termino && x.EnumSituacaoProprietario == situacao).OrderByDescending(x => x.Cadastro);

                else
                    return ObterTodos().Where(x => x.EnumSituacaoProprietario == situacao).OrderByDescending(x => x.Exclusao);
            }
            catch (Exception)
            {
               return new List<Proprietario>();
            }
        }
    }
}
