using OperaWeb.Models;
using OperaWeb.Repositories;
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
    }
}
