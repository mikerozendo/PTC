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

        public dynamic Inserir(Proprietario obj)
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
                        catch (Exception ex)
                        {
                            _enderecoService.Deletar(obj.Endereco);
                            return "Erro ao cadastrar proprietário, tente novamente mais tarde";
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
                if (situacao == EnumSituacao.Todos)
                    return ObterTodos().Where(x => x.Cadastro >= inicio && x.Cadastro <= termino);
                else
                    return ObterTodos().Where(x => x.Cadastro >= inicio && x.Cadastro <= termino && x.EnumSituacaoProprietario == situacao);
            }
            catch (Exception)
            {
                return new List<Proprietario>();
            }
        }

        public void Deletar(Proprietario obj)
        {
            _proprietarioRepository.Deletar(obj);
        }

        public string Alterar(Proprietario obj)
        {
            obj.FormatarEscritaDb();
            obj.Endereco.FormatarEscritaDb();

            if (_documentoService.ValidarDocumento(obj.Documento))
            {
                try
                {
                    obj.Endereco.ProprietarioId = obj.Id;
                    _enderecoService.Alterar(obj.Endereco);
                    _proprietarioRepository.Alterar(obj);
                    return "Alterado com sucesso!";
                }
                catch (Exception)
                {
                    return "Falha na alteração, revise seus dados";
                }
            }
            else
            {
                return "Documento inválido, informe um documento válido";
            }
        }

        public Proprietario ObterPorId(int id)
        {
            Proprietario proprietario = _proprietarioRepository.ObterPorId(id);
            proprietario.FormatarLeituraDb();
            proprietario.Endereco.FormatarLeituraDb();
            return proprietario;
        }

        public IEnumerable<Proprietario> Filtrar(string filtro)
        {
            if (!string.IsNullOrWhiteSpace(filtro) && !filtro.Contains("undefined"))
                return ObterTodos().Where(x => x.Documento.Contains(filtro) || x.Email.Contains(filtro) || x.Endereco.Cep.Contains(filtro) || x.Nome.Contains(filtro) || x.WhatsApp.Contains(filtro));
            else
                return ObterTodos();
        }
    }
}
