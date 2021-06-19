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

        public IEnumerable<Opera> FindByTitleContainsOrderByTitleOrYear(string q, string s)
        {
            IQueryable<Opera> query = _context.Operas.AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(o => o.Title.Contains(q));
            }

            switch (s)
            {
                case "title_asc":
                    query = query.OrderBy(o => o.Title);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(o => o.Title);
                    break;
                case "year_asc":
                    query = query.OrderBy(o => o.Year);
                    break;
                case "year_desc":
                    query = query.OrderByDescending(o => o.Year);
                    break;
                default:
                    break;
            }

            return query.ToList();
        }

        public IEnumerable<Opera> FindByTitleContainsOrderByTitleOrYearPaging(string q, string s, int pageNumber, int pageSize)
        {
            IQueryable<Opera> query = _context.Operas.AsQueryable();

            // 搜尋
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(o => o.Title.Contains(q));
            }

            // 排序
            switch (s)
            {
                case "title_asc":
                    query = query.OrderBy(o => o.Title);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(o => o.Title);
                    break;
                case "year_asc":
                    query = query.OrderBy(o => o.Year);
                    break;
                case "year_desc":
                    query = query.OrderByDescending(o => o.Year);
                    break;
                default:
                    break;
            }

            // 分頁
            query = query.Skip((pageNumber - 1) * pageSize);
            query = query.Take(pageSize);

            return query.ToList();
        }

        public int CountByTitleContains(string q)
        {
            IQueryable<Opera> query = _context.Operas.AsQueryable();

            // 搜尋
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(o => o.Title.Contains(q));
            }

            return query.Count();
        }
    }
}
