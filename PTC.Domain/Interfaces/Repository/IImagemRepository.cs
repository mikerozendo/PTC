﻿using PTC.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository
{
    public interface IImagemRepository : ICommandRepository<Imagem>
    {
        Task<List<string>> ObterImagensVeiculosPorIdOperacao(int idOperacao);
        Task<int> InserirImagemProprietario(Imagem obj);
        Task AlterarImagemProprietarioId(Imagem obj);
    }
}
