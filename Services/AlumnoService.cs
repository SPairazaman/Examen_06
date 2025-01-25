using Domain.Models;
using Infraestructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AlumnoService
    {
        public List<Alumno> Listar()
        {
            using (var _context = new Examen06DbContext())
            {
                return _context.Alumnos.Where(x=>x.Estado==true).ToList();
            }
        }

        public void Insertar(Alumno alumno) {
            using (var _context = new Examen06DbContext())
            {
                alumno.Estado = true;
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
            }
        }

        public void Editar(int id, Alumno alumno)
        {
            using (var _context = new Examen06DbContext())
            {
                Alumno alumnoModificar = BuscarPorId(id);
                alumnoModificar.AlumnoID=alumno.AlumnoID;
                alumnoModificar.Nombre = alumno.Nombre;
                alumnoModificar.Apellido = alumno.Apellido;
                alumnoModificar.FechaNacimiento=alumno.FechaNacimiento;
                alumnoModificar.CorreoElectronico=alumno.CorreoElectronico;

                _context.Entry(alumnoModificar).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var _context = new Examen06DbContext())
            {
                Alumno alumnoEliminar = _context.Alumnos.Find(id);
                alumnoEliminar.Estado= false;

                _context.Entry(alumnoEliminar).State=EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public Alumno BuscarPorId(int id)
        {
            using (var _context = new Examen06DbContext())
            {
               return _context.Alumnos.Find(id);
            }
        }

    }
}
