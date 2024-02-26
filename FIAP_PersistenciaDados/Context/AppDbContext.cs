using FIAP_PersistenciaDados.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FIAP_PersistenciaDados.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
