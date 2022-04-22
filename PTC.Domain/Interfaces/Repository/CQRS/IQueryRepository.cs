﻿using System;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository.CQRS
{
    public interface IQueryRepository<T>
    {
        IEnumerable<T> ObterTodos();
        T ObterPorId(int id);
        bool Existe(T obj);
        IEnumerable<T> ObterPorPeriodoCadastro(DateTime inicio, DateTime termino);
    }
}