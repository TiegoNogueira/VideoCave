using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VC.Data.Contexts;
using VC.Domain.Interfaces;
using VC.Domain.Models;

namespace VC.Data.Repositories
{
    public class VideoRepository : Repository<Video> , IVideoRepository
    {
        public VideoRepository(VideoCaveContext db) : base(db)
        {
        }

        IEnumerable<Video> IVideoRepository.Buscar(Expression<Func<Video, bool>> predicate, int quantity, int toSkip)
        {
            if (quantity > 20)
                quantity = 20;

            return Buscar(predicate, quantity, toSkip);
        }
    }
}