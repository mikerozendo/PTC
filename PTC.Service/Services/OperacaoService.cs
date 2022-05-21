using PTC.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Application.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IVeiculosService _veiculosService;

        public OperacaoService(IVeiculosService veiculosService)
        {
            _veiculosService = veiculosService;
        }


    }
}
