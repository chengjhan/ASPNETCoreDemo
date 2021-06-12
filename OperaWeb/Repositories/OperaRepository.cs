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
    }
}
