using PTC.WEB.Models.Enums;
using PTC.Web.Models.Interfaces.Services;
using iText.Layout;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace PTC.WEB.Models.Services
{
    public class GeracaoArquivoService : IGeracaoArquivoService
    {
        public async Task GerarImagem(IFormFile arquivo, EnumPastaArquivoIdentificador pasta, string path, string mensagem)
        {
            try
            {
                if (arquivo is not null && mensagem.ToLower().Contains("sucesso"))
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
                if (!string.IsNullOrEmpty(caminhoImagem) && arquivo is not null)
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

        public byte[] GerarImagensArquivoPDF(List<string> caminhosArquivos)
        {
            if (caminhosArquivos.Count == 0 || caminhosArquivos is null) 
                throw new Exception("Você esta tentando gerar o PDF porém o veículo não tem imagens registradas.");

            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            document.Add(
                new Paragraph("Imagens")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(15));

            foreach (string caminho in caminhosArquivos)
            {
                document.Add(new Image(ImageDataFactory
                   .Create(Path.Combine(caminho)))
                   .SetTextAlignment(TextAlignment.CENTER));
            }

            document.Close();
            return stream.ToArray();
        }
    }
}
