using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VC.Domain.Interfaces
{
    public interface IRepository <TEntity> : IDisposable where TEntity : class
    {
        void Incluir(TEntity obj);
        void Alterar(TEntity obj);
        TEntity ObterPorId(string id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate, int quantity, int toSkip);
        int SaveChanges();
    }
}