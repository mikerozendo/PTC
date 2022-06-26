using PTC.Application.Dtos;
using PTC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
