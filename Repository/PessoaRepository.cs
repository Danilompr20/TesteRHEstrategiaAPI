using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly TesteContext _context;
        public PessoaRepository(TesteContext context)
        {
            _context = context;
        }
        public IEnumerable<Pessoa> Get()
        {
            return _context.Set<Pessoa>().AsNoTracking();
        }

        public void Add(Pessoa entity)
        {
            _context.Set<Pessoa>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Pessoa entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<Pessoa>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Pessoa entity)
        {
            _context.Set<Pessoa>().Remove(entity);
            _context.SaveChanges();
        }

        public Pessoa GetById(int id)
        {
            return _context.Set<Pessoa>().Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }
    }
}
