﻿using PTC.Domain.Entities;
using System.Threading.Tasks;

namespace PTC.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : Base
    {
        Task<string> Inserir(T obj); //Volta mensagem de validacao do fluxo de inserir
        Task Deletar(T obj);
        Task<T> ObterPorId(int id);
    }
}
