using Domain.Models;
using Examen_06.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Examen_06.Controllers
{
    public class ProfesoresController : Controller
    {
        public IActionResult Index()
        {
            ProfesorService profesorService = new ProfesorService();
            var profesores = profesorService.Listar();

            var model = profesores.Select(x => new ProfesorModel
            {
                ProfesorID=x.ProfesorID,
                Nombre=x.Nombre,
                Apellido=x.Apellido,
                Especialidad=x.Especialidad,
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
        public IActionResult Create(ProfesorModel model )
        {
            if (ModelState.IsValid) { 
                ProfesorService profesorService=new ProfesorService();

                var dominio = new Profesor
                {
                    ProfesorID = model.ProfesorID,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Especialidad = model.Especialidad,
                    CorreoElectronico = model.CorreoElectronico
                };


                profesorService.Insertar(dominio);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            ProfesorService profesorService = new ProfesorService();
             ProfesorModel model = new ProfesorModel();
            Profesor profesor=profesorService.BuscarPorId(id);

            model.ProfesorID= profesor.ProfesorID;
            model.Nombre= profesor.Nombre;
            model.Apellido= profesor.Apellido;
            model.Especialidad=profesor.Especialidad;
            model.CorreoElectronico= profesor.CorreoElectronico;
            return View(model);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProfesorModel model)
        {
            ProfesorService profesorService = new ProfesorService();
            Profesor profesor=new Profesor();

            profesor.ProfesorID = model.ProfesorID;
            profesor.Nombre = model.Nombre;
            profesor.Apellido = model.Apellido;
            profesor.Especialidad=model.Especialidad;
            profesor.CorreoElectronico = model.CorreoElectronico;

            profesorService.Editar(id, profesor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) {
            ProfesorService profesorService = new ProfesorService();
            Profesor profesor =profesorService.BuscarPorId(id);

            ProfesorModel profesorModel = new ProfesorModel();

            profesorModel.ProfesorID= profesor.ProfesorID;
            profesorModel.Nombre= profesor.Nombre;
            profesorModel.Apellido= profesor.Apellido;
            profesorModel.Especialidad=profesor.Especialidad;
            profesorModel.CorreoElectronico= profesor.CorreoElectronico;

            return View(profesorModel);

        }

        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            ProfesorService profesorService = new ProfesorService();
            profesorService.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
