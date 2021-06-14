using OperaWeb.Data;
using OperaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperaWeb.Repositories
{
    public class OperaRepository : IOperaRepository
    {
        private readonly OperaContext _context;

        public OperaRepository(OperaContext context)
        {
            _context = context;
        }

        public IEnumerable<Opera> List()
        {
            return _context.Operas.ToList();
        }

        public Opera FindById(int id)
        {
            return _context.Operas.FirstOrDefault(m => m.OperaID == id);
        }

        public void Create(Opera opera)
        {
            _context.Add(opera);
            _context.SaveChanges();
        }

        public void Edit(Opera opera)
        {
            _context.Update(opera);
            _context.SaveChanges();
        }

        public void Delete(Opera opera)
        {
            _context.Remove(opera);
            _context.SaveChanges();
        }

        public IEnumerable<Opera> FindByTitleContains(string q)
        {
            IQueryable<Opera> query = _context.Operas.AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(o => o.Title.Contains(q));
            }

            return query.ToList();
        }
    }
}
