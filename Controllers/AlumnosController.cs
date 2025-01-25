using Domain.Models;
using Examen_06.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Examen_06.Controllers
{
    public class AlumnosController : Controller
    {
        public IActionResult Index()
        {
            AlumnoService alumnoService = new AlumnoService();
            var alumnos = alumnoService.Listar();

            var model = alumnos.Select(x => new AlumnoModel
            {
                AlumnoID=x.AlumnoID,
                Nombre=x.Nombre,
                Apellido=x.Apellido,
                FechaNacimiento=x.FechaNacimiento,
                CorreoElectronico=x.CorreoElectronico
            
            }).ToList();

           return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AlumnoModel model )
        {
            if (ModelState.IsValid) { 
                AlumnoService alumnoService=new AlumnoService();

                var dominio = new Alumno
                {
                    AlumnoID = model.AlumnoID,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    FechaNacimiento = model.FechaNacimiento,
                    CorreoElectronico = model.CorreoElectronico
                };


                alumnoService.Insertar(dominio);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int id) {
            AlumnoService alumnoService = new AlumnoService();
            Alumno alumno =alumnoService.BuscarPorId(id);

            AlumnoModel alumnoModel = new AlumnoModel();

            alumnoModel.AlumnoID= alumno.AlumnoID;
            alumnoModel.Nombre= alumno.Nombre;
            alumnoModel.Apellido= alumno.Apellido;
            alumnoModel.FechaNacimiento=alumno.FechaNacimiento;
            alumnoModel.CorreoElectronico= alumno.CorreoElectronico;

            return View(alumnoModel);

        }

        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            AlumnoService alumnoService = new AlumnoService();
            alumnoService.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
