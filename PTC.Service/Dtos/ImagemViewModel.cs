using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Application.Dtos
{
    public class ImagemViewModel
    {
        public string CaminhoImagem { get; set; }
        public IFormFile Imagem { get; set; }
        public ImagemViewModel() { }

    }
}
