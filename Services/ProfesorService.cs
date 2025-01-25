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
    public class ProfesorService
    {
        public List<Profesor> Listar()
        {
            using (var _context = new Examen06DbContext())
            {
                return _context.Profesores.Where(x=>x.Estado==true).ToList();
            }
        }

        public void Insertar(Profesor profesor) {
            using (var _context = new Examen06DbContext())
            {
                profesor.Estado = true;
                _context.Profesores.Add(profesor);
                _context.SaveChanges();
            }
        }

        public void Editar(int id, Profesor profesor)
        {
            using (var _context = new Examen06DbContext())
            {
                Profesor profesorModificar = BuscarPorId(id);
                profesorModificar.ProfesorID=profesor.ProfesorID;
                profesorModificar.Nombre = profesor.Nombre;
                profesorModificar.Apellido = profesor.Apellido;
                profesorModificar.Especialidad=profesor.Especialidad;
                profesorModificar.CorreoElectronico=profesor.CorreoElectronico;

                _context.Entry(profesorModificar).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var _context = new Examen06DbContext())
            {
                Profesor profesorEliminar = _context.Profesores.Find(id);
                profesorEliminar.Estado= false;

                _context.Entry(profesorEliminar).State=EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public Profesor BuscarPorId(int id)
        {
            using (var _context = new Examen06DbContext())
            {
               return _context.Profesores.Find(id);
            }
        }

    }
}
