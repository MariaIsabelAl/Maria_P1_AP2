using Microsoft.EntityFrameworkCore;
using Maria_P1_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maria_P1_AP2.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\Categoria.db");
        }

        public DbSet<Categorias> Categorias { get; set; }
    }
}