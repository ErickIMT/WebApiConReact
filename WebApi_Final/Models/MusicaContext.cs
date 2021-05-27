using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Final.Models
{
    public class MusicaContext:DbContext
    { 
        public MusicaContext(DbContextOptions<MusicaContext> options) : base(options)
        {

        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Cantante> Cantantes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pais> Paises { get; set; }
    }
}
