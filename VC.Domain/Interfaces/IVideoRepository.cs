using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VC.Domain.Models;

namespace VC.Domain.Interfaces
{
    public interface IVideoRepository : IRepository<Video>
    {
        new IEnumerable<Video> Buscar(Expression<Func<Video, bool>> predicate, int quantity, int toSkip);
    }
}