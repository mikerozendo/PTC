using System;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Repository
{
    interface IQueryRepository<T>
    {
        IEnumerable<T> ObterTodos();
        T ObterPorId(int id);
        bool Existe(T obj);
        IEnumerable<T> ObterPorPeriodo(DateTime inicio, DateTime termino);
    }
}
