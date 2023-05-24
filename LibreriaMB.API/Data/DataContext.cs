using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibreriaMB.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<LibreriaMB.Modelos.Libro> Libro { get; set; } = default!;

        public DbSet<LibreriaMB.Modelos.Libreria> Libreria { get; set; } = default!;
    }
