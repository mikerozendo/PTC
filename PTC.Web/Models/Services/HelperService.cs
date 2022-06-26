using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PTC.Web.Models.Enums;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.Web.Models.Services
{
    public class HelperService : IHelperService
    {
        public async Task GerarImagem(IFormFile arquivo, EnumPastaArquivoIdentificador pasta, string path, string mensagem)
        {
            try
            {
                if (!(arquivo is null) && mensagem.ToLower().Contains("sucesso"))
                {
                    string filePath = Path.Combine(path, "images", pasta.ToString(), arquivo.FileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
                    await arquivo.CopyToAsync(fileStream);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task AlterarImagem(IFormFile arquivo, EnumPastaArquivoIdentificador pasta, string path, string mensagem, string caminhoImagem)
        {
            try
            {
                if (!string.IsNullOrEmpty(caminhoImagem) && !(arquivo is null))
                {
                    string antigaImagem = Path.Combine(path, pasta.ToString(), caminhoImagem);
                    if (File.Exists(antigaImagem) && mensagem.ToLower().Contains("sucesso"))
                    {
                        File.Delete(antigaImagem);
                        string newFile = Path.Combine(path, "images", pasta.ToString(), arquivo.FileName);
                        using var fileStream = new FileStream(newFile, FileMode.Create, FileAccess.ReadWrite);
                        await arquivo.CopyToAsync(fileStream);
                    }
                }

                return;
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task GerarImagens(List<IFormFile> arquivos, EnumPastaArquivoIdentificador pasta, string path, string mensagem)
        {
            try
            {
                if (mensagem.ToLower().Contains("sucesso"))
                {
                    foreach (IFormFile item in arquivos)
                    {
                        await GerarImagem(item, pasta, path, mensagem);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
