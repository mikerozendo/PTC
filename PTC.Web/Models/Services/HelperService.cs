using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.Web.Models.Services
{
    public class HelperService : IHelperService
    {
        public async Task GerarImagemProprietario(IFormFile arquivo, string path, string mensagem)
        {
            try
            {
                if (mensagem.ToLower().Contains("sucesso"))
                {
                    string filePath = Path.Combine(path, "images", arquivo.FileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    await arquivo.CopyToAsync(fileStream);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task AlterarImagemProprietario(IFormFile arquivo, string path, string mensagem, string caminhoImagem)
        {
            try
            {

                if (!string.IsNullOrEmpty(caminhoImagem) && !(arquivo is null))
                {
                    string antigaImagem = Path.Combine(path, caminhoImagem);
                    if (File.Exists(antigaImagem) && mensagem.ToLower().Contains("sucesso"))
                    {
                        File.Delete(antigaImagem);
                        string newFile = Path.Combine(path, "images", arquivo.FileName);
                        using var fileStream = new FileStream(newFile, FileMode.Create);
                        await arquivo.CopyToAsync(fileStream);
                    }
                }
             
                await Task.Delay(1);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
