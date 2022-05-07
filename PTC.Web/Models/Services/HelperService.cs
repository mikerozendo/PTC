using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PTC.Domain.Entities;
using PTC.Web.Models.Interfaces.Services;

namespace PTC.Web.Models.Services
{
    public class HelperService : IHelperService
    {
        public async Task<Imagem> GerarImagemProprietario(IFormFile arquivo, string path)
        {
            try
            {
                string uploadsFolder = Path.Combine(path, "images");
                string filePath = Path.Combine(uploadsFolder, arquivo.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                await arquivo.CopyToAsync(fileStream);
                return new Imagem(arquivo.FileName, "Sucesso!");
            }
            catch (Exception)
            {
                return new Imagem(string.Empty, "Falha!");
            }
        }

        public void DeletarImagem(string path, string imagem, string mensagemInsert)
        {
            try
            {
                if (!mensagemInsert.ToLower().Contains("sucesso"))
                {
                    string uploadsFolder = Path.Combine(path, "images");
                    string filePath = Path.Combine(uploadsFolder, imagem);
                    File.Delete(filePath);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
