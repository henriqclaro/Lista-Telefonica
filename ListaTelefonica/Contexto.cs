using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaTelefonica.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonica
{
    public class Contexto : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;" +
                "Port=5432;" +
                "Database=ListaTelefonica;" +
                "User Id=postgres;" +
                "Password=postgres;");
        }
    }
}
