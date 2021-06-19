using OperaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperaWeb.Repositories
{
    public interface IOperaRepository
    {
        IEnumerable<Opera> List();

        Opera FindById(int id);

        void Create(Opera opera);

        void Edit(Opera opera);

        void Delete(Opera opera);

        IEnumerable<Opera> FindByTitleContains(string q);

        IEnumerable<Opera> FindByTitleContainsOrderByTitleOrYear(string q, string s);

        IEnumerable<Opera> FindByTitleContainsOrderByTitleOrYearPaging(string q, string s, int pageNumber, int pageSize);

        int CountByTitleContains(String q);
    }
}
