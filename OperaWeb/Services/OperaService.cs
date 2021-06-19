using OperaWeb.Models;
using OperaWeb.Repositories;
using OperaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperaWeb.Services
{
    public class OperaService : IOperaService
    {
        private readonly IOperaRepository _operaRepository;

        public OperaService(IOperaRepository operaRepository)
        {
            _operaRepository = operaRepository;
        }

        public IEnumerable<Opera> List()
        {
            return _operaRepository.List();
        }

        public Opera FindById(int id)
        {
            return _operaRepository.FindById(id);
        }

        public void Create(Opera opera)
        {
            _operaRepository.Create(opera);
        }

        public void Edit(Opera opera)
        {
            _operaRepository.Edit(opera);
        }

        public void Delete(int id)
        {
            _operaRepository.Delete(_operaRepository.FindById(id));
        }

        public IEnumerable<Opera> Search(string q)
        {
            return _operaRepository.FindByTitleContains(q);
        }

        public IEnumerable<Opera> Search(string q, string s)
        {
            return _operaRepository.FindByTitleContainsOrderByTitleOrYear(q, s);
        }

        public Pagination<Opera> Search(string q, string s, int pageNumber, int pageSize)
        {
            Pagination<Opera> pagination = new();
            pagination.List = _operaRepository.FindByTitleContainsOrderByTitleOrYearPaging(q, s, pageNumber, pageSize);
            pagination.Count = _operaRepository.CountByTitleContains(q);
            pagination.PageNumber = pageNumber;
            pagination.PageSize = pageSize;

            return pagination;
        }
    }
}
