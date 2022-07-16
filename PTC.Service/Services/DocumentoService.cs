using System;
using System.Linq;
using System.Collections.Generic;
using PTC.Domain.Interfaces.Services;
using PTC.Domain.Extentitions;

namespace PTC.Application.Services
{
    public class DocumentoService : IDocumentoService
    {
        public bool ValidarDocumento(string documento)
        {
            if (!String.IsNullOrEmpty(documento)) {
                string documentoFormatado = documento.DocumentoValidFormat();
                if (!string.IsNullOrEmpty(documentoFormatado) && !ValidarCaracteresIguais(documentoFormatado))
                {

                    if (documentoFormatado.Length == 11)
                        return ValidarCPF(documentoFormatado);
                    else
                        return ValidarCnpj(documentoFormatado);
                }

                return false;
            }

            else return false;
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
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
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

                    return segundoDV.ToString() == cpfBase[10].ToString() ||
                    segundoDV == 0 && cpfBase[10] == '0' ||
                    segundoDV == 1 && cpfBase[10] == '0';
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidarCaracteresIguais(string documento)
        {
            var array = documento.ToCharArray();
            string firstItem = array[0].ToString();
            bool allEqual = array.Skip(1).All(s => string.Equals(firstItem, s.ToString(), StringComparison.InvariantCultureIgnoreCase));
            return allEqual;
        }

        public string FormatarDocumento(string documento)
        {
            string documentoFormatado = documento;

            if (documentoFormatado.Contains("."))
                documentoFormatado = documentoFormatado.Replace(".", String.Empty);

            if (documentoFormatado.Contains("-"))
                documentoFormatado = documentoFormatado.Replace("-", String.Empty);

            if (documentoFormatado.Contains("/"))
                documentoFormatado = documentoFormatado.Replace("/", String.Empty);

            return documentoFormatado;
        }
    }
}
