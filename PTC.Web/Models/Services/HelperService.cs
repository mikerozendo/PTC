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
                    string uploadsFolder = Path.Combine(path, "images");
                    string filePath = Path.Combine(uploadsFolder, arquivo.FileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    await arquivo.CopyToAsync(fileStream);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
