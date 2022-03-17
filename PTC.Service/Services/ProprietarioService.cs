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

        public ProprietarioService(IProprietarioRepository proprietarioRepository, IEnderecoService enderecoService)
        {
            _proprietarioRepository = proprietarioRepository;
            _enderecoService = enderecoService;
        }

        public string Incluir(Proprietario obj)
        {
            obj.FormatarValoresEnvioDb();
            if (!Existe(obj))
            {
                if (ValidarDocumento(obj.Documento))
                {
                    int enderecoId = _enderecoService.Incluir(obj.Endereco);
                    if (enderecoId > 0)
                    {
                        try
                        {                    
                            _proprietarioRepository.Incluir(obj);
                        }
                        catch (Exception)
                        {
                            _enderecoService.ExcluirPorId(enderecoId);
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

        public bool ValidarDocumento(string documento)
        {
            if (documento.Length == 11)
                return ValidarCPF(documento);
            else
                return ValidarCnpj(documento);
        }

        public bool ValidarCPF(string cpf)
        {
            char[] cpfBase = cpf.ToCharArray();

            int primeiroDV, segundoDV, somaDv = 0;
            int multiplicador = 10;

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i < cpfBase.Count() - 2; i++)
                {
                    dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));
                    if (dictionary.TryGetValue(i, out int value))
                    {
                        somaDv += value;
                    }
                    multiplicador -= 1;
                }

                primeiroDV = 11 - (somaDv % 11);
                multiplicador = 11;
                dictionary.Clear();
                somaDv = 0;

                if (primeiroDV.ToString() == cpfBase[9].ToString() ||
                    (primeiroDV == 0 && cpfBase[9] == '0') ||
                    (primeiroDV == 1 && cpfBase[9] == '0'))
                {
                    for (int i = 0; i < cpfBase.Count() - 1; i++)
                    {
                        dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));

                        if (dictionary.TryGetValue(i, out int value))
                            somaDv += value;

                        multiplicador -= 1;
                    }
                    segundoDV = 11 - (somaDv % 11);

                    if (segundoDV.ToString() == cpfBase[10].ToString() ||
                    (segundoDV == 0 && cpfBase[10] == '0') ||
                    (segundoDV == 1 && cpfBase[10] == '0'))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            char[] cnpjCarcteres = cnpj.ToCharArray();

            int primeiroDV, segundoDV, somaDv = 0;
            int multiplicador = 6;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i <= cnpjCarcteres.Count() - 3; i++)
                {
                    if (multiplicador > 9)
                        multiplicador = 2;

                    dictionary.Add(i, multiplicador * int.Parse(cnpjCarcteres[i].ToString()));

                    if (dictionary.TryGetValue(i, out int value))
                        somaDv += value;

                    multiplicador++;
                }

                multiplicador = 5;
                primeiroDV = somaDv % 11;
                dictionary.Clear();

                if (primeiroDV.ToString() == cnpjCarcteres[12].ToString())
                {
                    for (int i = 0; i <= cnpjCarcteres.Count() - 2; i++)
                    {
                        if (multiplicador > 9)
                            multiplicador = 2;

                        dictionary.Add(i, multiplicador * int.Parse(cnpjCarcteres[i].ToString()));

                        if (dictionary.TryGetValue(i, out int value) && i == 0)
                            somaDv = value;
                        else if (dictionary.TryGetValue(i, out int obj))
                            somaDv += obj;

                        multiplicador++;
                    }

                    segundoDV = somaDv % 11;

                    return segundoDV.ToString() == cnpjCarcteres[13].ToString();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
