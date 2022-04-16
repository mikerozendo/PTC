﻿using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IProprietarioService
    {
        string Incluir(Proprietario proprietario);
        bool Existe(Proprietario proprietario);
        IEnumerable<Proprietario> Obter();
    }
}
