using PTC.Domain.Entities;
using PTC.Application.Dtos;

namespace PTC.Application.Mapper
{
    public static class ImagemMapper
    {
        public static Imagem ToDomain(ImagemViewModel viewModel)
        {
            return new Imagem
            {
                CaminhoImagem = viewModel.CaminhoImagem,
            };
        }
    }
}
