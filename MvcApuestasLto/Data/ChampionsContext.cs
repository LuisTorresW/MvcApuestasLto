using Microsoft.EntityFrameworkCore;
using MvcApuestasLto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasLto.Data
{
    public class ChampionsContext:DbContext
    {
        public ChampionsContext(DbContextOptions<ChampionsContext> options) : base(options) { }

        public DbSet<Apuestas> Apuestas { get; set; }

        public DbSet<Equipos> Equipos { get; set; }

        public DbSet<Jugadores> Jugadores { get; set; }
    }
}
