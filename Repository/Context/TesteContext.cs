using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options) : base(options)
        {

        }
        public DbSet<Pessoa> ClienteFornecedores { get; set; }
    }
}
