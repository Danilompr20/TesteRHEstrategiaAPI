using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public interface IPessoaRepository
    {
        void Add(Pessoa entity);
        void Delete(Pessoa entity);
        IEnumerable<Pessoa> Get();
        void Update(Pessoa entity);
        Pessoa GetById(int id);
    }
}