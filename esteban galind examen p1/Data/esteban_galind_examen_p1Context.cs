using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using esteban_galind_examen_p1.Models;

namespace esteban_galind_examen_p1.Data
{
    public class esteban_galind_examen_p1Context : DbContext
    {
        public esteban_galind_examen_p1Context (DbContextOptions<esteban_galind_examen_p1Context> options)
            : base(options)
        {
        }

        public DbSet<esteban_galind_examen_p1.Models.Celular> Celular { get; set; } = default!;
        public DbSet<esteban_galind_examen_p1.Models.EGalindo> EGalindo { get; set; } = default!;
    }
}
