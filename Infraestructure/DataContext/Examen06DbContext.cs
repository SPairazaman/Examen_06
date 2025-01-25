using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataContext
{
    public class Examen06DbContext:DbContext
    {
        public DbSet<Profesor> Profesores {  get; set; }
        public DbSet<Alumno> Alumnos {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=L-Lenovo1-SP\\SqlExpress2022;"+
                                                            "Database=Examen06DB;User Id=UserSql;Password=123456;"+
                                                            "Trust Server Certificate=True");
        }
    }
}
