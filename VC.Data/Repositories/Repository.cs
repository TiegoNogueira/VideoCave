using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VC.Data.Contexts;
using VC.Domain.Interfaces;

namespace VC.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly VideoCaveContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(VideoCaveContext context)
        {
            Db = context;
            DbSet = context.Set<TEntity>();
        }

        public void Incluir(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Alterar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public TEntity ObterPorId(string id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate, int quantity, int toSkip)
        {
            return DbSet.Where(predicate).Take(quantity).Skip(toSkip).ToList();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
