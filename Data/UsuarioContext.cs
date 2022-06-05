using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesafioSistemasInfo.Models;

namespace DesafioSistemasInfo.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext()
        {

        }
        public UsuarioContext (DbContextOptions<UsuarioContext> options)
            : base(options)
        {
        }

        public DbSet<DesafioSistemasInfo.Models.Usuario>? Usuario { get; set; }

    }

    
}
