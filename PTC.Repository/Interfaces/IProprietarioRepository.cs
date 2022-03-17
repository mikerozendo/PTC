using PTC.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PTC.Repository.Interfaces
{
    public interface IProprietarioRepository
    {
        bool Existe(Proprietario obj);
    }
}
