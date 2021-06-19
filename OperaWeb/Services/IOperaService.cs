using OperaWeb.Models;
using OperaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperaWeb.Services
{
    public interface IOperaService
    {
        IEnumerable<Opera> List();

        Opera FindById(int id);

        void Create(Opera opera);

        void Edit(Opera opera);

        void Delete(int id);

        IEnumerable<Opera> Search(string q);

        IEnumerable<Opera> Search(string q, string s);

        Pagination<Opera> Search(string q, string s, int pageNumber, int pageSize);
    }
}
